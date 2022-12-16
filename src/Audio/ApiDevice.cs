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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace MCM8.Audio
{
    public class ApiDevice : IADevice
    {
#       pragma warning disable CS8602

        public event EventHandler OnVolumeChanged = delegate { };
        public event EventHandler OnError = delegate { };

        public ApiDevice() { }
        public ApiDevice(MMDevice d) => device = d;
        ~ApiDevice() => Dispose();

        private AudioEndpointVolumeNotificationDelegate? dcb = null;
        private MMDevice? device = null;
        public MMDevice? Device
        {
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
        public bool Mute
        {
            get => IsApiDevice && Device.AudioEndpointVolume.Mute;
            set {
                if (!IsApiDevice) return;
                Device.AudioEndpointVolume.Mute = value;
            }
        }
        private float volume = 0.5f;
        public float Volume
        {
            get => IsApiDevice ? (volume = Device.AudioEndpointVolume.MasterVolumeLevelScalar) : volume;
            set {
                if (volume == value) return;
                volume = value;
                if (!IsApiDevice) return;
                Device.AudioEndpointVolume.MasterVolumeLevelScalar = value;
            }
        }
        public float VolumePeak => IsApiDevice ? Device.AudioMeterInformation.MasterPeakValue : 0.0f;

        public bool IsApiDevice => device != null;
        public bool IsApiDeviceReady => IsApiDevice && (device.State == DeviceState.Active);

        public int PlayCount => 0;
        public WaveFormat? WaveFormat { get; private set; } = null;
        public IWaveProvider? Provider => throw new NotImplementedException();
        public List<string> InputFiles { get => throw new NotImplementedException(); set { } }

        public void Dispose()
        {
            MMDevice? d = device;
            device = null;
            if (d == null) return;
            try {
                if (d.State == DeviceState.Active && dcb != null)
                    d.AudioEndpointVolume.OnVolumeNotification -= dcb;
                d.Dispose();
            }
            catch (Exception ex) {
                OnError.Invoke(this, new StringEventArgs(ex.Message));
            }
        }

        public void Clear() { }

        private void VolumeCb(AudioVolumeNotificationData data) =>
            OnVolumeChanged.Invoke(device, new VolumeEventArgs(data.MasterVolume, data.Muted));

#       pragma warning restore CS8602
    }
}
