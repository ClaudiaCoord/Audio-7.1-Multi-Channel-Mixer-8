/*
	Git: https://github.com/ClaudiaCoord/Audio-7.1-Multi-Channel-Mixer-8
	ASIO 8 Multi Channel Mixer / 7.1 Sound card compatible (CM6206).
	(c) CC 2022, MIT

	See README.md for more details.
	NOT FOR CHINESE USE FOR SALES! FREE SOFTWARE!
*/
using NAudio.Wave;

namespace MCM8.Audio
{
    public class AudioPlayerProvider : ISampleProvider
    {
        private readonly ISampleProvider[] providers;
        private int idx;

        public AudioPlayerProvider(List<AudioFileReader> providers)
        {
            if (providers == null)
                throw "Audio FileReader list argument null".AudioArgumentException(nameof(providers));
            this.providers = providers.ToArray();
            if (this.providers.Length == 0)
                throw "Must provide at least one input".AudioArgumentException(nameof(providers));
            if (this.providers.Any(p => p.WaveFormat.Channels != WaveFormat.Channels))
                throw "All inputs must have the same channel count".AudioArgumentException(nameof(providers));
            if (this.providers.Any(p => p.WaveFormat.SampleRate != WaveFormat.SampleRate))
                throw "All inputs must have the same sample rate".AudioArgumentException(nameof(providers));
        }

        public WaveFormat WaveFormat => providers[0].WaveFormat;

        public IWaveProvider GetWaveProvider() => this.ToWaveProvider16();

        public int Read(float[] buffer, int offset, int count)
        {
            int read = 0;
            while (read < count && idx < providers.Length)
            {
                int needed = count - read;
                int nread = providers[idx].Read(buffer, offset + read, needed);
                read += nread;
                if (nread == 0)
                    idx = ((providers.Length - 1) == idx) ? 0 : (idx + 1);
            }
            return read;
        }
    }
}
