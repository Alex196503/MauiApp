using System;
using MauiAppBazaSportiva;
using System.IO;
namespace MauiAppBazaSportiva
{
    public partial class App : Application
    {
      
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
        }
    }
}
