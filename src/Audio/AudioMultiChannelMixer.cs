/*
	Git: https://github.com/ClaudiaCoord/Audio-7.1-Multi-Channel-Mixer-8
	ASIO 8 Multi Channel Mixer / 7.1 Sound card compatible (CM6206).
	(c) CC 2022, MIT

	See README.md for more details.
	NOT FOR CHINESE USE FOR SALES! FREE SOFTWARE!
*/
using MCM8.UC;
using NAudio.Wave;

namespace MCM8.Audio
{
    internal class AudioMultiChannelMixer : IDisposable
    {
        private AsioOut? aout = default;
        readonly ListProviderIn pin = new();
        public bool IsStart { get; private set; } = false;

        public event EventHandler OnAsioEvent = delegate { };
        public event EventHandler OnError = delegate { };
        public event EventHandler OnPlayerError = delegate { };

        private AudioData? audioData = null;
        private List<ADev>? devList = null;

        public AudioMultiChannelMixer()
        {
            pin.OnError += (s, a) => OnError.Invoke(s, a);
            pin.OnPlayerError += (s, a) => OnPlayerError.Invoke(s, a);
        }

        public void Begin(AudioData? adata, List<ADev>? devlist)
        {
            audioData = adata;
            devList = devlist;

            if (adata == null || adata.ListAsio.SelectedDevice == null || string.IsNullOrWhiteSpace(adata.ListAsio.SelectedDevice.Name))
                throw "ASIO argument null".AudioArgumentException(nameof(adata.ListAsio));

            if (devlist == null || devlist.Count == 0)
                throw "Device list argument null".AudioArgumentException(nameof(devlist));

            List<SourceNumber> lcn = new();
            switch (adata.ListAsio.SelectedChannels)
            {
                case 2: lcn.Add(SourceNumber.Source_1_2); break;
                case 4:
                    lcn.AddRange(
                    new SourceNumber[] {
                        SourceNumber.Source_1_2,
                        SourceNumber.Source_3_4 }); break;
                case 6:
                    lcn.AddRange(
                    new SourceNumber[] {
                        SourceNumber.Source_1_2,
                        SourceNumber.Source_3_4,
                        SourceNumber.Source_5_6 }); break;
                case 8:
                    lcn.AddRange(
                    new SourceNumber[] {
                        SourceNumber.Source_1_2,
                        SourceNumber.Source_3_4,
                        SourceNumber.Source_5_6,
                        SourceNumber.Source_7_8 }); break;
            }

            if (lcn.Count == 0)
                throw "ASIO wrong Source number!".AudioException();

            int count = 0;
            List<IWaveProvider> lwp = new();
            List<int[]> chn = new();

            try {
                pin.Begin();
                foreach (SourceNumber cn in lcn) {
                    ADev? a = (from d in devList
                               where d.SourceId == cn
                               select d).FirstOrDefault();


                    do {
                        if (a != null) {
                            if ((a.Id > -1) && a.Enable) {
                                if (a.Channels.IsMapChannelsValid())
                                    chn.Add(a.Channels);
                                else
                                    chn.Add(cn.DefaultMapChannels());
                                pin.Add(cn, a);
                                count++;
                                break;
                            }
                            if ((a.Id == -10) && (adata.ListPlayers != null)) {
                                ApiPlayer? p = (from i in adata.ListPlayers.Players
                                              where i.PlayerId == cn.PlayerFromSourceNumber()
                                              select i).FirstOrDefault();
                                if (p != null) {
                                    pin.Add(cn, a, p);
                                    if (a.IsApiDevice) {
                                        count++;
                                        if (a.Channels.IsMapChannelsValid())
                                            chn.Add(a.Channels);
                                        else
                                            chn.Add(cn.DefaultMapChannels());
                                        break;
                                    }
                                        
                                }
                            }
                        }
                        pin.Add(cn, ListProviderIn.DefaultRate, ListProviderIn.DefaultBits, ListProviderIn.DefaultChannels);
                        chn.Add(cn.DefaultMapChannels());

                    } while (false);

                    IWaveProvider? iwp = pin.GetProvider(cn);
                    if (iwp != null) lwp.Add(iwp);
                }
            }
            finally
            {
                pin.End();
            }

            if (lwp.Count == 0)
                throw $"Not selected input devices! ({lwp.Count}/{adata.ListAsio.SelectedChannels / 2})".AudioException();

            if (chn.Count == 0)
                throw $"Not selected output audio channels! ({chn.Count}/{adata.ListAsio.SelectedChannels})".AudioException();

            if (lcn.Count != count)
                OnError.Invoke(this, new StringEventArgs($"Not all selected devices were connected! ({count} from {lcn.Count})"));

            try {
                do {
                    var ratelist = (from d in devList
                                    where d.WaveFormat != null &&
                                         (d.WaveFormat.SampleRate != Properties.Settings.Default.DefaultRate ||
                                          d.WaveFormat.BitsPerSample != Properties.Settings.Default.DefaultBits)
                                    select new { d.SourceId, d.WaveFormat?.SampleRate, d.WaveFormat?.BitsPerSample }).ToArray();

                    if (ratelist == null || ratelist.Length == 0) break;

                    for (int n = 0; n < ratelist.Length; n++)
                        OnError.Invoke(this, new StringEventArgs(
                            $"Warning! Source sample rate or bits not equals: [{ratelist[n]?.SourceId.ToInt()}]: [{ratelist[n].SampleRate}/{ratelist[n].BitsPerSample}] : {Properties.Settings.Default.DefaultRate}/{Properties.Settings.Default.DefaultBits}"));

                } while (false);

                bool[] chchk = new bool[8];
                for (int i = 0; i < chn.Count; i++)
                {
                    int idx = i * 2;
                    int[] x = chn[i];

                    foreach (int n in x)
                        if (n >= 0 && n < 8)
                            chchk[n] = true;

                    var dup = (from z in chn.Select((value, index) => new { value, index })
                               where z.index > i && (z.value[0] == x[0] || z.value[0] == x[0])
                               select z).ToArray();
                    if (dup != null && dup.Length > 0)
                    {
                        for (int n = 0; n < dup.Length; n++)
                            OnError.Invoke(this, new StringEventArgs(
                                $"Warning! duplicate selected port [{dup[n].index + 1}]: [{dup[n].value[0]}/{dup[n].value[1]}]/{dup.Length}"));
                    }
                }
                var zero = (from z in chchk.Select((value, index) => new { value, index })
                            where z.index < adata.ListAsio.SelectedChannels && !z.value
                            select z).ToArray();

                if (zero != null && zero.Length > 0) {
                    foreach (var z in zero)
                        OnError.Invoke(this, new StringEventArgs(
                            $"Warning! not selected channel [{z.index + 1}]"));
                    throw $"Not all audio channels are selected! {zero.Length} channels not selected".AudioException();
                }


                MultiplexingWaveProvider m = new MultiplexingWaveProvider(lwp, adata.ListAsio.SelectedChannels); ;

                for (int i = 0; i < chn.Count; i++) {
                    int idx = i * 2;
                    int[] x = chn[i];

                    m.ConnectInputToOutput(idx, x[0]);
                    m.ConnectInputToOutput(idx + 1, x[1]);
                    OnError.Invoke(this, new StringEventArgs($"Source [{i + 1}] mapping channels to: [{idx}/{x[0]}, {idx + 1}/{x[1]}]"));
                }

                aout = new AsioOut(adata.ListAsio.SelectedDevice.Name);
                OnAsioEvent.Invoke(this, new StringEventArgs($"Out: {aout.DriverName}"));
                aout.AudioAvailable += AsioOut_AudioAvailable;
                aout.DriverResetRequest += Aout_DriverResetRequest;
                aout.Init(m);
                aout.Play();
                IsStart = true;

            } catch {
                Dispose();
                IsStart = false;
                throw;
            }
        }
        
        private void Aout_DriverResetRequest(object? sender, EventArgs e)
        {
            try {
                if ((audioData != null) && (audioData.Ctrl != null))
                    audioData.Ctrl.Invoke(() => FromDriverRestart());
                /*
                 * WindowsFormsSynchronizationContext sui = new WindowsFormsSynchronizationContext();
                 * sui.Post(FromDriverRestart, null);
                 */
            }
            catch (Exception ex) {
                ErrorEnd(ex);
            }
        }

        private void FromDriverRestart(object? state = null)
        {
            try {
                Dispose();
                Begin(audioData, devList);
            }
            catch (Exception ex) {
                ErrorEnd(ex);
            }
        }

        public void End()
        {
            Dispose();
            ErrorEnd();
        }

        public void Dispose()
        {
            AsioOut? a = aout;
            aout = null;
            if (a != null)
            {
                a.Stop();
                a.Dispose();
            }
            pin.Dispose();
        }

        public void ShowASIOPanel()
        {
            try {
                AsioOut? a = aout;
                a?.ShowControlPanel();
            }
            catch (Exception ex) {
                OnError.Invoke(this, new StringEventArgs(ex.Message));
            }
        }

        void AsioOut_AudioAvailable(object? sender, AsioAudioAvailableEventArgs e) =>
            OnAsioEvent.Invoke(this, new StringEventArgs("ASIO available"));

        public void ErrorEnd(Exception? ex = null)
        {
            if (ex != null)
                OnError.Invoke(this, new StringEventArgs(ex.Message));
            devList = null;
            audioData = null;
            IsStart = false;
        }
    }
}
