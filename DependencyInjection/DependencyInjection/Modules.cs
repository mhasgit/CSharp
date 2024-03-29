using Ninject;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjection
{
    public class SwordModule : NinjectModule
    {
        public override void Load()
        {

            Bind<IWeapon>().To<Sword>();
            Bind<Samurai>().ToSelf().InSingletonScope();
            
            // non generic method to bind
            //Bind(typeof(IWeapon)).To(typeof(Sword));
        }
    }

    public class ShurikenModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IWeapon>().To<Shuriken>();
            Bind<Samurai>().ToSelf().InSingletonScope();
        }
    }

    class WeaponsModule : NinjectModule
    {
        private readonly bool useMeleeWeapons;
        public WeaponsModule(bool useMeleeWeapons)
        {
            this.useMeleeWeapons = useMeleeWeapons;
        }

        public override void Load()
        {
            if (this.useMeleeWeapons)
                Bind<IWeapon>().To<Sword>();
            else
                Bind<IWeapon>().To<Shuriken>();
        }
    }

    public class KnifeModule : INinjectModule
    {
        public string Name => throw new NotImplementedException();

        public IKernel Kernel => throw new NotImplementedException();

        public void OnLoad(IKernel kernel)
        {
            throw new NotImplementedException();
        }

        public void OnUnload(IKernel kernel)
        {
            throw new NotImplementedException();
        }

        public void OnVerifyRequiredModules()
        {
            throw new NotImplementedException();
        }
    }
}
