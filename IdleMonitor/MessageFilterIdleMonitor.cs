using System;
using System.Windows.Forms;

namespace IdleMonitor
{
    public class MessageFilterIdleMonitor : IdleMonitor
    {
        private MessageFilter m_MessageFilter;

        public MessageFilterIdleMonitor(TimeSpan timeout) : base(timeout)
        {
            m_Timer.Interval = m_Timeout;
        }
        protected override void Timer_Tick(object sender, EventArgs e)
        {
            InvokeTimeoutEventHandler();
        }

        public void Reset()
        {
            m_Timer.Stop();
            m_Timer.Start();
        }

        public override void Start()
        {
            m_Timer.Start();
            m_MessageFilter = new MessageFilter(this);
            Application.AddMessageFilter(m_MessageFilter);
        }

        public override void Stop()
        {
            m_Timer.Stop();
            Application.RemoveMessageFilter(m_MessageFilter);
        }
    }

    class MessageFilter : IMessageFilter
    {
        private const int WM_KEYFIRST = 0x100;
        private const int WM_KEYLAST = 0x108;
        private const int WM_MOUSEFIRST = 0x200;
        private const int WM_XBUTTONDBLCLK = 0x20d;
        private const int WM_NCMOUSEMOVE = 0xa0;
        private const int WM_NCXBUTTONDBLCLK = 0xad;


        private readonly MessageFilterIdleMonitor m_IdleMonitor;

        public MessageFilter(MessageFilterIdleMonitor idleMonitor)
        {
            m_IdleMonitor = idleMonitor;
        }

        public bool PreFilterMessage(ref Message m)
        {

            //Check for mouse clicks or movements
            bool isMouseEvent = (m.Msg >= WM_MOUSEFIRST & m.Msg <= WM_XBUTTONDBLCLK) |
                                (m.Msg >= WM_NCMOUSEMOVE & m.Msg <= WM_NCXBUTTONDBLCLK);

            //Check for keyboard button presses
            bool isKeyboradEvent = (m.Msg >= WM_KEYFIRST & m.Msg <= WM_KEYLAST);

            if (isMouseEvent | isKeyboradEvent)
            {
                m_IdleMonitor.Reset();
            }
            return false;
        }
    }
}