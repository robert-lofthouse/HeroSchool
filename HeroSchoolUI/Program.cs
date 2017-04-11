using HeroSchool;
using HeroSchool.Interface;
using HeroSchool.Repository;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
            unityContainer.RegisterType<frmHeroes>();
            unityContainer.RegisterType<frmCards>();
            unityContainer.RegisterType<frmHeroes>();
            unityContainer.RegisterType<frmPlayerCards>();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            frmHeroSchool frmhs = unityContainer.Resolve<frmHeroSchool>();
            Application.Run(frmhs);
        }
    }
}
