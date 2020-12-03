namespace FinalProject
{
    public class Boss : Enemy
    {
        public Boss(string name, int hp, int mana, int atk, int def, string etype) : base(name, hp, mana, atk, def,
            etype)
        {
            
        }

        public override void Attack(Character opponent)
        {
            base.Attack(opponent);
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