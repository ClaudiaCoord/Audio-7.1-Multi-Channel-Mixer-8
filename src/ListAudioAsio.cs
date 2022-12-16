﻿/*
	Git: https://github.com/ClaudiaCoord/Audio-7.1-Multi-Channel-Mixer-8
	ASIO 8 Multi Channel Mixer / 7.1 Sound card compatible (CM6206).
	(c) CC 2022, MIT

	See README.md for more details.
	NOT FOR CHINESE USE FOR SALES! FREE SOFTWARE!
*/
using System.Collections.ObjectModel;
using NAudio.Wave;

namespace MCM8
{
    internal class ListAudioAsio
    {
        public ObservableCollection<ADev> Devices { get; } = new ObservableCollection<ADev>();
        public Action<int> OnDevicesListComplette = (n) => { };
        public ADev? SelectedDevice {
            get {
                if (Devices.Count == 0)
                    return null;
                string name = Properties.Settings.Default.AsioOutName;
                if (string.IsNullOrWhiteSpace(name))
                    return null;
                return (from i in Devices
                        where i.Name.Equals(name)
                        select i).FirstOrDefault();
            }
            set {
                if (value != null)
                    Properties.Settings.Default.AsioOutName = value.Name;
            }
        }

        public int SelectedChannels {
            get => (Properties.Settings.Default.AsioOutChannel < 2) ? 2 :
                ((Properties.Settings.Default.AsioOutChannel > 8) ? 8 : Properties.Settings.Default.AsioOutChannel);
            set => Properties.Settings.Default.AsioOutChannel = value;
        }

        public void Init()
        {
            Devices.Clear();
            int n = 0;
            var ss = AsioOut.GetDriverNames();
            foreach (var s in ss)
                Devices.Add(new ADev(n++, s));
            OnDevicesListComplette.Invoke(n);
        }
    }
}
