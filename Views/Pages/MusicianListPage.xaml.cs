using System.Windows.Controls;
using MusicShop.ViewModels.Pages;
using Wpf.Ui.Controls;

namespace MusicShop.Views.Pages;

public partial class MusicianListPage : INavigableView<MusicianListViewModel>
{
    
    public MusicianListViewModel ViewModel { get; }
    
    public MusicianListPage(MusicianListViewModel viewModel)
    {
        ViewModel = viewModel;
        DataContext = this;
        
        InitializeComponent();
    }
}