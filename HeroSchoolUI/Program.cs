using HeroSchool.Interface;
using HeroSchool.Model;
using HeroSchool.Repository;
using Microsoft.Practices.Unity;
using System;
using System.Windows.Forms;

namespace HeroSchoolUI
{
    static class Program
    {

        
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            IUnityContainer unityContainer = new UnityContainer();

            unityContainer.RegisterType<Repository<Player>>(new ContainerControlledLifetimeManager());
            unityContainer.RegisterType<IRepository<ICard>, CardRepository>(new ContainerControlledLifetimeManager());
            unityContainer.RegisterType<frmPlayers>();
            unityContainer.RegisterType<frmCards>();
            unityContainer.RegisterType<frmPlayer>();
            unityContainer.RegisterType<frmHero>();
            unityContainer.RegisterType<frmBattle>();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            frmHeroSchool frmhs = unityContainer.Resolve<frmHeroSchool>();
            unityContainer.Resolve<frmBattle>();
            Application.Run(frmhs);
        }
    }
}
