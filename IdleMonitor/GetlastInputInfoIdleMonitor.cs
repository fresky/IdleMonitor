using System;
using System.Runtime.InteropServices;

namespace IdleMonitor
{
    public class GetlastInputInfoIdleMonitor : IdleMonitor
    {
        private DateTime m_StartTime;

        public GetlastInputInfoIdleMonitor(TimeSpan timeout) : base(timeout)
        {
            m_Timer.Interval = TimeSpan.FromSeconds(1);
        }

        public override void Start()
        {
            m_StartTime = DateTime.Now;
            m_Timer.Start();
        }

        public override void Stop()
        {
            m_Timer.Stop();
        }

        protected override void Timer_Tick(object sender, EventArgs e)
        {
            LASTINPUTINFO lastinputinfo;
            lastinputinfo.cbSize = Marshal.SizeOf(typeof(LASTINPUTINFO));
            if (GetLastInputInfo(out lastinputinfo))
            {
                TimeSpan idleTimeSpan = TimeSpan.FromMilliseconds(unchecked((uint)Environment.TickCount - lastinputinfo.dwTime));
                if (lastinputinfo.dwTime >= m_StartTime.Millisecond && idleTimeSpan >= m_Timeout)
                {
                    m_Timer.Stop();
                    InvokeTimeoutEventHandler();
                    m_Timer.Start();
                }
            }
        }

        private struct LASTINPUTINFO
        {
            public int cbSize;
            public uint dwTime;
        }

        [DllImport("User32.dll")]
        private extern static bool GetLastInputInfo(out LASTINPUTINFO plii);
    }
}