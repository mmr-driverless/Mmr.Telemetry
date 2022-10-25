namespace Mmr.Telemetry.Ui.Pages;

public partial class ChartTests : ContentPage
{
	private readonly ChartTestsViewModel vm;

	public ChartTests()
	{
		BindingContext = vm = new ChartTestsViewModel();

		InitializeComponent();
	}
}