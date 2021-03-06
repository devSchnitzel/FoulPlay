﻿using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using PlaystationApp.Core.Entity;
using PlaystationApp.Core.Manager;
using PlaystationApp.Resources;

namespace PlaystationApp.Views
{
    public partial class TrophyPage : PhoneApplicationPage
    {
        public TrophyPage()
        {
            InitializeComponent();
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            TrophyTitleGrid.DataContext = App.SelectedTrophyTitle;
            var trophyDetailManager = new TrophyDetailManager();
            TrophyDetailEntity trophys =
                await
                    trophyDetailManager.GetTrophyDetailList(App.SelectedTrophyTitle.NpCommunicationId,
                        App.SelectedUser.OnlineId, true,
                        App.UserAccountEntity);
            if (trophys == null)
            {
                MessageBox.Show(AppResources.GenericError);
                var rootFrame = Application.Current.RootVisual as PhoneApplicationFrame;
                if (rootFrame != null)
                    rootFrame.GoBack();
                return;
            }
            TrophyList.DataContext = trophys;
        }

        private void TrophyList_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var item = (TrophyDetailEntity.Trophy) TrophyList.SelectedItem;
            if (item == null) return;
            App.SelectedTrophyDetail = item;
            NavigationService.Navigate(new Uri("/Views/TrophyDetailPage.xaml", UriKind.Relative));
        }
    }
}