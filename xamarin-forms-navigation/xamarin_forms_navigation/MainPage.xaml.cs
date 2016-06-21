namespace xamarin_forms_navigation
{
    public partial class MainPage
    {
		public string[] MenuItems { get; private set; }

		public MainPage()
		{
			MenuItems = new string[]
			{
				"Item #1",
				"Item #2",
				"Item #3"
			};

			InitializeComponent();

			BindingContext = this;

			ListViewMenu.SelectedItem = MenuItems[0];

			ListViewMenu.ItemSelected += async (sender, e) =>
				{
					IsPresented = false;

					var dynamicPage = new DynamicPage { Title = "New Page "};
					await Navigation.PushAsync(dynamicPage);
				};
		}
    }
}
