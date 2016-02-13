﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using VKShop_Lite.Common;
using VKShop_Lite.Views.Groups;

// Шаблон элемента пустой страницы задокументирован по адресу http://go.microsoft.com/fwlink/?LinkId=234238

namespace VKShop_Lite.Views.Main
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    public sealed partial class UserMainPage : Page
    {
        public static UserMainPage Current;
        public UserMainPage()
        {
            this.InitializeComponent();
            Current = this;
            SystemNavigationManager.GetForCurrentView().BackRequested += OnBackRequested;

        }
        private void OnBackRequested(object sender, BackRequestedEventArgs e)
        {
           
            if (RootFrame.CanGoBack)
            {
               
                    RootFrame.GoBack();
               

            }
         
            
          
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            SuspensionManager.RegisterFrame(RootFrame, "RootFrame");
            if (RootFrame.Content == null)
            {
                // When the navigation stack isn't restored navigate to the ScenarioList
                if (!RootFrame.Navigate(typeof(UserGroupsPage)))
                {
                    throw new Exception("Ошибка");
                }
            }
        }

      
    }
}
