/*
	Git: https://github.com/ClaudiaCoord/Audio-7.1-Multi-Channel-Mixer-8
	ASIO 8 Multi Channel Mixer / 7.1 Sound card compatible (CM6206).
	(c) CC 2022, MIT

	See README.md for more details.
	NOT FOR CHINESE USE FOR SALES! FREE SOFTWARE!
*/

namespace MCM8.Audio
{
    internal class AudioData : IAList, IDisposable
    {
        public Control? Ctrl = null;
        public event EventHandler OnError = delegate { };

        private readonly AudioMultiChannelMixer audioChannelMix = new();
        private readonly ListAudioAsio listAsio = new();
        private readonly ListAudioIn listIn = new();
        private readonly ListAudioPlayers listPlayers = new();

        public AudioMultiChannelMixer AudioChannelMix => audioChannelMix;
        public ListAudioPlayers ListPlayers => listPlayers;
        public ListAudioAsio ListAsio => listAsio;
        public ListAudioIn ListIn => listIn;

        public AudioData() {
            audioChannelMix.OnError += ToLog;
            listPlayers.OnError += ToLog;
            listAsio.OnError += ToLog;
            listIn.OnError += ToLog;
        }
        ~AudioData() {
            audioChannelMix.OnError -= ToLog;
            listPlayers.OnError -= ToLog;
            listAsio.OnError -= ToLog;
            listIn.OnError -= ToLog;
            Dispose();
        }

        public void Dispose()
        {
            audioChannelMix.Dispose();
            listPlayers.Dispose();
        }

        public void Begin(List<ADev> list) =>
            AudioChannelMix.Begin(this, list);

        public void End()
        {
            AudioChannelMix.End();
            listPlayers.Clear();
        }

        public void Load() => Load((a) => { });
        public void Load(Action<int> act)
        {
            act.Invoke(15);
            listAsio.Load();
            act.Invoke(30);
            listIn.Load();
            act.Invoke(75);
            listPlayers.Load();
            act.Invoke(80);
        }

        public async void Save()
        {
            await Task.Factory.StartNew(() => {
                listAsio.Save();
                listIn.Save();
                listPlayers.Save();
                Properties.Settings.Default.Save();
            });
        }

        private void ToLog(object? sender, EventArgs args) =>
            OnError.Invoke(sender, args);
    }
}
