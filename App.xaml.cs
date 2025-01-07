using System;
using MauiAppBazaSportiva;
using System.IO;
using MauiAppBazaSportiva.Data;
namespace MauiAppBazaSportiva
{
    public partial class App : Application
    {
        static MemberDatabase database;
        public static MemberDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new
                   MemberDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.
                   LocalApplicationData), "Member.db3"));
                }
                return database;
            }
        }
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
        }
    }
}
