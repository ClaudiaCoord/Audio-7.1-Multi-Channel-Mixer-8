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
using NAudio.CoreAudioApi;
using NAudio.Wave;

namespace MCM8
{
    internal class ListAudioIn
    {
        public ObservableCollection<ADev> AudioInDevices { get; } = new ObservableCollection<ADev>();
        public Action<int> OnDevicesListComplette = (n) => { };
        public event EventHandler OnError = delegate { };

        public void Init()
        {
            try {
                AudioInDevices.Clear();
                AudioInDevices.Add(new ADev(-1, Properties.Resources.ComboBoxNotSelected));
                MMDeviceEnumerator? enumerator = null;

                try {
                    enumerator = new MMDeviceEnumerator();
                    var devices = enumerator.EnumerateAudioEndPoints(DataFlow.Capture, DeviceState.Active);

                    for (int n = 0; n < WaveIn.DeviceCount; n++)
                    {
                        var a = WaveIn.GetCapabilities(n);
                        var d = (from i in devices
                                 where i.FriendlyName.StartsWith(a.ProductName)
                                 select i).FirstOrDefault();
                        if (d != null)
                            AudioInDevices.Add(new ADev(n, d.FriendlyName, d.IconPath));
                        else
                            AudioInDevices.Add(new ADev(n, a.ProductName));
                        OnError.Invoke(this, new StringEventArgs($"{n}: {a.ProductName} {a.Channels}"));
                    }
                }
                catch (Exception ex) {
                    OnError.Invoke(this, new StringEventArgs(ex.Message));
                    return;
                }
                finally
                {
                    enumerator?.Dispose();
                }
                var json = Properties.Settings.Default.JsonInputDevices;
                if (!string.IsNullOrWhiteSpace(json))
                {
                    var opt = new JsonSerializerOptions
                    {
                        IgnoreReadOnlyFields = true,
                        IgnoreReadOnlyProperties = true,
                        AllowTrailingCommas = true,
                    };
                    ADevList? list = JsonSerializer.Deserialize<ADevList>(json, opt);
                    if ((list != null) && (list.Devices.Count > 0))
                    {
                        foreach(ADev? a in list.Devices)
                        {
                            ADev? dev = (from i in AudioInDevices
                                         where i.Name.Equals(a.Name)
                                         select i).FirstOrDefault();
                            dev?.Copy(a);
                        }
                    }
                }
                OnDevicesListComplette.Invoke(WaveIn.DeviceCount);
            }
            catch (Exception ex) {
                OnError.Invoke(this, new StringEventArgs(ex.Message));
                OnDevicesListComplette.Invoke(0);
            }
        }

        public List<ADev> GetDevicesList() => AudioInDevices.ToList();
        public ADev? GetDevice(SourceNumber cn) =>
            (from i in AudioInDevices
             where i.Source == cn
             select i).FirstOrDefault();

        public void Save()
        {
            try {
                ADevList list = new(AudioInDevices.ToList());
                var opt = new JsonSerializerOptions {
                    WriteIndented = true,
                    IgnoreReadOnlyFields = true,
                    IgnoreReadOnlyProperties = true,
                    AllowTrailingCommas = true
                };
                string json = JsonSerializer.Serialize<ADevList>(list, opt);
                if (!string.IsNullOrWhiteSpace(json))
                    Properties.Settings.Default.JsonInputDevices = json;
            }
            catch (Exception ex) {
                OnError.Invoke(this, new StringEventArgs(ex.Message));
            }
        }

        public void MergeChanged(ADev a)
        {
            if (a.Source == SourceNumber.Source_None)
                return;

            var aa = (from i in AudioInDevices
                      where i.Source == a.Source
                      select i).ToArray();

            if ((aa != null) && (aa.Length > 0)) {
                foreach (ADev dev in aa) {
                    if (dev.Id == a.Id)
                        dev.Copy(a);
                    else
                        dev.Source = SourceNumber.Source_None; 
                }
            }
        }

        public void SetDisable(SourceNumber cn)
        {
            ADev? a =(from i in AudioInDevices
                      where i.Source == cn
                      select i).FirstOrDefault();
            if ((a != null) && a.Enable)
                a.Enable = false;
        }
    }
}
