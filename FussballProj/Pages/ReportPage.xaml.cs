using FussballProj.Core.ViewModels;

namespace FussballProj.Pages;

public partial class ReportPage : ContentPage
{
	public ReportPage(ReportViewModel viewModel)
	{
		InitializeComponent();
		this.BindingContext = viewModel;
	}
}