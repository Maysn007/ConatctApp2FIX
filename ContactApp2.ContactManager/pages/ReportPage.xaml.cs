using ContactApp2.Core.ViewModels;

namespace ContactApp2.ContactManager.pages;

public partial class ReportPage : ContentPage
{
	public ReportPage(ReportViewModel viewmodel)
	{
		InitializeComponent();
		this.BindingContext = viewmodel;
	}
}