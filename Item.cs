using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FinalProject
{
    public class Item
    {
        // 2 Types Hp and Mp
        public string Name { get; private set; }
        public bool useable { get; private set; }
        public int HealingAmount { get; private set; }
        
        public int ManaAmount { get; private set; }
        
        public Item(string name, bool useable, int healingAmount, int manaAmount)
        {
            Name = name;
            this.useable = useable;
            HealingAmount = healingAmount;
            ManaAmount = manaAmount;
        }
    }
}