using System;
using System.Collections.Generic;
using System.Linq;

namespace FinalProject
{
    public class Character
    {
        private const int MaxSkill = 3;
        private const int MaxInventory = 6;
        public string Name { get; private set; }
        public int Hp { get; private set; }
        public int Mana { get; private set; }
        public int Atk { get; private set; }
        public int Def { get; private set; }
        public bool IsDead { get; private set; }
        public int WeaponType { get; private set; }
        public int ItemCount { get; private set; }
        public int playerCurrentSpot;

        private Skill[] Skills;

        public Item Weapon { get; private set; }
        
        public List<Item> Inventory { get; private set; }

        public Character(string name, int hp, int mana, int atk, int def, int weapontype)
        {
            Name = name;
            Hp = hp;
            Mana = mana;
            Atk = atk;
            Def = def;
            IsDead = false;
            Skills = new Skill[MaxSkill];
            WeaponType = weapontype;
            Weapon = new Item("null", false, 0,0,0,0,0,false) ;
            Inventory = new List<Item>();
        }

        public void AddItem(Item items)
        {
            ItemCount++;
            if (ItemCount > 0 && ItemCount < MaxInventory)
            {
                Inventory.Add(items);
                Console.WriteLine($"You get {items.Name} 1 ea.");
            }
            else
            {
                Console.WriteLine("Your bag is full!!");
            }
        }

        public void OpenInventory()
        {
            Console.WriteLine("Your Inventory (To Select Type: 0 - 4):");
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

            if (potion.HealingAmount >= 1)
            {
                Hp = Hp + potion.HealingAmount;
                Console.WriteLine($"You used a Health Potion (Health Increases: {potion.HealingAmount})");
            }

            if (potion.ManaAmount >= 1)
            {
                Mana = Mana + potion.ManaAmount;
                Console.WriteLine($"You used a Mana Potion (Mana Increases: {potion.ManaAmount})");
            }
            
        }

        public Item EquipWeapon(Item weapons1)
        {
            if (WeaponType != weapons1.WeaponType && !weapons1.Equipable)
            {
                Console.WriteLine("You cannot equip this item!!");
            }
            
            return Weapon = weapons1;
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
        
        public void PhysicalAttack(Enemy opponent)
        {
            var wepondamage = Weapon.WeaponDamage;
            var damage = Atk + wepondamage - opponent.Def;
            Console.WriteLine($"{Name} used physical attack to {opponent.Name}!");
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
            Console.WriteLine($"Select your skill \n 0.{Skills[0].Name} \n 1.{Skills[1].Name} \n 2. {Skills[2].Name}");
            var skillNumber = Convert.ToInt32(Console.ReadLine());
            var selectedSkill = Skills[skillNumber];
            var weaponDamage = Weapon.WeaponDamage / 3;
            var damage = weaponDamage;
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
            //var weapon01 = new Item("Sword", false, 0, 0, 20,0, 1,true);
            var weapon04 = new Item("Long Sword", false, 0, 0, 25,0, 1,true);
            var weapon05 = new Item("Katana", false, 0, 0, 45,0, 1,true);
            var weapon06 = new Item("Solar Sword", false, 0, 0, 50,0, 1,true);
            var weapon07 = new Item("Excalibur", false, 0, 0, 70,0, 1,true);
            
            //var weapon02 = new Item("Bow",false, 0, 0, 15,0, 2,true);
            var weapon08 = new Item("Composite Bow",false, 0, 0, 30,0, 2,true);
            var weapon09 = new Item("Cross Bow",false, 0, 0, 50,0, 2,true);
            var weapon10 = new Item("Big Cross Bow",false, 0, 0, 65,0, 2,true);
            var weapon11 = new Item("Mystic Bow",false, 0, 0, 75,0, 2,true);
            
            //var weapon03 = new Item("Rod",false, 0, 0, 15,0, 3,true);
            var weapon12 = new Item("Wand",false, 0, 0, 30,0, 3,true);
            var weapon13 = new Item("Arc Wand",false, 0, 0, 50,0, 3,true);
            var weapon14 = new Item("Survivor's Rod",false, 0, 0, 60,0, 3,true);
            var weapon15 = new Item("Royal Cleric Staff",false, 0, 0, 80,0, 3,true);
            
            var hpPotion = new Item("Health Potion", true, 40, 0,0,0,0,false);
            var manaPotion = new Item("Mana Potion", true, 0, 25,0,0,0,false);
            
            var itemDrop = hpPotion;
            var itemRandom = new Random();
            var numberItem = itemRandom.Next(87);
            
            // 15 Chance
            if(numberItem >= 1 && numberItem <= 15)
            {
                itemDrop = hpPotion;
            }else if (numberItem >= 16 && numberItem <= 30)
            {
                itemDrop = manaPotion;
            }
            // 10 Chance
            else if (numberItem >= 31 && numberItem <= 40)
            {
                itemDrop = weapon04;
            }else if (numberItem >= 41 && numberItem <= 50)
            {
                itemDrop = weapon08;
            }else if (numberItem >= 51 && numberItem <= 60)
            {
                itemDrop = weapon12;
            }
            // 5 Chance
            else if (numberItem >= 61 && numberItem <= 65)
            {
                itemDrop = weapon05;
            }else if (numberItem >= 66 && numberItem <= 70)
            {
                itemDrop = weapon09;
            }else if (numberItem >= 71 && numberItem <= 75)
            {
                itemDrop = weapon13;
            }
            // 3 Chance
            else if (numberItem >= 76 && numberItem <= 78)
            {
                itemDrop = weapon06;
            }else if (numberItem >= 78 && numberItem <= 80)
            {
                itemDrop = weapon10;
            }else if (numberItem >= 81 && numberItem <= 83)
            {
                itemDrop = weapon14;
            }
            // 1 Chance
            else if (numberItem == 84)
            {
                itemDrop = weapon07;
            }else if (numberItem == 85)
            {
                itemDrop = weapon11;
            }else if (numberItem == 86)
            {
                itemDrop = weapon15;
            }
                            
            Console.WriteLine($"You have found item {itemDrop.Name} !");
            AddItem(itemDrop);
        }
    }
}