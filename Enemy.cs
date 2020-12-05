using System;

namespace FinalProject
{
    public class Enemy
    {
        // Enemy 6 types Include Boss
        public string Name { get; private set; }
        public int Hp { get; private set; }
        public int Mana { get; protected set; }
        public int Atk { get; private set; }
        public int Def { get; private set; }
        public string eType { get; private set; }
        public bool IsDead { get; private set; }
        public bool Dropitem { get; private set; }
        public Item ItemDrop { get; private set; }
        public Enemy(string name, int hp, int mana, int atk, int def, string etype)
        {
            Name = name;
            Hp = hp;
            Mana = mana;
            Atk = atk;
            Def = def;
            eType = etype;
            Dropitem = false;
            ItemDrop = new Item("",false,0,0,0,0,0,false,0);
        }
        
        public virtual int SetRandomAtk()
        {
            var damage = Atk;
            var minAtk = damage - 5;
            var maxAtk = damage + 20;
            Random rnd = new Random();
            var rndDamage = rnd.Next(minAtk, maxAtk);
            return damage = rndDamage;
        }

        public virtual int SetRandomDef()
        {
            var defend = Def;
            var minDef = defend - 15;
            var maxDef = defend;
            Random rnd = new Random();
            var rndDef = rnd.Next(minDef,maxDef);
            return defend = rndDef;
        }
        
        public virtual void Attack(Character opponent)
        {
            if (!IsDead)
            {
                var damage = SetRandomAtk() - opponent.SetRandomDef();
                Console.WriteLine($"{Name} dealing damage to {opponent.Name} {damage} unit!");
                if (damage > 0)
                {
                    opponent.TakeDamage(damage);
                }else if (damage < 0)
                {
                    damage = 0;
                    Console.WriteLine($"{opponent.Name} has block {Name}'s attack!");
                }
            }
        }
        
        public virtual void TakeDamage(int damage)
        {
            Hp -= damage;
            if (Hp > 0)
            {
                Console.WriteLine($"{Name} is taken damage {damage} unit, Hp after take damage: {Hp}");
                Console.WriteLine();
            }
            
            if (Hp <= 0)
            {
                IsDead = true;
                Dead();
            }
        }

        public virtual void Dead()
        {
            Console.WriteLine($"{Name} is Dead!");
            Random rand = new Random();
            var itemDropChance = rand.Next(0,100);
            if (itemDropChance < 40) // 40% chance to drop
            {
                Dropitem = true;
                EnemyDropItem();
            }
        }

        public Enemy RandomEnemy(Character character)
        {
            var enemy01 = new Enemy("Goblin Axe", 150, 0, 35, 35, "Demi-Human");
            var enemy02 = new Enemy("Goblin Hammer", 155, 0, 30, 40, "Demi-Human");
            var enemy03 = new Enemy("Goblin Archer", 150, 0, 45, 30, "Demi-Human");
            var enemy04 = new Enemy("Wolf", 100, 0, 55, 30, "Beast");
            var enemy05 = new Enemy("Goblin Leader", 200, 0, 60, 50, "Demi-Human");
            
            Console.WriteLine("You have found the enemy!");
            // Random Enemy
            var random = new Random();
            var enemyType = random.Next(52);
            var currentEnemy = enemy01;

            if (enemyType <= 1 || enemyType <= 15)
            {
                currentEnemy = enemy01;
            }
            else if (enemyType <= 16 || enemyType <= 25)
            {
                if (character.PlayerCurrentSpot >= 5)
                {
                    currentEnemy = enemy02;
                }
                else
                {
                    currentEnemy = enemy01;
                }
            }
            else if (enemyType <= 26 || enemyType <= 35)
            {
                if (character.PlayerCurrentSpot >= 10)
                {
                    currentEnemy = enemy03;
                }
                else
                {
                    currentEnemy = enemy02;
                }
            }
            else if (enemyType <= 36 || enemyType <= 44)
            {
                if (character.PlayerCurrentSpot >= 15)
                {
                    currentEnemy = enemy04;
                }
                else
                {
                    currentEnemy = enemy03;
                }
            }
            else if (enemyType <= 45 || enemyType <= 51)
            {
                if (character.PlayerCurrentSpot >= 20)
                {
                    currentEnemy = enemy05;
                }
                else
                {
                    currentEnemy = enemy04;
                }
            }

            return currentEnemy;
        }

        public void EnemyDropItem()
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

            ItemDrop = itemDrop;
        }
    }
}