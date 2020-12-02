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

        public void Attack(Character opponent)
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
        public void TakeDamage(int damage)
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

        public void Dead()
        {
            Console.WriteLine($"{Name} is Dead!");
        }
    }
}