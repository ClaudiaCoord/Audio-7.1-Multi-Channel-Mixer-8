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

namespace MCM8.Audio
{
    internal class ADevIn : IDisposable
    {
        public AudioItem[] Items = new AudioItem[4];
        public event EventHandler OnError = delegate { };


        public ADevIn()
        {
            for (int i = 0; i < Items.Length; i++)
            {
                Items[i] = new AudioItem();
                Items[i].OnError += (s, a) => OnError.Invoke(s, a);
            }
        }

        public void Dispose()
        {
            for (int i = 0; i < Items.Length; i++)
                Items[i].Dispose();
        }
        public AudioItem? GetAudioItem(int n) => Items[n];
        public AudioItem? GetAudioItem(SourceNumber cn)
        {
            int n = cn.ToInt();
            if (n < 0) return null;
            return Items[n];
        }
        public IWaveProvider? GetProvider(SourceNumber cn)
        {
            int n = cn.ToInt();
            if (n < 0) return null;
            return Items[n].Provider;
        }
        public IWaveIn? GetWaveIn(SourceNumber cn)
        {
            int n = cn.ToInt();
            if (n < 0) return null;
            return Items[n].Wavein;
        }
    }
    internal class AudioItem : IDisposable
    {
        public IWaveIn? Wavein = null;
        public IWaveProvider? Provider = null;

        public bool IsWave { get => Wavein != null; }
        public bool IsProvider { get => Provider != null; }

        public event EventHandler OnError = delegate { };

        public void SetWaveIn(WaveIn w)
        {
            try {
                Dispose();
                Wavein = w;
                Provider = new WaveInProvider(Wavein);
            }
            catch (Exception ex) {
                OnError.Invoke(this, new StringEventArgs(ex.Message));
            }

        }
        public void SetWasapi(ADev dev)
        {
            try {
                Dispose();
                if ((dev == null) || !dev.IsApiDeviceReady) return;
#               pragma warning disable CS8602
                Wavein = dev.Device.DataFlow == DataFlow.Capture ?
                    new WasapiCapture(dev.Device) :
                    new WasapiLoopbackCapture(dev.Device);
#               pragma warning restore CS8602
                Provider = new WaveInProvider(Wavein);
            }
            catch (Exception ex) {
                OnError.Invoke(this, new StringEventArgs(ex.Message));
            }
        }
        public void SetProvider(IWaveProvider p)
        {
            Dispose();
            Provider = p;
        }

        public bool Start()
        {
            try {
                if (!IsWave) return false;
                Wavein?.StartRecording();
                return true;
            }
            catch (Exception ex) {
                OnError.Invoke(this, new StringEventArgs(ex.Message));
            }
            return false;
        }

        public bool Stop()
        {
            try {
                if (!IsWave) return false;
                Wavein?.StopRecording();
                return true;
            }
            catch (Exception ex) {
                OnError.Invoke(this, new StringEventArgs(ex.Message));
            }
            return false;
        }

        public void Dispose()
        {
            IWaveIn? w = Wavein;
            Wavein = null;
            if (w != null) {
                try { w.StopRecording(); } catch { }
                try { w.Dispose(); } catch { }
            }
            Provider = null;
        }
    }

}
