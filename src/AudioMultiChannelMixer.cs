/*
	Git: https://github.com/ClaudiaCoord/Audio-7.1-Multi-Channel-Mixer-8
	ASIO 8 Multi Channel Mixer / 7.1 Sound card compatible (CM6206).
	(c) CC 2022, MIT

	See README.md for more details.
	NOT FOR CHINESE USE FOR SALES! FREE SOFTWARE!
*/
using System.Security.Cryptography;
using MCM8.UC;
using NAudio.Wave;

namespace MCM8
{
    internal class AudioMultiChannelMixer : IDisposable
    {
        private AsioOut? aout = default;
        readonly ListProviderIn pin = new();
        public bool IsStart { get; private set; } = false;

        public event EventHandler OnAsioEvent = delegate { };
        public event EventHandler OnError = delegate { };

        private ListAudioAsio? audioAsio = null;
        private List<ADev>? devList = null;

        public AudioMultiChannelMixer() {
            pin.OnError += (s, a) => OnError.Invoke(s, a);
        }

        public void Begin(ListAudioAsio? asio, List<ADev>? devlist)
        {
            audioAsio = asio;
            devList = devlist;

            if ((audioAsio == null) || (audioAsio.SelectedDevice == null) || string.IsNullOrWhiteSpace(audioAsio.SelectedDevice.Name))
                throw new NullReferenceException(nameof(audioAsio));

            if ((devlist == null) || (devlist.Count == 0))
                throw new NullReferenceException(nameof(devlist));

            List<SourceNumber> lcn = new();
            switch (audioAsio.SelectedChannels)
            {
                case 2: lcn.Add(SourceNumber.Source_1_2); break;
                case 4: lcn.AddRange(
                    new SourceNumber[] {
                        SourceNumber.Source_1_2,
                        SourceNumber.Source_3_4 }); break;
                case 6: lcn.AddRange(
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

            if (lcn.Count== 0)
                throw new Exception("ASIO wrong Source number!");

            int count = 0;
            List<IWaveProvider> lwp = new();
            List<int[]> chn = new();

            try {
                pin.Begin();
                foreach (SourceNumber cn in lcn) {
                    ADev? a = (from d in devList
                               where d.Source == cn
                               select d).FirstOrDefault();
                    if ((a != null) && (a.Id > -1) && a.Enable) {
                        if (a.Channels.IsMapChannelsValid())
                            chn.Add(a.Channels);
                        else
                            chn.Add(cn.DefaultMapChannels());
                        pin.Add(cn, a);
                        count++;
                    } else {
                        pin.Add(cn, ListProviderIn.DefaultRate, ListProviderIn.DefaultBits, ListProviderIn.DefaultChannels);
                        chn.Add(cn.DefaultMapChannels());
                    }
                    IWaveProvider? iwp = pin.GetProvider(cn);
                    if (iwp != null) lwp.Add(iwp);
                }
            } finally {
                pin.End();
            }

            if (lwp.Count == 0)
                throw new Exception($"Not selected input devices! ({lwp.Count}/{audioAsio.SelectedChannels / 2})");

            if (lcn.Count != count)
                OnError.Invoke(this, new StringEventArgs($"Not all selected devices were connected! ({count}/{lcn.Count})"));

            var m = new MultiplexingWaveProvider(lwp, audioAsio.SelectedChannels);

            for (int i = 0; i < chn.Count; i++) {
                int idx = i * 2;
                int[] x = chn[i];

                var dup = (from z in chn.Select((value, index) => new { value, index })
                           where (z.index > i) && (z.value[0] == x[0] || z.value[0] == x[0])
                           select z).ToArray();
                if (dup != null) {
                    for (int n = 0; n < dup.Length; n++)
                        OnError.Invoke(this, new StringEventArgs(
                            $"Warning! duplicate selected port [{dup[n].index}]: [{dup[n].value[0]}/{dup[n].value[1]}]/{dup.Count()}"));
                }

                m.ConnectInputToOutput(idx, x[0]);
                m.ConnectInputToOutput(idx + 1, x[1]);
                OnError.Invoke(this, new StringEventArgs($"Source [{i + 1}] mapping channels to: [{idx}/{x[0]}, {idx + 1}/{x[1]}]"));
            }

            aout = new AsioOut(audioAsio.SelectedDevice.Name);
            OnAsioEvent.Invoke(this, new StringEventArgs($"Out: {aout.DriverName}"));
            aout.AudioAvailable += AsioOut_AudioAvailable;
            aout.DriverResetRequest += Aout_DriverResetRequest;
            aout.Init(m);
            aout.Play();
            IsStart = true;
        }

        private void Aout_DriverResetRequest(object? sender, EventArgs e)
        {
            try {
                Dispose();
                Begin(audioAsio, devList);
            } catch (Exception ex) {
                OnError.Invoke(this, new StringEventArgs(ex.Message));
                IsStart = false;
            }
        }

        public void End()
        {
            Dispose();
            IsStart = false;
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
    }
}
