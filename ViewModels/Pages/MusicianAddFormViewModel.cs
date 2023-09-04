using System.Collections;
using System.Collections.ObjectModel;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.IO;
using System.Windows.Threading;
using Microsoft.Win32;
using MusicShop.Core;
using MusicShop.Models;
using MusicShop.Services;
using Wpf.Ui.Common;
using Wpf.Ui.Controls;

namespace MusicShop.ViewModels.Pages;

public partial class MusicianAddFormViewModel : ViewModel, INavigationAware
{
    private IContentDialogService DialogService { get; }
    private INavigationService NavigationService { get; }
    private ISnackbarService SnackbarService { get; }
    
    private IDataService<Ensemble> EnsembleService { get; }

    public MusicianAddFormViewModel(
        INavigationService navigationService,
        IContentDialogService dialogService,
        ISnackbarService snackbarService, IDataService<Ensemble> ensembleService)
    {
        NavigationService = navigationService;
        DialogService = dialogService;
        SnackbarService = snackbarService;
        EnsembleService = ensembleService;
    }
    
    [ObservableProperty]
    private byte[] _avatar;
    [ObservableProperty]
    private string _firstName;
    [ObservableProperty]
    private string _lastName;    
    [ObservableProperty]
    private string _surname;
    [ObservableProperty]
    private ObservableCollection<Ensemble> _selectedEnsembles = new();
    [ObservableProperty]
    private bool _isSoloist;
    [ObservableProperty]
    private ObservableCollection<Ensemble> _ensembles;

    public void OnNavigatedTo()
    {
        Load();
    }

    public void OnNavigatedFrom()
    {
        
    }

    private void Load()
    {
        EnsembleService.GetAll().ContinueWith(task =>
        {
            if (task.Exception == null)
            {
                Ensembles = new ObservableCollection<Ensemble>(task.Result);
            }
        });
    }
    
    [RelayCommand]
    private void AddImage()
    {
        

        OpenFileDialog fileDialog = new();
        fileDialog.Filter = "Изображения (*.jpg;*.jpeg;*.png)|*.jpg;*.jpeg;*.png";
        if (fileDialog.ShowDialog() == true)
        {
            string path = fileDialog.FileName;
            byte[] imageBytes = File.ReadAllBytes(path);
            if (imageBytes.Length < 2000000)
            {
                Avatar = imageBytes;
                return;
            }
            
            SnackbarService.Show(
                "Изображение слишком большое","Размер изображение не должен привышать 2 МБ. Уменьшите размер и попробуйте заново",
                ControlAppearance.Caution,
                new SymbolIcon(SymbolRegular.ImageOff24),
                new TimeSpan(0,0,0,5)
            );
        }
    }
    
    [RelayCommand]
    private void Cancel()
    {
        DialogService.ShowSimpleDialogAsync(new SimpleContentDialogCreateOptions
            {
                CloseButtonText = "Остаться",
                PrimaryButtonText = "Подтвердить",
                Content = "Все несохраненные данные будут потеряны. Вы уверены?",
                Title = "Несохраненные данные"
            }).ContinueWith(task =>
        {
            if (task.Exception == null)
            {
                if (task.Result == ContentDialogResult.Primary)
                {
                    Application.Current.Dispatcher.Invoke(() => { NavigationService.GoBack(); });
                }
            }
        });
    }

    [RelayCommand]
    private void Clear()
    {
        Avatar = Array.Empty<byte>();
        FirstName = string.Empty;
        LastName = string.Empty;
        Surname = string.Empty;
        Console.WriteLine(SelectedEnsembles);
        SelectedEnsembles.Clear();
        IsSoloist = false;
    }
}