namespace FinalProject
{
    public class Weapon : Item
    {
        // Weapon 3 Type and 5 unique each type
        public int WeaponDamage { get; private set; }
        public int WeaponType { get; private set; }
        public bool Equipable { get; private set; }
        public Weapon(string name, bool useable, int healingamount, int manaamount, bool equipable, int weaponDamage, int weaponType) : base(name, useable, healingamount, manaamount)
        {
            WeaponDamage = weaponDamage;
            WeaponType = weaponType;
            Equipable = equipable;
        }
    }
}