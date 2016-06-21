using System;

namespace xamarin_forms_navigation
{
	public partial class DynamicPage
	{
		public DynamicPage()
		{
			InitializeComponent();

			NavigationButton.Clicked += async delegate {
				await Navigation.PushAsync(new DynamicPage { Title = "Child page #" + Navigation.NavigationStack.Count });
			}; 

			DynamicContent.Text = "New page created at - " + DateTime.Now;
		}
	}
}
