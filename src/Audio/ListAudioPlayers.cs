/*
	Git: https://github.com/ClaudiaCoord/Audio-7.1-Multi-Channel-Mixer-8
	ASIO 8 Multi Channel Mixer / 7.1 Sound card compatible (CM6206).
	(c) CC 2022, MIT

	See README.md for more details.
	NOT FOR CHINESE USE FOR SALES! FREE SOFTWARE!
*/
using System.Collections.ObjectModel;
using System.Text.Json;
using MCM8.UC;

namespace MCM8.Audio
{
    public class ListAudioPlayers : IAList, IDisposable
    {
        public ObservableCollection<ApiPlayer> Players { get; set; } = new ObservableCollection<ApiPlayer>();
        public event EventHandler OnError = delegate { };

        public ListAudioPlayers()
        {
            for (int i = 0; i < 4; i++)
                Players.Add(new ApiPlayer(i.PlayerFromInt()));
        }
        ~ListAudioPlayers() => Dispose();

        public void Load()
        {
            try
            {
                var json = Properties.Settings.Default.JsonPlayLists;
                if (!string.IsNullOrWhiteSpace(json)) {
                    var opt = new JsonSerializerOptions {
                        IgnoreReadOnlyFields = true,
                        IgnoreReadOnlyProperties = true,
                        AllowTrailingCommas = true,
                    };
                    ListAudioPlayers? list = JsonSerializer.Deserialize<ListAudioPlayers>(json, opt);
                    if (list != null) {
                        for (int i = 0; i < list.Players.Count; i++) {
                            var a = list.Players.ElementAt(i);
                            if (a != null)
                                Players[i] = a;
                        }
                    }
                }
            }
            catch (Exception ex) {
                OnError.Invoke(this, new StringEventArgs(ex.Message));
            }
        }

        public void Save()
        {
            try {
                var opt = new JsonSerializerOptions {
                    WriteIndented = true,
                    IgnoreReadOnlyFields = true,
                    IgnoreReadOnlyProperties = true,
                    AllowTrailingCommas = true
                };
                string json = JsonSerializer.Serialize(this, opt);
                if (!string.IsNullOrWhiteSpace(json))
                    Properties.Settings.Default.JsonPlayLists = json;
            }
            catch (Exception ex) {
                OnError.Invoke(this, new StringEventArgs(ex.Message));
            }
        }

        public void Clear()
        {
            try {
                foreach (var player in Players)
                    player?.Dispose();
            }
            catch (Exception ex) {
                OnError.Invoke(this, new StringEventArgs(ex.Message));
            }
        }

        public void Dispose()
        {
            ApiPlayer[] p = Players.ToArray();
            Players.Clear();
            if (p == null) return;
            for (int i = 0; i < p.Length; i++)
                p[i]?.Dispose();
        }
    }
}
