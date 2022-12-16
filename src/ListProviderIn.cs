/*
	Git: https://github.com/ClaudiaCoord/Audio-7.1-Multi-Channel-Mixer-8
	ASIO 8 Multi Channel Mixer / 7.1 Sound card compatible (CM6206).
	(c) CC 2022, MIT

	See README.md for more details.
	NOT FOR CHINESE USE FOR SALES! FREE SOFTWARE!
*/
using MCM8.UC;
using NAudio.CoreAudioApi;
using NAudio.Wave;

namespace MCM8
{
    internal class ListProviderIn : IDisposable
    {
        private readonly ADevIn audioIn = new();
        private MMDeviceEnumerator? MMEnumerator = null;
        private MMDeviceCollection? MMDevices = null;

        public event EventHandler OnError = delegate { };

        public static int DefaultRate {
            get => Properties.Settings.Default.DefaultRate;
            set => Properties.Settings.Default.DefaultRate = value;
        }
        public static int DefaultBits {
            get => Properties.Settings.Default.DefaultBits;
            set => Properties.Settings.Default.DefaultBits = value;
        }
        public static int DefaultChannels {
            get => Properties.Settings.Default.DefaultChannels;
            set => Properties.Settings.Default.DefaultChannels = value;
        }

        public ListProviderIn() {
            audioIn.OnError += (s, a) => OnError.Invoke(s, a);
        }
        ~ListProviderIn() => Dispose();

        public void Dispose(bool isallclear)
        {
            MMDeviceEnumerator? mmd = MMEnumerator;
            MMEnumerator = null;
            MMDevices = null;
            mmd?.Dispose();
            if (isallclear)
                audioIn.Dispose();
        }

        public void Dispose() => Dispose(true);


        public void Begin()
        {
            Dispose(false);
            MMEnumerator = new MMDeviceEnumerator();
            MMDevices = MMEnumerator.EnumerateAudioEndPoints(DataFlow.Capture, DeviceState.Active);
        }
        public void End() => Dispose(false);

        public void Add(SourceNumber cn, int rate, int bits, int channels)
        {
            var item = audioIn.GetAudioItem(cn);
            if (item == null) return;
            try {
                item.SetProvider(
                    new SilenceProvider(new WaveFormat(rate, bits, WaveIn.GetCapabilities(channels).Channels)));
            } catch (Exception ex) {
                OnError.Invoke(this, new StringEventArgs(ex.Message));
            }
        }
        public void Add(SourceNumber cn, ADev? dev)
        {
            if (dev == null) return;
            var item = audioIn.GetAudioItem(cn);
            if (item == null) return;

            GetApiDevice(dev);
            try {
                if (dev.WaveFormat != null)
                    item.SetWasapi(dev);
                else
                    item.SetWaveIn(new WaveIn {
                        DeviceNumber = dev.Id,
                        WaveFormat = new WaveFormat(DefaultRate, DefaultBits, WaveIn.GetCapabilities(DefaultChannels).Channels)
                    });
                item.Start();
            }
            catch (Exception ex) {
                OnError.Invoke(this, new StringEventArgs(ex.Message));
            }
        }

        private void GetApiDevice(ADev dev)
        {
            if ((MMEnumerator == null) || (MMDevices == null)) Begin();
            try {
                dev.ApiDevice.Device = (from i in MMDevices
                                        where i.FriendlyName.StartsWith(dev.Name)
                                        select i).FirstOrDefault();
            } catch (Exception ex) {
                OnError.Invoke(this, new StringEventArgs(ex.Message));
            }
        }

        public IWaveIn? GetWaveIn(SourceNumber cn) => audioIn.GetWaveIn(cn);
        public IWaveProvider? GetProvider(SourceNumber cn) => audioIn.GetProvider(cn);
        public AudioItem? GetAudioDevice(SourceNumber cn) => audioIn.GetAudioItem(cn);
    }
}
