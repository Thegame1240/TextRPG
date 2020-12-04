using System;

namespace FinalProject
{
    public class Boss : Enemy
    {
        public const int MaxSkill = 3;
        private Skill[] Skills;
        public Boss(string name, int hp, int mana, int atk, int def, string etype) : base(name, hp, mana, atk, def,
            etype)
        {
            Skills = new Skill[MaxSkill];
        }
        
        public void SetBossSkill(Skill[] skills)
        {
            if (skills.Length != MaxSkill)
            {
                Console.WriteLine("Invalid size of the array");
                return;
            }
            
            Skills = skills;
        }
        public override int SetRandomAtk()
        {
            return base.SetRandomAtk();
        }

        public override int SetRandomDef()
        {
            return base.SetRandomDef();
        }

        public override void Attack(Character opponent)
        {
            var random = new Random();
            var attackType = random.Next(2);
            
            if (attackType == 0)
            {
                // Physical attack
                PhysicalAttack(opponent);
            }
            else
            {
                // Skill attack
                SkillAttack(opponent);
            }
        }

        public void PhysicalAttack(Character opponent)
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

        public void SkillAttack(Character opponent)
        {
            Random rnd = new Random();
            var skillNumber = rnd.Next(0, 3);
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

                    damage += selectedSkill.Damage;
                    attackSucess = true;
                    Console.WriteLine($"{Name} used skill {selectedSkill.Name} causing {selectedSkill.Damage}");
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
            }

            if (attackSucess)
            {
                opponent.TakeDamage(damage);
            }
        }

        public override void TakeDamage(int damage)
        {
            base.TakeDamage(damage);
        }

        public override void Dead()
        {
            base.Dead();
        }
    }
}