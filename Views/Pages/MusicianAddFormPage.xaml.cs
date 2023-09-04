using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using MusicShop.ViewModels.Pages;
using Wpf.Ui.Controls;

namespace MusicShop.Views.Pages;

public partial class MusicianAddFormPage : INavigableView<MusicianAddFormViewModel>
{
    
    public MusicianAddFormViewModel ViewModel { get; }
    
    
    public MusicianAddFormPage(MusicianAddFormViewModel viewModel)
    {
        ViewModel = viewModel;
        DataContext = this;
        InitializeComponent();
    }
}