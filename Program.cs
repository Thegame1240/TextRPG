using System;

namespace FinalProject
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create Character (Objects)
            var char0 = new Character("", 0,0,0,0, 1);
            var char1 = new Character("Swordman", 100,25,10,15, 1);
            var char2 = new Character("Archer", 100, 50, 15, 10, 2);
            var char3 = new Character("Magician", 100, 60, 20, 5, 3);
            
            // Main Player
            var player = char0;
            bool characterSelected = false;
            
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
            var weapon04 = new Item("Long Sword", false, 0, 0, 25,0, 1,true);
            var weapon05 = new Item("Katana", false, 0, 0, 45,0, 1,true);
            var weapon06 = new Item("Solar Sword", false, 0, 0, 50,0, 1,true);
            var weapon07 = new Item("Excalibur", false, 0, 0, 70,0, 1,true);
            
            var weapon02 = new Item("Bow",false, 0, 0, 15,0, 2,true);
            var weapon08 = new Item("Composite Bow",false, 0, 0, 30,0, 2,true);
            var weapon09 = new Item("Cross Bow",false, 0, 0, 50,0, 2,true);
            var weapon10 = new Item("Big Cross Bow",false, 0, 0, 65,0, 2,true);
            var weapon11 = new Item("Mystic Bow",false, 0, 0, 75,0, 2,true);
            
            var weapon03 = new Item("Rod",false, 0, 0, 15,0, 3,true);
            var weapon12 = new Item("Wand",false, 0, 0, 30,0, 3,true);
            var weapon13 = new Item("Arc Wand",false, 0, 0, 50,0, 3,true);
            var weapon14 = new Item("Survivor's Rod",false, 0, 0, 60,0, 3,true);
            var weapon15 = new Item("Royal Cleric Staff",false, 0, 0, 80,0, 3,true);
            
            // Crate Enemy
            var enemy01 = new Enemy("Goblin Axe", 100, 0, 10, 10, "Demi-Human");
            var enemy02 = new Enemy("Goblin Hammer", 150, 0, 15, 20, "Demi-Human");
            var enemy03 = new Enemy("Goblin Archer", 100, 0, 20, 10, "Demi-Human");
            var enemy04 = new Enemy("Wolf", 80, 0, 55, 30, "Beast");
            var enemy05 = new Enemy("Goblin Leader", 250, 0, 70, 65, "Demi-Human");
            
            // Call Function //
            IntroGame(); 
            
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
                Console.WriteLine("Now select your stater Item (Type: 1, 2, 3) \n 1. 2 Healing potion \n 2. 2 Mana potion \n 3. 1 Healing potion and 1 Mana potion");
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

            // Set Destination 
            var destination = 25;
            var playerCurrentSpot = 0;
                
            // Variables
            bool playerSafe = true;

            // Equip Weapon By Start Character
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
            
            // Player Option
            while (playerSafe && playerCurrentSpot != destination)
            {
                Console.WriteLine($"=== Current Player Status === \n == HP: {player.Hp} MP: {player.Mana} == PlayerSpot {playerCurrentSpot}");
                Console.WriteLine("Please Select your action ! \n 1. Walk \n 2. Open Inventory \n 3. Open Menu");
                var playerOption = Console.ReadLine();
                
                if (playerOption == "1")
                {
                    var isWalk = true;
                    // Walk 1 unit //
                    playerCurrentSpot++;
                    if (isWalk)
                    {
                        var random = new Random();
                        var randomEvent = random.Next(3);
                        if (randomEvent == 0) //Found Enemy
                        {
                            playerSafe = false;
                            Console.WriteLine("You have found the enemy !");
                            
                            // Random Enemy
                            random = new Random();
                            var enemyType = random.Next(52);
                            var currentEnemy = enemy01;

                            if (enemyType <= 1 || enemyType <= 15)
                            {
                                currentEnemy = enemy01;
                            }
                            else if (enemyType <= 16 || enemyType <= 25 && playerCurrentSpot > 5)
                            {
                                currentEnemy = enemy02;
                            }
                            else if (enemyType <= 26 || enemyType <= 35 && playerCurrentSpot > 10)
                            {
                                currentEnemy = enemy03;
                            }
                            else if (enemyType <= 36 || enemyType <= 44 && playerCurrentSpot > 15)
                            {
                                currentEnemy = enemy04;
                            }
                            else if (enemyType <= 45 || enemyType <= 51 && playerCurrentSpot > 20)
                            {
                                currentEnemy = enemy05;
                            }
                            
                            Console.WriteLine($"{currentEnemy.Name} has spawn");

                            while (player.Hp > 0 && currentEnemy.Hp > 0)
                            {
                                Console.WriteLine(
                                    $"=== STATUS === \n== Hp: {player.Hp} == MP: {player.Mana} == {player.Weapon.Name}");
                                Console.WriteLine(
                                    "Chose your action \n 1.Normal attack \n 2.Use skill \n 3.Use item \n 4.Escape");
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
                                else if (playerAction == "4")
                                {
                                    Console.WriteLine("You have try to escape!");
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
                            var itemDrop = hpPotion;
                            var itemRandom = new Random();
                            var numberItem = itemRandom.Next(87);
            
                            // 15 Chance
                            if(numberItem >= 1 && numberItem <= 15)
                            {
                                itemDrop = hpPotion;
                            }else if (numberItem >= 16 && numberItem <= 30)
                            {
                                itemDrop = manaPotion;
                            }
                            // 10 Chance
                            else if (numberItem >= 31 && numberItem <= 40)
                            {
                                itemDrop = weapon04;
                            }else if (numberItem >= 41 && numberItem <= 50)
                            {
                                itemDrop = weapon08;
                            }else if (numberItem >= 51 && numberItem <= 60)
                            {
                                itemDrop = weapon12;
                            }
                            // 5 Chance
                            else if (numberItem >= 61 && numberItem <= 65)
                            {
                                itemDrop = weapon05;
                            }else if (numberItem >= 66 && numberItem <= 70)
                            {
                                itemDrop = weapon09;
                            }else if (numberItem >= 71 && numberItem <= 75)
                            {
                                itemDrop = weapon13;
                            }
                            // 3 Chance
                            else if (numberItem >= 76 && numberItem <= 78)
                            {
                                itemDrop = weapon06;
                            }else if (numberItem >= 78 && numberItem <= 80)
                            {
                                itemDrop = weapon10;
                            }else if (numberItem >= 81 && numberItem <= 83)
                            {
                                itemDrop = weapon14;
                            }
                            // 1 Chance
                            else if (numberItem == 84)
                            {
                                itemDrop = weapon07;
                            }else if (numberItem == 85)
                            {
                                itemDrop = weapon11;
                            }else if (numberItem == 86)
                            {
                                itemDrop = weapon15;
                            }
                            
                            Console.WriteLine($"You have found item {itemDrop.Name} !");
                            player.AddItem(itemDrop);
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
                    
                    Console.WriteLine("Select your item 0-4");
                    var playerItemSelected = Convert.ToInt32(Console.ReadLine());
                    var itemSelect = player.Inventory[playerItemSelected];

                    Console.WriteLine("Select your action \n 1.Use item \n 2.Equip item \n 3.Drop item");
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
                    Console.WriteLine("Menu : \n 1: Resume (This will clear the Console) \n 2: Quit");
                    var openMenuOption = Console.ReadLine();
                    if (openMenuOption == "1") // resume
                    {
                        Console.Clear();
                    }
                    else if (openMenuOption == "2") // quit
                    {
                        Console.Clear();
                        Console.WriteLine("Game over now !");
                        return;
                    }
                }
            }

            if (playerCurrentSpot == destination) // To Final Bosss
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
                Console.WriteLine($"{finalBoss.Name} Well done Adventure! You came along here \n Now it's time to Die!");
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
        }
    }
}