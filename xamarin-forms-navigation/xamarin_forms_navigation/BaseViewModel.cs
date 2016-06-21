using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace xamarin_forms_navigation
{
	public class BaseViewModel : INotifyPropertyChanged
	{
		public bool IsBusy { get; set; }
		public string Title { get; internal set; }
		public string Subtitle { get; internal set; }
		public string Icon { get; internal set; }

		public event PropertyChangedEventHandler PropertyChanged;

		protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			if (PropertyChanged != null)
			{
				PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
			}
		}

		public async Task RunSafe(Task task, bool notifyOnError = true, [CallerMemberName] string caller = "")
		{
			/*if (!App.IsNetworkRechable)
            {
                MessagingCenter.Send<BaseViewModel, Exception>(this, Messages.ExceptionOccurred, new WebException("Please connect to the Information Super Highway"));
                return;
            }*/

			Exception exception = null;

			try
			{
				await Task.Run(() =>
				{
					/*if (!CancellationToken.IsCancellationRequested)
                    {
                        task.Start();
                        task.Wait();
                    }*/
				});
			}
			catch (TaskCanceledException)
			{
				Debug.WriteLine("Task Cancelled");
			}
			catch (AggregateException e)
			{
				var ex = e.InnerException;
				while (ex.InnerException != null)
					ex = ex.InnerException;

				exception = ex;
			}
			catch (Exception e)
			{
				exception = e;
			}

			if (exception != null)
			{
				//InsightsManager.Report(exception);
				Debug.WriteLine(exception);

				/*if (notifyOnError)
                {
                    NotifyException(exception);
                }*/
			}
		}
	}
}