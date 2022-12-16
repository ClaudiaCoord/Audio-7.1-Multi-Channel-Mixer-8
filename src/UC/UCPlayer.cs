/*
	Git: https://github.com/ClaudiaCoord/Audio-7.1-Multi-Channel-Mixer-8
	ASIO 8 Multi Channel Mixer / 7.1 Sound card compatible (CM6206).
	(c) CC 2022, MIT

	See README.md for more details.
	NOT FOR CHINESE USE FOR SALES! FREE SOFTWARE!
*/

using System.ComponentModel;
using MCM8.Audio;

namespace MCM8.UC
{
    public partial class UCPlayer : UserControl
    {
        public UCPlayer()
        {
            InitializeComponent();
            cbSource.SelectedIndex = 0;
        }

        public event EventHandler OnError = delegate { };
        public event EventHandler OnFolderSelected = delegate { };
        public event EventHandler OnPlayerSelected = delegate { };
        public event EventHandler OnMediaControl = delegate { };

        public string FolderPath {
            get => lbFolderPath.Text;
            set => lbFolderPath.Invoker(() => lbFolderPath.Text = value);
        }
        public int PlayCounts {
            set => pbPlayStatus.Invoker(() => {
                bool b = value > 0;
                lbPlayCounts.Text = b ? value.ToString() : "-";
                btnClearControl.Enabled = b;
                pbPlayStatus.Image = b ?
                    Properties.Resources.Media_Controls_Pause_icon_32x32 :
                     Properties.Resources.Media_Controls_Stop_icon_32x32;
            });
        }
        public new bool Enabled {
            get => pbEnabled.Enabled;
            set => pbEnabled.Invoker(() => {
                pbEnabled.Image = value ?
                    Properties.Resources.Media_Controls_Medium_Volume_icon_32x32 :
                    Properties.Resources.Media_Controls_Mute_icon_32x32;
                gbPlayerControl.Enabled = value;
                if (!value) {
                    lbPlayCounts.Text = "-";
                    lbFolderPath.Text = string.Empty;
                }
                }); 
        }
        private bool statusPlay = false;
        public bool StatusPlay {
            get => statusPlay;
            set {
                if (statusPlay == value) return;
                statusPlay = value;
                pbPlayStatus.Invoker(() => {
                    pbPlayStatus.Image = value ?
                        Properties.Resources.Media_Controls_Play_icon_32x32 :
                        Properties.Resources.Media_Controls_Stop_icon_32x32;
                    btnClearControl.Enabled =
                    btnFolderSelect.Enabled = !value;
                });
            }
        }
        public int SelectedIndex
        {
            get => cbSource.SelectedIndex;
            set => cbSource.SelectedIndex = value;
        }
        public string SetError { set => PanelErrorProvider(value); }

        public void InitPlayer(string path) => bgWorker.RunWorkerAsync(path);

        private void cbSource_SelectedValueChanged(object sender, EventArgs e) =>
            OnPlayerSelected.Invoke(this, new MediaCtrlEventArgs(cbSource.SelectedIndex.PlayerFromInt(), PlayerSourceControl.Player_Idle));

        private void btnClearControl_Click(object sender, EventArgs e) =>
            OnPlayerSelected.Invoke(this, new MediaCtrlEventArgs(cbSource.SelectedIndex.PlayerFromInt(), PlayerSourceControl.Player_Clear));

        private void btnFolderSelect_Click(object sender, EventArgs e)
        {
            if (dialogFolderBrowser.ShowDialog() == DialogResult.OK)
                bgWorker.RunWorkerAsync(new Tuple<PlayerSourceNumber, string>(
                    cbSource.SelectedIndex.PlayerFromInt(),
                    dialogFolderBrowser.SelectedPath));
        }

        private void bgWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            try {
                FolderPath = string.Empty;
                PlayCounts = 0;

                if (e.Argument is Tuple<PlayerSourceNumber, string> t) {
                    string[] fp = Directory.GetFiles(t.Item2, "*.mp3", SearchOption.AllDirectories);
                    if (fp.Length == 0) return;
                    OnFolderSelected.Invoke(this, new ListEventArgs(t.Item1, t.Item2, new List<string>(fp)));
                    e.Result = true;
                } else {
                    e.Result = false;
                }
            } catch (Exception ex) {
                OnError.Invoke(this, new StringEventArgs(ex.Message));
                PanelErrorProvider(ex.Message);
            }
        }

        private void bgWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if ((e.Result != null) && (bool)e.Result) {
                Enabled = true;
            }
        }

        private void PanelErrorProvider(string s)
        {
            lbPlayCounts.Invoker(() => {
                try {
                    if (string.IsNullOrWhiteSpace(s))
                        ucErrorProvider.Clear();
                    else
                        ucErrorProvider.SetError(lbPlayCounts, s.ToLower());
                } catch { }
            });
        }
    }
}
