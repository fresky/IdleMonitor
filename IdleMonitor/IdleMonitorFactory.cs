using System;

namespace IdleMonitor
{
    public static class IdleMonitorFactory
    {
        public static IdleMonitor GetIdleMonitor(string monitorName, TimeSpan timeout)
        {
            switch (monitorName)
            {
                case "ComponentDispatcherIdleMonitor":
                    return new ComponentDispatcherIdleMonitor(timeout);
                case "MessageFilterIdleMonitor":
                    return new MessageFilterIdleMonitor(timeout);
                default:
                    return new GetlastInputInfoIdleMonitor(timeout);
            }
        }
    }
}