/*
	Git: https://github.com/ClaudiaCoord/Audio-7.1-Multi-Channel-Mixer-8
	ASIO 8 Multi Channel Mixer / 7.1 Sound card compatible (CM6206).
	(c) CC 2022, MIT

	See README.md for more details.
	NOT FOR CHINESE USE FOR SALES! FREE SOFTWARE!
*/

namespace MCM8.UC
{
    public partial class UCASIO : UserControl
    {
        private RadioButton[] ChannelsSelector;

        public UCASIO()
        {
            InitializeComponent();
            DeviceAsioOutBox.DisplayMember = ADev.Member;

            ChannelsSelector = new RadioButton[] {
                rb2, rb4, rb6, rb8
            };
        }

        public event EventHandler OnSelectedDestination = delegate { };
        public event EventHandler OnChannelsCountChanged = delegate { };
        public event EventHandler OnCallAsioPanel = delegate { };
        public event EventHandler OnError = delegate { };

        public List<ADev>? DevicesList
        {
            get => DeviceAsioOutBox.DataSource as List<ADev>;
            set => DeviceAsioOutBox.Invoker(() => DeviceAsioOutBox.DataSource = value);
        }
        public ADev? SelectedDevice
        {
            get {
                if (DeviceAsioOutBox.SelectedItem is ADev dev) {
                    dev.Source = SourceNumber.Source_None;
                    dev.Channels[0] = -1;
                    dev.Channels[1] = -1;
                    return dev;
                }
                return null;
            }
            set {
                if (DeviceAsioOutBox.SelectedItem is ADev dev) {
                    dev.Source = SourceNumber.Source_None;
                    dev.Channels[0] = -1;
                    dev.Channels[1] = -1;
                    dev.Enable = true;
                }
                if (value == null) return;
                DeviceAsioOutBox.Invoker(() => DeviceAsioOutBox.SelectedItem = value);
            }
        }

        public string AsioStatus {
            set => labelAsioStatus.Invoker(() => labelAsioStatus.Text = value);
        }

        public int ChannelsCount
        {
            get {
                int x = -1;
                try {
                    string? s = gbAsio?.Controls?.OfType<RadioButton>()?.FirstOrDefault(r => r.Checked)?.Tag as string;
                    if (s != null)
                        if (!int.TryParse(s, out x)) x = -1;
                }
                catch (Exception ex) { OnError.Invoke(this, new StringEventArgs(ex.Message)); }
                return x;
            }
            set {
                int x = value.ToChannelIndex();
                if ((x < 0) || (x > 3)) return;

                ChannelsSelector[x].Invoker(() => ChannelsSelector[x].Checked = true);
                OnChannelsCountChanged.Invoke(this, new IntEventArgs(value));
            }
        }

        public bool ControlEnabled
        {
            get => base.Enabled;
            set {
                if (value == base.Enabled) return;
                gbAsio.Invoker(() => gbAsio.Enabled = value);
            }
        }


        private void DeviceAsioOutBox_SelectedValueChanged(object sender, EventArgs e)
        {
            if (sender is ComboBox cmb) {
                if (cmb.SelectedItem is ADev dev) {
                    try {
                        OnSelectedDestination.Invoke(this, new ADevEventArgs(dev));
                    }
                    catch (Exception ex) { OnError.Invoke(this, new StringEventArgs(ex.Message)); }
                }
            }
        }

        private void CheckedChanged(object sender)
        {
            if ((sender is RadioButton rb) && (rb.Tag != null)) {
                try {
                    int x;
                    if (int.TryParse(rb.Tag.ToString(), out x))
                        OnChannelsCountChanged.Invoke(this, new IntEventArgs(x));
                }
                catch (Exception ex) { OnError.Invoke(this, new StringEventArgs(ex.Message)); }
            }
        }

        private void rb2_CheckedChanged(object sender, EventArgs e) => CheckedChanged(sender);
        private void rb4_CheckedChanged(object sender, EventArgs e) => CheckedChanged(sender);
        private void rb6_CheckedChanged(object sender, EventArgs e) => CheckedChanged(sender);
        private void rb8_CheckedChanged(object sender, EventArgs e) => CheckedChanged(sender);

        private void pictureBox1_DoubleClick(object sender, EventArgs e) =>
            OnCallAsioPanel.Invoke(sender, e);
    }
}
