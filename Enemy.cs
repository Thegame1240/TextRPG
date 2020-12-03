using System;

namespace FinalProject
{
    public class Enemy
    {
        // Enemy 6 types Include Boss
        public string Name { get; private set; }
        public int Hp { get; private set; }
        public int Mana { get; private set; }
        public int Atk { get; private set; }
        public int Def { get; private set; }
        public string eType { get; private set; }
        public bool IsDead { get; private set; }

        public Enemy(string name, int hp, int mana, int atk, int def, string etype)
        {
            Name = name;
            Hp = hp;
            Mana = mana;
            Atk = atk;
            Def = def;
            eType = etype;
        }

        public virtual void Attack(Character opponent)
        {
            
            //var random = new Random();
            //var attackType = random.Next(2);

            //if (attackType == 0)
            //{
            if (!IsDead)
            {
                Console.WriteLine($"{Name} is attacking {opponent.Name}");
                var damage = Atk - opponent.Def;
            
                if (damage > 0)
                {
                    opponent.TakeDamage(damage);
                }else if (damage < 0)
                {
                    opponent.TakeDamage(-damage);
                }
                else
                {
                    Console.WriteLine($"{opponent.Name} has block {Name}'s attack!");
                }
            }
                
            //}
            //else
            //{
            //    Console.WriteLine("Enemy escape!");
            //    return;
            //}
            
            
        }
        public virtual void TakeDamage(int damage)
        {
            Hp -= damage;
            if (Hp > 0)
            {
                Console.WriteLine($"{Name} is taken damage {damage} Unit, Hp after take damage: {Hp}");
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
        }

        public Enemy RandomEnemy(Character character)
        {
            var enemy01 = new Enemy("Goblin Axe", 100, 0, 10, 10, "Demi-Human");
            var enemy02 = new Enemy("Goblin Hammer", 150, 0, 15, 20, "Demi-Human");
            var enemy03 = new Enemy("Goblin Archer", 100, 0, 20, 10, "Demi-Human");
            var enemy04 = new Enemy("Wolf", 80, 0, 55, 30, "Beast");
            var enemy05 = new Enemy("Goblin Leader", 250, 0, 70, 65, "Demi-Human");
            
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
                if (character.playerCurrentSpot >= 5)
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
                if (character.playerCurrentSpot >= 10)
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
                if (character.playerCurrentSpot >= 15)
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
                if (character.playerCurrentSpot >= 20)
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
    }
}