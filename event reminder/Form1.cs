namespace event_reminder
{
    public partial class Form1 : Form
    {
        int nowmonth,nowdate,nowhours,nowminutes,count=1,i,remhours,remmins,remdays;
        int[] date =new int[4];
        int[] minutes = new int[4];
        int[] month = new int[4];
        int[] hours = new int[4];
        string[] s = new string[10];

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Move(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                notifyIcon1.ShowBalloonTip(1000, "I am here", "i will be here. click me to open the application.", ToolTipIcon.Info);
                this.Hide();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult option =MessageBox.Show("Are you sure you want to close?\n","sure??",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if(option==DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            for (i = 0; i < 3; i++)
            { 
            remhours = hours[i] - nowhours;
            remmins = minutes[i] - nowminutes;
            remdays = date[i] - nowdate;
                if ((remhours <= 0) && (remmins <= 0) && (remdays <= 0))
                {
                    notifyIcon1.ShowBalloonTip(1000, "reminder", "this is a reminder that you have this scheduled at this time\n click to know more details", ToolTipIcon.Info);
                    timer1.Stop();
                }
            }
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            i = count;
            hours[i] = Convert.ToInt32(textBox1.Text);
            minutes[i] = Convert.ToInt32(textBox2.Text);
            date[i]=dateTimePicker1.Value.Day;
            month[i] = dateTimePicker1.Value.Month;
            nowdate = DateTime.Now.Day;
            nowmonth = DateTime.Now.Month;
            nowhours= Convert.ToInt32(DateTime.Now.Hour);
            nowminutes= Convert.ToInt32(DateTime.Now.Minute);
            s[i]=textBox3.Text;
            label2.Visible = true;
            label3.Visible = true;
            label5.Visible = true;
            label4.Visible = true;
            label7.Visible = true;
            label6.Visible = true;
            if (count == 1)
            {
                label2.Text = string.Format("--> on {0} / {1} at {2} : {3}", date[i], month[i], hours[i], minutes[i]);
                label3.Text = String.Format("--> {0}", s[i]);
            }
            if (count == 2)
            {
                label5.Text = string.Format("--> on {0} / {1} at {2} : {3}", date[i], month[i], hours[i], minutes[i]);
                label4.Text = String.Format("--> {0}", s[i]);
            }
            if (count == 3)
            {
                label7.Text = string.Format("--> on {0} / {1} at {2} : {3}", date[i], month[i], hours[i], minutes[i]);
                label6.Text = String.Format("--> {0}", s[i]);
                button1.Hide();
            }
            count++;
            timer1.Start();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}