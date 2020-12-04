using System;
using System.Collections.Generic;
using System.Linq;

namespace FinalProject
{
    public class Character
    {
        private const int MaxSkill = 3;
        private const int MaxInventory = 5;
        public string Name { get; private set; }
        public int Hp { get; private set; }
        public int Mana { get; private set; }
        public int Atk { get; private set; }
        public int Def { get; private set; }
        public bool IsDead { get; private set; }
        public int WeaponType { get; private set; }
        public int ItemCount { get; private set; }
        public int MaxHp { get; private set; }
        public int MaxMana { get; private set; }
        public int BaseAtk { get; private set; }
        public int BaseDef { get; private set; }
        public int PlayerCurrentSpot;

        private Skill[] Skills;

        public Item Weapon { get; private set; }
        public Item Head { get; private set; }
        public Item Armor { get; private set; }
        public Item Accessory { get; private set; }
        public List<Item> Inventory { get; private set; }

        public Character(string name, int hp, int mana, int atk, int def, int weapontype)
        {
            Name = name;
            Hp = hp;
            MaxHp = 200;
            Mana = mana;
            MaxMana = 100;
            Atk = atk;
            Def = def;
            IsDead = false;
            Skills = new Skill[MaxSkill];
            WeaponType = weapontype;
            Weapon = new Item("", false, 0,0,0,0,0,false, 0);
            Head = new Item("", false, 0,0,0,0,0,false, 0);
            Armor = new Item("", false, 0,0,0,0,0,false,0);
            Accessory = new Item("", false, 0,0,0,0,0,false,0);
            Inventory = new List<Item>(MaxInventory);
            ItemCount = 1;
            BaseAtk = Atk + Weapon.WeaponDamage + Accessory.WeaponDamage;
            BaseDef = Def + Head.ArmorDef + Armor.ArmorDef + Accessory.ArmorDef;
            PlayerCurrentSpot = 0;
        }

        public void AddItem(Item items)
        {
            if (ItemCount >= 0 && ItemCount <= MaxInventory)
            {
                Inventory.Add(items);
                ItemCount++;
                Console.WriteLine($"You get {items.Name} 1 ea.");
            }
            else
            {
                Console.WriteLine("Your bag is full!!");
            }
        }

        public void OpenInventory()
        {
            Console.WriteLine($"Your Inventory {ItemCount}/{MaxInventory} (To Select Type: 0 - 4):");
            foreach (var item in Inventory)
            {
                Console.WriteLine($"==> {item.Name}");
            }
        }

        public void UseItem(Item potion)
        {
            if (!potion.useable)
            {
                Console.WriteLine("This item cannot use!");
            }

            if (potion.HealingAmount >= 1 && Hp < MaxHp)
            {
                Hp = Hp + potion.HealingAmount;
                Console.WriteLine($"You used a Health Potion (Health Increases: {potion.HealingAmount})");
                if (Hp > MaxHp)
                {
                    Hp = MaxHp;
                }
                Inventory.Remove(potion);
                ItemCount--;
            }
            else if (Hp == MaxHp)
            {
                Console.WriteLine("Your HP is already full!!");
            }

            if (potion.ManaAmount >= 1 && Mana < MaxMana)
            {
                Mana = Mana + potion.ManaAmount;
                Console.WriteLine($"You used a Mana Potion (Mana Increases: {potion.ManaAmount})");
                if (Mana > MaxMana)
                {
                    Mana = MaxMana;
                }
                Inventory.Remove(potion);
                ItemCount--;
            }
            else if (Mana == MaxMana)
            {
                Console.WriteLine("Your Mana is already full!!");
            }

        }

        public void EquipWeapon(Item weapons1)
        {
            if (WeaponType != weapons1.WeaponType && !weapons1.Equipable)
            {
                Console.WriteLine("You cannot equip this item!!");
            }
            ItemCount--;
            Inventory.Remove(weapons1);
            Weapon = weapons1;
        }
        public void EquipHead(Item head1)
        {
            if (head1.ArmorType != 1)
            {
                Console.WriteLine("You cannot equip this item!!");
            }
            
            Inventory.Remove(head1);
            ItemCount--;
            Head = head1;
        }
        public void EquipArmor(Item armor1)
        {
            if (armor1.ArmorType != 2)
            {
                Console.WriteLine("You cannot equip this item!!");
            }
            ItemCount--;
            Inventory.Remove(armor1);
            Armor = armor1;
        }
        public void EquipAccessory(Item acc1)
        {
            if (acc1.ArmorType != 3)
            {
                Console.WriteLine("You cannot equip this item!!");
            }
            ItemCount--;
            Inventory.Remove(acc1);
            Accessory = acc1;
        }
        public void SetSkill(Skill[] skills)
        {
            if (skills.Length != MaxSkill)
            {
                Console.WriteLine("Invalid size of the array");
                return;
            }
            
            Skills = skills;
        }
        
        public int SetRandomAtk()
        {
            var damage = Atk + Weapon.WeaponDamage + Accessory.WeaponDamage;
            var minAtk = damage - 10;
            var maxAtk = damage + 10;
            Random rnd = new Random();
            var rndAtk = rnd.Next(minAtk, maxAtk);
            return damage = rndAtk;
        }

        public int SetRandomDef()
        {
            var defend = Def + Head.ArmorDef + Armor.ArmorDef + Accessory.ArmorDef;
            var minDef = defend - 10;
            var maxDef = defend + 10;
            Random rnd = new Random();
            var rndDef = rnd.Next(minDef,maxDef);
            return defend = rndDef;
        }
        public void PhysicalAttack(Enemy opponent)
        {
            var damage = (SetRandomAtk() - opponent.SetRandomDef());
            Console.WriteLine($"{Name} Dealing damage to {opponent.Name} {damage} unit!");
            //Console.WriteLine($"player Damage : {damage}");
            if (damage > 0)
            {
                opponent.TakeDamage(damage);
            }else if (damage < 0)
            {
                damage = 0;
                Console.WriteLine("Enemy block your attack!");
            }
        }

        public void SkillAttack(Enemy opponent)
        {
            Console.WriteLine($"Select your skill \n 0.{Skills[0].Name} (Mana: {Skills[0].ManaConsume}) \n 1.{Skills[1].Name} (Mana: {Skills[1].ManaConsume}) \n 2.{Skills[2].Name} (Mana: {Skills[2].ManaConsume})");
            var skillNumber = Convert.ToInt32(Console.ReadLine());
            var selectedSkill = Skills[skillNumber];
            var calculateDamage = (Accessory.WeaponDamage + Weapon.WeaponDamage) / 3;
            var damage = calculateDamage;
            var attackSucess = false;
            if (skillNumber == 0)
            {
                if (Mana >= selectedSkill.ManaConsume)
                {
                    Mana -= selectedSkill.ManaConsume;

                    if (Mana < 0)
                    {
                        Mana = 0;
                    }

                    damage += selectedSkill.Damage;
                    attackSucess = true;
                    Console.WriteLine($"{Name} used skill {selectedSkill.Name} causing {selectedSkill.Damage}");
                }
                else
                {
                    Console.WriteLine("You don't have enough Mana!");
                }
            }else if (skillNumber == 1)
            {
                if (Mana >= selectedSkill.ManaConsume)
                {
                    Mana -= selectedSkill.ManaConsume;

                    if (Mana < 0)
                    {
                        Mana = 0;
                    }

                    damage += selectedSkill.Damage;
                    attackSucess = true;
                    Console.WriteLine($"{Name} used skill {selectedSkill.Name} causing {selectedSkill.Damage}");
                }
                else
                {
                    Console.WriteLine("You don't have enough Mana!");
                }
            }else if (skillNumber == 2)
            {
                if (Mana >= selectedSkill.ManaConsume)
                {
                    Mana -= selectedSkill.ManaConsume;

                    if (Mana < 0)
                    {
                        Mana = 0;
                    }

                    damage += selectedSkill.Damage;
                    attackSucess = true;
                    Console.WriteLine($"{Name} used skill {selectedSkill.Name} causing {selectedSkill.Damage}");
                }
                else
                {
                    Console.WriteLine("You don't have enough Mana!");
                }
            }
            else if (skillNumber >= 3)
            {
                Console.WriteLine("Please enter number of skill! (Type: 0, 1, 2)");
            }

            if (attackSucess)
            {
                opponent.TakeDamage(damage);
            }
            
        }

        public void TakeDamage(int damage)
        {
            Hp -= damage;
            Console.WriteLine($"{Name} taken damage {damage} unit, Hp after take damage: {Hp}");
            if (Hp <= 0)
            {
                IsDead = true;
                Dead();
            }
        }

        public void Dead()
        {
            Console.WriteLine($"You are Dead! Game is ending!");
            Console.WriteLine("Press any key to quit...");
            Console.ReadKey();
        }

        public string ChangeName()
        {
            Name = Console.ReadLine();
            return Name;
        }

        public void RandomItemFound()
        {
            // Weapon Type 1 : Sword
            var weapon04 = new Item("Long Sword", false, 0, 0, 25,0, 1,true,0);
            var weapon05 = new Item("Katana", false, 0, 0, 45,0, 1,true,0);
            var weapon06 = new Item("Solar Sword", false, 0, 0, 50,0, 1,true,0);
            var weapon07 = new Item("Excalibur", false, 0, 0, 70,0, 1,true,0);
            
            // Weapon Type 2 : Bow
            var weapon08 = new Item("Composite Bow",false, 0, 0, 30,0, 2,true,0);
            var weapon09 = new Item("Cross Bow",false, 0, 0, 50,0, 2,true,0);
            var weapon10 = new Item("Big Cross Bow",false, 0, 0, 65,0, 2,true,0);
            var weapon11 = new Item("Mystic Bow",false, 0, 0, 75,0, 2,true,0);
            
            // Weapon Type 3 : Rod
            var weapon12 = new Item("Wand",false, 0, 0, 30,0, 3,true,0);
            var weapon13 = new Item("Arc Wand",false, 0, 0, 50,0, 3,true,0);
            var weapon14 = new Item("Survivor's Rod",false, 0, 0, 60,0, 3,true,0);
            var weapon15 = new Item("Royal Cleric Staff",false, 0, 0, 80,0, 3,true,0);
            
            // Item
            var hpPotion = new Item("Health Potion", true, 40, 0,0,0,0,false,0);
            var manaPotion = new Item("Mana Potion", true, 0, 25,0,0,0,false,0);
            
            // Head 
            var head01 = new Item("Old Helm", false, 0, 0, 0, 10, 0, true,1);
            var head02 = new Item("Helm", false, 0, 0, 0, 20, 0, true,1);
            var head03 = new Item("Royal Helm", false, 0, 0, 0, 30, 0, true,1);
            
            // Armor 
            var armor01 = new Item("Old Mail", false, 0, 0, 0, 20, 0, true,2);
            var armor02 = new Item("Bone Plate", false, 0, 0, 0, 35, 0, true,2);
            var armor03 = new Item("Royal Armor", false, 0, 0, 0, 50, 0, true,2);
            
            // Accessory 
            var accessory01 = new Item("Ring", false, 0, 0, 0, 5, 0, true,3);
            var accessory02 = new Item("Necklace", false, 0, 0, 5, 15, 0, true,3);
            var accessory03 = new Item("Royal Ring", false, 0, 0, 15, 10, 0, true,3);
            
            var itemDrop = hpPotion;
            var itemRandom = new Random();
            double numberTypeDrop = itemRandom.Next(0,101);
            
            if(numberTypeDrop < 50) // Drop item 50%
            {
                var rand = itemRandom.Next(0, 3);
                if (rand == 1)
                {
                    itemDrop = hpPotion;
                }
                else if (rand == 2)
                {
                    itemDrop = manaPotion;
                }

            }else if (numberTypeDrop > 50 && numberTypeDrop < 75) // Drop Weapons 25%
            {
                double rand = itemRandom.Next(0, 100);
                // 20%
                if (rand < 20)
                {
                    itemDrop = weapon04;
                }else if (rand > 20 && rand < 40)
                {
                    itemDrop = weapon08;
                }else if (rand > 40 && rand < 60)
                {
                    itemDrop = weapon12;
                }
                
                // 10% Chance
                else if (rand > 60 && rand < 70)
                {
                    itemDrop = weapon05;
                }else if (rand > 70 && rand < 80)
                {
                    itemDrop = weapon09;
                }else if (rand > 80 && rand < 90)
                {
                    itemDrop = weapon13;
                }
                // 2% Chance
                else if (rand > 90 && rand < 92)
                {
                    itemDrop = weapon06;
                }else if (rand > 92 && rand < 94)
                {
                    itemDrop = weapon10;
                }else if (rand > 94 && rand < 96)
                {
                    itemDrop = weapon14;
                }
                // <1% Chance
                else if (rand > 96 && rand < 97)
                {
                    itemDrop = weapon07;
                }else if (rand > 97 && rand < 98)
                {
                    itemDrop = weapon11;
                }else if (rand > 98 && rand < 99)
                {
                    itemDrop = weapon15;
                }
            }else if (numberTypeDrop > 75 && numberTypeDrop < 100) // Drop Armor 25%
            {
                double rand = itemRandom.Next(0, 100);
                // 20%
                if (rand < 20)
                {
                    itemDrop = head01;
                }else if (rand > 20 && rand < 40)
                {
                    itemDrop = armor01;
                }else if (rand > 40 && rand < 60)
                {
                    itemDrop = accessory01;
                }
                // 10%
                else if (rand > 60 && rand < 70)
                {
                    itemDrop = head02;
                }
                else if (rand > 70 && rand < 80)
                {
                    itemDrop = armor02;
                }
                else if (rand > 80 && rand < 90)
                {
                    itemDrop = accessory02;
                }
                // 3%
                else if (rand > 90 && rand < 93)
                {
                    itemDrop = head03;
                }
                else if (rand > 93 && rand < 96)
                {
                    itemDrop = armor03;
                }
                else if (rand > 96 && rand < 99)
                {
                    itemDrop = accessory03;
                }
            }
                            
            Console.WriteLine($"You have found item {itemDrop.Name} !");
            AddItem(itemDrop);
        }
    }
}