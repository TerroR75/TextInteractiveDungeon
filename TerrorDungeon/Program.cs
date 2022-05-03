using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace TerrorDungeon
{
    class Program
    {

        // Wypisywanie liter
        public static void Print(string text, int speed = 10)
        {
            foreach (char c in text)
            {
                Console.Write(c);
                System.Threading.Thread.Sleep(speed);
            }
        }
        
        public static Player currentPlayer = new Player();
        public static bool mainLoop = true;
        // KONSOLA
        static void Main(string[] args)
        {
            if (!Directory.Exists("saves"))
            {
                Directory.CreateDirectory("saves");
            }
            currentPlayer = Load(out bool newP);

            if (newP)
            {
                encounters.Encounter1();
            }

            while (mainLoop)
            {
                encounters.RandomEncounterHolder();
            }
        }




        // FABUŁA 
        static void Start()
        {
            currentPlayer.name = "";
        death:
            {

                while (currentPlayer.name == "")
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Terror Dungeon!");
                    Console.ResetColor();
                    Console.Write("Player name: ");
                    currentPlayer.name = Console.ReadLine();
                    Console.Clear();
                }


                Print("[STORY BEGINNING PLACEHOLDER]\n");
                Print("[STORY BEGINNING PLACEHOLDER]\n");
                Console.ReadKey();

                Console.Write("Choose what do you want to do (standup/sleep): ");
                string akcja1 = Console.ReadLine();
                Console.Clear();
                if (akcja1.ToLower() == "sleep")
                {
                    Console.Clear();
                    Print("[STORY BEGINNING = DEATH = PLACEHOLDER]\n");
                    Console.ReadKey();
                    Console.WriteLine("YOU ARE DEAD.");
                    Console.ReadKey();
                    Console.Clear();
                    currentPlayer.name = "";
                    goto death;


                }
                else if (akcja1.ToLower() == "standup")
                {
                    Print("[STORY BEGINNING PLACEHOLDER]\n");
                    Print("[STORY BEGINNING PLACEHOLDER]\n");
                    Print("[STORY BEGINNING PLACEHOLDER]\n\n");
                    Console.ReadKey();
                    Console.WriteLine("Wounded Bandit:");
                    Print("[STORY BEGINNING PLACEHOLDER - BANDIT DIALOGUE]");
                    Console.ReadKey();
                    Console.Clear();
                    
                    Console.ReadKey();
                }
            }
        }


        public static Player NewStart(int i)
        {
            Console.Clear();
            Player p = new Player();

                Console.Write("Name: ");
                p.name = Console.ReadLine();

            p.id = i;
            Console.Clear();
            Console.WriteLine("[STORY PLACEHOLDER]");
            Console.WriteLine("[STORY PLACEHOLDER]");
            Console.WriteLine("[STORY PLACEHOLDER]");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("[STORY PLACEHOLDER]");
            Console.WriteLine("[STORY PLACEHOLDER]");
            Console.WriteLine("[STORY PLACEHOLDER]");
            Console.WriteLine("[STORY PLACEHOLDER]");
            Console.ReadKey();
            return p;
        }
        public static void Quit()
        {
            Save();
            Environment.Exit(0);
        }
        public static void Save()
        {
            BinaryFormatter binForm = new BinaryFormatter();
            string path = "saves/" + currentPlayer.id.ToString();
            FileStream file = File.Open(path, FileMode.OpenOrCreate);
            binForm.Serialize(file, currentPlayer);
            file.Close();
        }
        public static Player Load(out bool newP)
        {
            newP = false;
            Console.Clear();
            string[] paths = Directory.GetFiles("saves");
            List<Player> players = new List<Player>();
            int idCount = 0;

            BinaryFormatter binForm = new BinaryFormatter();
            foreach (string p in paths)
            {
                FileStream file = File.Open(p, FileMode.Open);
                Player player = (Player)binForm.Deserialize(file);
                file.Close();
                players.Add(player);
            }
            idCount = players.Count;

            while (true)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.WriteLine("The Incubator");
                Console.ResetColor();

                Console.WriteLine("\n\nChoose saved game: ");

                foreach (Player p in players)
                {
                    Console.WriteLine(p.id + ": " + p.name);
                }
                Console.WriteLine("Input player id or name (id:# OR playername)\n");
                Console.WriteLine("To create a new game, input CREATE");
                string[] data = Console.ReadLine().Split(':');

                try
                {
                    if (data[0] == "id")
                    {
                        if (int.TryParse(data[1], out int id))
                        {
                            foreach(Player player in players)
                            {
                                if(player.id == id)
                                {
                                    return player;
                                }
                            }
                            Console.WriteLine("There is no player with that id!");
                            Console.ReadKey();

                        }
                        else
                        {
                            Console.WriteLine("Your id needs to be a number! Press any key to continue.");
                            Console.ReadKey();
                        }
                    }
                    else if(data[0] == "CREATE" || data[0] == "create")
                    {
                        Player newPlayer = NewStart(idCount);
                        newP = true;
                        return newPlayer;
                    }
                    else
                    {
                        foreach(Player player in players)
                        {
                            if (player.name == data[0])
                            {
                                return player;
                            }
                        }
                        Console.WriteLine("There is no player with that name!");
                        Console.ReadKey();
                    }
                }
                catch(IndexOutOfRangeException)
                {
                    Console.WriteLine("Your id needs to be a number! Press any key to continue");
                    Console.ReadKey();
                }
            }
            
        }
    }
}
