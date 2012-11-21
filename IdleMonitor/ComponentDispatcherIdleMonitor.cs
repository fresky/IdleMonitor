using System;
using System.Windows.Interop;
using System.Windows.Threading;

namespace IdleMonitor
{
    public class ComponentDispatcherIdleMonitor : IdleMonitor
    {
        public ComponentDispatcherIdleMonitor(TimeSpan timeout) : base(timeout)
        {
            m_Timer.Interval = m_Timeout;
        }

        private void componentDispatcherThreadIdle(object sender, EventArgs e)
        {
            m_Timer.Start();
        }

        private void hooksOnOperationPosted(object sender, DispatcherHookEventArgs dispatcherHookEventArgs)
        {
            if (m_Timer != null)
            {
                m_Timer.Stop();
            }
        }

        protected override void Timer_Tick(object sender, EventArgs e)
        {
            if (m_Timer != null)
            {
                InvokeTimeoutEventHandler();
            }
        }

        public override void Start()
        {
            ComponentDispatcher.ThreadIdle += componentDispatcherThreadIdle;
            Dispatcher.CurrentDispatcher.Hooks.OperationPosted += hooksOnOperationPosted;
        }
        public override void Stop()
        {
            m_Timer.Stop();
            ComponentDispatcher.ThreadIdle -= componentDispatcherThreadIdle;
            Dispatcher.CurrentDispatcher.Hooks.OperationPosted -= hooksOnOperationPosted;
        }
    }
}