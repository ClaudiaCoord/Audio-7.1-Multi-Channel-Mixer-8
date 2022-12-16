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
using NAudio.Wave.SampleProviders;
using System.Text.Json.Serialization;

namespace MCM8.Audio
{
    public class ApiPlayer : IADevice
    {
        [JsonIgnore]
        List<AudioFileReader> Readers = new();
        [JsonIgnore]
        readonly List<string> Files = new();

        public event EventHandler OnVolumeChanged = delegate { };
        public event EventHandler OnError = delegate { };

        public ApiPlayer() { }
        public ApiPlayer(PlayerSourceNumber psn) => PlayerId = psn;
        ~ApiPlayer() => Dispose();

        public List<string> InputFiles {
            get => Files;
            set {
                Dispose();
                Files.Clear();
                Files.AddRange(value);
            }
        }

        private IWaveProvider? provider = null;
        [JsonIgnore]
        public IWaveProvider? Provider {
            get {
                if (provider == null) BuildProvider();
                return provider;
            }
        }

        [JsonIgnore]
        public MMDevice? Device { get => null; set {}}

        private bool mute = false;
        public bool Mute
        {
            get => mute;
            set {
                if (mute == value) return;
                mute = value;
                SetVolume(mute ? 0.0f : volume);
            }
        }
        private float volume = 0.5f;
        public float Volume
        {
            get => (IsApiDevice && IsReaders) ? (volume = Readers[0].Volume) : volume;
            set {
                if (volume == value) return;
                volume = value;
                if (!IsReaders) return;
                SetVolume(volume);
            }
        }

        public PlayerSourceNumber PlayerId { get; set; } = PlayerSourceNumber.Player_None;

        [JsonIgnore]
        private bool IsReaders => Readers.Count > 0;
        [JsonIgnore]
        public bool IsApiDevice => Files.Count > 0;
        [JsonIgnore]
        public bool IsApiDeviceReady => IsApiDevice && IsReaders;
        [JsonIgnore]
        public float VolumePeak => (IsApiDevice && IsReaders) ? (Readers[0].Volume * 1.8f) : 0.0f;
        [JsonIgnore]
        public int PlayCount => Files.Count;
        [JsonIgnore]
        public WaveFormat? WaveFormat { get; private set; } = null;

        public void Clear() { Files.Clear(); Dispose(); }

        public void Dispose()
        {
            AudioFileReader[] r = Readers.ToArray();
            Readers.Clear();
            provider = null;
            Dispose(r);
        }

        private async void Dispose(AudioFileReader[] r)
        {
            foreach (var reader in r) {
                try {
                    await reader.DisposeAsync().ConfigureAwait(false);
                }
                catch (Exception ex) {
                    OnError.Invoke(this, new StringEventArgs(ex.Message));
                }
            }
        }

        private void BuildProvider()
        {
            try {
                if (!IsApiDevice)
                    throw new FileLoadException("Player file list not selected!");

                if (IsApiDevice)
                    Dispose();

                foreach (string s in Files) {
                    try {
                        if (!File.Exists(s)) continue;
                        var af = new AudioFileReader(s);
                        af.ConfigureAwait(false);
                        Readers.Add(af);
                    }
                    catch (Exception ex) {
                        OnError.Invoke(this, new StringEventArgs(ex.Message));
                    }
                }
                if (!IsApiDevice)
                    throw new FileLoadException("Player file list not find valid files!");

                provider = new AudioPlayerProvider(Readers).GetWaveProvider();
                WaveFormat = provider.WaveFormat;
            }
            catch (Exception ex) {
                OnError.Invoke(this, new StringEventArgs(ex.Message));
            }
        }
        private void SetVolume(float vol)
        {
            if (!IsApiDevice || !IsReaders) return;
            foreach (var reader in Readers) {
                try {
                    reader.Volume = vol;
                }
                catch (Exception ex) {
                    OnError.Invoke(this, new StringEventArgs(ex.Message));
                }
            }
        }

    }
}
