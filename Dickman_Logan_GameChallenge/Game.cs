using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Dickman_Logan_GameChallenge
{
    class Game
    {
        int curSelection = -1;
        Character Attacker = null;
        Character Defender = null;
        Random rng = new Random();

        bool playerTurn = true;

        Player[] PlayerArray;

        Enemy[] RivalArray;

        bool ActionSelection = false;
        bool AttackTypeChosen = false;
        char AttackType;
        bool PlayerCustom = true;
        bool customName = true;
        bool customHealth = true;
        bool customStrength = true;
        bool customArmor = true;
        bool customWand = true;
        bool customTrinket = true;
        bool customAbility = true;
        int progressCount = 0;

        Enemy[] SampleArray;
        Enemy[] SampleArray2;
        Enemy[] BossArray;

        public void Init()
        {
            // fill the player party array with 3 Players filled out with use of the overloaded constructor
            PlayerArray = new Player[3];
            PlayerArray[0] = new Player("First", 10, 5, 10, 1, "none", "none");

            // fill the rival party array with 3 Enemies filled out with use of the overloaded constructor
            SampleArray = new Enemy[3];
            SampleArray[0] = new Enemy("Goblin", 10, 3, 0, 1, "none");
            SampleArray[1] = new Enemy("Skeleton", 8, 3, 2, 2, "none");
            SampleArray[2] = new Enemy("Wraith", 12, 3, 10, 1, "none");

            SampleArray2 = new Enemy[3];
            SampleArray2[0] = new Enemy("Orc", 12, 3, 8, 2, "none");
            SampleArray2[1] = new Enemy("LizardMan", 8, 3, 5, 3, "none");
            SampleArray2[2] = new Enemy("Necromancer", 8, 5, 10, 1, "none");

            BossArray = new Enemy[3];
            BossArray[0] = new Enemy("Infested Brood Queen", 30, 3, 10, 1, "Life Drain");
            BossArray[1] = new Enemy("Owl Bear", 25, 3, 10, 2, "Enrage");
            BossArray[2] = new Enemy("Flesh Golem", 100, 1, 50, 0, "Rot");

            RivalArray = new Enemy[3];
            RivalArray[0] = new Enemy("default", 1, 1, 10, 0, "none");

            GenerateEnemy();
        }

        public void GenerateEnemy()
        {
            for (int i = 0; i < 1; i++)
            {
                if (progressCount == 10)
                {
                    int arraychoice = rng.Next(BossArray.Length);
                    string namechoice = BossArray[arraychoice].Name();
                    float healthchoice = BossArray[arraychoice].GetHP();
                    float strengthchoice = BossArray[arraychoice].GetStrength();
                    float manachoice = BossArray[arraychoice].GetMana();
                    float defensechoice = BossArray[arraychoice].GetDefense();
                    string abilitychoie = BossArray[arraychoice].GetAbility();
                    RivalArray[i] = new Enemy(namechoice, healthchoice, strengthchoice, manachoice, defensechoice, abilitychoie);
                }
                else if (progressCount >= 5 && progressCount < 10)
                {
                    int arraychoice = rng.Next(SampleArray2.Length);
                    string namechoice = SampleArray2[arraychoice].Name();
                    float healthchoice = SampleArray2[arraychoice].GetHP();
                    float strengthchoice = SampleArray2[arraychoice].GetStrength();
                    float manachoice = SampleArray2[arraychoice].GetMana();
                    float defensechoice = SampleArray2[arraychoice].GetDefense();
                    string abilitychoie = SampleArray2[arraychoice].GetAbility();
                    RivalArray[i] = new Enemy(namechoice, healthchoice, strengthchoice, manachoice, defensechoice, abilitychoie);
                }
                else
                {
                    int arraychoice = rng.Next(SampleArray.Length);
                    string namechoice = SampleArray[arraychoice].Name();
                    float healthchoice = SampleArray[arraychoice].GetHP();
                    float strengthchoice = SampleArray[arraychoice].GetStrength();
                    float manachoice = SampleArray[arraychoice].GetMana();
                    float defensechoice = SampleArray[arraychoice].GetDefense();
                    string abilitychoie = SampleArray[arraychoice].GetAbility();
                    RivalArray[i] = new Enemy(namechoice, healthchoice, strengthchoice, manachoice, defensechoice, abilitychoie);
                }
            }
        }

        public bool Update()
        {
            // clears console for a fresh start
            Console.Clear();
            Console.WriteLine("Logan Dickman's Game Challenge V2\n" +
                "You are tasked with braving the dangers of the \"Ichor Valley\". A mountain range chock full of monsters and the ancient treasures of a long extinguished civilization.\n" +
                "You are seeking the very center of wealth itself... The treasury of the capital city of old. It is infested with monsters even more so than the trecharous highlands cradling the city.\n" +
                "This can only end two ways:\n\n" +
                "Success...\n" +
                "Or death.\n" +
                "Make your preparations wisely. The elements will afford you little rest between encounters.\n\n" +
                "Press any key to continue...\n");
            Console.ReadKey();
            while (PlayerCustom == true)
            {
                Console.Clear();
                Console.WriteLine("Please enter the data for your character:\nPress \"8\" to select stats, \"9\" to select equipment, and \"0\" to select special ability.\nPress \"x\" to start game when ready...\n\n" +
                    "If you wish to change your preparations simply press the designated key again and enter new values.");
                char optionKey = Console.ReadKey().KeyChar;
                switch (optionKey)
                {
                    case '8':
                        while (customName == true)
                        {
                            Console.WriteLine($"\nEnter Person's's Name:\n");
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.ForegroundColor = ConsoleColor.Gray;
                            string enteredname = Console.ReadLine().ToString();
                            if (enteredname.Length < 20)
                            {
                                PlayerArray[0].SetName(enteredname);
                                Console.WriteLine($"\n{PlayerArray[0].Name()}'s name is now \"{enteredname}\"\n");
                                customName = false;
                                Console.WriteLine("Press any key to continue");
                                Console.ReadKey();
                                break;
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                Console.WriteLine("\nToo many characters. The character limit is 20\nPlease choose another name\n");
                                Console.ForegroundColor = ConsoleColor.Gray;
                                enteredname = "";
                                Console.ReadKey();
                                Console.WriteLine("Press any key to continue");
                                continue;
                            }
                        }
                        while (customHealth == true)
                        {
                            Console.Clear();
                            Console.WriteLine($"Enter {PlayerArray[0].Name()}'s health:\n");
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.ForegroundColor = ConsoleColor.Gray;
                            string enteredhealth = Console.ReadLine();
                            bool successHealth = Int32.TryParse(enteredhealth, out int verifiedHealth);
                            if (successHealth == true)
                            {
                                if (verifiedHealth >= 8 && verifiedHealth <= 12)
                                {
                                    PlayerArray[0].SetHealth(verifiedHealth);
                                    Console.WriteLine($"\n{PlayerArray[0].Name()}'s health is now \"{verifiedHealth}\"\n");
                                    customHealth = false;
                                    Console.WriteLine("Press any key to continue");
                                    Console.ReadKey();
                                    break;
                                }
                                else
                                {
                                    Console.ForegroundColor = ConsoleColor.DarkRed;
                                    Console.WriteLine("\nInvalid health. A character's health must fall between 8 and 12.\nPlease try again\n");
                                    Console.ForegroundColor = ConsoleColor.Gray;
                                    enteredhealth = "rejected";
                                    Console.ReadKey();
                                    Console.WriteLine("Press any key to continue");
                                    continue;
                                }
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                Console.WriteLine("\nInvalid health. A character's health must fall between 8 and 12.\nPlease try again\n");
                                Console.ForegroundColor = ConsoleColor.Gray;
                                enteredhealth = "rejected";
                                Console.ReadKey();
                                Console.WriteLine("Press any key to continue");
                                continue;
                            }
                        }
                        while (customStrength == true)
                        {
                            Console.Clear();
                            Console.WriteLine($"Enter {PlayerArray[0].Name()}'s strength:\n" +
                                $"Your strength will determine your attack damage.\n");
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.ForegroundColor = ConsoleColor.Gray;
                            string enteredstrength = Console.ReadLine();
                            bool successStrength = Int32.TryParse(enteredstrength, out int verifiedStrength);
                            if (successStrength == true)
                            {
                                if (verifiedStrength >= 3 && verifiedStrength <= 5)
                                {
                                    PlayerArray[0].SetStrength(verifiedStrength);
                                    Console.WriteLine($"\n{PlayerArray[0].Name()}'s strength is now \"{verifiedStrength}\"\n");
                                    customStrength = false;
                                    Console.WriteLine("Press any key to continue");
                                    Console.ReadKey();
                                    break;
                                }
                                else
                                {
                                    Console.ForegroundColor = ConsoleColor.DarkRed;
                                    Console.WriteLine("\nInvalid strength. A character's strength must fall between 3 and 5.\nPlease try again\n");
                                    Console.ForegroundColor = ConsoleColor.Gray;
                                    enteredstrength = "rejected";
                                    Console.ReadKey();
                                    Console.WriteLine("Press any key to continue");
                                    continue;
                                }
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                Console.WriteLine("\nInvalid strength. A character's strength must fall between 3 and 5.\nPlease try again\n");
                                Console.ForegroundColor = ConsoleColor.Gray;
                                enteredstrength = "rejected";
                                Console.ReadKey();
                                Console.WriteLine("Press any key to continue");
                                continue;
                            }
                        }
                        customName = true;
                        customHealth = true;
                        customStrength = true;
                        Console.Clear();
                        Console.WriteLine($"Character's stats:\nName: {PlayerArray[0].Name()}\n" +
                            $"Health: {PlayerArray[0].GetHP()}\nStrength: {PlayerArray[0].GetStrength()}");
                        Console.WriteLine("\nPress any key to continue...");
                        Console.ReadKey();
                        break;
                    case '9':
                        while (customArmor == true)
                        {
                            Console.Clear();
                            Console.WriteLine("Please choose an armor set for your adventure.\nPress \"j\" to select the light set, which has no drawbacks, but provides the least defense." +
                                "\nPress \"k\" to select the medium set, which prevents you from choosing certain trinkets and abilites, but provides more defense." +
                                "\nPress \"l\" to select the heavy set, which is like the meduim, but also limits your wand set, but provides the most defense.");
                            char selectionKey = Console.ReadKey().KeyChar;
                            switch (selectionKey)
                            {
                                case 'j':
                                    PlayerArray[0].SetDefense(1);
                                    Console.WriteLine("\nYou have chosen the light set...");
                                    Console.WriteLine($"\nYour armor value has been set to {PlayerArray[0].GetDefense()}");
                                    Console.WriteLine("\nPress any key to continue...");
                                    Console.ReadKey();

                                    customArmor = false;
                                    break;
                                case 'k':
                                    PlayerArray[0].SetDefense(2);
                                    Console.WriteLine("\nYou have chosen the meduim set...");
                                    Console.WriteLine($"\nYour armor value has been set to {PlayerArray[0].GetDefense()}");
                                    Console.WriteLine("\nPress any key to continue...");
                                    Console.ReadKey();

                                    customArmor = false;
                                    break;
                                case 'l':
                                    PlayerArray[0].SetDefense(3);
                                    Console.WriteLine("\nYou have chosen the heavy set...");
                                    Console.WriteLine($"\nYour armor value has been set to {PlayerArray[0].GetDefense()}");
                                    Console.WriteLine("\nPress any key to continue...");
                                    Console.ReadKey();

                                    customArmor = false;
                                    break;
                            }

                            
                        }
                        while (customWand == true)
                        {
                            Console.Clear();
                            Console.WriteLine("Please choose a wand for your adventure.\nPress \"j\" to select the novice set, which has no drawbacks, but is the weakest." +
                                "\nPress \"k\" to select the professional set, which prevents you from choosing certain trinkets and abilites, but is more powerful." +
                                "\nPress \"l\" to select the archmage set, which is like the professional, but provides the most power.");
                            char selectionKey = Console.ReadKey().KeyChar;
                            switch (selectionKey)
                            {
                                case 'j':
                                    PlayerArray[0].SetMana(5);
                                    Console.WriteLine("\nYou have chosen the novice set...");
                                    Console.WriteLine($"\nYour mana value has been set to {PlayerArray[0].GetMana()}");
                                    Console.WriteLine("\nPress any key to continue...");
                                    Console.ReadKey();

                                    customWand = false;
                                    break;
                                case 'k':
                                    PlayerArray[0].SetMana(10);
                                    Console.WriteLine("\nYou have chosen the professional set...");
                                    Console.WriteLine($"\nYour mana value has been set to {PlayerArray[0].GetMana()}");
                                    Console.WriteLine("\nPress any key to continue...");
                                    Console.ReadKey();

                                    customWand = false;
                                    break;
                                case 'l':
                                    if (PlayerArray[0].GetDefense() < 3)
                                    {
                                        PlayerArray[0].SetMana(25);
                                        Console.WriteLine("\nYou have chosen the archmage set...");
                                        Console.WriteLine($"\nYour mana value has been set to {PlayerArray[0].GetMana()}");
                                        Console.WriteLine("\nPress any key to continue...");
                                        Console.ReadKey();

                                        customWand = false;
                                        break;
                                    }
                                    else
                                    {
                                        Console.Clear();
                                        Console.WriteLine("The heavy armor set prevents this choice\nPlease choose another set");
                                        Console.WriteLine("\nPress any key to continue...");
                                        Console.ReadKey();
                                        continue;
                                    }
                            }


                        }
                        while (customTrinket == true)
                        {
                            Console.Clear();
                            Console.WriteLine("Please choose a trinket for your adventure. Some trinkets can only be used once, while others provide a passive bonus.\n" +
                                "\nPress \"u\" to select the Hunter's Horn, which calls nearby wildife to chase away your current foe." + //Marked
                                "\nPress \"i\" to select the Jade Amulet, which gives you 10 mana instantly." +
                                "\nPress \"o\" to select the Ogre Tooth, which raises your strength by 2. (Passive)" + //Marked
                                "\nPress \"j\" to select the Vampire's Cloak, which allows you to gain 3 health on a lethal blow to an enemy. (Passive)" +
                                "\nPress \"k\" to select the Sap of Vigour, which heals you by 12 on a lethal attack. (Sort of passive)" +
                                "\nPress \"l\" to select the Bloody Wraps, which sets your defense to zero, but each defense point lost gives 6 extra health. (Compatable with medium armor)"); //Marked
                            char selectionKey = Console.ReadKey().KeyChar;
                            switch (selectionKey)
                            {
                                case 'u':
                                    if (PlayerArray[0].GetDefense() < 2 && PlayerArray[0].GetMana() < 10)
                                    {
                                        PlayerArray[0].SetTrinket("Hunter's Horn");
                                        Console.WriteLine("\nYou have chosen the Hunter's Horn...");
                                        Console.WriteLine("\nPress any key to continue...");
                                        Console.ReadKey();

                                        customTrinket = false;
                                        break;
                                    }
                                    else
                                    {
                                        Console.Clear();
                                        Console.WriteLine("One of your chosen equipment prevents this choice\nPlease choose another set");
                                        Console.WriteLine("\nPress any key to continue...");
                                        Console.ReadKey();
                                        continue;
                                    }

                                case 'i':
                                    PlayerArray[0].SetTrinket("Jade Amulet");
                                    Console.WriteLine("\nYou have chosen the Jade Amulet...");
                                    Console.WriteLine("\nPress any key to continue...");
                                    Console.ReadKey();

                                    customTrinket = false;
                                    break;

                                case 'o':
                                    if (PlayerArray[0].GetDefense() < 2 && PlayerArray[0].GetMana() < 10)
                                    {
                                        PlayerArray[0].SetTrinket("Ogre Tooth");
                                        Console.WriteLine("\nYou have chosen the Ogre Tooth...");

                                        PlayerArray[0].FortifyStrength(2);
                                        Console.WriteLine($"\nYour strength has been set to {PlayerArray[0].GetStrength()}");

                                        Console.WriteLine("\nPress any key to continue...");
                                        Console.ReadKey();

                                        customTrinket = false;
                                        break;
                                    }
                                    else
                                    {
                                        Console.Clear();
                                        Console.WriteLine("One of your chosen equipment prevents this choice\nPlease choose another set");
                                        Console.WriteLine("\nPress any key to continue...");
                                        Console.ReadKey();
                                        continue;
                                    }

                                case 'p':
                                    if (PlayerArray[0].GetDefense() < 2 && PlayerArray[0].GetMana() < 10)
                                    {
                                        PlayerArray[0].SetTrinket("Tiger's Paw");
                                        Console.WriteLine("\nYou have chosen the Tiger's Paw...");
                                        Console.WriteLine("\nPress any key to continue...");
                                        Console.ReadKey();

                                        customTrinket = false;
                                        break;
                                    }
                                    else
                                    {
                                        Console.Clear();
                                        Console.WriteLine("One of your chosen equipment prevents this choice\nPlease choose another set");
                                        Console.WriteLine("\nPress any key to continue...");
                                        Console.ReadKey();
                                        continue;
                                    }

                                case 'j':
                                    PlayerArray[0].SetTrinket("Vampire's Cloak");
                                    Console.WriteLine("\nYou have chosen the Vampire's Cloak...");
                                    Console.WriteLine("\nPress any key to continue...");
                                    Console.ReadKey();

                                    customTrinket = false;
                                    break;
                                case 'k':
                                    PlayerArray[0].SetTrinket("Sap of Vigour");
                                    Console.WriteLine("\nYou have chosen the Sap of Vigour...");
                                    Console.WriteLine("\nPress any key to continue...");
                                    Console.ReadKey();

                                    customTrinket = false;
                                    break;
                                case 'l':
                                    if (PlayerArray[0].GetDefense() < 3)
                                    {
                                        PlayerArray[0].SetTrinket("Bloody Wraps");
                                        Console.WriteLine("\nYou have chosen the Bloody Wraps...");
                                        Console.WriteLine("\nPress any key to continue...");
                                        Console.ReadKey();

                                        customTrinket = false;
                                        break;
                                    }
                                    else
                                    {
                                        Console.Clear();
                                        Console.WriteLine("One of your chosen equipment prevents this choice\nPlease choose another set");
                                        Console.WriteLine("\nPress any key to continue...");
                                        Console.ReadKey();
                                        continue;
                                    }
                            }


                        }
                        customArmor = true;
                        customWand = true;
                        customTrinket = true;
                        Console.Clear();
                        Console.WriteLine($"Character's stats:\nArmor: {PlayerArray[0].GetDefense()}\n" +
                            $"Magic: {PlayerArray[0].GetMana()}\nTrinket: {PlayerArray[0].GetTrinket()}");
                        Console.WriteLine("\nPress any key to continue...");
                        Console.ReadKey();
                        break;
                    case '0':
                        while (customAbility)
                        {
                            Console.Clear();
                            Console.WriteLine("Please choose an ability to use:\n" +
                                "Press 1 to chose Fire Breath, which deals 10 damage and uses 10 mana.\n" +
                                "Press 2 to chose Withering Smog, which sets enemy defense to 0 permanently for 10 mana.\n" +
                                "Press 3 to chose Restoration, which heals you fully for 10 mana.");
                            char selectionKey = Console.ReadKey().KeyChar;
                            switch (selectionKey)
                            {
                                case '1':
                                    PlayerArray[0].SetAbility("Fire Breath");
                                    Console.WriteLine("\nYou have chosen the Fire Breath...");
                                    Console.WriteLine("\nPress any key to continue...");
                                    Console.ReadKey();

                                    customAbility = false;
                                    break;
                                case '2':
                                    PlayerArray[0].SetAbility("Withering Smog");
                                    Console.WriteLine("\nYou have chosen the Withering Smog...");
                                    Console.WriteLine("\nPress any key to continue...");
                                    Console.ReadKey();

                                    customAbility = false;
                                    break;
                                case '3':
                                    PlayerArray[0].SetAbility("Restoration");
                                    Console.WriteLine("\nYou have chosen Restoration...");
                                    Console.WriteLine("\nPress any key to continue...");
                                    Console.ReadKey();

                                    customAbility = false;
                                    break;
                            }
                        }
                        customAbility = true;
                        Console.Clear();
                        Console.WriteLine($"You have chosen the {PlayerArray[0].GetAbility()} ability.");
                        Console.WriteLine("\nPress any key to continue...");
                        Console.ReadKey();
                        break;
                    case 'x':
                        PlayerCustom = false;
                        Console.Clear();
                        break;
                    case 'f':
                        PlayerArray[0].SetHealth(100);
                        PlayerArray[0].SetStrength(100);
                        PlayerArray[0].SetMana(100);
                        PlayerArray[0].SetDefense(5);
                        Console.Clear();
                        Console.WriteLine("You have paid your respects to the gods. They have blessed you accordingly.");
                        Console.WriteLine("\nPress any key to continue...");
                        Console.ReadKey();
                        PlayerCustom = false;
                        Console.Clear();
                        break;
                }
            }
            //branch who's turn it is and add a line indicating so
            if (playerTurn == true)
            {
                //print that it's the player's turn
                Console.WriteLine("Player turn starts now.");
                //print the current parties
                PrintParties();
                //run the player turn
                PlayerTurn();
            }
            else
            {
                //print the rivals turn label
                Console.WriteLine("Rival turn starts now.");
                //print the current parties
                PrintParties();
                //run the rivals turn
                RivalsTurn();
            }

            //end game check
            return EndTurn();
        }

        void PlayerTurn()
        {
            Console.WriteLine("\nYour turn. What will you do?...\n");
                Attacker = PlayerArray[0];
            Console.WriteLine("Press \"a\" to attack, \"h\" to use 3 mana to heal yourself, \"t\" to consume your trinket, or \"m\" to use your special ability...\n");
            while (AttackTypeChosen == false)
            {
                ConsoleKeyInfo k = Console.ReadKey();
                if (k.KeyChar == 'a')
                {
                    AttackType = 'a';
                    AttackTypeChosen = true;
                    break;
                }
                else if (k.KeyChar == 'h')
                {
                    if (Attacker.GetMana() < 3)
                    {
                        Console.WriteLine("\nNot enough mana. Please choose another acttion.\n");
                        continue;
                    }
                    else
                    {
                        AttackType = 'h';
                        AttackTypeChosen = true;
                        break;
                    }
                }
                else if (k.KeyChar == 'm')
                {
                    if (Attacker.GetMana() < 5)
                    {
                        Console.WriteLine("\nNot enough mana. Please choose another acttion.\n");
                        continue;
                    }
                    else
                    {
                        AttackType = 'm';
                        AttackTypeChosen = true;
                        break;
                    }
                }
                else if (k.KeyChar == 't')
                {
                    if (PlayerArray[0].GetTrinket() != "none")
                    {
                        AttackType = 't';
                        AttackTypeChosen = true;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("\nNo trinket equipped. Please choose another action.\n");
                        continue;
                    }
                }
                else
                {
                    Console.Clear();
                    PrintParties();
                    Console.WriteLine("\nInvalid input\n");
                    Console.WriteLine("Press \"a\" to select attack, \"h\" to select heal, \"t\" to consume trinket, or \"m\" to select magic attack...\n");
                    continue;
                }
            }
            while (ActionSelection == false)
            {
                if (AttackType == 'a')
                {
                    Defender = RivalArray[0];

                    Defender.ApplyDamage(Attacker.GetStrength());

                    Console.BackgroundColor = RivalArray[0].GetTeamColor();
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.WriteLine($"\n{Defender.Name()}'s health is now {Defender.GetHP()}\n");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.Black;
                    Thread.Sleep(2000);

                    //reset attacker/defender for next attack
                    Attacker = null;
                    Defender = null;
                    break;
                }
                else if (AttackType == 'h')
                {
                    Defender = Attacker;

                    Defender.HealApplyDamage(-3);
                    while (PlayerArray[0].GetHP() > PlayerArray[0].HPmax())
                    {
                        PlayerArray[0].HealApplyDamage(1);
                    }

                    Console.BackgroundColor = PlayerArray[0].GetTeamColor();
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.WriteLine($"\n{Defender.Name()}'s health is now {Defender.GetHP()}\n");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.Black;

                    Attacker.LoseMana(3);
                    Console.WriteLine($"{Attacker.Name()}'s mana is now {Attacker.GetMana()}\n");

                    Thread.Sleep(4000);

                    Attacker = null;
                    Defender = null;
                    break;
                }
                else if(AttackType == 't')
                {
                    if (Attacker.GetTrinket() == "Hunter's Horn")
                    {
                        Defender = RivalArray[0];
                        Defender.ApplyDamage(1000);
                        progressCount--;
                        Console.WriteLine($"\nThe enemy flees!\nYour {PlayerArray[0].GetTrinket()} crumbles...\n");
                        Attacker.SetTrinket("none");
                    }
                    else if (Attacker.GetTrinket() == "Jade Amulet")
                    {
                        Attacker.LoseMana(-10);
                        Console.WriteLine($"\nYou feel a surge of power!\nYour {PlayerArray[0].GetTrinket()} crumbles...\n");
                        Attacker.SetTrinket("none");
                    }
                    else if (Attacker.GetTrinket() == "Bloody Wraps")
                    {
                        if(Attacker.GetDefense() == 1)
                        {
                            PlayerArray[0].FortifyHealth(6);
                            PlayerArray[0].SetDefense(0);
                        }
                        else if (Attacker.GetDefense() == 2)
                        {
                            PlayerArray[0].FortifyHealth(12);
                            PlayerArray[0].SetDefense(0);
                        }
                        else
                        {
                            Console.WriteLine("Error! Hax detected. Armor value of 0 or 3+.");
                        }
                        Console.WriteLine($"You feel your armor fade away and you heart beat stronger.\nYour {PlayerArray[0].GetTrinket()} crumbles...\n");
                        Attacker.SetTrinket("none");
                    }
                    else
                    {
                        Console.WriteLine("Error! No trinket specified\n");
                        continue;
                    }


                    Thread.Sleep(2000);

                    Attacker = null;
                    Defender = null;
                    break;
                }
                else if (AttackType == 'm')
                {
                    if(Attacker.GetAbility() == "Fire Breath")
                    {
                        Defender = RivalArray[0];
                        Defender.ApplyDamage(10);
                        Console.WriteLine($"{Defender.Name()}'s health is now {Defender.GetHP()}\n");
                    }
                    else if(Attacker.GetAbility() == "Withering Smog")
                    {
                        Defender = RivalArray[0];
                        Defender.SetDefense(0);
                        Console.WriteLine($"{Defender.Name()}'s defense is now {Defender.GetDefense()}\n");
                    }
                    else if (Attacker.GetAbility() == "Restoration")
                    {
                        Defender = PlayerArray[0];
                        Defender.HealApplyDamage(-25);
                        while (RivalArray[0].GetHP() > RivalArray[0].HPmax())
                        {
                            Defender.HealApplyDamage(1);
                        }
                        Console.WriteLine($"{Defender.Name()}'s health is now {Defender.GetHP()}\n");
                    }
                    else
                    {
                        Console.WriteLine("\nError! No ability specified");
                        continue;
                    }

                        Attacker.LoseMana(5);
                        Console.WriteLine($"{Attacker.Name()}'s mana is now {Attacker.GetMana()}\n");

                        Thread.Sleep(5000);

                        Attacker = null;
                        Defender = null;
                        break;
                    
                }
            }

            AttackTypeChosen = false;
            ActionSelection = false;
            AttackType = 'q';
        }

        void RivalsTurn()
        {
            Console.WriteLine("\nRival is choosing an attack: ");
            Thread.Sleep(2000);

            Attacker = RivalArray[0];

            while (AttackTypeChosen == false)
            {
                curSelection = rng.Next(3);
                if (curSelection == 1)
                {
                    Console.WriteLine($"{Attacker.Name()} will attack...\n");
                    Thread.Sleep(2000);

                    Defender = PlayerArray[0];

                    Defender.ApplyDamage(Attacker.GetStrength());

                    Console.BackgroundColor = PlayerArray[0].GetTeamColor();
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.WriteLine($"{Defender.Name()}'s health is now {Defender.GetHP()}\n");
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.Black;
                    Thread.Sleep(2000);

                    Attacker = null;
                    Defender = null;
                    AttackTypeChosen = true;
                    break;
                }
                else if (curSelection == 2)
                {
                    if (Attacker.GetMana() < 3)
                    {
                        continue;
                    }
                    else if(Attacker.GetHP() == Attacker.HPmax())
                    {
                        continue;
                    }
                    else
                    {
                        Console.WriteLine($"{Attacker.Name()} will heal...\n");
                        Thread.Sleep(2000);

                        Attacker.HealApplyDamage(-3);
                        while(RivalArray[0].GetHP() > RivalArray[0].HPmax())
                        {
                            RivalArray[0].HealApplyDamage(1);
                        }

                        Console.BackgroundColor = RivalArray[0].GetTeamColor();
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.WriteLine($"{Attacker.Name()}'s health is now {Attacker.GetHP()}\n");
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.BackgroundColor = ConsoleColor.Black;

                        Attacker.LoseMana(3);
                        Console.WriteLine($"{Attacker.Name()}'s mana is now {Attacker.GetMana()}\n");

                        Thread.Sleep(2000);

                        Attacker = null;
                        Defender = null;
                        AttackTypeChosen = true;
                        break;
                    }
                }
                else
                {
                    if (Attacker.GetMana() < 10)
                    {
                        continue;
                    }
                    else if (Attacker.GetAbility() == "none")
                    {
                        continue;
                    }
                    else
                    {
                        if (Attacker.GetAbility() == "Life Drain")
                        {
                            Attacker.ApplyDamage(-3);
                            while (RivalArray[0].GetHP() > RivalArray[0].HPmax())
                            {
                                Attacker.ApplyDamage(1);
                            }
                            Attacker.LoseMana(-10);
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine($"{Attacker.Name()}'s health is now {Attacker.GetHP()}\n");
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        else if (Attacker.GetAbility() == "Enrage")
                        {
                            Attacker.SetStrength(6);
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine($"{Attacker.Name()}'s strength is now {Attacker.GetStrength()}\n");
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        else if (Attacker.GetAbility() == "Rot")
                        {
                            Attacker.FortifyStrength(1);
                            Attacker.ApplyDamage(10);
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine($"{Attacker.Name()}'s strength is now {Attacker.GetStrength()}\n");
                            Console.WriteLine($"{Attacker.Name()}'s health is now {Attacker.GetHP()}\n");
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        else
                        {
                            Console.WriteLine("Error! No ability specified!\n");
                        }

                        Attacker.LoseMana(10);
                        Console.WriteLine($"{Attacker.Name()}'s mana is now {Attacker.GetMana()}\n");

                        Thread.Sleep(5000);

                        Attacker = null;
                        Defender = null;
                        AttackTypeChosen = true;
                        break;
                    }
                }
            }

            AttackTypeChosen = false;
        }

        void PrintParties()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Player's Current Party:");
            PlayerArray[0].PrintStats();
            Console.ForegroundColor = ConsoleColor.Black;

            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("\n\nRival's Current Party:");
            RivalArray[0].PrintEnemy();
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.BackgroundColor = ConsoleColor.Black;
        }

        bool EndTurn()
        {
            playerTurn = !playerTurn;

            bool playersAlive = true;
            bool rivalsAlive = true;
            if (PlayerArray[0].GetHP() > 0 )
            {
                playersAlive = true;
            }
            else
            {
                playersAlive = false;
            }
            if (RivalArray[0].GetHP() > 0)
            {
                rivalsAlive = true;
            }
            else
            {
                rivalsAlive = false;
            }

            if (playersAlive && rivalsAlive)
            {
                Console.WriteLine("Next Round Starts in 5 seconds");
                Thread.Sleep(5000);
                return true;
            }
            else if (playersAlive == true && rivalsAlive == false)
            {
                if(PlayerArray[0].GetTrinket() == "Vampire's Cloak")
                {
                    PlayerArray[0].HealApplyDamage(-3);
                    while (PlayerArray[0].GetHP() > PlayerArray[0].HPmax())
                    {
                        Defender.HealApplyDamage(1);
                    }
                }

                if (progressCount == 9)
                {
                    Console.Clear();
                    progressCount++;
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine($"You have done well to come so far, however you have one last challenge to face. Rest well and hope you have the nerves to sleep." +
                        $"\n\nThe howling cries have begun...");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    Console.Clear();
                    RestTime();
                    playerTurn = !playerTurn;
                    GenerateEnemy();
                    return true;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Congrats you win! Final Standings:");
                    PrintParties();

                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();


                    if (progressCount < 5)
                    {
                        Console.Clear();
                        progressCount++;
                        Console.WriteLine($"You have now defeated {progressCount} enemies. Your adventure continues...\nYou may now rest and replenish yourself.");
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                        Console.Clear();
                        RestTime();
                        playerTurn = !playerTurn;
                        GenerateEnemy();
                        return true;
                    }
                    else if (progressCount >= 5 && progressCount <= 8)
                    {
                        Console.Clear();
                        progressCount++;
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"You have now defeated {progressCount} enemies. Your adventure continues...\nYou will now face far stronger foes. Steel yourself.\nYou may now rest and replenish yourself.");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                        Console.Clear();
                        RestTime();
                        playerTurn = !playerTurn;
                        GenerateEnemy();
                        return true;
                    }
                    else
                    {
                        Console.WriteLine("Congratulations! You have defeated the boss and claimed the treasure! Your adventure is over.");
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                        return false;
                    }
                }
            }
            else
            {
                if (PlayerArray[0].GetTrinket() == "Sap of Vigour")
                {
                    PlayerArray[0].HealApplyDamage(-12);
                    Console.Clear();
                    Console.WriteLine("Your Sap of Vigour has saved you for now.");
                    PlayerArray[0].SetTrinket("none");
                    playersAlive = true;
                    Console.WriteLine("Your Sap of Vigour crumbles...\n");
                    PrintParties();

                    Console.WriteLine("Next Round Starts in 5 seconds\n");
                    Thread.Sleep(5000);
                    return true;
                }
                else
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Your adventure has come to a grim end.\n\nPerhaps another may succeed where you have failed...");
                    Console.ForegroundColor = ConsoleColor.White;
                    return false;
                }
            }
        }

        void RestTime()
        {
            int restHours;
            bool resting = true;

            if (progressCount == 10)
            {
                restHours = 24;
            }
            else if(progressCount >= 5)
            {
                restHours = rng.Next(4, 6);
            }
            else
            {
                restHours = rng.Next(2, 4);
            }

            Console.Clear();
            Console.WriteLine("You have a few hours to rest.\n");
            while (resting == true)
            {
                if (restHours > 0)
                {
                    PlayerArray[0].PrintStats();
                    Console.WriteLine($"\n\nYou still have {restHours} hours left. How will you spend this time?\n" +
                    "Press 4 to adress your wounds...\n" +
                    "Press 5 to sleep and recover some of your mana...\n" +
                    "Press 6 to fortify your health, increasing it by 1 permanently...\n" +
                    "Press 7 to fortify your mana, increasing it by 2 permanently...\n" +
                    "Press x to forfiet your remaining hours...\n");
                    char optionKey = Console.ReadKey().KeyChar;
                    switch (optionKey)
                    {
                        case '4':
                            if (restHours > 0)
                            {
                                Console.Clear();

                                PlayerArray[0].HealApplyDamage(rng.Next(-2, -1));
                                while (PlayerArray[0].GetHP() > PlayerArray[0].HPmax())
                                {
                                    PlayerArray[0].HealApplyDamage(1);
                                }
                                Console.WriteLine($"Your health is now {PlayerArray[0].GetHP()}");
                                restHours--;

                                Console.WriteLine("\nPress any key to continue...");
                                Console.ReadKey();
                                break;
                            }
                            else
                            {
                                Console.Clear();

                                Console.WriteLine("There isn't enough time left to do anything.");

                                Console.WriteLine("\nPress any key to continue...");
                                Console.ReadKey();
                                break;
                            }
                        case '5':
                            if (restHours > 0)
                            {
                                Console.Clear();

                                PlayerArray[0].LoseMana(rng.Next(-2, -1));
                                Console.WriteLine($"Your mana is now {PlayerArray[0].GetMana()}");
                                restHours--;

                                Console.WriteLine("\nPress any key to continue...");
                                Console.ReadKey();
                                break;
                            }
                            else
                            {
                                Console.Clear();

                                Console.WriteLine("There isn't enough time left to do anything.");

                                Console.WriteLine("\nPress any key to continue...");
                                Console.ReadKey();
                                break;
                            }
                        case '6':
                            if (restHours > 0)
                            {
                                Console.Clear();

                                PlayerArray[0].FortifyHealth(1);
                                Console.WriteLine($"Your health is now {PlayerArray[0].GetHP()}");
                                restHours--;

                                Console.WriteLine("\nPress any key to continue...");
                                Console.ReadKey();
                                break;
                            }
                            else
                            {
                                Console.Clear();

                                Console.WriteLine("There isn't enough time left to do anything.");

                                Console.WriteLine("\nPress any key to continue...");
                                Console.ReadKey();
                                break;
                            }
                        case '7':
                            if (restHours > 0)
                            {
                                Console.Clear();

                                PlayerArray[0].FortifyMana(2);
                                Console.WriteLine($"Your mana is now {PlayerArray[0].GetMana()}");
                                restHours--;

                                Console.WriteLine("\nPress any key to continue...");
                                Console.ReadKey();
                                break;
                            }
                            else
                            {
                                Console.Clear();

                                Console.WriteLine("There isn't enough time left to do anything.");

                                Console.WriteLine("\nPress any key to continue...");
                                Console.ReadKey();
                                break;
                            }
                        case 'x':
                            resting = false;
                            break;
                    }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("It seems there's no time left. You'll have to press on now.");

                    Console.WriteLine("\nPress any key to continue...");
                    Console.ReadKey();
                    resting = false;
                    break;
                }
            }
            resting = true;
        }
    }
}
