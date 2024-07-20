using ApiTest.Desktop.ViewModels;
using System.Windows.Controls;

namespace ApiTest.Desktop.Views.Pages
{
    /// <summary>
    /// Interação lógica para AddTestPage.xam
    /// </summary>
    public partial class AddTestPage : Page
    {
        private readonly AddTestPageViewModel _viewModel;

        public AddTestPage(AddTestPageViewModel viewModel)
        {
            InitializeComponent();
            _viewModel = viewModel;
            DataContext = _viewModel;
        }
    }
}
