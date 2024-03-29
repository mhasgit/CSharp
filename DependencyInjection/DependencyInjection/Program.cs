using DependencyInjection;
using Ninject;
using System.ComponentModel;

//var warrior1 = new Samurai(new Sword());
//var warrior2 = new Samurai(new Shuriken());

//warrior1.Attack("The Evildoers");
//warrior2.Attack("The Evildoers");

//using Ninject
//IKernel kernel = new StandardKernel(new SwordModule());
//IKernel kernel = new StandardKernel(new ShurikenModule());

//var samurai = kernel.Get<Samurai>();

//samurai.Attack("The Evildoers");

bool useMeleeWeapons = true;
IKernel kernel = new StandardKernel(new WeaponsModule(useMeleeWeapons));
Samurai warrior = kernel.Get<Samurai>();
warrior.Attack("the evildoers");