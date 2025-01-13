using System;
using MauiAppBazaSportiva;
using System.IO;
using MauiAppBazaSportiva.Data;
using WebApiProjec.Data;
namespace MauiAppBazaSportiva
{
    public partial class App : Application
    {
        public static MemberDatabase Database { get; private set; }
        public App()
        {
            InitializeComponent();
            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "members.db3");
            Database = new MemberDatabase(new RestService(), dbPath);

            DependencyService.Register<IRestService,RestService>();

            MainPage = new NavigationPage(new IntrariMembri());
        }
    }
}
