namespace DependencyInjection
{
    public class Shuriken : IWeapon
    {
        public void Hit(string target)
        {
            Console.WriteLine($"Pierced {target}'s armor");
        }
    }
}
