using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjection
{
    public class Samurai
    {
        // Tightly coupled without in interface
        /*
        readonly Sword sword;

        public Samurai()
        {
            this.sword = new Sword();
        }

        public void Attack(string target)
        {
            this.sword.Hit(target);
        }
        */

        // Samurai now uses interface to avoid tight coupling

        readonly IWeapon weapon;

        public Samurai(IWeapon weapon)
        {
            this.weapon = weapon;
        }

        public void Attack(string target)
        {
            this.weapon.Hit(target);
        }
    }
}
