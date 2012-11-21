using System;
using System.Windows.Forms;
using System.Windows.Threading;

namespace IdleMonitor
{
    abstract public class IdleMonitor
    {
        protected readonly DispatcherTimer m_Timer;
        protected TimeSpan m_Timeout;
        public event EventHandler TimeoutEventHandler;

        protected IdleMonitor(TimeSpan timeout)
        {
            m_Timeout = timeout;
            m_Timer = new DispatcherTimer();
            m_Timer.Tick += Timer_Tick;
        }

        protected abstract void Timer_Tick(object sender, EventArgs e);

        public abstract void Start();

        public abstract void Stop();

        protected void InvokeTimeoutEventHandler()
        {
            Stop();
            if (TimeoutEventHandler != null)
            {
                TimeoutEventHandler.Invoke(this, EventArgs.Empty);
            }
            else
            {
                showIdleMessage();
            }
            Start();
        }

        private void showIdleMessage()
        {
            MessageBox.Show(string.Format("Application has been inactive for {0}!", m_Timeout.ToString()));
        }
    }
}
