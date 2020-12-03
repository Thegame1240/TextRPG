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
            Console.WriteLine("Your Inventory :");
            foreach (var item in Inventory)
            {
                Console.WriteLine($"==> {item.Name}");
            }
        }

        public void UseItem(Item potion)
        {
            if (!potion.useable)
            {
                Console.WriteLine("This item cannot use");
            }

            if (potion.HealingAmount >= 1)
            {
                Hp = Hp + potion.HealingAmount;
                Console.WriteLine($"You have use a Healing Potion (Health Increases: {potion.HealingAmount})");
            }

            if (potion.ManaAmount >= 1)
            {
                Mana = Mana + potion.ManaAmount;
                Console.WriteLine($"You have use a Mana Potion (Mana Increases: {potion.ManaAmount})");
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
            Console.WriteLine($"{Name} used physical attack!");
            Console.WriteLine($"player Damage : {damage}");
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
            Console.WriteLine($"You are Dead! The game is ending!");
        }
    }
}