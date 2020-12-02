namespace FinalProject
{
    public class Skill
    {
        public string Name { get; private set; }
        public int ManaConsume { get; private set; }
        public int Damage { get; private set; }

        public Skill(string name, int manaConsume, int damage)
        {
            Name = name;
            ManaConsume = manaConsume;
            Damage = damage;
        }

        public string getName()
        {
            return Name;
        }
    }
}