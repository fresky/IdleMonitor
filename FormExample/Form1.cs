using System;
using System.Windows.Forms;
using IdleMonitor;

namespace FormExample
{
    public partial class Form1 : Form
    {
        private const string m_GetlastInputInfoIdleMonitor = "GetlastInputInfoIdleMonitor";
        private const string m_ComponentDispatcherIdleMonitor = "ComponentDispatcherIdleMonitor";
        private const string m_MessageFilterIdleMonitor = "MessageFilterIdleMonitor";
        private IdleMonitor.IdleMonitor m_IdleMonitor;
        public Form1()
        {
            InitializeComponent();
            monitors.Items.Add(m_GetlastInputInfoIdleMonitor);
            monitors.Items.Add(m_ComponentDispatcherIdleMonitor);
            monitors.Items.Add(m_MessageFilterIdleMonitor);
            monitors.SelectedIndex = 0;            
        }

        void idleMonitor_TimeoutEventHandler(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show(string.Format("Application has been inactive for {0} seconds! Do you want to close it?", timeout.Text), "Warning!", MessageBoxButtons.YesNo))
            {
                Application.Exit();
            }
        }

        private void toggleIdleMonitor_CheckedChanged(object sender, EventArgs e)
        {
            if (m_IdleMonitor != null)
            {
                m_IdleMonitor.Stop();
                m_IdleMonitor = null;
            }
            if (toggleMonitor.Checked)
            {
                int seconds;
                if (int.TryParse(timeout.Text, out seconds))
                {
                    m_IdleMonitor = IdleMonitorFactory.GetIdleMonitor(monitors.SelectedItem.ToString(),
                                                                      TimeSpan.FromSeconds(seconds));
                    m_IdleMonitor.TimeoutEventHandler += idleMonitor_TimeoutEventHandler;
                    m_IdleMonitor.Start();
                }
                else
                {
                    MessageBox.Show("Please set the idle time out!");
                    toggleMonitor.Checked = false;
                }
            }
        }
    }
}
