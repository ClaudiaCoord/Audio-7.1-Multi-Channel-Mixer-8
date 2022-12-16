/*
	Git: https://github.com/ClaudiaCoord/Audio-7.1-Multi-Channel-Mixer-8
	ASIO 8 Multi Channel Mixer / 7.1 Sound card compatible (CM6206).
	(c) CC 2022, MIT

	See README.md for more details.
	NOT FOR CHINESE USE FOR SALES! FREE SOFTWARE!
*/

#define TRAY_ICON_ALWAYS

using System.ComponentModel;
using MCM8.Audio;
using MCM8.UC;

namespace MCM8
{
    public partial class Form1 : Form
    {
        private bool OnInit = false;
        private int keyIndex = -1;
        private readonly Label[] labelPlayers = new Label[4];
        private readonly UCSource[] audioSrc = new UCSource[4];
        private readonly List<string> logList = new();
        private readonly AudioData AData = new();

        public Form1() => InitializeComponent();

        private void Form1_Load(object sender, EventArgs e)
        {
            AData.Ctrl = this;

            audioSrc[0] = ucSource1;
            audioSrc[1] = ucSource2;
            audioSrc[2] = ucSource3;
            audioSrc[3] = ucSource4;

            labelPlayers[0] = lbPlayer1;
            labelPlayers[1] = lbPlayer2;
            labelPlayers[2] = lbPlayer3;
            labelPlayers[3] = lbPlayer4;

            AData.OnError += ToLog;
            AData.AudioChannelMix.OnPlayerError += (s, a) =>
            {
                if (a is StringEventArgs args) ucPlayer.SetError = args.Text;
            };
            AData.AudioChannelMix.OnAsioEvent += (s, a) =>
            {
                if (a is StringEventArgs args) ucAsio.AsioStatus = args.Text;
            };
            ucPlayer.OnError += ToLog;
            ucPlayer.OnFolderSelected += (s, a) => UcSelectedPlayer(a);
            ucPlayer.OnPlayerSelected += (s, a) => UcSelectedPlayer(a);
            ucPlayer.OnMediaControl += (s, a) =>
            {
                if (a is MediaCtrlEventArgs args)
                    ToLog($"Media Controls Event Arguments: {args.PlayerId}, {args.PlayerCtrl}");
            };

            ucAsio.OnError += ToLog;
            ucAsio.OnChannelsCountChanged += (s, a) =>
            {
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
                    AData.ListAsio.SelectedChannels = args.Number;
                }
            };
            ucAsio.OnSelectedDestination += (s, a) =>
            {
                if (!OnInit) return;
                if (a is ADevEventArgs args)
                    AData.ListAsio.SelectedDevice = args.Dev;
            };
            ucAsio.OnCallAsioPanel += (s, a) => btnASIOSettings_Click(s, a);

            backgroundWorker1.RunWorkerAsync();
        }

        private void timer1_Tick(object? sender, EventArgs e)
        {
            progressBar1.Invoker(() => progressBar1.Visible = false);
            timer1.Stop();
            timer1.Tick -= timer1_Tick;
            timer1.Tick += timer1_TickPeak;
        }

        private void timer1_TickPeak(object? sender, EventArgs e)
        {
            for (int i = 0; i < audioSrc.Length; i++)
            {
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

            worker.ReportProgress(5);
            AData.Load((a) => worker.ReportProgress(a));
            if (worker.CancellationPending == true)
            {
                e.Cancel = true;
                return;
            }
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled == true)
                ToLog("Loading Canceled!");
            else if (e.Error != null)
                ToLog($"Error: {e.Error.Message}");
            else
                ToLog("Loading Done..");

            ucAsio.ChannelsCount = AData.ListAsio.SelectedChannels;
            ucAsio.DevicesList = AData.ListAsio.Devices.ToList();
            ADev? a = AData.ListAsio.SelectedDevice;
            if (a != null)
                ucAsio.SelectedDevice = a;
            else
            {
                AData.ListAsio.SelectedDevice = ucAsio.SelectedDevice;
            }

            for (int i = 0; i < audioSrc.Length; i++)
            {
                audioSrc[i].OnError += ToLog;
                audioSrc[i].OnSelectedSource += UcSelectedSource;
                audioSrc[i].SourceId = i.SourceFromInt();
                audioSrc[i].DevicesList = AData.ListIn.GetDevicesList();
            }

            backgroundWorker1_ProgressChanged(new object(), new ProgressChangedEventArgs(100, null));
            timer1.Interval = 1000;
            timer1.Start();
            btnStart.Enabled = true;

            OnInit = true;
        }

        #region ToLog
        public void ToLog(Exception? e)
        {
#           if DEBUG
            if (e is Audio8Exception ea)
                ToLog($"{ea.Message} ({ea.ExcClass}:{ea.ExcLine})");
            else
#           endif
            if (e != null)
                ToLog(e.Message);
        }
        public void ToLog(string msg)
        {
            try
            {
                logList.Insert(0, msg);
                textBox1.Invoker(() => textBox1.Lines = logList.ToArray());
            }
            catch { }
        }
        public void ToLog(object? sender, EventArgs args)
        {
            try
            {
                if (args is StringEventArgs s)
                {
                    logList.Insert(0, s.Text);
                    textBox1.Invoker(() => textBox1.Lines = logList.ToArray());
                }
            }
            catch { }
        }
        #endregion

        private void UcSelectedSource(object? sender, EventArgs args)
        {
            if (args is ADevEventArgs a)
            {
                if (a.Dev.Id == -1)
                {
                    a.Dev.SourceId = SourceNumber.Source_None;
                    a.Dev.Enable = false;
                    return;
                }
                a.Dev.Enable = a.Dev.SourceId != SourceNumber.Source_None;
                AData.ListIn.MergeChanged(a.Dev);
                if ((a.Dev.Id == -10) && (a.Dev.SourceId != SourceNumber.Source_None))
                {
                    int x = a.Dev.SourceId.ToInt();
                    if (x >= 0)
                        ucPlayer.SelectedIndex = x;
                }
            }
        }

        private void UcSelectedPlayer(EventArgs a)
        {
            try
            {

                PlayerSourceNumber pid = PlayerSourceNumber.Player_None;
                PlayerSourceControl psc = PlayerSourceControl.Player_Idle;
                if (a is MediaCtrlEventArgs arg1)
                {
                    pid = arg1.PlayerId;
                    psc = arg1.PlayerCtrl;
                }
                else if (a is ListEventArgs arg2) pid = arg2.PlayerId;
                else return;
                if (pid == PlayerSourceNumber.Player_None) return;

                ApiPlayer? player = (from i in AData.ListPlayers.Players
                                     where i.PlayerId == pid
                                     select i).FirstOrDefault();
                if (player != null)
                {

                    if (psc == PlayerSourceControl.Player_Clear)
                        player.Clear();

                    else if (a is ListEventArgs arg2)
                    {
                        player.InputFiles = arg2.List;
                        ToLog($"Play list build from  {arg2.Folder}");
                        foreach (var p in arg2.List)
                            ToLog($"+ {Path.GetFileName(p)}");
                    }
                    UcSetPlayer(pid, psc, player.InputFiles);
                }
            }
            catch (Exception ex) { ToLog(ex.Message); }
        }
        private void UcSetPlayer(PlayerSourceNumber pid, PlayerSourceControl psc, List<string> list)
        {
            int x = pid.ToInt();
            if (x >= 0)
            {
                bool b = list.Count > 0;
                labelPlayers[x].ForeColor = b ? Color.White : Color.Black;
                labelPlayers[x].BackColor = b ? Color.Black : Color.White;
                string? s = b ? Path.GetDirectoryName(list[0]) : string.Empty;
                if (s != null)
                    ucPlayer.FolderPath = s;
                ucPlayer.PlayCounts = list.Count;
                ucPlayer.Enabled = b;
            }
        }

        #region Buttons

        private void btnStart_Click(object sender, EventArgs e)
        {
            /* Start */
            try
            {
                List<ADev> list = new();
                for (int i = 0; i < audioSrc.Length; i++)
                {
                    ADev? dev = audioSrc[i].SelectedDevice;
                    if ((dev != null) && dev.Enable && (dev.Id != -1))
                        list.Add(dev);
                }

                ucPlayer.SetError = string.Empty;

                AData.Begin(list);
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

                foreach (var p in AData.ListPlayers.Players)
                {
                    if ((p != null) && p.IsApiDeviceReady)
                    {
                        ucPlayer.StatusPlay = true; break;
                    }
                }
            }
            catch (Exception ex)
            {
                ToLog(ex);
                btnStop_Click(sender, e);
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            /* Stop */
            try
            {
                AData.End();
                timer1.Stop();

                btnStop.Enabled =
                btnASIOSettings.Enabled = false;
                btnStart.Enabled =
                btnDefaultChannels.Enabled = true;

                ucAsio.ControlEnabled = true;
                ucAsio.AsioStatus = Properties.Resources.LabelAsioOff;

                for (int i = 0; i < audioSrc.Length; i++)
                {
                    audioSrc[i].ControlEnabled = true;
                    audioSrc[i].VolumeView = 0.0f;
                }
                ucPlayer.StatusPlay = false;
                notifyIcon1.Icon = Properties.Resources.main_tray_off;
            }
            catch (Exception ex)
            {
                ToLog(ex);
            }
        }

        private void btnSaveSettings_Click(object sender, EventArgs e) =>
            AData.Save();

        private void btnClearLog_Click(object sender, EventArgs e)
        {
            try
            {
                logList.Clear();
                textBox1.Invoker(() => textBox1.Text = string.Empty);
            }
            catch { }
        }

        private void btnDefaultChannels_Click(object sender, EventArgs e)
        {
            try
            {
                int[] x = new int[] { -1, -1 };
                for (int i = 0; i < audioSrc.Length; i++)
                    audioSrc[i].Channels = x;
            }
            catch { }
        }

        private void btnASIOSettings_Click(object? sender, EventArgs e)
        {
            if (AData.AudioChannelMix.IsStart)
                AData.AudioChannelMix.ShowASIOPanel();
        }
        #endregion

        #region Forms handlers

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                notifyIcon1.Visible = true;
                if (AData.AudioChannelMix.IsStart && timer1.Enabled) timer1.Stop();
                Hide();
            }
            else if (WindowState == FormWindowState.Normal)
            {
#if !TRAY_ICON_ALWAYS
                notifyIcon1.Visible = false;
#endif
                if (AData.AudioChannelMix.IsStart) timer1.Start();
            }
        }

        private void notifyIcon1_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                Show();
                Activate();
                WindowState = FormWindowState.Normal;
#if !TRAY_ICON_ALWAYS
                notifyIcon1.Visible = false;
#endif
                if (AData.AudioChannelMix.IsStart) timer1.Start();
            }
            else if (WindowState == FormWindowState.Normal)
            {
                Hide();
                WindowState = FormWindowState.Minimized;
                notifyIcon1.Visible = true;
                if (AData.AudioChannelMix.IsStart && timer1.Enabled) timer1.Stop();
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            try {
                AData.End();
                AData.Dispose();
            } catch { }
            e.Cancel = false;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch(e.KeyCode) {
                case Keys.Play:
                case Keys.Pause:
                case Keys.MediaStop:
                case Keys.MediaPlayPause: {
                        if (btnStop.Enabled)
                            btnStop_Click(this, new EventArgs());
                        else
                            btnStart_Click(this, new EventArgs());
                        break;
                    }
                case Keys.MediaNextTrack:
                case Keys.MediaPreviousTrack: {
                        keyIndex = (keyIndex >= (audioSrc.Length - 1)) ? -1 :
                            (e.KeyCode == Keys.MediaNextTrack) ? keyIndex + 1 : keyIndex - 1;
                        for (int i = 0; i < audioSrc.Length; i++) {
                            if (i == keyIndex)
                                audioSrc[i].VolumeMute = true;
                            else
                                audioSrc[i].VolumeMute = false;
                        }
                        break;
                    }
            }
        }
        #endregion

    }
}