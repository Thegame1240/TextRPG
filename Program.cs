using System;
using System.Collections.Generic;

namespace FinalProject
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create Character (Objects)
            var char0 = new Character("", 0,0,0,0, 1);
            var char1 = new Character("Swordman", 100,20,10,15, 1);
            var char2 = new Character("Archer", 100, 30, 15, 10, 2);
            var char3 = new Character("Magician", 100, 50, 20, 5, 3);
            
            // Main Player
            var player = char0;
            bool characterSelected = false;
            
            // Create Skills
            var swordSkill01 = new Skill("Bash", 5, 20);
            var swordSkill02 = new Skill("Pices", 7, 25);
            var swordSkill03 = new Skill("Smash", 10, 30);
            
            var archerSkill01 = new Skill("Double Arrow", 5, 20);
            var archerSkill02 = new Skill("Arrow Shower", 10, 25);
            var archerSkill03 = new Skill("Aimed bolt", 12, 30);
            
            var magicSkill01 = new Skill("Fire", 15, 30);
            var magicSkill02 = new Skill("Ice", 10, 25);
            var magicSkill03 = new Skill("Wind", 7, 20);
            
            // Set Skills
            char1.SetSkill(new [] {swordSkill01, swordSkill02, swordSkill03});
            char2.SetSkill(new []{archerSkill01, archerSkill02, archerSkill03});
            char3.SetSkill(new []{magicSkill01, magicSkill02, magicSkill03});
            
            // Create Enemy
            var enemy01 = new Enemy("Goblin", 100, 50, 10, 20, "Baby");
            
            // Create Item
            var hpPotion = new Item("Health Potion", true, 40, 0);
            var manaPotion = new Item("Mana Potion", true, 0, 25);
            
            // Create Wepaon
            var weapon01 = new Weapon("Sword", false, 0, 0, true, 20, 1);
            var weapon02 = new Weapon("Bow",false, 0, 0,true, 15, 2);
            var weapon03 = new Weapon("Rod",false, 0, 0, true, 10, 3);
            var weapon04 = new Weapon("Long Sword", false, 0, 0, true, 25, 1);
            
            
            // Equip weapon
            if (player.WeaponType == 1)
            {
                player.EquipWeapon(new []{weapon01});
            }else if (player.WeaponType == 2)
            {
                player.EquipWeapon(new []{weapon02});
            }else if (player.WeaponType == 3)
            {
                player.EquipWeapon(new []{weapon03});
            }
            
            // Player select start character
            while (!characterSelected)
            {
                Console.WriteLine("Welcome to Adventure Game");
                Console.WriteLine("Please Select your character (Type: 1, 2, 3) \n 1.Swordman \n 2.Archer \n 3.Magician");
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
            
            // Player select start item //
            bool itemSelected = false;
            while (!itemSelected)
            {
                Console.WriteLine("Now select Item (Type: 1, 2, 3) \n 1. 2 Healing potion \n 2. 2 Mana potion \n 3. 1 Healing potion and 1 Mana potion");
                var itemChoice = Console.ReadLine();
                switch (itemChoice)
                {
                    case "1":
                        itemSelected = true;
                        Console.WriteLine("You got 2 Healing Potion");
                        player.AddItem(new []{hpPotion, hpPotion});
                        break;
                    case "2":
                        itemSelected = true;
                        Console.WriteLine("You got 2 Mana potion");
                        player.AddItem(new []{manaPotion,manaPotion});
                        break;
                    case "3":
                        itemSelected = true;
                        Console.WriteLine("You got 1 Healing potion and 1 Mana potion");
                        player.AddItem(new []{hpPotion,manaPotion});
                        break;
                    default:
                        Console.WriteLine("Please Chose your item to begin.. (type: 1, 2, 3)");
                        break;
                }
            }
            
            // Call Function //
            Console.Clear();
            IntroGame(); 
            PlayerOption(player);
            
            // Methods //
            static void IntroGame() // To Start Storyline and Explain Player
            {
                Console.WriteLine("Welcome Adventure... Bla Bla "); // TODO: Story telling
                Console.WriteLine("Press any key to start");
                Console.ReadKey();
                Console.Clear();
            }

            static void FoundEnemy(Character player) // When player found enemy This function will call
            {
                var enemy01 = new Enemy("Goblin Axe", 100, 0, 10, 10, "Baby");
                var enemy02 = new Enemy("Goblin Hammer", 150, 0, 15, 20, "Baby");
                var enemy03 = new Enemy("Goblin Archer", 100, 0, 20, 10, "Baby");
                var enemy04 = new Enemy("Wolf", 80, 0, 45, 30, "Baby");
                var enemy05 = new Enemy("Goblin Leader", 250, 0, 50, 65, "Baby");
                
                var random = new Random();
                var enemyType = random.Next(52);
                var currentEnemy = enemy01;
                
                if (enemyType <= 1 || enemyType <= 15)
                {
                    currentEnemy = enemy01;
                }else if (enemyType <= 16 || enemyType <= 25)
                {
                    currentEnemy = enemy02;
                }else if (enemyType <= 26 || enemyType <= 35)
                {
                    currentEnemy = enemy03;
                }else if (enemyType <= 36 || enemyType <= 44)
                {
                    currentEnemy = enemy04;
                }else if (enemyType <= 45 || enemyType <= 51)
                {
                    currentEnemy = enemy05;
                }
                
                
                Console.WriteLine($"{currentEnemy.Name} has spawn");
                
                while (player.Hp > 0 && currentEnemy.Hp > 0)
                {
                    Console.WriteLine($"=== STATUS === \n== Hp: {player.Hp} == MP: {player.Mana} ==");
                    Console.WriteLine("Chose your action \n 1.Normal attack \n 2.Use skill \n 3.Use item \n 4.Escape");
                    var playerAction = Console.ReadLine();
                    if (playerAction == "1")
                    {
                        player.PhysicalAttack(currentEnemy);
                        enemy01.Attack(player);
                    }else if (playerAction == "2")
                    {
                        player.SkillAttack(currentEnemy);
                        enemy01.Attack(player);
                    }else if (playerAction == "3")
                    {
                        int playerItemSelectedInCombat;
                        player.openInventory();
                        Console.WriteLine("Select your item 0-4");
                        playerItemSelectedInCombat = Convert.ToInt32(Console.ReadLine());
                        var itemSelectInCombat = player.inventories[playerItemSelectedInCombat];
                        player.UseItem(itemSelectInCombat);
                    }else if (playerAction == "4")
                    {
                        Console.WriteLine("You have try to escape!");
                    }
                }
            }

            static void PlayerOption(Character player) // This is Menu for player action
            {
                // Set Destination 
                var destination = 25;
                var playerCurrentSpot = 0;
                
                // Variables
                int playerInventoryAction;
                int playerItemSelected;
                bool playerSafe = true;
                
                while (playerSafe && playerCurrentSpot != destination)
                {
                    Console.WriteLine($"Current Player Status: \n HP: {player.Hp} MP {player.Mana}");
                    Console.WriteLine("Please Select your action ! \n 1. Walk \n 2. Open Inventory \n 3. Open Menu");
                    var playerOption = Console.ReadLine();
                    
                    // === Player Option === //
                    switch (playerOption)
                    {
                        case "1": // Walk 1 unit //
                            bool isWalk = true;
                            if (isWalk)
                            {
                                playerCurrentSpot++;
                                var random = new Random();
                                var randomEvent = random.Next(3);
                                if (randomEvent == 0) //Found Enemy
                                {
                                    playerSafe = false;
                                    Console.WriteLine("You have found the enemy !");
                                    FoundEnemy(player);
                                    if (!player.IsDead)
                                    {
                                        playerSafe = true;
                                    }
                                }
                                else if (randomEvent == 1) //Found Item
                                {
                                    Console.WriteLine("You have found item(name) !");
                                    playerSafe = true;
                                }
                                else if (randomEvent == 2) //Safely arrive
                                {
                                    Console.WriteLine("Nothing happen, You are safe!");
                                    playerSafe = true;
                                }
                            }
                            break;
                        case "2":   // Open Inventory //
                        case "i":   // 5 slot // not stack at one slot
                                    // select item // to use , equip , drop
                            player.openInventory();
                            // ====================================
                            Console.WriteLine("Select your item 0-4");
                            playerItemSelected = Convert.ToInt32(Console.ReadLine());
                            var itemSelect = player.inventories[playerItemSelected];
                    
                            Console.WriteLine("Select your action \n 1.Use item \n 2.Equip item \n 3.Drop item");
                            playerInventoryAction = Convert.ToInt32(Console.ReadLine());
                            if (playerInventoryAction == 1 && itemSelect.useable)
                            {
                                // Use item
                                player.UseItem(itemSelect);
                            }else if (playerInventoryAction == 2)
                            {
                                // Equip item
                            }else if (playerInventoryAction == 3)
                            {
                                // Drop item
                            }
                            break;
                        case "3":
                        case "o":
                            // Open Menu //
                            Console.WriteLine("Menu : \n 1: Resume \n 2: Quit");
                            var openMenuOption = Console.ReadLine();
                            if (openMenuOption == "1") // resume
                            {
                                Console.Clear();
                                //PlayerOption();
                                playerSafe = true;
                            }
                            else if (openMenuOption == "2") // quit
                            {
                                Console.Clear();
                                Console.WriteLine("Game over now !");
                                return;
                            }
                            break;
                        default:
                            Console.WriteLine("Error (wrong action type!) Please try agin.. (Type: 1, 2 or (i), 3 or (o) )");
                            break;

                    }
                }

                if (playerCurrentSpot == destination)
                {
                    playerSafe = false;
                    Console.WriteLine("You have found the enemy !");
                    FoundEnemy(player);
                }
            }
        }
    }
}