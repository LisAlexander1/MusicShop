// This Source Code Form is subject to the terms of the MIT License.
// If a copy of the MIT was not distributed with this file, You can obtain one at https://opensource.org/licenses/MIT.
// Copyright (C) Leszek Pomianowski and WPF UI Contributors.
// All Rights Reserved.
using MusicShop.Models;
using MusicShop.Services;
using MusicShop.Views.Pages;
using Wpf.Ui.Controls;

namespace MusicShop.ViewModels.Pages
{
    public partial class MusicianListViewModel : ObservableObject, INavigationAware
    {
        private bool _isInitialized = false;

        private IDataService<Musician> MusicianDataService { get; }
        private INavigationService NavigationService { get; }
        private IContentDialogService ContentDialogService { get; }

        [ObservableProperty]
        private IEnumerable<Musician> _musicians;

        [ObservableProperty]
        private bool _isLoading;

        public MusicianListViewModel(
            IDataService<Musician> musicianDataService,
            IContentDialogService contentDialogService,
            INavigationService navigationService)
        {
            MusicianDataService = musicianDataService;
            ContentDialogService = contentDialogService;
            NavigationService = navigationService;
        }

        public void OnNavigatedTo()
        {
            if (!_isInitialized)
                InitializeViewModel();
        }

        public void OnNavigatedFrom() { }

        private void InitializeViewModel()
        {
            LoadMusiciansCommand.Execute(null);
            _isInitialized = true;
        }

        [RelayCommand]
        private void LoadMusicians()
        {
            IsLoading = true;
            MusicianDataService.GetAll().ContinueWith(task =>
            {
                if (task.Exception == null)
                {
                    Musicians = task.Result;
                }
                IsLoading = false;
            });
        }

        [RelayCommand]
        private void AddMusician()
        {
            NavigationService.Navigate(typeof(MusicianAddFormPage));
        }
    }
}
