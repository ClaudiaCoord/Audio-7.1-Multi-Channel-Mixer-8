/*
	Git: https://github.com/ClaudiaCoord/Audio-7.1-Multi-Channel-Mixer-8
	ASIO 8 Multi Channel Mixer / 7.1 Sound card compatible (CM6206).
	(c) CC 2022, MIT

	See README.md for more details.
	NOT FOR CHINESE USE FOR SALES! FREE SOFTWARE!
*/

using System.Text.Json.Serialization;
using MCM8.UC;
using NAudio.CoreAudioApi;
using NAudio.Wave;

namespace MCM8
{
    public class ADevList
    {
        [JsonPropertyName("InputDevices")]
        public IList<ADev> Devices { get; set; }
        public ADevList() { Devices = new List<ADev>(); }
        public ADevList(List<ADev> list) {
            Devices = (from i in list
                       where i.Source != SourceNumber.Source_None
                       select i).ToList();
            Devices ??= new List<ADev>();
        }
    }
    public class ApiDev : IDisposable
    {
        public event EventHandler OnVolumeChanged = delegate { };

        private AudioEndpointVolumeNotificationDelegate? dcb = null;
        private float volume = 0.5f;
        private MMDevice? device = null;
        public MMDevice? Device {
            get => device;
            set {
                Dispose();
                device = value;
                if (device != null) {
                    WaveFormat = device.AudioClient?.MixFormat;
                    dcb = new AudioEndpointVolumeNotificationDelegate(VolumeCb);
                    device.AudioEndpointVolume.OnVolumeNotification += dcb;
                }
            }
        }
        public bool Mute {
            get => Device != null && Device.State == DeviceState.Active && Device.AudioEndpointVolume.Mute;
            set {
                if ((Device == null) || (Device.State != DeviceState.Active)) return;
                Device.AudioEndpointVolume.Mute = value;
            }
        }
        public float Volume {
            get => ((Device == null) || (Device.State != DeviceState.Active)) ? volume :
                (volume = Device.AudioEndpointVolume.MasterVolumeLevelScalar);
            set {
                volume = value;
                if ((Device == null) || (Device.State != DeviceState.Active)) return;
                Device.AudioEndpointVolume.MasterVolumeLevelScalar = value;
            }
        }
        public float VolumePeak => ((Device == null) || (Device.State != DeviceState.Active)) ? 0.0f :
            Device.AudioMeterInformation.MasterPeakValue;

        public WaveFormat? WaveFormat { get; set; } = null;

        ~ApiDev() => Dispose();

        public void Dispose() {
            MMDevice? d = device;
            device = null;
            if (d == null) return;
            if ((d.State == DeviceState.Active) && (dcb != null))
                d.AudioEndpointVolume.OnVolumeNotification -= dcb;
            d.Dispose();
        }

        private void VolumeCb(AudioVolumeNotificationData data) =>
            OnVolumeChanged.Invoke(device, new VolumeEventArgs(data.MasterVolume, data.Muted));

    }
    public class ADev : IDisposable
    {
        [JsonIgnore]
        public static readonly string Member = "Name";
        [JsonIgnore]
        public int Id { get; } = -1;
        [JsonPropertyOrder(0)]
        public SourceNumber Source { get; set; } = SourceNumber.Source_None;
        [JsonPropertyOrder(1)]
        public string Name { get; set; } = string.Empty;
        [JsonPropertyOrder(4)]
        public string Icon { get; set; } = string.Empty;
        [JsonPropertyOrder(2)]
        public bool Enable { get; set; } = false;
        [JsonPropertyOrder(5)]
        public int[] Channels { get; set; } = new int[2] { -1,-1 };
        [JsonPropertyOrder(3)]
        public float Volume {
            get => ApiDevice.Volume;
            set => ApiDevice.Volume = value;
        }
        [JsonIgnore]
        public bool Mute {
            get => ApiDevice.Mute;
            set => ApiDevice.Mute = value;
        }
        [JsonIgnore]
        public float VolumePeak {
            get => ApiDevice.VolumePeak;
        }
        [JsonIgnore]
        public ApiDev ApiDevice { get; } = new();
        [JsonIgnore]
        public WaveFormat? WaveFormat { get => ApiDevice.WaveFormat; }

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
        ~ADev() { Dispose(); }

        public void Dispose() => ApiDevice.Dispose();

        public void Copy(ADev dev)
        {
            Enable = (dev.Source != SourceNumber.Source_None) && dev.Enable;
            Source = dev.Source;
            if (dev.Channels != null) Channels = dev.Channels;
            if (dev.Volume != 0.5f) Volume = dev.Volume;
            if (!string.IsNullOrWhiteSpace(dev.Icon))
                SetIconName(dev.Icon);
        }

        private void SetIconName(string s) =>
            Icon = s.Replace("%windir%\\system32\\", "", StringComparison.InvariantCultureIgnoreCase)
                    .Replace(".dll,-", "_", StringComparison.InvariantCultureIgnoreCase);
    }
}
