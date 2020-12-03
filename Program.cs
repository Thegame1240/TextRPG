using System;

namespace FinalProject
{
    class Program
    {
        public static bool playerSafe = true;
        static void Main(string[] args)
        {
            // Create Character (Objects)
            var char0 = new Character("", 0,0,0,0, 1);
            var char1 = new Character("Swordman", 150,50,30,20, 1);
            var char2 = new Character("Archer", 125, 60, 25, 15, 2);
            var char3 = new Character("Magician", 100, 80, 20, 10, 3);
            
            // Main Player
            var player = char0;
            bool characterSelected = false;
            
            // Set Destination 
            var destination = 25;
            
            // Create Skills
            var swordSkill01 = new Skill("Bash", 5, 30);
            var swordSkill02 = new Skill("Pices", 7, 45);
            var swordSkill03 = new Skill("Smash", 10, 55);
            
            var archerSkill01 = new Skill("Double Arrow", 5, 35);
            var archerSkill02 = new Skill("Arrow Shower", 8, 40);
            var archerSkill03 = new Skill("Aimed bolt", 12, 55);
            
            var magicSkill01 = new Skill("Fire", 20, 60);
            var magicSkill02 = new Skill("Ice", 15, 45);
            var magicSkill03 = new Skill("Wind", 5, 30);
            
            // Set Skills
            char1.SetSkill(new [] {swordSkill01, swordSkill02, swordSkill03});
            char2.SetSkill(new []{archerSkill01, archerSkill02, archerSkill03});
            char3.SetSkill(new []{magicSkill01, magicSkill02, magicSkill03});
            
            // Create Item
            var hpPotion = new Item("Health Potion", true, 40, 0,0,0,0,false);
            var manaPotion = new Item("Mana Potion", true, 0, 25,0,0,0,false);
            
            // Create Wepaon
            var weapon01 = new Item("Sword", false, 0, 0, 20,0, 1,true);
            
            var weapon02 = new Item("Bow",false, 0, 0, 15,0, 2,true);
            
            var weapon03 = new Item("Rod",false, 0, 0, 15,0, 3,true);
            
            // Crate Enemy
            var enemy01 = new Enemy("Goblin Axe", 100, 0, 10, 10, "Demi-Human");
            
            // Call Function //
            IntroGame(); 
            
            // Player select start character //
            while (!characterSelected)
            {
                Console.WriteLine("Welcome Adventure!");
                Console.WriteLine("=== Please Chose your character (Type: 1, 2, 3) ===\n 1.Swordman \n 2.Archer \n 3.Magician");
                var selectedCharacter = Console.ReadLine();
                switch (selectedCharacter)
                {
                    case "1":
                        player = char1;
                        Console.WriteLine($"You selected {char1.Name} to be your character");
                        characterSelected = true;
                        break;
                    case "2":
                        player = char2;
                        Console.WriteLine($"You selected {char2.Name} to be your character");
                        characterSelected = true;
                        break;
                    case "3":
                        player = char3;
                        Console.WriteLine($"You selected {char3.Name} to be your character");
                        characterSelected = true;
                        break;
                    default:
                        Console.WriteLine("Please select your character again.. (type: 1, 2, 3)");
                        break;
                }
            }
            
            //Change Name //
            Console.WriteLine("You can change you character name here: ");
            player.ChangeName();
            
            // Player select start item //
            bool itemSelected = false;
            while (!itemSelected)
            {
                Console.WriteLine("=== Now select your stater Item (Type: 1, 2, 3) ===\n 1. 2 Healing potion \n 2. 2 Mana potion \n 3. 1 Healing potion and 1 Mana potion");
                var itemChoice = Console.ReadLine();
                switch (itemChoice)
                {
                    case "1":
                        itemSelected = true;
                        player.AddItem(hpPotion);
                        player.AddItem(hpPotion);
                        break;
                    case "2":
                        itemSelected = true;
                        player.AddItem(manaPotion);
                        player.AddItem(manaPotion);
                        break;
                    case "3":
                        itemSelected = true;
                        player.AddItem(hpPotion);
                        player.AddItem(manaPotion);
                        break;
                    default:
                        Console.WriteLine("Please Chose your item to begin.. (type: 1, 2, 3)");
                        break;
                }
            }

            // Equip Weapon By Start Character //
            if (player == char1)
            {
                player.EquipWeapon(weapon01);
            }else if (player == char2)
            {
                player.EquipWeapon(weapon02);
            }else if (player == char3)
            {
                player.EquipWeapon(weapon03);
            }
            
            // Player Option //
            while (playerSafe && player.playerCurrentSpot != destination)
            {
                PlayerOption(player,enemy01);
            }

            if (player.playerCurrentSpot == destination) // To Final Bosss
            {
                Console.WriteLine("The Final Boss is Coming !"); // TODO: Final Boss 
                FinalBoss(player);
            }
            
            // Methods //
            static void IntroGame() // To Start Storyline and Explain Player
            {
                Console.Clear();
                Console.WriteLine("===== Welcome Adventure, You're awake alone in the middle of Forrest Village. ====="); // TODO: Story telling
                Console.WriteLine("===== While you sleep there is an attack of this village by goblin. ===============");
                Console.WriteLine("===== The Leader of this village has been captured to the Goblin Camp. ============");
                Console.WriteLine("===== People are begging you to help the Leader. ==================================");
                Console.WriteLine("===== Now it's time to begin! =====================================================");
                Console.WriteLine("Press any key to start...");
                Console.ReadKey();
                Console.Clear();
            }

            static void FinalBoss(Character player) // When player found enemy This function will call
            {
                var finalBoss = new Boss("Goblin Lord",500,150,100,60,"Boss");
                Console.WriteLine($"{finalBoss.Name} Well done Adventure! You come along here \n Now it's time to Die!!");
                while (player.Hp > 0 && finalBoss.Hp > 0)
                {
                    Console.WriteLine($"=== STATUS === \n== Hp: {player.Hp} == MP: {player.Mana} ==");
                    Console.WriteLine("Chose your action \n 1.Normal attack \n 2.Use skill \n 3.Use item ");
                    var playerAction = Console.ReadLine();
                    if (playerAction == "1")
                    {
                        player.PhysicalAttack(finalBoss);
                        finalBoss.Attack(player);
                    }
                    else if (playerAction == "2")
                    {
                        player.SkillAttack(finalBoss);
                        finalBoss.Attack(player);
                    }
                    else if (playerAction == "3")
                    {
                        player.OpenInventory();
                        Console.WriteLine("Select your item 0-4");
                        var playerItemSelectedInCombat = Convert.ToInt32(Console.ReadLine());
                        var itemSelectInCombat = player.Inventory[playerItemSelectedInCombat];
                        player.UseItem(itemSelectInCombat);
                        player.Inventory.Remove(itemSelectInCombat);
                    }
                }
            }

            static void PlayerOption(Character player, Enemy enemy01)
            {
                Console.WriteLine($"=== Current Player Status === \n== HP: {player.Hp} MP: {player.Mana} ==\n== PlayerSpot: {player.playerCurrentSpot}/25 ==");
                Console.WriteLine("Please Select your action ! \n 1. Walk \n 2. Open Inventory \n 3. Open Menu");
                var playerOption = Console.ReadLine();
                if (playerOption == "1")
                {
                    var isWalk = true;
                    // Walk 1 unit //
                    player.playerCurrentSpot++;
                    if (isWalk)
                    {
                        var random = new Random();
                        var randomEvent = random.Next(3);
                        if (randomEvent == 0) //Found Enemy
                        {
                            playerSafe = false;
                            var currentEnemy = enemy01.RandomEnemy(player);
                            Console.WriteLine($"{currentEnemy.Name} has spawn");

                            while (player.Hp > 0 && currentEnemy.Hp > 0)
                            {
                                Console.WriteLine($"=== PLAYER STATUS === \n== Hp: {player.Hp} == MP: {player.Mana} == ATK: {player.Atk} == DEF: {player.Def} ==");
                                Console.WriteLine($"=== {currentEnemy.Name} STATUS === \n== Hp: {currentEnemy.Hp} == ATK: {currentEnemy.Atk} == DEF: {currentEnemy.Def} ==");
                                Console.WriteLine("==== Chose your action ====\n 1.Normal attack \n 2.Use skill \n 3.Use item \n 4.Wait for Action \n 5.Try Escape");
                                var playerAction = Console.ReadLine();
                                if (playerAction == "1")
                                {
                                    player.PhysicalAttack(currentEnemy);
                                    currentEnemy.Attack(player);
                                }
                                else if (playerAction == "2")
                                {
                                    player.SkillAttack(currentEnemy);
                                    currentEnemy.Attack(player);
                                }
                                else if (playerAction == "3")
                                {
                                    player.OpenInventory();
                                    Console.WriteLine("Select your item 0-4");
                                    var playerItemSelectedInCombat = Convert.ToInt32(Console.ReadLine());
                                    var itemSelectInCombat = player.Inventory[playerItemSelectedInCombat];
                                    player.UseItem(itemSelectInCombat);
                                    player.Inventory.Remove(itemSelectInCombat);
                                }
                                else if (playerAction == "4") // TODO: Random Chance escape
                                {
                                    currentEnemy.Attack(player);
                                }else if (playerAction == "5")
                                {
                                    var escapeChance = random.Next(2);
                                    if (escapeChance == 1)
                                    {
                                        Console.WriteLine("Escape Success!");
                                        PlayerOption(player, currentEnemy);
                                    }
                                    else
                                    {
                                        Console.WriteLine("Escape Failed!");
                                    }
                                }
                            }

                            if (!player.IsDead)
                            {
                                playerSafe = true;
                            }
                        }
                        else if (randomEvent == 1) //Found Item
                        {
                            // Random item Drop !!!
                            player.RandomItemFound();
                        }
                        else if (randomEvent == 2) //Safely arrive
                        {
                            Console.WriteLine("Nothing happen, You are safe!");
                        }
                    }
                }else if (playerOption == "2")
                {
                    // Open Inventory //
                    // 5 slot // not stack at one slot
                    // select item // to use , equip , drop
                    player.OpenInventory();
                    
                    Console.WriteLine("=== Select your item (Type: 0 - 4) ===");
                    var playerItemSelected = Convert.ToInt32(Console.ReadLine());
                    var itemSelect = player.Inventory[playerItemSelected];

                    Console.WriteLine("=== Select your action ===\n 1.Use item \n 2.Equip item \n 3.Drop item");
                    var playerInventoryAction = Convert.ToInt32(Console.ReadLine());
                    
                    if (playerInventoryAction == 1)
                    {
                        // Use item
                        if (itemSelect.useable)
                        {
                            player.UseItem(itemSelect);
                            player.Inventory.Remove(itemSelect);
                        }
                        else
                        {
                            Console.WriteLine("This item can't be use!!");
                        }
                        
                    }
                    else if (playerInventoryAction == 2)
                    {
                        // Equip item
                        if (itemSelect.Equipable && player.WeaponType == itemSelect.WeaponType)
                        {
                            player.EquipWeapon(itemSelect);
                            Console.WriteLine($"You have equip {itemSelect.Name}");
                            player.Inventory.Remove(itemSelect);
                        }
                        else
                        {
                            Console.WriteLine("You cannot equip this item!!");
                        }
                    }
                    else if (playerInventoryAction == 3)
                    {
                        // Drop item
                        player.Inventory.Remove(itemSelect);
                        Console.WriteLine($"{itemSelect.Name} has remove.");
                    }
                    else
                    {
                        Console.WriteLine("Something went wrong! Please try again...");
                    }
                }
                else if (playerOption == "3")
                {
                    // Open Menu //
                    Console.WriteLine("===== Menu ===== \n 1: Resume (Warring: This will clear the Console) \n 2: Quit");
                    var openMenuOption = Console.ReadLine();
                    if (openMenuOption == "1") // resume
                    {
                        Console.Clear();
                    }
                    else if (openMenuOption == "2") // quit
                    {
                        Console.Clear();
                        Console.WriteLine("Game Over! \nPress Any key to Exit...");
                        Console.ReadKey();
                        System.Environment.Exit(0);
                    }
                }
            }
        }
    }
}