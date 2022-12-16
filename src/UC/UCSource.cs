/*
	Git: https://github.com/ClaudiaCoord/Audio-7.1-Multi-Channel-Mixer-8
	ASIO 8 Multi Channel Mixer / 7.1 Sound card compatible (CM6206).
	(c) CC 2022, MIT

	See README.md for more details.
	NOT FOR CHINESE USE FOR SALES! FREE SOFTWARE!
*/

using MCM8.Audio;
using NAudio.Gui;

namespace MCM8.UC
{
    public partial class UCSource : UserControl
    {
        private readonly RadioButton[] ChannelsMatrix1;
        private readonly RadioButton[] ChannelsMatrix2;
        private SourceNumber sourceId = SourceNumber.Source_None;

        public UCSource()
        {
            InitializeComponent();
            cmDevicesBox.DisplayMember = ADev.Member;

            ChannelsMatrix1 = new RadioButton[] {
                rbn11, rbn12, rbn13, rbn14, rbn15, rbn16, rbn17, rbn18
            };
            ChannelsMatrix2 = new RadioButton[] {
                rbn21, rbn22, rbn23, rbn24, rbn25, rbn26, rbn27, rbn28
            };
        }

        public event EventHandler OnEnebledSource = delegate { };
        public event EventHandler OnSelectedSource = delegate { };
        public event EventHandler OnVolumeChanged = delegate { };
        public event EventHandler OnError = delegate { };

        public SourceNumber SourceId {
            get => sourceId;
            set {
                if ((sourceId == value) || !(sourceId == SourceNumber.Source_None)) return;
                sourceId = value;
                int x = sourceId.ToInt() + 1;
                lbChannel1.Text = $"{x}/1";
                lbChannel2.Text = $"{x}/2";
                gbSourceCtrl.Text = $"{gbSourceCtrl.Text} {x}";
            }
        }

        public List<ADev>? DevicesList {
            get => cmDevicesBox.DataSource as List<ADev>;
            set {
                if (value == null) return;
                List<ADev> devs = new List<ADev>();
                foreach (var v in value) {
                    if ((v.Id == -10) && (v.PlayerId.ToInt() != SourceId.ToInt()))
                        continue;
                    devs.Add(v);
                }
                cmDevicesBox.Invoker(() => cmDevicesBox.DataSource = devs);
                ADev? dev = (from i in devs
                             where i.SourceId == SourceId
                             select i).FirstOrDefault();
                if (dev != null) {
                    if ((dev.Id >= 0) || (dev.Id == -10))
                        cmDevicesBox.Invoker(() => cmDevicesBox.SelectedItem = dev);
                    else
                        dev.SourceId = SourceNumber.Source_None;
                }
            }
        }
        public ADev? SelectedDevice
        {
            get {
                if (cmDevicesBox.SelectedItem is ADev dev) {
                    dev.SourceId = SourceId;
                    dev.PlayerId = (dev.Id == -10) ? SourceId.PlayerFromSourceNumber() : PlayerSourceNumber.Player_None;
                    dev.Channels = Channels;
                    dev.OnVolumeChanged -= DeviceVolumeChanged;
                    SelectedName(dev);
                    return dev;
                }
                return null;
            }
            set {
                if ((cmDevicesBox.SelectedItem is ADev dev) && (value != dev)) {
                    dev.SourceId = SourceNumber.Source_None;
                    dev.PlayerId = PlayerSourceNumber.Player_None;
                    dev.Channels[0] = -1;
                    dev.Channels[1] = -1;
                    dev.Enable = true;
                }
                if (value == null) return;
                cmDevicesBox.Invoker(() => cmDevicesBox.SelectedItem = value);
            }
        }

        public int[] Channels
        {
            get {
                int xx = sourceId.ToInt() * 2;
                int[] x = new int[] { xx, xx + 1 };
                try {
                    string? s;
                    s = gbSourceChannel1?.Controls?.OfType<RadioButton>()?.FirstOrDefault(r => r.Checked)?.Tag as string;
                    if (s != null)
                        if (!int.TryParse(s, out x[0])) x[0] = xx;
                    s = gbSourceChannel2?.Controls?.OfType<RadioButton>()?.FirstOrDefault(r => r.Checked)?.Tag as string;
                    if (s != null)
                        if (!int.TryParse(s, out x[1])) x[1] = xx + 1;
                }
                catch (Exception ex) { OnError.Invoke(this, new StringEventArgs(ex.Message)); }
                return x;
            }
            set {
                if ((value == null) || (value.Length < 2)) return;
                if ((value[0] >= 0) && (value[0] < ChannelsMatrix1.Length)) {
                    ChannelsMatrix1[value[0]].Invoker(() => ChannelsMatrix1[value[0]].Checked = true);
                } else {
                    int x = sourceId.ToInt();
                    if (x >= 0) {
                        x *= 2;
                        if (x < ChannelsMatrix1.Length)
                            ChannelsMatrix1[x].Invoker(() => ChannelsMatrix1[x].Checked = true);
                    }
                }
                if ((value[1] >= 0) && (value[1] < ChannelsMatrix2.Length)) {
                    ChannelsMatrix2[value[1]].Invoker(() => ChannelsMatrix2[value[1]].Checked = true);
                } else {
                    int x = sourceId.ToInt();
                    if (x >= 0) {
                        x = (x * 2) + 1;
                        if (x < ChannelsMatrix2.Length)
                            ChannelsMatrix2[x].Invoker(() => ChannelsMatrix2[x].Checked = true);
                    }
                }
            }
        }

        private bool volumeMute = false;
        public bool VolumeMute
        {
            get => volumeMute;
            set {
                if (volumeMute == value) return;
                volumeMute = value;
                potVolume.Invoker(() => potVolume.ForeColor = volumeMute ? Color.OrangeRed : Color.DimGray);
            }
        }

        public double Volume
        {
            get => potVolume.Value;
            set
            {
                if (potVolume.Value != value)
                    potVolume.Invoker(() => potVolume.Value = value);
            }
        }

        public bool VolumeEnable
        {
            get => potVolume.Enabled;
            set
            {
                if (potVolume.Enabled != value)
                    potVolume.Invoker(() => {
                        potVolume.Enabled = value;
                        potVolume.ForeColor = value ? Color.DimGray : Color.DarkGray;
                    });
            }
        }

        public float VolumeView
        {
            set => volumeMeter.Invoker(() => volumeMeter.Amplitude = value);
        }

        public new bool Enabled
        {
            get => base.Enabled;
            set {
                if (value == base.Enabled) return;
                chkEnableBox.Invoker(() => chkEnableBox.Checked = base.Enabled = value);
            }
        }

        public bool ControlEnabled
        {
            get => cmDevicesBox.Enabled;
            set {
                if (value == cmDevicesBox.Enabled) return;
                chkEnableBox.Invoker(() =>
                    chkEnableBox.Enabled =
                    gbSourceChannel1.Enabled =
                    gbSourceChannel2.Enabled =
                    cmDevicesBox.Visible =
                    cmDevicesBox.Enabled = value);
                lbName.Visible = !value;
            }
        }

        #region private

        private void cmDevicesBox_SelectedValueChanged(object sender, EventArgs e) {
            if (sender is ComboBox cmb) {
                if (cmb.SelectedItem is ADev dev) {
                    try {
                        if (dev.Id == -10) dev.Enable = true;
                        chkEnableBox.Invoker(() => {
                            chkEnableBox.Checked = dev.Enable;
                            lbName.Text = (dev.Id == -10) ? $"{dev.Name} - {dev.PlayCount} files" : dev.Name;
                        });
                        SelectedName(dev);
                        dev.SourceId = SourceId;
                        Channels = dev.Channels;
                        VolumeEnable = true;

                        if (dev.Volume != 0.5)
                            Volume = 0.0 + dev.Volume;

                        OnSelectedSource.Invoke(this, new ADevEventArgs(dev));
                        ImageChange(dev);
                        dev.OnVolumeChanged += DeviceVolumeChanged;
                    }
                    catch (Exception ex) { OnError.Invoke(this, new StringEventArgs(ex.Message)); }
                }
            }
        }

        #region Volume/Mute

        private void DeviceVolumeChanged(object? sender, EventArgs e)
        {
            if (e is VolumeEventArgs args) {
                Volume = args.Volume;
                VolumeMute = args.Mute;
            }
        }

        private void potVolume_VolumeChanged(object sender, EventArgs e)
        {
            if (sender is Pot pot) {
                OnVolumeChanged.Invoke(this, new VolumeEventArgs((float)pot.Value, VolumeMute));
                if (cmDevicesBox.SelectedItem is ADev dev)
                    dev.Volume = (float) pot.Value;
            }
        }
        private void potVolume_MuteChanged(object sender, EventArgs e)
        {
            if (sender is Pot pot) {
                OnVolumeChanged.Invoke(this, new VolumeEventArgs((float)pot.Value, VolumeMute));
                if (cmDevicesBox.SelectedItem is ADev dev)
                    dev.Mute = VolumeMute;
            }
        }
        private void potVolume_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right) {
                VolumeMute = !volumeMute;
                potVolume_MuteChanged(potVolume, e);
            }
            else if (e.Button == MouseButtons.Middle) {
                potVolume.Value = 0.5;
                potVolume_VolumeChanged(potVolume, e);
            }
        }
        private void potVolume_DoubleClick(object sender, EventArgs e)
        {
            if (sender is Pot pot) {
                pot.Value = 0.5;
                potVolume_VolumeChanged(sender, e);
            }
        }
        #endregion

        private void chkEnableBox_CheckedChanged(object sender, EventArgs e)
        {
            if (sender is CheckBox chb) {
                try {
                    cmDevicesBox.Invoker(() => {
                        cmDevicesBox.Enabled =
                            gbSourceChannel1.Enabled =
                            gbSourceChannel2.Enabled =
                            imgDeviceIconBox.Enabled =
                            volumeMeter.Enabled = chb.Checked;
                    });
                    VolumeEnable = chb.Checked;

                    if (cmDevicesBox.SelectedItem is ADev adev) {
                        adev.Enable = chb.Checked;
                    }
                    OnEnebledSource.Invoke(this, new BoolEventArgs(chb.Checked));
                }
                catch (Exception ex) { OnError.Invoke(this, new StringEventArgs(ex.Message)); }
            }
            
        }

        #endregion

        #region utils private

        private void ImageChange(ADev a)
        {
            if (string.IsNullOrWhiteSpace(a.Icon)) return;
            try {
                if (imgDeviceIconBox.Image != null) {
                    imgDeviceIconBox.Invoker(() => {
                        imgDeviceIconBox.Image.Dispose();
                        imgDeviceIconBox.Image = null;
                    });
                    
                }
                if (a.Icon.StartsWith("mmres_")) {
                    object? obj = Properties.Resources.ResourceManager.GetObject(a.Icon);
                    obj ??= Properties.Resources.ResourceManager.GetObject("main");
                    if (obj is Image img)
                        imgDeviceIconBox.Invoker(() => imgDeviceIconBox.Image = img);
                }
                else
                    imgDeviceIconBox.Invoker(() => imgDeviceIconBox.Load(a.Icon));
            }
            catch (Exception ex) { OnError.Invoke(this, new StringEventArgs(ex.Message)); }
        }

        private void SelectedName(ADev dev) =>
            lbName.Invoker(() => {
                lbName.Text = (dev.Id == -10) ? $"{dev.Name} - ({dev.PlayCount} files)" : dev.Name;
            });
        #endregion

    }
}
