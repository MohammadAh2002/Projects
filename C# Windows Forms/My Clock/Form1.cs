using System;
using System.Drawing;
using System.Windows.Forms;

namespace My_Clock
{

    public partial class ClockForm : Form
    {

        public ClockForm()
        {
            InitializeComponent();

            rdAlarm.Checked = true;

        }

        // Alarm
        void AlarmVisableFalse()
        {

            lbAlarmAt.Visible = false;
            lbHours.Visible = false;
            lbMinutes.Visible = false;
            lbSeconds.Visible = false;

            btAlarm.Visible = false;
            bCancelAlarm.Visible = false;

            nudHours.Visible = false;
            nudMinutes.Visible = false;
            nudSeconds.Visible = false;

            MainTimer.Enabled = false;
            lbTime.Visible = false;

        }
        void AlarmVisableTrue()
        {

            lbAlarmAt.Visible = true;
            lbHours.Visible = true;
            lbMinutes.Visible = true;
            lbSeconds.Visible = true;

            btAlarm.Visible = true;
            bCancelAlarm.Visible = true;

            nudHours.Value = 0;
            nudMinutes.Value = 0;
            nudSeconds.Value = 0;

            nudHours.Visible = true;
            nudMinutes.Visible = true;
            nudSeconds.Visible = true;

            MainTimer.Enabled = true;
            lbTime.Visible = true;
            lbAlarmAt.Text = "No Alarm Set";

        }
        void UpdateALarmTime()
        {

            lbAlarmAt.Text = "Alarm at: " + GetHours() + ":" + GetMinutes() + ":" + GetSeconds();

        }
        private void SetAlarm(object sender, EventArgs e)
        {

            AlarmTick.Enabled = true;

            notifyIcon1.Icon = SystemIcons.Application;
            notifyIcon1.BalloonTipIcon = ToolTipIcon.Info;
            notifyIcon1.BalloonTipTitle = "Alarm Set";
            notifyIcon1.BalloonTipText = "Alarm set on: " + GetHours() + ":" + GetMinutes() + ":" + GetSeconds();

            notifyIcon1.ShowBalloonTip(1000);

        }
        private void CancelAlarm(object sender, EventArgs e)
        {
            AlarmTick.Enabled = false;

            notifyIcon1.Icon = SystemIcons.Application;
            notifyIcon1.BalloonTipIcon = ToolTipIcon.Info;
            notifyIcon1.BalloonTipTitle = "Alarm Cancel";
            notifyIcon1.BalloonTipText = "Alarm Canceld ";

            lbAlarmAt.Text = "No Alarm Set";

            notifyIcon1.ShowBalloonTip(1000);

        }
        private void IsAlarmTime(object sender, EventArgs e)
        {

            if ((GetHours() + ":" + GetMinutes() + ":" + GetSeconds()) == DateTime.Now.ToString("HH:mm:ss"))
            {

                notifyIcon1.Icon = SystemIcons.Application;
                notifyIcon1.BalloonTipIcon = ToolTipIcon.Info;
                notifyIcon1.BalloonTipTitle = "Alarm Time";
                notifyIcon1.BalloonTipText = "the Time is: " + DateTime.Now.ToString("HH:mm:ss");

                notifyIcon1.ShowBalloonTip(1000);

            }

        }
        private void CurrentTime(object sender, EventArgs e)
        {

            lbTime.Text = DateTime.Now.ToString("HH:mm:ss");

        }
       
        // StopWatch
        struct StopWatch
        {

            public DateTime StopWatchTime;
            public TimeSpan StopWatchSpan;

        }
        StopWatch StopWatchInfo;
        void StopWatchVisableFalse()
        {

            lbTime.Visible = false;

            pictureBox1.Visible = false;
            pictureBox2.Visible = false;
            pictureBox3.Visible = false;

        }
        void StopWatchVisableTrue()
        {

            lbTime.Visible = true;
            lbTime.Text = "00:00:00";

            pictureBox1.Visible = true;
            pictureBox2.Visible = true;
            pictureBox3.Visible = true;

        }
        private void StartStopWatch(object sender, EventArgs e)
        {

            if (StopWatchInfo.StopWatchTime.ToString("HH:mm:ss") == "00:00:00")
            {
                StopWatchInfo.StopWatchTime = DateTime.Today
                .AddHours(0)
                .AddMinutes(0)
                .AddSeconds(0);

                StopWatchInfo.StopWatchSpan = TimeSpan.FromSeconds(1);

            }

            StopWatchTick.Enabled = true;

        }
        private void PauseStopWatch(object sender, EventArgs e)
        {

            StopWatchTick.Enabled = false;

        }
        private void ResetStopWatch(object sender, EventArgs e)
        {

            lbTime.Text = "00:00:00";

            StopWatchInfo.StopWatchTime = DateTime.Today
            .AddHours(0)
            .AddMinutes(0)
            .AddSeconds(0);

            StopWatchInfo.StopWatchSpan = TimeSpan.FromSeconds(1);

            StopWatchTick.Enabled = false;

        }
        private void StopWatchRunning(object sender, EventArgs e)
        {

            StopWatchInfo.StopWatchTime += StopWatchInfo.StopWatchSpan;
            lbTime.Text = StopWatchInfo.StopWatchTime.ToString("HH:mm:ss");

        }

        // Timer
        struct TimerInfo
        {

            public DateTime TimerTime;
            public TimeSpan timerSpan;

        }
        TimerInfo Timerinfo;
        void UpdateTimer()
        {

            lbTime.Text = GetHours() + ":" + GetMinutes() + ":" + GetSeconds();

        }
        void TimerVisableFalse()
        {

            lbHours.Visible = false;
            lbMinutes.Visible = false;
            lbSeconds.Visible = false;

            nudHours.Visible = false;
            nudMinutes.Visible = false;
            nudSeconds.Visible = false;

            BStartTimer.Visible = false;
            bResetTimer.Visible = false;

            lbTime.Visible = false;

        }
        void TimerVisableTrue()
        {

            lbHours.Visible = true;
            lbMinutes.Visible = true;
            lbSeconds.Visible = true;

            nudHours.Value = 0;
            nudMinutes.Value = 0;
            nudSeconds.Value = 0;

            nudHours.Visible = true;
            nudMinutes.Visible = true;
            nudSeconds.Visible = true;

            BStartTimer.Visible = true;
            bResetTimer.Visible = true;

            lbTime.Visible = true;
            lbTime.Text = "00:00:00";

        }
        private void ResetTimer(object sender, EventArgs e)
        {
            TimerTick.Enabled = false;

            nudHours.Value = 0;
            nudMinutes.Value = 0;
            nudSeconds.Value = 0;

            lbTime.Text = "00:00:00";

        }
        private void StartTimer(object sender, EventArgs e)
        {

            Timerinfo.TimerTime = DateTime.Today
            .AddHours(Convert.ToInt16(nudHours.Value))
            .AddMinutes(Convert.ToInt16(nudMinutes.Value))
            .AddSeconds(Convert.ToInt16(nudSeconds.Value));

            Timerinfo.timerSpan = TimeSpan.FromSeconds(1);

            TimerTick.Enabled = true;

        }
        void TimerFinshedMessage()
        {

            notifyIcon1.Icon = SystemIcons.Application;
            notifyIcon1.BalloonTipIcon = ToolTipIcon.Info;
            notifyIcon1.BalloonTipTitle = "Timer";
            notifyIcon1.BalloonTipText = "Timer Finshed :-)";

            notifyIcon1.ShowBalloonTip(1000);

        }
        private void IsTimerFinshed(object sender, EventArgs e)
        {

            if (Timerinfo.TimerTime.ToString("HH:mm:ss") != "00:00:00")
            {

                Timerinfo.TimerTime -= Timerinfo.timerSpan;
                lbTime.Text = Timerinfo.TimerTime.ToString("HH:mm:ss");

            }
            else
            {

                TimerFinshedMessage();
                TimerTick.Enabled = false;

            }
        }

        // ValueChange
        private void nudHours_ValueChanged(object sender, EventArgs e)
        {

            if (rdAlarm.Checked)
            {

                UpdateALarmTime();

            }
            if (rdTimer.Checked)
            {

                UpdateTimer();

            }

        }
        private void nudMinutes_ValueChanged(object sender, EventArgs e)
        {
            if (rdAlarm.Checked)
            {

                UpdateALarmTime();

            }
            if (rdTimer.Checked)
            {

                UpdateTimer();

            }

        }
        private void nudSeconds_ValueChanged(object sender, EventArgs e)
        {
            if (rdAlarm.Checked)
            {

                UpdateALarmTime();

            }
            if (rdTimer.Checked)
            {

                UpdateTimer();

            }

        }

        // Main Buttons
        private void rdAlarm_CheckedChanged(object sender, EventArgs e)
        {

            TimerVisableFalse();
            StopWatchVisableFalse();
            AlarmVisableTrue();
            PickedPanelLocation((RadioButton)sender);

        }
        private void rdTimer_CheckedChanged(object sender, EventArgs e)
        {

            AlarmVisableFalse();
            StopWatchVisableFalse();
            TimerVisableTrue();
            PickedPanelLocation((RadioButton)sender);

        }
        private void rdStopWatch_CheckedChanged(object sender, EventArgs e)
        {

            AlarmVisableFalse();
            TimerVisableFalse();
            StopWatchVisableTrue();
            PickedPanelLocation((RadioButton)sender);

        }

        // GetTime
        string GetHours()
        {

            if (nudHours.Value < 10)
            {
                return "0" + nudHours.Value.ToString();

            }

            return nudHours.Value.ToString();
        }
        string GetMinutes()
        {

            if (nudMinutes.Value < 10)
            {
                return "0" + nudMinutes.Value.ToString();

            }

            return nudMinutes.Value.ToString();

        }
        string GetSeconds()
        {

            if (nudSeconds.Value < 10)
            {
                return "0" + nudSeconds.Value.ToString();

            }

            return nudSeconds.Value.ToString();

        }

        // Pick Paned
        void PickedPanelLocation(RadioButton rdButton)
        {

            pPicked.Location = rdButton.Location;

            pPicked.Width = rdButton.Width;

        }

    }
}
