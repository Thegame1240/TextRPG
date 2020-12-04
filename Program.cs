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
            var char1 = new Character("Swordman", 150,100,30,20, 1);
            var char2 = new Character("Archer", 150, 100, 25, 15, 2);
            var char3 = new Character("Magician", 150, 100, 20, 10, 3);
            
            // Main Player
            var player = char0;
            bool characterSelected = false;
            
            // Set Destination 
            var destination = 25;
            
            // Create Skills
            var swordSkill01 = new Skill("Bash", 10, 30);
            var swordSkill02 = new Skill("Pices", 15, 45);
            var swordSkill03 = new Skill("Smash", 20, 55);
            
            var archerSkill01 = new Skill("Double Arrow", 10, 35);
            var archerSkill02 = new Skill("Arrow Shower", 15, 40);
            var archerSkill03 = new Skill("Aimed bolt", 20, 55);
            
            var magicSkill01 = new Skill("Fire", 15, 45);
            var magicSkill02 = new Skill("Ice", 20, 60);
            var magicSkill03 = new Skill("Wind", 25, 80);
            
            // Set Skills
            char1.SetSkill(new [] {swordSkill01, swordSkill02, swordSkill03});
            char2.SetSkill(new []{archerSkill01, archerSkill02, archerSkill03});
            char3.SetSkill(new []{magicSkill01, magicSkill02, magicSkill03});
            
            // Create Item
            var hpPotion = new Item("Health Potion", true, 40, 0,0,0,0,false,0);
            var manaPotion = new Item("Mana Potion", true, 0, 25,0,0,0,false,0);
            
            // Create Wepaon
            var weapon01 = new Item("Sword", false, 0, 0, 20,0, 1,true,0);
            
            var weapon02 = new Item("Bow",false, 0, 0, 20,0, 2,true,0);
            
            var weapon03 = new Item("Rod",false, 0, 0, 15,0, 3,true,0);
            
            // Crate Enemy
            var enemy01 = new Enemy("Goblin Axe", 100, 0, 10, 10, "Demi-Human");
            
            // Call Function //
            IntroGame(); 
            
            // Player select start character //
            while (!characterSelected)
            {
                Console.WriteLine();
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
            Console.WriteLine("Please Enter Your Name: ");
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
            
            // Main Parts //
            while (playerSafe && player.PlayerCurrentSpot != destination)
            {
                PlayerOption(player,enemy01);
            }

            if (player.PlayerCurrentSpot == destination) // To Final Bosss
            {
                Console.Clear();
                Console.WriteLine("The Final Boss is Coming !");
                FinalBoss(player);
            }
            
            // Methods //
            static void IntroGame() // To Start Storyline and Explain the GamePlay
            {
                Console.Clear();
                Console.WriteLine("===================================================================================");
                Console.WriteLine("===================================================================================");
                Console.WriteLine("=====             Welcome to an Adventure Console Text based Game             =====");
                Console.WriteLine("=================                 Presented by                    =================");
                Console.WriteLine(@"===    _______    ______   _______    ______    ______   _______   __    __    ===");
                Console.WriteLine(@"===   |       \  /      \ |       \  /      \  /      \ |       \ |  \  |  \   ===");
                Console.WriteLine(@"===   | $$$$$$$\|  $$$$$$\| $$$$$$$\|  $$$$$$\|  $$$$$$\| $$$$$$$\| $$\ | $$   ===");
                Console.WriteLine(@"===   | $$__/ $$| $$  | $$| $$__/ $$| $$   \$$| $$  | $$| $$__| $$| $$$\| $$   ===");
                Console.WriteLine(@"===   | $$    $$| $$  | $$| $$    $$| $$      | $$  | $$| $$    $$| $$$$\ $$   ===");
                Console.WriteLine(@"===   | $$$$$$$ | $$  | $$| $$$$$$$ | $$   __ | $$  | $$| $$$$$$$\| $$\$$ $$   ===");
                Console.WriteLine(@"===   | $$      | $$__/ $$| $$      | $$__/  \| $$__/ $$| $$  | $$| $$ \$$$$   ===");
                Console.WriteLine(@"===   | $$       \$$    $$| $$       \$$    $$ \$$    $$| $$  | $$| $$  \$$$   ===");
                Console.WriteLine(@"===   \$$        \$$$$$$  \$$        \$$$$$$   \$$$$$$  \$$   \$$ \$$   \$$.   ===");
                Console.WriteLine("===================================================================================");
                Console.WriteLine("===================================================================================");
                Console.WriteLine();
                Console.WriteLine("===== Welcome Adventure, You're awake alone in the middle of Forrest Village. =====");
                Console.WriteLine("=====      While you sleep there is an attack of this village by goblin.      =====");
                Console.WriteLine("=====     The Leader of this village has been captured to the Goblin Camp.    =====");
                Console.WriteLine("=====            People are begging you to help the Leader.                   =====");
                Console.WriteLine("=====                     Now it's time to begin!                             =====");
                Console.WriteLine("Press any key to start...");
                Console.ReadKey();
                Console.Clear();
            }

            static void FinalBoss(Character player) // FinalBossArrive
            {
                var finalBoss = new Boss("Goblin Lord", 500, 150, 100, 60, "Boss");
                Console.WriteLine($"{finalBoss.Name} Well done Adventure! You come along here \n Now it's time to Die!!");

                while (player.Hp > 0 && finalBoss.Hp > 0)
                {
                    Console.WriteLine($"=== PLAYER STATUS === \n== Hp: {player.Hp} == MP: {player.Mana} ==");
                    Console.WriteLine($"=== {finalBoss.Name} STATUS === \n== Hp: {finalBoss.Hp} ==");
                    Console.WriteLine("==== Chose your action ====\n 1.Normal attack \n 2.Use skill \n 3.Use item \n 4.Wait for Action ");
                    var playerAction = Console.ReadLine();

                    if (playerAction == "1") // Normal Attack
                    {
                        player.PhysicalAttack(finalBoss);
                        finalBoss.Attack(player);
                    }
                    else if (playerAction == "2") // Use Skill
                    {
                        player.SkillAttack(finalBoss);
                        finalBoss.Attack(player);
                    }
                    else if (playerAction == "3") // Use Item
                    {
                        player.OpenInventory();
                        Console.WriteLine("Select your item 0-4");
                        var playerItemSelectedInCombat = Convert.ToInt32(Console.ReadLine());
                        var itemSelectInCombat = player.Inventory[playerItemSelectedInCombat];
                        player.UseItem(itemSelectInCombat);
                    }
                    else if (playerAction == "4") // Wait of Action
                    {
                        finalBoss.Attack(player);
                    }
                }

                if (finalBoss.IsDead)
                {
                    EndGame();
                }
            }

            static void PlayerOption(Character player, Enemy enemy01)
            {
                Console.WriteLine();
                Console.WriteLine($"=== Current Player Status === \n== HP: {player.Hp} MP: {player.Mana} ==\n== PlayerSpot: {player.PlayerCurrentSpot}/25 ==");
                Console.WriteLine("Please Select your action ! \n 1. Walk \n 2. Open Inventory \n 3. Open Status \n 4. Open Menu");
                var playerOption = Console.ReadLine();
                if (playerOption == "1") // Walk 1 Unit
                {
                    player.PlayerCurrentSpot++;
                    var random = new Random();
                    var randomEvent = random.Next(3);
                    if (randomEvent == 0) //Found Enemy
                    {
                        playerSafe = false;
                        var currentEnemy = enemy01.RandomEnemy(player);
                        Console.WriteLine($"{currentEnemy.Name} has spawn");

                        while (player.Hp > 0 && currentEnemy.Hp > 0)
                        {
                            Console.WriteLine();
                            Console.WriteLine($"=== PLAYER STATUS === \n== Hp: {player.Hp} == MP: {player.Mana} ==");
                            Console.WriteLine($"=== {currentEnemy.Name} STATUS === \n=== Hp: {currentEnemy.Hp} ===");
                            Console.WriteLine("==== Chose your action ====\n 1.Normal attack \n 2.Use skill \n 3.Use item \n 4.Wait for Action \n 5.Try Escape");
                            var playerAction = Console.ReadLine();
                            
                            if (playerAction == "1") // Normal Attack
                            {
                                player.PhysicalAttack(currentEnemy);
                                currentEnemy.Attack(player);
                            }
                            else if (playerAction == "2") // Use Skill
                            {
                                player.SkillAttack(currentEnemy);
                                currentEnemy.Attack(player);
                            }
                            else if (playerAction == "3") // Use Item
                            {
                                player.OpenInventory();
                                Console.WriteLine("Select your item 0-4");
                                var playerItemSelectedInCombat = Convert.ToInt32(Console.ReadLine());
                                var itemSelectInCombat = player.Inventory[playerItemSelectedInCombat];
                                player.UseItem(itemSelectInCombat);
                            }
                            else if (playerAction == "4") // Wait of Action
                            {
                                currentEnemy.Attack(player);
                            }else if (playerAction == "5") // Try Escape
                            {
                                var escapeChance = random.Next(2);
                                if (escapeChance == 1)
                                {
                                    Console.WriteLine("Escape Success!");
                                    PlayerOption(player, enemy01);
                                }
                                else
                                {
                                    Console.WriteLine("Escape Failed!");
                                }
                            }
                        }

                        if (currentEnemy.IsDead)
                        {
                            if (currentEnemy.Dropitem)
                            {
                                player.AddItem(currentEnemy.ItemDrop);
                                Console.WriteLine($"{currentEnemy.Name} Drop item {currentEnemy.ItemDrop.Name} 1ea.!");
                            }
                            else
                            {
                                Console.WriteLine($"{currentEnemy.Name} doesn't drop anything");
                            }
                            PlayerOption(player,enemy01);
                        }
                    }
                    else if (randomEvent == 1) //Found Item
                    {
                        // Random item Drop !!
                        player.RandomItemFound();
                        PlayerOption(player, enemy01);
                    }
                    else if (randomEvent == 2) //Safely arrive
                    {
                        Console.WriteLine("You found nothing!, You are safe!");
                        PlayerOption(player,enemy01);
                    }
                    
                }else if (playerOption == "2") // Open Inventory //
                {
                    player.OpenInventory();
                    
                    Console.WriteLine("=== Select your item (Type: 0 - 4) ===");
                    var playerItemSelected = Convert.ToInt32(Console.ReadLine());
                    var itemSelect = player.Inventory[playerItemSelected];

                    Console.WriteLine("=== Select your action ===\n 1.Use item \n 2.Equip item \n 3.Drop item \n 4.Go Back");
                    var playerInventoryAction = Convert.ToInt32(Console.ReadLine());
                    
                    if (playerInventoryAction == 1)// Use item
                    {
                        if (itemSelect.useable)
                        {
                            player.UseItem(itemSelect);
                        }
                        else
                        {
                            Console.WriteLine("This item can't be use!!");
                        }
                        PlayerOption(player,enemy01);
                    }
                    else if (playerInventoryAction == 2) // Equip item
                    {
                        if (itemSelect.Equipable && player.WeaponType == itemSelect.WeaponType) // Check Weapon
                        {
                            player.EquipWeapon(itemSelect);
                            Console.WriteLine($"You have equip {itemSelect.Name}");
                        }
                        else if (itemSelect.Equipable && itemSelect.ArmorType == 1) // Check Head
                        {
                            player.EquipHead(itemSelect);
                            Console.WriteLine($"You have equip {itemSelect.Name}");
                        }
                        else if (itemSelect.Equipable && itemSelect.ArmorType == 2) // Check Armor
                        {
                            player.EquipArmor(itemSelect);
                            Console.WriteLine($"You have equip {itemSelect.Name}");
                        }
                        else if (itemSelect.Equipable && itemSelect.ArmorType == 3) // Check Accessory
                        {
                            player.EquipAccessory(itemSelect);
                            Console.WriteLine($"You have equip {itemSelect.Name}");
                        }
                        else
                        {
                            Console.WriteLine("You cannot equip this item!!");
                        }
                        PlayerOption(player,enemy01);
                    }
                    else if (playerInventoryAction == 3) // Drop item
                    {
                        player.Inventory.Remove(itemSelect);
                        Console.WriteLine($"{itemSelect.Name} has remove.");
                        PlayerOption(player,enemy01);
                    }
                    else if (playerInventoryAction == 4) // Go back
                    {
                        PlayerOption(player,enemy01);
                    }
                    else
                    {
                        Console.WriteLine("Something went wrong! Please try again...");
                    }
                }
                else if (playerOption == "3") // Check Status
                {
                    Console.WriteLine($"=== Name: {player.Name} ===");
                    Console.WriteLine($"=== HP: {player.Hp} MP: {player.Mana} ===");
                    Console.WriteLine($"=== Base Atk: {player.BaseAtk} Base Def: {player.BaseDef} ===");
                    Console.WriteLine($"=== Current Weapon: {player.Weapon.Name} ===");
                    Console.WriteLine($"=== Head: {player.Head.Name} ===");
                    Console.WriteLine($"=== Armor: {player.Armor.Name} ===");
                    Console.WriteLine($"=== Accessory: {player.Accessory.Name} ===");
                    Console.WriteLine("Press any key to go back...");
                    Console.ReadKey();
                    PlayerOption(player,enemy01);
                }
                else if (playerOption == "4") // Open Menu //
                {
                    Console.WriteLine("===== Menu ===== \n 1: Resume (Warring: This will clear the Console) \n 2: Quit");
                    var openMenuOption = Console.ReadLine();
                    
                    if (openMenuOption == "1") // resume
                    {
                        Console.Clear();
                        PlayerOption(player,enemy01);
                    }
                    else if (openMenuOption == "2") // quit
                    {
                        Console.Clear();
                        Console.WriteLine("Game Over! \nPress Any key to Exit...");
                        Console.ReadKey();
                        Environment.Exit(0);
                    }
                }
            }

            static void EndGame()
            {
                Console.WriteLine("================ This Game is the Final Project of Subject GI161 ==================");
                Console.WriteLine("=====                              Created by                                 =====");
                Console.WriteLine("=====  ID: 1620700656 Name: Pongsakorn Soontorn        Section: 2521  No: 3   =====");
                Console.WriteLine("=====  ID: 1620705069 Name: Ponthakorn Pongsakorntorn  Section: 2521  No: 29  =====");
                Console.WriteLine("=====  ID: 1620705101 Name: Worawat    Kotchagreang    Section: 2521  No: 30  =====");
                Console.WriteLine("=====  ID: 1620705184 Name: Wachira    Pedhan          Section: 2521  No: 32  =====");
                Console.WriteLine("=====  ID: 1621100955 Name: Peerapat   Phongsiang      Section: 2522  No: 30  =====");
                Console.WriteLine("=====                 Presented to Dr. Wiyada Thitimajshima                   =====");
                Console.WriteLine("===================================================================================");
                Console.WriteLine();
                Console.WriteLine("=====                 The End's              =====");
                Console.WriteLine("===== You save the Leader of Forrest Village =====");
                Console.WriteLine("=====         Thanks you all for playing     =====");
                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
            }
        }
    }
}