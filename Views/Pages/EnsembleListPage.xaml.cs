using System.Windows.Controls;
using MusicShop.ViewModels.Pages;
using Wpf.Ui.Controls;

namespace MusicShop.Views.Pages;

public partial class EnsembleListPage : INavigableView<EnsembleListViewModel>
{
    
    public EnsembleListViewModel ViewModel { get; }
    
    public EnsembleListPage(EnsembleListViewModel viewModel)
    {
        ViewModel = viewModel;
        DataContext = this;
        
        InitializeComponent();
    }
}