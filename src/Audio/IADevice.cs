/*
	Git: https://github.com/ClaudiaCoord/Audio-7.1-Multi-Channel-Mixer-8
	ASIO 8 Multi Channel Mixer / 7.1 Sound card compatible (CM6206).
	(c) CC 2022, MIT

	See README.md for more details.
	NOT FOR CHINESE USE FOR SALES! FREE SOFTWARE!
*/
using NAudio.CoreAudioApi;
using NAudio.Wave;

namespace MCM8.Audio
{
    public interface IADevice : IDisposable
    {
        public event EventHandler OnVolumeChanged;
        public event EventHandler OnError;

        public MMDevice? Device { get; }
        public WaveFormat? WaveFormat { get; }
        public IWaveProvider? Provider { get; }
        public List<string> InputFiles { get; set; }
        public bool IsApiDevice { get; }
        public bool IsApiDeviceReady { get; }
        public bool Mute { get; set; }
        public float Volume { get; set; }
        public float VolumePeak { get; }
        public int PlayCount { get; }

        public void Clear();
    }
}
