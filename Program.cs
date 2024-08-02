using System;
using System.ComponentModel;
using System.Data;
class HelloWorld
{
    static int hp = 100;
    static int luck = 10;
    static int atk = 5;
    static int def = 5;
    static int monster_hp;
    static int m_atk;
    static int m_def;
    static string[] monsters = new string[2];
    static int monster_num;
    static string[] items = new string[10];
    static string[] food = new string[10];
    static string arm;
    static Random rand = new Random();
    static string[] item = new string[10];
    static string[] inventory = new string[10];
    static int inv_num = 1;
    static int item_num = 1;
    static bool game = true;
    static void loot()
    {
        if (items[0] != "Rabbit_Foot")
        {
            items[0] = "Rabbit_Foot";
            items[1] = "Bloody_bandana";
            items[2] = "Boxing_Gloves";
            items[3] = "Wooden_Shield";
            items[4] = "Lucky_Penny";
            items[5] = "Dices";
            items[6] = "Batery";
            items[7] = "Jocker's_Hat";
            items[8] = "Broken_Arrow";
            items[9] = "Death_Note";
            food[0] = "Steak";
            food[1] = "Mystery_Pill";
            food[2] = "Fish_Head";
            food[3] = "Magic_Candy";
        }
        else
        {
            int drop;
            if (arm == "Lucky_Penny")
            {
                drop = rand.Next(1, 140 + 20);
            }
            else
            {
                drop = rand.Next(1, 140);
            }
            if (inv_num < 10)
            {

                if (drop + luck <= 50)
                {
                    int i = rand.Next(0, 4);
                    inventory[inv_num] = food[i];
                    inv_num++;
                    Console.WriteLine($"Loot:{food[i]}");
                }
            }
            if (item_num < 10)
            {
                if (drop + luck > 50 && drop + luck <= 90)
                {
                    int i = rand.Next(0, 4);
                    item[item_num] = items[i];
                    item_num++;
                    Console.WriteLine($"Loot:{items[i]}");
                }
                else if (drop + luck > 90 && drop + luck <= 120)
                {
                    int i = rand.Next(0, 4);
                    item[item_num] = items[i];
                    item_num++;
                    Console.WriteLine($"Loot:{items[i]}");
                }
                else if (drop + luck > 120)
                {
                    int i = rand.Next(0, 2);
                    item[item_num] = items[i];
                    item_num++;
                    Console.WriteLine($"Loot:{items[i]}");
                }
            }
            
        }
    }
    static void inv()
    {
        for (int j = 0; j < 10; j++)
        {
            Console.WriteLine($"{j + 1}.{inventory[j]}");
        }
        if (int.TryParse(Console.ReadLine(), out int i))
        {

            if (inventory[i - 1] != null)
            {
                Console.WriteLine($"{inventory[i - 1]}\n1.Use\n2.Delete\n3.Info");
                if (int.TryParse(Console.ReadLine(), out int chose))
                {
                    if (chose == 1)
                    {

                        switch (inventory[i - 1])
                        {
                            case "Steak":

                                hp += 25;
                                break;
                            case "Fish_Head":
                                hp += 50;
                                break;
                            case "Mystery_Pill":

                                hp += rand.Next(-25, 26);
                                break;
                            case "Magic_Candy":
                                hp += rand.Next(25, 101);
                                break;
                        }
                        while (i < 10)
                        {
                            inventory[i - 1] = inventory[i - 1 + 1];
                            i++;
                        }
                        Array.Resize(ref inventory, 9);
                        Array.Resize(ref inventory, 10);
                        inv_num--;
                        if (hp > 100)
                        {
                            hp = 100;
                        }
                    }
                    if (chose == 3)
                    {
                        switch (inventory[i - 1])
                        {
                            case "Steak":

                                Console.WriteLine($"Steak:\nhp + 25");
                                break;
                            case "Fish_Head":
                                Console.WriteLine($"Fish_Head:\nhp + 50");
                                break;
                            case "Mystery_Pill":
                                Console.WriteLine($"Mystery_Pill:\nhp +- 25");
                                break;
                            case "Magic_Candy":
                                Console.WriteLine($"Magic_Candy:\nhp + 25-100");
                                break;
                        }
                    }
                    if (chose == 2)
                    {
                        while (i < 10)
                        {
                            inventory[i - 1] = inventory[i - 1 + 1];
                            i++;
                        }
                        Array.Resize(ref inventory, 9);
                        Array.Resize(ref inventory, 10);
                        inv_num--;
                    }

                }
            }

        }
    }
    static void armor()
    {
        for (int j = 0; j < 10; j++)
        {
            Console.WriteLine($"{j + 1}.{item[j]}");

        }
        if (int.TryParse(Console.ReadLine(), out int i))
        {

            if (item[i - 1] != null)
            {
                Console.WriteLine($"{item[i - 1]}\n1.Use\n2.Delete\n3.Info");
                if (int.TryParse(Console.ReadLine(), out int chose))
                {
                    if (chose == 1)
                    {
                        luck = 10;
                        atk = 5;
                        def = 5;
                        arm = item[i - 1];

                        switch (arm)
                        {
                            case "Rabbit_Foot":

                                luck += 10;
                                break;
                            case "Boxing_Gloves":
                                atk += 2;
                                break;
                            case "Wooden_Shield":

                                def += 10;
                                break;
                            case "Batery":
                                atk += 5;
                                luck -= 5;
                                def += 10;
                                break;
                        }

                    }
                    if (chose == 3)
                    {
                        switch (item[i - 1])
                        {
                            case "Rabbit_Foot":

                                Console.WriteLine($"Rabbit_Foot:\nluck + 10");
                                break;
                            case "Boxing_Gloves":
                                Console.WriteLine($"Boxing_Gloves\natk + 2"); 
                                break;
                            case "Wooden_Shield":

                                Console.WriteLine($"Wooden_Shield:\ndef + 10");
                                break;
                            case "Batery":
                                Console.WriteLine($"Batery:\nluck - 5\n atk + 5\n def + 10");
                                break;
                            case "Bloody_Bandana":
                                Console.WriteLine($"Bloody_Bandana:\nDMG = DMG");
                                break;
                            case "Lucky_Penny":
                                Console.WriteLine($"Lucky_Penny:\nbeter loot");
                                break;
                            case "Dices":
                                Console.WriteLine($"Dices:\nD&D mod");
                                break;
                            case "Jocker's_Hat":
                                Console.WriteLine($"Jocker's_Hat:\nLay on luck");
                                break;
                            case "Brocken_Arrow":
                                Console.WriteLine($"Brocken_Arrow:\n???");
                                break;
                            case "Death_Note":
                                Console.WriteLine($"Death_Note:\nJust strange note");
                                break;
                        }
                    }
                    if (chose == 2)
                    {
                        while (i < 10)
                        {
                            item[i - 1] = item[i - 1 + 1];
                            i++;
                        }
                        Array.Resize(ref item, 9);
                        Array.Resize(ref item, 10);
                        item_num--;
                        if (arm == item[i - 1])
                        {
                            luck = 10;
                        atk = 5;
                        def = 5;
                        arm = item[i - 1];

                        }
                    }
                }
            }

        }
    }
    static void check()
    {

        Console.WriteLine($"{monsters[monster_num]}\nHP-{monster_hp}\nATK-{m_atk}\nDEF-{m_def}\nYour HP-{hp}\nYour ATK-{atk}\nYour DEF-{def}");
   
    }
    static void defence()
    {
        int dmg = rand.Next(1, 6) * m_atk + 5 / 2 - rand.Next(0, def) - (luck / 2);
        if (dmg >0)
        {
            hp -= dmg;
            if (arm == "Bloody_Bandana")
            {
                atk += dmg / 2;
            }
        }
    
    
    }
    static void  atak()
    {
        int dmg = rand.Next(1, 6) * atk + luck / 2 - rand.Next(0, m_def) - (5 / 2);
        if (dmg > 0)
        {
          monster_hp -= dmg;
        }
        if (monster_hp > 0)
        {
          defence();
        }
        
    
    }
   
    static void fight()
    {
        monster_hp = 100;
        monster_num = rand.Next(0, 2);
        m_atk = rand.Next(5, 11);
        m_def = rand.Next(2, 11);
        do
        {
            if (arm == "Jocker's_Hat")
            {
                luck += rand.Next(-20, 21);
                def += rand.Next(-5, 21);
                atk += rand.Next(-5, 21);
            }
            else if (arm == "Dices")
            {
                luck += rand.Next(0, 20);
                def += rand.Next(0, 6);
                atk += rand.Next(0, 4);
            }
            Console.WriteLine($"Your HP-{hp}\n1.Atak\n2.Check\n3.Inventory");
            if (int.TryParse(Console.ReadLine(), out int i))
            {
                switch(i)
                {
                    case 1:
                        atak();
                        
                        break;
                    case 2:
                        check();
                        break;
                    case 3:
                        inv();
                        break;
                }
            }
            if (arm == "Death_Note")
            {
                monster_hp -= 5;
            }
        } while (hp > 0 && monster_hp > 0);
       
        if (monster_hp < 1)
        {
            Console.WriteLine($"Your HP-{hp}\nYou-WIN");
            if (arm == "Bloody_Bandana")
            {
                atk = 5;
            }
            loot();
            
        }
        else
        {
            Console.WriteLine("You-Lose");
            game = false;
        }
    }

    static void Main()
    {
        monsters[0] = "Zombie";
        monsters[1] = "Goblin";
        loot();
        int start_item = rand.Next(0, 4);
        arm = items[start_item];
        item[0] = items[start_item];
        items[0].Remove(start_item);
        start_item = rand.Next(0, 2);
        inventory[0] = food[start_item];
        switch (arm)
        {
            case "Rabbit_Foot":

                luck += 10;
                break;
            case "Boxing_Gloves":
                atk += 2;
                break;
            case "Wooden_Shield":

                def += 10;
                break;
            case "Batery":
                atk += 5;
                luck -= 5;
                def += 10;
                break;


        }
        while (game)
        {
            Console.WriteLine($"1.Fight\n2.Inventory\n3.Armor");
        
            if (int.TryParse(Console.ReadLine(), out int i))
            {
                switch (i)
                {
                    case 1:
                        fight();
                        break;
                    case 2:
                        inv();
                        break;
                    case 3:
                        armor();
                        break;
                    default:
                        Console.WriteLine("Wrong number");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Wrong Input");
            }
        }
    }
}
