using System;
using MauiAppBazaSportiva.Data;
using System.IO;
namespace MauiAppBazaSportiva
{
    public partial class App : Application
    {
        static MemberDatabase database;
        public static MemberDatabase Database
        {
            get
            {
                if(database==null)
                {
                    database = new
MemberDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.
LocalApplicationData), "MemberDatabase.db3"));

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
