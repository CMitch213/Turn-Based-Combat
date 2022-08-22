using System;

namespace TurnBaseCombat
{
    class Program
    {
        static void Main(string[] args)
        {
            int playerHP = 50;
            int cpuHP = 45;

            int playerAttack;
            int cpuAttack;

            int persuade;
            int persuadeOpt;

            int heal;
            int magicChoice;
            int thwackHit;

            int cpuChoice;
            int crit;

            int atkMult = 0;
            int healMult = 0;
            int defMult = 0;

            bool stuns = false;
            bool atkUP = false;
            bool hlUP = false;
            bool defUP = false;
            bool burn = false;

            int cpuatkMult = 0;
            int cpuhealMult = 0;
            int cpudefMult = 0;

            bool cpustuns = false;
            bool cpuatkUP = false;
            bool cpuhlUP = false;
            bool cpudefUP = false;
            bool cpuburn = false;

            Random randomAtk = new Random();
            Random cpuMove = new Random();
            Random critChance = new Random();
            Random healAmount = new Random();
            Random magic = new Random();
            Random thwack = new Random();
            Random random = new Random();

            Console.WriteLine("-- Player HP: " + playerHP + "  CPU HP: " + cpuHP + " --");
            while (playerHP > 0 && cpuHP > 0)
            {
                stuns = false;
                //Player's Turn
                Console.WriteLine("~~ Player's Turn ~~");
                Console.WriteLine("Enter 'Q' to ATTACK the enemy, 'E' to HEAL, 'R' for MAGIC, or 'F' for Items");
                string choice = Console.ReadLine();

                if (choice == "q" && cpustuns == false)
                {
                    crit = critChance.Next(1, 6);
                    Console.WriteLine("");
                    if(atkUP == true)
                    {
                        playerAttack = randomAtk.Next(5, 11);
                        playerAttack += 3 * atkMult;
                        cpuHP -= playerAttack;
                        System.Threading.Thread.Sleep(300);
                        Console.WriteLine("*Player Attacks The CPU! Your Move Did " + playerAttack + " Damage!");
                        System.Threading.Thread.Sleep(300);
                        Console.WriteLine("-- Player HP: " + playerHP + "CPU HP: " + cpuHP + " --");
                    }
                    if(crit < 5)
                    {
                        playerAttack = randomAtk.Next(5, 11);
                        cpuHP -= playerAttack;
                        System.Threading.Thread.Sleep(300);
                        Console.WriteLine("*Player Attacks The CPU! Your Move Did " + playerAttack + " Damage!");
                        System.Threading.Thread.Sleep(300);
                        Console.WriteLine("-- Player HP: " + playerHP + "CPU HP: " + cpuHP + " --");
                    }
                    else if(crit == 5)
                    {
                        playerAttack = randomAtk.Next(10, 20);
                        cpuHP -= playerAttack;
                        System.Threading.Thread.Sleep(300);
                        Console.WriteLine("");
                        Console.WriteLine("CRIT!");
                        System.Threading.Thread.Sleep(300);
                        Console.WriteLine("*Player Attacks The CPU! Your Move Did " + playerAttack + " Damage!");
                        System.Threading.Thread.Sleep(300);
                        Console.WriteLine("-- Player HP: " + playerHP + "CPU HP: " + cpuHP + " --");
                    }
                }
                else if(choice == "e" && cpustuns == false)
                {
                    if(hlUP == true)
                    {
                        heal = healAmount.Next(5, 11);
                        Console.WriteLine("");
                        heal += 5 * healMult;
                        playerHP += heal;
                        System.Threading.Thread.Sleep(300);
                        Console.WriteLine("~~Healing~~");
                        System.Threading.Thread.Sleep(300);
                        Console.WriteLine("*Player Healed For " + heal + " Health");
                        System.Threading.Thread.Sleep(600);
                        Console.WriteLine("-- Player HP: " + playerHP + "  CPU HP: " + cpuHP + " --");
                    }
                    heal = healAmount.Next(5, 11);
                    Console.WriteLine("");
                    playerHP += heal;
                    System.Threading.Thread.Sleep(300);
                    Console.WriteLine("~~Healing~~");
                    System.Threading.Thread.Sleep(300);
                    Console.WriteLine("*Player Healed For " + heal + " Health");
                    System.Threading.Thread.Sleep(600);
                    Console.WriteLine("-- Player HP: " + playerHP + "  CPU HP: " + cpuHP + " --");
                }
                else if (choice == "r" && cpustuns == false)
                {
                    magicChoice = magic.Next(1, 11);
                    if(magicChoice == 1 && cpustuns == false)
                    {
                        stuns = true;
                        System.Threading.Thread.Sleep(300);
                        Console.WriteLine("You Used: Neck-Down Paralysis");
                        System.Threading.Thread.Sleep(300);
                        Console.WriteLine("ENEMY IS STUNNED!");
                        System.Threading.Thread.Sleep(300);
                        Console.WriteLine("...");
                        System.Threading.Thread.Sleep(300);
                        Console.WriteLine("Enemy turned skipped");
                    }
                    else if(magicChoice == 2)
                    {
                        System.Threading.Thread.Sleep(300);
                        Console.WriteLine("Your attack does more because you used: Muscle Milk!");
                        System.Threading.Thread.Sleep(300);
                        atkUP = true;
                        atkMult += 1;
                    }
                    else if(magicChoice == 3)
                    {
                        System.Threading.Thread.Sleep(300);
                        Console.WriteLine("Your heal is better because you used: Turnip!");
                        System.Threading.Thread.Sleep(300);
                        hlUP = true;
                        healMult += 1;
                    }
                    else if(magicChoice == 4)
                    {
                        System.Threading.Thread.Sleep(300);
                        Console.WriteLine("You used: Creeper, It blew up the enemy");
                        System.Threading.Thread.Sleep(300);
                        playerAttack = randomAtk.Next(15, 20);
                        cpuHP -= playerAttack;
                        System.Threading.Thread.Sleep(300);
                        Console.WriteLine("*Player Blows up The CPU! Your Move Did " + playerAttack + " Damage!");
                        System.Threading.Thread.Sleep(300);
                        Console.WriteLine("Awww Man!");
                        System.Threading.Thread.Sleep(300);
                        Console.WriteLine("-- Player HP: " + playerHP + "CPU HP: " + cpuHP + " --");
                    }
                    else if (magicChoice == 5)
                    {
                        System.Threading.Thread.Sleep(300);
                        Console.WriteLine("You used: Dani Devito, Your Defence Rose Sharply");
                        System.Threading.Thread.Sleep(300);
                        defUP = true;
                        defMult += 1;
                        Console.WriteLine("-- Player HP: " + playerHP + "CPU HP: " + cpuHP + " --");
                    }
                    else if (magicChoice == 6)
                    {
                        System.Threading.Thread.Sleep(300);
                        Console.WriteLine("You used: KAMIKAZEEEEE!, LETS GOOOOO!!!!");
                        System.Threading.Thread.Sleep(300);
                        cpuHP -= 40;
                        playerHP -= 400;
                        Console.WriteLine("-- Player HP: " + playerHP + "CPU HP: " + cpuHP + " --");
                    }
                    else if (magicChoice == 7)
                    {
                        System.Threading.Thread.Sleep(300);
                        Console.WriteLine("You used: Fireball!, The enemy has bit lit aflame.");
                        System.Threading.Thread.Sleep(300);
                        burn = true;
                        playerAttack = randomAtk.Next(3, 8);
                        cpuHP -= playerAttack;
                        Console.WriteLine("-- Player HP: " + playerHP + "CPU HP: " + cpuHP + " --");
                    }
                    else if (magicChoice == 8)
                    {
                        System.Threading.Thread.Sleep(300);
                        Console.WriteLine("You used: Persuasion.");
                        System.Threading.Thread.Sleep(300);
                        persuade = random.Next(1, 4);
                        if(persuade == 1)
                        {
                            System.Threading.Thread.Sleep(300);
                            Console.WriteLine("You persuade them to: THE COIN FLIP OF DEATH!");
                            System.Threading.Thread.Sleep(300);
                            Console.WriteLine("If heads the opponent dies!");
                            persuadeOpt = random.Next(1, 3);
                            if(persuadeOpt == 1)
                            {
                                System.Threading.Thread.Sleep(300);
                                Console.WriteLine("Flipping...");
                                System.Threading.Thread.Sleep(300);
                                Console.WriteLine("HEADS THIS MAN IS DEAD!!!!!");
                                cpuHP -= 400;
                                Console.WriteLine("-- Player HP: " + playerHP + "CPU HP: " + cpuHP + " --");
                            }
                            else
                            {
                                System.Threading.Thread.Sleep(300);
                                Console.WriteLine("Flipping...");
                                System.Threading.Thread.Sleep(300);
                                Console.WriteLine("It failed");
                            }
                        }
                        else if (persuade == 2)
                        {
                            System.Threading.Thread.Sleep(300);
                            Console.WriteLine("You persuade them to: RUSSIAN ROULETTE!");
                            System.Threading.Thread.Sleep(300);
                            persuadeOpt = random.Next(1, 7);
                            if (persuadeOpt == 1)
                            {
                                System.Threading.Thread.Sleep(300);
                                Console.WriteLine("FIRE!");
                                System.Threading.Thread.Sleep(300);
                                cpuHP -= 30;
                            }
                            else
                            {
                                System.Threading.Thread.Sleep(300);
                                Console.WriteLine("The enemy lives, *for now*");
                                System.Threading.Thread.Sleep(300);
                            }
                        }
                        else if (persuade == 3)
                        {
                            System.Threading.Thread.Sleep(300);
                            Console.WriteLine("You persuade them to be in a relationship.");
                            System.Threading.Thread.Sleep(300);
                            persuadeOpt = random.Next(1, 101);
                            if (persuadeOpt < 11)
                            {
                                System.Threading.Thread.Sleep(300);
                                Console.WriteLine("They agree to date you but..");
                                System.Threading.Thread.Sleep(300);
                                Console.WriteLine("In the middle of the night you feel something sharp in your back.");
                                System.Threading.Thread.Sleep(300);
                                Console.WriteLine("It's the cold relief of death.");
                                playerHP -= 400;
                            }
                            else if(persuadeOpt == 69)
                            {
                                System.Threading.Thread.Sleep(300);
                                Console.WriteLine("You get married and live *sorta* happily ever after.");
                                System.Threading.Thread.Sleep(300);
                                cpuHP -= 400;
                                playerHP -= 400;
                            }
                            else
                            {
                                System.Threading.Thread.Sleep(300);
                                Console.WriteLine("They rejected you..");
                                System.Threading.Thread.Sleep(300);
                                Console.WriteLine("Seriously they're trying to kill you what'd you expect?");
                                System.Threading.Thread.Sleep(300);
                            }
                        }
                    }
                    else if (magicChoice == 9)
                    {
                        System.Threading.Thread.Sleep(300);
                        Console.WriteLine("You threw the kitchen sink at them. YOU ACTUALLY THREW A SINK");
                        System.Threading.Thread.Sleep(300);
                        cpuHP -= 15;
                        Console.WriteLine("-- Player HP: " + playerHP + "CPU HP: " + cpuHP + " --");
                    }
                    else if (magicChoice == 10)
                    {
                        System.Threading.Thread.Sleep(300);
                        Console.WriteLine("You used: Health Leech");
                        System.Threading.Thread.Sleep(300);
                        playerAttack = randomAtk.Next(5, 11);
                        cpuHP -= playerAttack;
                        Console.WriteLine("You did " + playerAttack + " damage!");
                        System.Threading.Thread.Sleep(300);
                        playerHP += playerAttack;
                        Console.WriteLine("You gained " + playerAttack + " health!");
                        Console.WriteLine("-- Player HP: " + playerHP + " CPU HP: " + cpuHP + " --");
                    }
                }
                else
                {
                    Console.WriteLine("You opened the item menu; press 1 for spikes, 2 for leftovers");
                    string itemChoice = Console.ReadLine();
                    System.Threading.Thread.Sleep(1000);
                    if(itemChoice == "1")
                    {
                        System.Threading.Thread.Sleep(300);
                        Console.WriteLine("You used spikes.");
                        System.Threading.Thread.Sleep(300);
                        cpuHP -= 4;
                        Console.WriteLine("-- Player HP: " + playerHP + " CPU HP: " + cpuHP + " --");
                        cpuHP -= 3;
                        Console.WriteLine("-- Player HP: " + playerHP + " CPU HP: " + cpuHP + " --");
                    }
                    else if(itemChoice == "2")
                    {
                        System.Threading.Thread.Sleep(300);
                        Console.WriteLine("You used leftovers.");
                        System.Threading.Thread.Sleep(300);
                        int leftovers = random.Next(1, 4);
                        int leftoversVal;
                        if (leftovers < 3)
                        {
                            leftoversVal = playerHP / 1;
                            playerHP += leftoversVal;
                            System.Threading.Thread.Sleep(300);
                            Console.WriteLine("You healed for 10% of your health.");
                            System.Threading.Thread.Sleep(300);
                            Console.WriteLine("-- Player HP: " + playerHP + " CPU HP: " + cpuHP + " --");
                        }
                        else if(leftovers == 3)
                        {
                            System.Threading.Thread.Sleep(300);
                            Console.WriteLine("Leftovers Failed.");
                            System.Threading.Thread.Sleep(300);
                        }
                    }

                }
                if(burn == true)
                {
                    System.Threading.Thread.Sleep(300);
                    Console.WriteLine("CPU took burn damage!");
                    System.Threading.Thread.Sleep(300);
                    cpuHP -= 3;
                    Console.WriteLine("-- Player HP: " + playerHP + "CPU HP: " + cpuHP + " --");
                }

                //Enemy's Turn
                if(cpuHP > 0 && stuns == false)
                {
                    cpustuns = false;
                    Console.WriteLine("");
                    System.Threading.Thread.Sleep(300);
                    Console.WriteLine("~~ Enemy Turn ~~");
                    cpuChoice = cpuMove.Next(0, 3);

                    if(cpuChoice == 0)
                    {
                        crit = critChance.Next(1, 6);
                        Console.WriteLine("");
                        if(crit < 5)
                        {
                            if(defUP == true)
                            {
                                cpuAttack = randomAtk.Next(6, 14);
                                cpuAttack -= 4 * defMult;
                                playerHP -= cpuAttack;
                                System.Threading.Thread.Sleep(200);
                                Console.WriteLine("*CPU Attacks The Player! It's Move Did " + cpuAttack + " Damage!");
                                System.Threading.Thread.Sleep(300);
                                Console.WriteLine("-- Player HP: " + playerHP + "  CPU HP: " + cpuHP + " --");
                            }
                            else
                            {
                                cpuAttack = randomAtk.Next(6, 14);
                                cpuAttack -= 4 * defMult;
                                playerHP -= cpuAttack;
                                System.Threading.Thread.Sleep(200);
                                Console.WriteLine("*CPU Attacks The Player! It's Move Did " + cpuAttack + " Damage!");
                                System.Threading.Thread.Sleep(300);
                                Console.WriteLine("-- Player HP: " + playerHP + "  CPU HP: " + cpuHP + " --");
                            }
                        }
                        else if (crit == 5)
                        {
                            if (defUP == true)
                            {
                                cpuAttack = randomAtk.Next(12, 28);
                                playerHP -= cpuAttack;
                                System.Threading.Thread.Sleep(200);
                                Console.WriteLine("CPU CRITS!");
                                System.Threading.Thread.Sleep(200);
                                Console.WriteLine("*CPU Attacks The Player! It's Move Did " + cpuAttack + " Damage!");
                                System.Threading.Thread.Sleep(300);
                                Console.WriteLine("-- Player HP: " + playerHP + "  CPU HP: " + cpuHP + " --");
                            }
                            else
                            {
                                cpuAttack = randomAtk.Next(12, 28);
                                playerHP -= cpuAttack;
                                System.Threading.Thread.Sleep(200);
                                Console.WriteLine("CPU CRITS!");
                                System.Threading.Thread.Sleep(200);
                                Console.WriteLine("*CPU Attacks The Player! It's Move Did " + cpuAttack + " Damage!");
                                System.Threading.Thread.Sleep(300);
                                Console.WriteLine("-- Player HP: " + playerHP + "  CPU HP: " + cpuHP + " --");
                            }  
                        }
                        
                        
                    }
                    else if(cpuChoice == 1)
                    {
                        heal = healAmount.Next(5, 11);
                        Console.WriteLine("");
                        cpuHP += heal;
                        System.Threading.Thread.Sleep(300);
                        Console.WriteLine("~~Healing~~");
                        System.Threading.Thread.Sleep(300);
                        Console.WriteLine("*CPU Healed For " + heal + " Health");
                        System.Threading.Thread.Sleep(600);
                        Console.WriteLine("-- Player HP: " + playerHP + "  CPU HP: " + cpuHP + " --");
                    }
                    else if (cpuChoice == 2)
                    {
                        magicChoice = magic.Next(1, 11);
                        if (magicChoice == 1)
                        {
                            cpustuns = true;
                            System.Threading.Thread.Sleep(300);
                            Console.WriteLine("CPU Used: Neck-Down Paralysis");
                            System.Threading.Thread.Sleep(300);
                            Console.WriteLine("YOU ARE STUNNED!");
                            System.Threading.Thread.Sleep(300);
                            Console.WriteLine("...");
                            System.Threading.Thread.Sleep(300);
                            Console.WriteLine("Your turned skipped");
                        }
                        else if (magicChoice == 2)
                        {
                            System.Threading.Thread.Sleep(300);
                            Console.WriteLine("CPU attack does more because it used: Muscle Milk!");
                            System.Threading.Thread.Sleep(300);
                            cpuatkUP = true;
                            cpuatkMult += 1;
                        }
                        else if (magicChoice == 3)
                        {
                            System.Threading.Thread.Sleep(300);
                            Console.WriteLine("CPU heal is better because it used: Turnip!");
                            System.Threading.Thread.Sleep(300);
                            cpuhlUP = true;
                            cpuhealMult += 1;
                        }
                        else if (magicChoice == 4)
                        {
                            System.Threading.Thread.Sleep(300);
                            Console.WriteLine("CPU used: Creeper, It blew up the enemy");
                            System.Threading.Thread.Sleep(300);
                            cpuAttack = randomAtk.Next(18, 23);
                            playerHP -= cpuAttack;
                            System.Threading.Thread.Sleep(300);
                            Console.WriteLine("*CPU Blows up You! It's Move Did " + cpuAttack + " Damage!");
                            System.Threading.Thread.Sleep(300);
                            Console.WriteLine("Awww Man!");
                            System.Threading.Thread.Sleep(300);
                            Console.WriteLine("-- Player HP: " + playerHP + "CPU HP: " + cpuHP + " --");
                        }
                        else if (magicChoice == 5)
                        {
                            System.Threading.Thread.Sleep(300);
                            Console.WriteLine("CPU used: Dani Devito, It's Defence Rose Sharply");
                            System.Threading.Thread.Sleep(300);
                            defUP = true;
                            defMult += 1;
                        }
                        else if (magicChoice == 6)
                        {
                            System.Threading.Thread.Sleep(300);
                            Console.WriteLine("CPU used: KAMIKAZEEEEE!, LETS GOOOOO!!!!");
                            System.Threading.Thread.Sleep(300);
                            playerHP -= 40;
                            cpuHP -= 400;
                        }
                        else if (magicChoice == 7)
                        {
                            System.Threading.Thread.Sleep(300);
                            Console.WriteLine("The CPU used: Fireball!, You've been lit aflame.");
                            System.Threading.Thread.Sleep(300);
                            cpuburn = true;
                            cpuAttack = randomAtk.Next(3, 8);
                            playerHP -= cpuAttack;
                        }
                        else if (magicChoice == 8)
                        {
                            System.Threading.Thread.Sleep(300);
                            Console.WriteLine("CPU used: Persuasion.");
                            System.Threading.Thread.Sleep(300);
                            persuade = random.Next(1, 4);
                            if (persuade == 1)
                            {
                                System.Threading.Thread.Sleep(300);
                                Console.WriteLine("CPU persuaded you to: THE COIN FLIP OF DEATH!");
                                System.Threading.Thread.Sleep(300);
                                Console.WriteLine("If heads you die!");
                                persuadeOpt = random.Next(1, 3);
                                if (persuadeOpt == 1)
                                {
                                    System.Threading.Thread.Sleep(300);
                                    Console.WriteLine("Flipping...");
                                    System.Threading.Thread.Sleep(300);
                                    Console.WriteLine("HEADS THIS MAN IS DEAD!!!!!");
                                    playerHP -= 400;
                                    Console.WriteLine("-- Player HP: " + playerHP + "CPU HP: " + cpuHP + " --");
                                }
                            }
                            else if (persuade == 2)
                            {
                                System.Threading.Thread.Sleep(300);
                                Console.WriteLine("They persuade you to: RUSSIAN ROULETTE!");
                                System.Threading.Thread.Sleep(300);
                                persuadeOpt = random.Next(1, 7);
                                if (persuadeOpt == 1)
                                {
                                    System.Threading.Thread.Sleep(300);
                                    Console.WriteLine("FIRE!");
                                    System.Threading.Thread.Sleep(300);
                                    playerHP -= 30;
                                }
                                else
                                {
                                    System.Threading.Thread.Sleep(300);
                                    Console.WriteLine("You live, *for now*");
                                    System.Threading.Thread.Sleep(300);
                                }
                            }
                            else if (persuade == 3)
                            {
                                System.Threading.Thread.Sleep(300);
                                Console.WriteLine("They persuade you to be in a relationship.");
                                System.Threading.Thread.Sleep(300);
                                persuadeOpt = random.Next(1, 101);
                                if (persuadeOpt < 11)
                                {
                                    System.Threading.Thread.Sleep(300);
                                    Console.WriteLine("You agree to date them but..");
                                    System.Threading.Thread.Sleep(300);
                                    Console.WriteLine("In the middle of the night you stab them in their back.");
                                    System.Threading.Thread.Sleep(300);
                                    Console.WriteLine("They're dead.");
                                    cpuHP -= 400;
                                }
                                else if (persuadeOpt == 69)
                                {
                                    System.Threading.Thread.Sleep(300);
                                    Console.WriteLine("You get married and live *sorta* happily ever after.");
                                    System.Threading.Thread.Sleep(300);
                                    cpuHP -= 400;
                                    playerHP -= 400;
                                }
                                else
                                {
                                    System.Threading.Thread.Sleep(300);
                                    Console.WriteLine("You rejected them..");
                                    System.Threading.Thread.Sleep(300);
                                    Console.WriteLine("Seriously you're trying to kill them what'd they expect?");
                                    System.Threading.Thread.Sleep(300);
                                }
                            }
                        }
                        else if (magicChoice == 9)
                        {
                            System.Threading.Thread.Sleep(300);
                            Console.WriteLine("They threw the kitchen sink at you. THEY ACTUALLY THREW A SINK");
                            System.Threading.Thread.Sleep(300);
                            playerHP -= 15;
                            Console.WriteLine("-- Player HP: " + playerHP + "CPU HP: " + cpuHP + " --");
                        }
                        else if (magicChoice == 10)
                        {
                            System.Threading.Thread.Sleep(300);
                            Console.WriteLine("CPU used: Health Leech");
                            System.Threading.Thread.Sleep(300);
                            cpuAttack = randomAtk.Next(5, 11);
                            playerHP -= cpuAttack;
                            Console.WriteLine("You did " + cpuAttack + " damage!");
                            System.Threading.Thread.Sleep(300);
                            cpuHP += cpuAttack;
                            Console.WriteLine("You gained " + cpuAttack + " health!");
                            Console.WriteLine("-- Player HP: " + playerHP + " CPU HP: " + cpuHP + " --");
                        }
                    }
                }
                if (cpuburn == true)
                {
                    System.Threading.Thread.Sleep(300);
                    Console.WriteLine("You took burn damage!");
                    System.Threading.Thread.Sleep(300);
                    playerHP -= 3;
                    Console.WriteLine("-- Player HP: " + playerHP + "CPU HP: " + cpuHP + " --");
                }
            }

            if(playerHP > 0)
            {
                Console.WriteLine("");
                System.Threading.Thread.Sleep(200);
                Console.WriteLine("Congrats, You Won!");
            }
            else if(cpuHP > 0)
            {
                Console.WriteLine("");
                System.Threading.Thread.Sleep(200);
                Console.WriteLine("You've Lost! ):");
            }
            else
            {
                Console.WriteLine("");
                System.Threading.Thread.Sleep(200);
                Console.WriteLine("IT'S A TIE! somehow");
            }
        }
    }
}
