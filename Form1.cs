using System.Runtime.InteropServices;
using System.Diagnostics;
// Usage: Debug.WriteLine("Text")
using MigraDoc.Rendering;

namespace timetracker
{
    public partial class Form1 : Form
    {
        string path;

        int timeSession = 0;
        int timeToday = 0;
        int timeTotal = 0;

        string startDate;
        string startTime;

        // Time passed since the last break
        // Saved to file on every break
        int timePassed = 0;

        bool idle = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timeSession++;
            timeToday++;
            timeTotal++;
            timePassed++;

            timeSessionLabel.Text = formatTime(timeSession);
            timeTodayLabel.Text = formatTime(timeToday);
            timeTotalLabel.Text = formatTime(timeTotal);
        }

        private void startButton_click(object sender, EventArgs e)
        {
            startTimer();
        }

        private void stopButton_click(object sender, EventArgs e)
        {
            stopTimer();
        }

        private void toolCreateButton_click(object sender, EventArgs e)
        {
            if (timer1.Enabled)
            {
                stopTimer();
            }

            SaveFileDialog sfd = new SaveFileDialog();

            sfd.Title = "Create a new project";
            sfd.Filter = "CSV file (*.csv)|*.csv";
            sfd.FilterIndex = 2;
            sfd.RestoreDirectory = true;
            sfd.InitialDirectory = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "projects");
            sfd.OverwritePrompt = false;

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                path = sfd.FileName;

                // Write project name into file
                using (StreamWriter sw = File.AppendText(path))
                {
                    sw.WriteLine(Path.GetFileNameWithoutExtension(path));
                }

                // Load file to update the GUI
                loadProject(File.Open(path, FileMode.Open));
            }
        }

        private void toolOpenButton_Click(object sender, EventArgs e)
        {
            if (timer1.Enabled)
            {
                stopTimer();
            }

            OpenFileDialog ofd = new OpenFileDialog();

            ofd.Title = "Open a project";
            ofd.Filter = "CSV file (*.csv)|*.csv";
            ofd.RestoreDirectory = true;
            ofd.InitialDirectory = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "projects");

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                path = ofd.FileName;
                loadProject(ofd.OpenFile());
            }
        }

        private void startButton_enabledChanged(object sender, EventArgs e)
        {
            if (startButton.Enabled)
            {
                startButton.BackColor = System.Drawing.Color.LimeGreen;
                startButton.ForeColor = System.Drawing.Color.Black;
            }
            else
            {
                timer1.Start();
                timerIdle.Start();

                // Save the start time for later
                startDate = DateTime.Now.ToString("yyyy-MM-dd");
                startTime = DateTime.Now.ToString("HH:mm");

                startButton.BackColor = System.Drawing.Color.DarkSeaGreen;
                startButton.ForeColor = System.Drawing.Color.Gray;
            }
        }

        private void stopButton_enabledChanged(object sender, EventArgs e)
        {
            if (stopButton.Enabled)
            {
                stopButton.BackColor = System.Drawing.Color.Tomato;
                stopButton.ForeColor = System.Drawing.Color.Black;
            }
            else
            {
                stopButton.BackColor = System.Drawing.Color.Salmon;
                stopButton.ForeColor = System.Drawing.Color.Gray;

                // Save the time when the user stops or opens a new dialog
                timer1.Stop();

                if (timePassed != 0)
                {
                    string content = startDate + ";" + startTime + ";" + timePassed;
                    updateFile(content);
                }

                timePassed = 0;
            }
        }

        private void startButton_paint(object sender, PaintEventArgs e)
        {
            Button btn = (Button)sender;

            // Make sure Text is not also written on button
            btn.Text = string.Empty;

            // Set flags to center text on button
            TextFormatFlags flags = TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter | TextFormatFlags.WordBreak;

            // Render the text onto the button
            TextRenderer.DrawText(e.Graphics, "Start", btn.Font, e.ClipRectangle, btn.ForeColor, flags);
        }

        private void stopButton_paint(object sender, PaintEventArgs e)
        {
            Button btn = (Button)sender;
            btn.Text = string.Empty;
            TextFormatFlags flags = TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter | TextFormatFlags.WordBreak;
            TextRenderer.DrawText(e.Graphics, "Stop", btn.Font, e.ClipRectangle, btn.ForeColor, flags);
        }

        private void loadProject(Stream fileStream)
        {
            toolExportButton.Enabled = true;

            using (var streamReader = new StreamReader(fileStream))
            {
                string line;
                string today = DateTime.Now.ToString("yyyy-MM-dd").ToString();
                timeSession = 0;
                timeToday = 0;
                timeTotal = 0;

                // Display project name
                if ((line = streamReader.ReadLine()) != null)
                {
                    projectLabel.Text = line;
                }

                // Sum up total time
                while ((line = streamReader.ReadLine()) != null)
                {
                    // Prevent IndexOutOfRangeException
                    if (line.Length > 17)
                    {
                        int session;
                        try
                        {
                            session = Int32.Parse(line[17..]);
                        }
                        catch
                        {
                            MessageBox.Show("The file is corrupt.");
                            startButton.Enabled = false;
                            stopButton_enabledChanged(new object(), new EventArgs());
                            toolExportButton.Enabled = false;
                            return;
                        }

                        // Sum up total time
                        timeTotal += session;

                        // Sum up today time
                        if (line[..10] == today)
                        {
                            timeToday += session;
                        }
                    }
                }

                timeSessionLabel.Text = formatTime(timeSession);
                timeTodayLabel.Text = formatTime(timeToday);
                timeTotalLabel.Text = formatTime(timeTotal);

                startButton.Enabled = true;
            }
        }

        private void updateFile(string content)
        {
            // Write the latest record into the file
            try
            {
                using (StreamWriter sw = File.AppendText(path))
                {
                    sw.WriteLine(content);
                }
            }
            catch (UnauthorizedAccessException)
            {
                MessageBox.Show("Access to the path '" + path + "' denied (no record saved).");
            }
        }

        private void startTimer()
        {
            startButton.Enabled = false;
            stopButton.Enabled = true;
        }

        private void stopTimer()
        {
            stopButton.Enabled = false;
            startButton.Enabled = true;
        }

        public static string formatTime(int time)
        {
            // Time is saved in seconds

            int hr = time / 3600;
            int remainingSec = time % 3600;
            int min = remainingSec / 60;
            remainingSec = remainingSec % 60;
            int sec = remainingSec % 60;

            string hrStr;
            if (hr < 10)
            {
                hrStr = "0" + hr.ToString();
            }
            else
            {
                hrStr = hr.ToString();
            }

            string minStr;
            if (min < 10)
            {
                minStr = "0" + min.ToString();
            }
            else
            {
                minStr = min.ToString();
            }

            string secStr;
            if (sec < 10)
            {
                secStr = "0" + sec.ToString();
            }
            else
            {
                secStr = sec.ToString();
            }

            return hrStr + ":" + minStr + ":" + secStr;
        }

        // Unmanaged function from user32.dll    
        [DllImport("user32.dll")]
        static extern bool GetLastInputInfo(ref LASTINPUTINFO plii);
        // Struct we'll need to pass to the function    
        internal struct LASTINPUTINFO
        {
            public uint cbSize;
            public uint dwTime;
        }

        private void timerIdle_Tick(object sender, EventArgs e)
        {
            // Check idle time only while running
            if (!startButton.Enabled) {
                // Get the system uptime    
                int systemUptime = Environment.TickCount;
                // The tick at which the last input was recorded    
                int LastInputTicks = 0;
                // The number of ticks that passed since last input    
                int IdleTicks = 0;
                // Set the struct    
                LASTINPUTINFO LastInputInfo = new LASTINPUTINFO();
                LastInputInfo.cbSize = (uint)Marshal.SizeOf(LastInputInfo);
                LastInputInfo.dwTime = 0;

                // If we have a value from the function    
                if (GetLastInputInfo(ref LastInputInfo))
                {
                    // Get the number of ticks at the point when the last activity was seen    
                    LastInputTicks = (int)LastInputInfo.dwTime;
                    // Number of idle ticks = system uptime ticks - number of ticks at last input    
                    IdleTicks = systemUptime - LastInputTicks;

                    // Idle after 1 minute without input
                    if (idle && IdleTicks < 500)
                    {
                        timer1.Start();
                        idle = false;
                    }

                    // Pause timer without changing button states
                    else if (IdleTicks > 60000)
                    {
                        timer1.Stop();
                        idle = true;
                    }
                }
            }
        }

        private void toolExportButton_Click(object sender, EventArgs e)
        {
            if (path != null)
            {
                // Read the project file's content
                string[] lines = System.IO.File.ReadAllLines(path);

                // Create a MigraDoc document
                var document = Documents.CreateDocument(lines);

                // var ddl = MigraDoc.DocumentObjectModel.IO.DdlWriter.WriteToString(document);
                MigraDoc.DocumentObjectModel.IO.DdlWriter.WriteToFile(document, "MigraDoc.mdddl");

                var renderer = new PdfDocumentRenderer(true);
                renderer.Document = document;

                System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);

                renderer.RenderDocument();

                var filename = lines[0];

                // Save the document...
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Title = "Export project as PDF";
                sfd.Filter = "PDF file (*.pdf)|*.pdf";
                sfd.DefaultExt = "pdf";
                sfd.FileName = filename;
                sfd.FilterIndex = 2;
                sfd.RestoreDirectory = true;
                sfd.InitialDirectory = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "projects");
                sfd.OverwritePrompt = false;

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        filename = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "projects/" + sfd.FileName);
                        renderer.PdfDocument.Save(filename);
                    }
                    catch
                    {
                        // Save in the root directory if 'projects' doesn't exist
                        filename = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, sfd.FileName);
                        renderer.PdfDocument.Save(filename);
                    }
                    
                }

                // ...and start a viewer
                using (Process process = new Process())
                {
                    process.StartInfo.UseShellExecute = true;
                    process.StartInfo.FileName = filename;
                    process.Start();
                }
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Save latest record if the form gets closed while timer is running
            stopTimer();
        }

        private void openFileDialog1_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

    }
}