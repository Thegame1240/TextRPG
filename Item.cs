namespace FinalProject
{
    public class Item : IItem
    {
        // 2 Types Hp and Mp
        public string Name { get; private set; }
        public bool useable { get; private set; }
        public int HealingAmount { get; private set; }
        
        public int ManaAmount { get; private set; }
        public int WeaponDamage { get; private set; }
        public int ArmorDef { get; private set; }
        public int WeaponType { get; private set; }
        public bool Equipable { get; private set; }
        public int ArmorType { get; private set; }
        public Item(string name, bool useable, int healingAmount, int manaAmount,int weaponDamage, int armorDef, int weaponType, bool equipable, int armorType)
        {
            Name = name;
            this.useable = useable;
            HealingAmount = healingAmount;
            ManaAmount = manaAmount;
            WeaponDamage = weaponDamage;
            ArmorDef = armorDef;
            WeaponType = weaponType;
            Equipable = equipable;
            ArmorType = armorType;
        }

        public int getItemDamage()
        {
            return WeaponDamage;
        }

        public int getItemDef()
        {
            return ArmorDef;
        }
    }
}