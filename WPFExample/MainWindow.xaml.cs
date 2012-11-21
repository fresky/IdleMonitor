using System;
using System.Windows;
using IdleMonitor;

namespace WPFExample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const string m_GetlastInputInfoIdleMonitor = "GetlastInputInfoIdleMonitor";
        private const string m_ComponentDispatcherIdleMonitor = "ComponentDispatcherIdleMonitor";
        private const string m_MessageFilterIdleMonitor = "MessageFilterIdleMonitor";
        private IdleMonitor.IdleMonitor m_IdleMonitor;

        public MainWindow()
        {
            InitializeComponent();
            monitors.Items.Add(m_GetlastInputInfoIdleMonitor);
            monitors.Items.Add(m_ComponentDispatcherIdleMonitor);
            monitors.Items.Add(m_MessageFilterIdleMonitor);
            monitors.SelectedIndex = 0;
        }

        void idleMonitor_TimeoutEventHandler(object sender, EventArgs e)
        {
            if (MessageBoxResult.Yes==MessageBox.Show(string.Format("Application has been inactive for {0} seconds! Do you want to close it?", timeout.Text), "Warning!", MessageBoxButton.YesNo))
            {
                Application.Current.Shutdown();
            }
        }

        private void toggleMonitor_Checked(object sender, RoutedEventArgs e)
        {
            if (m_IdleMonitor != null)
            {
                m_IdleMonitor.Stop();
                m_IdleMonitor = null;
            }
            if (toggleMonitor.IsChecked == true)
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
                    toggleMonitor.IsChecked = false;
                }
            }
        }
    }
}
