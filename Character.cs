using System;
using System.Collections.Generic;

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
        

        private Skill[] Skills;

        private Weapon[] Weapon;
        
        public Item[] inventories { get; private set; }

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
            Weapon = new Weapon[1];
            inventories = new Item[MaxInventory];
        }

        /// <summary>
        /// Set Skills to Character
        /// </summary>
        /// <param name="name"></param>

        public void AddItem(Item[] _inventory)
        {
            if (_inventory.Length != MaxInventory)
            {
                Console.WriteLine("Invalid !!");
            }

            inventories = _inventory;
        }

        public void openInventory()
        {
            Console.WriteLine("Your Inventory :");
            foreach (var VARIABLE in inventories)
            {
                var i = 0;
                i++;
                Console.WriteLine($"{i}. {VARIABLE.Name}");
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

        public void EquipWeapon(Weapon[] weapons1)
        {
            if (WeaponType != weapons1[0].WeaponType && !weapons1[0].Equipable)
            {
                Console.WriteLine("You cannot equip this item");
                return;
            }
            
            Weapon = weapons1;
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
        /*
        public void Attack(Enemy opponent)
        {
            Console.WriteLine($"{Name} is attacking {opponent.Name}");
            var damage = Atk + Weapon[0].weaponDamage - opponent.Def;
            
            if (damage > 0)
            {
                opponent.TakeDamage(damage);
            }else if (damage < 0)
            {
                TakeDamage(-damage);
            }
            else
            {
                Console.WriteLine($"{opponent.Name} has block {Name}'s attack!");
            }
        }
        */
        public void PhysicalAttack(Enemy opponent)
        {
            var damage = Atk + Weapon[0].WeaponDamage - opponent.Def;
            Console.WriteLine($"{Name} used physical attack!");
            Console.WriteLine($"player Damage : {damage}");
            if (damage > 0)
            {
                opponent.TakeDamage(damage);
            }else if (damage < 0)
            {
                damage = 0;
            }
        }

        public void SkillAttack(Enemy opponent)
        {
            Console.WriteLine($"Select your skill \n 0.{Skills[0].Name} \n 1.{Skills[1].Name} \n 2. {Skills[2].Name}");
            var skillNumber = Convert.ToInt32(Console.ReadLine());
            var selectedSkill = Skills[skillNumber];
            var damage = 0;
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

                    damage = selectedSkill.Damage;
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

                    damage = selectedSkill.Damage;
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

                    damage = selectedSkill.Damage;
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
                attackSucess = false;
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