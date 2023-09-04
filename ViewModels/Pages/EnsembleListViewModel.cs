// This Source Code Form is subject to the terms of the MIT License.
// If a copy of the MIT was not distributed with this file, You can obtain one at https://opensource.org/licenses/MIT.
// Copyright (C) Leszek Pomianowski and WPF UI Contributors.
// All Rights Reserved.
using MusicShop.Models;
using MusicShop.Services;
using Wpf.Ui.Controls;

namespace MusicShop.ViewModels.Pages
{
    public partial class EnsembleListViewModel : ObservableObject, INavigationAware
    {
        private bool _isInitialized = false;

        private IDataService<Ensemble> EnsembleDataService { get; }

        [ObservableProperty]
        private IEnumerable<Ensemble> _ensembles;

        [ObservableProperty]
        private bool _isLoading;

        public EnsembleListViewModel(IDataService<Ensemble> ensembleDataService)
        {
            EnsembleDataService = ensembleDataService;
        }

        public void OnNavigatedTo()
        {
            if (!_isInitialized)
                InitializeViewModel();
        }

        public void OnNavigatedFrom() { }

        private void InitializeViewModel()
        {
            LoadEnsemblesCommand.Execute(null);
            _isInitialized = true;
        }

        [RelayCommand]
        private void LoadEnsembles()
        {
            IsLoading = true;
            EnsembleDataService.GetAll().ContinueWith(task =>
            {
                if (task.Exception == null)
                {
                    Ensembles = task.Result;
                    IsLoading = false;
                }
            });
        }
    }
}
