/*
	Git: https://github.com/ClaudiaCoord/Audio-7.1-Multi-Channel-Mixer-8
	ASIO 8 Multi Channel Mixer / 7.1 Sound card compatible (CM6206).
	(c) CC 2022, MIT

	See README.md for more details.
	NOT FOR CHINESE USE FOR SALES! FREE SOFTWARE!
*/

using System.Text.Json.Serialization;
using NAudio.CoreAudioApi;
using NAudio.Wave;

namespace MCM8.Audio
{
    public class ADevList
    {
        [JsonPropertyName("InputDevices")]
        public IList<ADev> Devices { get; set; }
        public ADevList() { Devices = new List<ADev>(); }
        public ADevList(List<ADev> list)
        {
            Devices = (from   i in list
                       where  i.SourceId != SourceNumber.Source_None ||
                              i.PlayerId != PlayerSourceNumber.Player_None
                       select i).ToList();
            Devices ??= new List<ADev>();
        }
    }
    public class ADev : IADevice
    {
        public event EventHandler OnVolumeChanged = delegate { };
        public event EventHandler OnError = delegate { };

#       pragma warning disable CS8602

        [JsonIgnore]
        public static readonly string Member = "Name";
        [JsonIgnore]
        public int Id { get; } = -1;
        [JsonPropertyOrder(0)]
        public SourceNumber SourceId { get; set; } = SourceNumber.Source_None;
        [JsonPropertyOrder(1)]
        public PlayerSourceNumber PlayerId { get; set; } = PlayerSourceNumber.Player_None;
        [JsonPropertyOrder(2)]
        public string Name { get; set; } = string.Empty;
        [JsonPropertyOrder(3)]
        public string Icon { get; set; } = string.Empty;
        [JsonPropertyOrder(4)]
        public bool Enable { get; set; } = false;
        [JsonPropertyOrder(5)]
        public int[] Channels { get; set; } = new int[2] { -1, -1 };

        private float volume = 0.5f;
        [JsonPropertyOrder(6)]
        public float Volume {
            get => IsApiDevice ? (volume = ApiDevice.Volume) : volume;
            set { if (IsApiDevice) ApiDevice.Volume = volume = value; else volume = value; }
        }
        [JsonIgnore]
        public bool Mute {
            get => IsApiDevice && ApiDevice.Mute;
            set { if (IsApiDevice) ApiDevice.Mute = value; }
        }
        [JsonIgnore]
        public float VolumePeak {
            get => IsApiDevice ? ApiDevice.VolumePeak : 0.0f;
        }
        [JsonIgnore]
        public WaveFormat? WaveFormat { get => ApiDevice?.WaveFormat; }
        [JsonIgnore]
        public MMDevice? Device => ApiDevice?.Device;

        [JsonIgnore]
        public bool IsApiDevice => (ApiDevice != null) && ApiDevice.IsApiDevice;
        [JsonIgnore]
        public bool IsApiDeviceReady => IsApiDevice && ApiDevice.IsApiDeviceReady;
        [JsonIgnore]
        public IWaveProvider? Provider => IsApiDevice ? ApiDevice.Provider : null;
        [JsonIgnore]
        public int PlayCount => IsApiDevice ? ApiDevice.InputFiles.Count : 0;
        [JsonIgnore]
        public List<string> InputFiles {
            get => IsApiDevice ? ApiDevice.InputFiles : new();
            set { if (IsApiDevice) ApiDevice.InputFiles = value; }
        }
        [JsonIgnore]
        private IADevice? ApiDevice { get; set; } = null;

        public ADev() { }
        public ADev(int i, string s)
        {
            Id = i;
            Name = s;
            Enable = Id != -1;
        }
        public ADev(int i, string s, string m)
        {
            Id = i;
            Name = s;
            Enable = Id != -1;
            if (!string.IsNullOrWhiteSpace(m))
                SetIconName(m);
        }
        public ADev(int i)
        {
            Id = -10;
            PlayerId = i.PlayerFromInt();
            SourceId = i.SourceFromInt();
            Enable = true;
            Name = $"{Properties.Resources.ComboBoxPlayerSelected} {i + 1}";
            SetIconName("mmres_3019");
        }
        ~ADev() { Dispose(); }

        public void Dispose() {
            IADevice? a = ApiDevice;
            ApiDevice = null;
            if (a == null) return;
            a.Dispose();
            a.OnError -= OnErrorCb;
            a.OnVolumeChanged -= VolumeCb;
        }

        public void Copy(ADev dev)
        {
            Enable = dev.SourceId != SourceNumber.Source_None && dev.Enable;
            SourceId = dev.SourceId;
            if (dev.Channels != null) Channels = dev.Channels;
            if (dev.Volume != 0.5f) Volume = dev.Volume;
            if (!string.IsNullOrWhiteSpace(dev.Icon))
                SetIconName(dev.Icon);
        }

        public void Clear()
        {
            if (IsApiDevice) ApiDevice.Clear();
        }

        public ADev SetDevice<T>(T dev) where T : class, new()
        {
            Dispose();
            if (dev is IADevice d) {
                ApiDevice = d;
                ApiDevice.OnError += OnErrorCb;
                ApiDevice.OnVolumeChanged += VolumeCb;
                ApiDevice.Volume = volume;
            }
            return this;
        }

        private void OnErrorCb(object? s, EventArgs a) => OnError.Invoke(s, a);
        private void VolumeCb(object? s, EventArgs a) => OnVolumeChanged.Invoke(s, a);

        private void SetIconName(string s) =>
            Icon = s.Replace("%windir%\\system32\\", "", StringComparison.InvariantCultureIgnoreCase)
                    .Replace(".dll,-", "_", StringComparison.InvariantCultureIgnoreCase);

#       pragma warning restore CS8602
    }
}
