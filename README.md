#IdleMonitor


This is an example code to check if the application has been inactive for a given time.

###IdleMonitor abstract class

The interface is defined in the abstract class IdleMonitor like below.

```C#
	public abstract class IdleMonitor
	{
		...
		public event EventHandler TimeoutEventHandler;
		protected IdleMonitor(TimeSpan timeout){...}
		public abstract void Start();
		public abstract void Stop();
		...
	}
```
In the WinForm or WPF application, it can just create one IdelMonitor from ```IdleMonitorFactory```, 
then call the ```Start()``` to start the Idle Monitor, and call the ```Stop()``` to stop the IdleMonitor. 
The application can add event handler to TimeoutEventHandler, when the timeout reached, the event handler will be called. 

### Idle Monitor implementation
##### GetlastInputInfoIdleMonitor
Using the [GetlastInputInfo](http://msdn.microsoft.com/en-us/library/windows/desktop/ms646272%28v=vs.85%29.aspx) API. It works for WinForm and WPF.
#####MessageFilterIdleMonitor
Using the MessageFilter, here is [List_Of_Windows_Messages](http://wiki.winehq.org/List_Of_Windows_Messages). It works for WinForm and WPF.
#####ComponentDispatcherIdleMonitor
Using the [Operationposted](http://msdn.microsoft.com/en-us/library/system.windows.threading.dispatcherhooks.operationposted.aspx)
 and [ThreadIdle](http://msdn.microsoft.com/en-us/library/system.windows.interop.componentdispatcher.threadidle%28v=vs.110%29.aspx).
It works only for WPF.
### WinForm and WPF Example
The WinForm and WPF examples are also included.


