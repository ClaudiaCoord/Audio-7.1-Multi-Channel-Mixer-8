/*
	Git: https://github.com/ClaudiaCoord/Audio-7.1-Multi-Channel-Mixer-8
	ASIO 8 Multi Channel Mixer / 7.1 Sound card compatible (CM6206).
	(c) CC 2022, MIT

	See README.md for more details.
	NOT FOR CHINESE USE FOR SALES! FREE SOFTWARE!
*/

#define TRAY_ICON_ALWAYS

using System.ComponentModel;
using MCM8.UC;

namespace MCM8
{
    public partial class Form1 : Form
    {
        private bool OnInit = false;
        private readonly UCSource[] audioSrc = new UCSource[4];
        private readonly AudioMultiChannelMixer AudioChannelMix = new();
        private readonly ListAudioAsio ListAsio = new();
        private readonly ListAudioIn ListIn = new();
        private readonly List<string> LogList = new();

        public Form1() => InitializeComponent();

        private void Form1_Load(object sender, EventArgs e)
        {
            audioSrc[0] = ucSource1;
            audioSrc[1] = ucSource2;
            audioSrc[2] = ucSource3;
            audioSrc[3] = ucSource4;

            ListIn.OnError += ToLog;
            AudioChannelMix.OnError += ToLog;
            AudioChannelMix.OnAsioEvent += (s, a) => {
                if (a is StringEventArgs args) ucAsio.AsioStatus = args.Text;
            };

            ucAsio.OnError += ToLog;
            ucAsio.OnChannelsCountChanged += (s, a) => {
                if (a is IntEventArgs args)
                {
                    switch (args.Number)
                    {
                        case 2:
                            {
                                audioSrc[0].Enabled = true;
                                audioSrc[1].Enabled = false;
                                audioSrc[2].Enabled = false;
                                audioSrc[3].Enabled = false;
                                break;
                            }
                        case 4:
                            {
                                audioSrc[0].Enabled = true;
                                audioSrc[1].Enabled = true;
                                audioSrc[2].Enabled = false;
                                audioSrc[3].Enabled = false;
                                break;
                            }
                        case 6:
                            {
                                audioSrc[0].Enabled = true;
                                audioSrc[1].Enabled = true;
                                audioSrc[2].Enabled = true;
                                audioSrc[3].Enabled = false;
                                break;
                            }
                        case 8:
                            {
                                for (int i = 0; i < audioSrc.Length; i++)
                                    audioSrc[i].Enabled = true;
                                break;
                            }
                    }
                    ListAsio.SelectedChannels = args.Number;
                }
            };
            ucAsio.OnSelectedDestination += (s, a) => {
                if (!OnInit) return;
                if (a is ADevEventArgs args)
                    ListAsio.SelectedDevice = args.Dev;
            };
            ucAsio.OnCallAsioPanel += (s, a) => btnASIOSettings_Click(s,a);

            backgroundWorker1.RunWorkerAsync();
        }

        private void timer1_Tick(object? sender, EventArgs e) {
            progressBar1.Invoker(() => progressBar1.Visible = false);
            timer1.Stop();
            timer1.Tick -= timer1_Tick;
            timer1.Tick += timer1_TickPeak;
        }

        private void timer1_TickPeak(object? sender, EventArgs e)
        {
            for (int i = 0; i < audioSrc.Length; i++) {
                ADev? dev = audioSrc[i].SelectedDevice;
                if (dev != null)
                    audioSrc[i].VolumeView = dev.VolumePeak;
            }
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e) =>
            progressBar1.Value = e.ProgressPercentage;

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            if (sender is not BackgroundWorker worker) return;

            ListAsio.Init();
            worker.ReportProgress(30);
            if (worker.CancellationPending == true)
            {
                e.Cancel = true;
                return;
            }
            ListIn.Init();
            worker.ReportProgress(95);
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled == true)
                ToLog("Loading Canceled!");
            else if (e.Error != null)
                ToLog($"Error: {e.Error.Message}");
            else
                ToLog("Loading Done..");

            ucAsio.ChannelsCount = ListAsio.SelectedChannels;
            ucAsio.DevicesList = ListAsio.Devices.ToList();
            ADev? a = ListAsio.SelectedDevice;
            if (a != null)
                ucAsio.SelectedDevice = a;
            else {
                ListAsio.SelectedDevice = ucAsio.SelectedDevice;
            }

            for (int i = 0; i < audioSrc.Length; i++)
            {
                audioSrc[i].OnError += ToLog;
                audioSrc[i].OnSelectedSource += UcSelectedSource;
                audioSrc[i].SourceNumber = i.FromInt();
                audioSrc[i].DevicesList = ListIn.GetDevicesList();
            }

            backgroundWorker1_ProgressChanged(new object(), new ProgressChangedEventArgs(100, null));
            timer1.Interval = 1000;
            timer1.Start();

            OnInit = true;
        }

        public void ToLog(string msg) {
            try {
                LogList.Insert(0, msg);
                textBox1.Invoker(() => textBox1.Lines = LogList.ToArray());
            } catch { }
        }
        public void ToLog(object? sender, EventArgs args)
        {
            try {
                if (args is StringEventArgs s) {
                    LogList.Insert(0, s.Text);
                    textBox1.Invoker(() => textBox1.Lines = LogList.ToArray());
                }
            } catch { }
        }

        private void UcSelectedSource(object? sender, EventArgs args)
        {
            if (args is ADevEventArgs a) {
                if (a.Dev.Id == -1) {
                    a.Dev.Source = SourceNumber.Source_None;
                    a.Dev.Enable = false;
                    return;
                }
                a.Dev.Enable = a.Dev.Source != SourceNumber.Source_None;
                ListIn.MergeChanged(a.Dev);
            }
        }

        #region Buttons

        private void btnStart_Click(object sender, EventArgs e)
        {
            /* Start */
            try
            {
                List<ADev> list = new();
                for (int i = 0; i < audioSrc.Length; i++) {
                    ADev? dev = audioSrc[i].SelectedDevice;
                    if ((dev != null) && dev.Enable && (dev.Id >= 0))
                        list.Add(dev);
                }

                AudioChannelMix.Begin(ListAsio, list);
                btnStop.Enabled =
                btnASIOSettings.Enabled = true;
                btnStart.Enabled =
                btnDefaultChannels.Enabled = false;

                ucAsio.ControlEnabled = false;
                for (int i = 0; i < audioSrc.Length; i++)
                    audioSrc[i].ControlEnabled = false;

                notifyIcon1.Icon = Properties.Resources.main_tray_on;
                timer1.Interval = 100;
                timer1.Start();
            }
            catch (Exception ex) { ToLog(ex.Message); }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            /* Stop */
            try {
                AudioChannelMix.End();
                timer1.Stop();

                btnStop.Enabled =
                btnASIOSettings.Enabled = false;
                btnStart.Enabled =
                btnDefaultChannels.Enabled = true;

                ucAsio.ControlEnabled = true;
                ucAsio.AsioStatus = Properties.Resources.LabelAsioOff;

                for (int i = 0; i < audioSrc.Length; i++) {
                    audioSrc[i].ControlEnabled = true;
                    audioSrc[i].VolumeView = 0.0f;
                }

                notifyIcon1.Icon = Properties.Resources.main_tray_off;
            }
            catch (Exception ex) { ToLog(ex.Message); }
        }

        private void btnSaveSettings_Click(object sender, EventArgs e)
        {
            ListIn.Save();
            Properties.Settings.Default.Save();
        }

        private void btnClearLog_Click(object sender, EventArgs e)
        {
            try {
                LogList.Clear();
                textBox1.Invoker(() => textBox1.Text = string.Empty);
            }
            catch { }
        }

        private void btnDefaultChannels_Click(object sender, EventArgs e)
        {
            try {
                int[] x = new int[] { -1,-1 };
                for (int i = 0; i < audioSrc.Length; i++)
                    audioSrc[i].Channels = x;
            }
            catch { }
        }

        private void btnASIOSettings_Click(object? sender, EventArgs e)
        {
            if (AudioChannelMix.IsStart)
                AudioChannelMix.ShowASIOPanel();
        }

        #endregion

        #region Forms handlers

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                notifyIcon1.Visible = true;
                if (AudioChannelMix.IsStart && timer1.Enabled) timer1.Stop();
                Hide();
            }
            else if (WindowState == FormWindowState.Normal) {
#               if !TRAY_ICON_ALWAYS
                notifyIcon1.Visible = false;
#               endif
                if (AudioChannelMix.IsStart) timer1.Start();
            }
        }

        private void notifyIcon1_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized) {
                Show();
                Activate();
                WindowState = FormWindowState.Normal;
#               if !TRAY_ICON_ALWAYS
                notifyIcon1.Visible = false;
#               endif
                if (AudioChannelMix.IsStart) timer1.Start();
            }
            else if (WindowState == FormWindowState.Normal)
            {
                Hide();
                WindowState = FormWindowState.Minimized;
                notifyIcon1.Visible = true;
                if (AudioChannelMix.IsStart && timer1.Enabled) timer1.Stop();
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            try {
                AudioChannelMix.End();
            }
            catch {}
            e.Cancel = false;
        }
        #endregion
    }
}