using System;
using System.Threading;

namespace NUPP_NET_LabApp.Sync
{
	public static class SyncHelpers
	{
		private static readonly SemaphoreSlim _semaphore = new SemaphoreSlim(1, 1);
		private static readonly object _lock = new object();
		private static readonly AutoResetEvent _autoResetEvent = new AutoResetEvent(false);

		public static void UseLock()
		{
			lock (_lock)
			{
				Console.WriteLine("Lock acquired");

			}
		}

		public static void UseSemaphore()
		{
			_semaphore.Wait();
			try
			{
				Console.WriteLine("Semaphore acquired");
			}
			finally
			{
				_semaphore.Release();
			}
		}

		public static void UseAutoResetEvent()
		{
			Console.WriteLine("Waiting for event...");
			_autoResetEvent.WaitOne(); 
			Console.WriteLine("Event signaled");
		}

		public static void SignalAutoResetEvent()
		{
			_autoResetEvent.Set();  
		}
	}
}
