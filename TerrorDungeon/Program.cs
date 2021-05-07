using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            Start();
            while (mainLoop)
            {
                encounters.RandomEncounterHolder();
            }
        }




        // FABUŁA 
        static void Start()
        {
            currentPlayer.name = "";
        wyjebka:
            {

                while (currentPlayer.name == "")
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Terror Dungeon!");
                    Console.ResetColor();
                    Console.Write("Nazwa postaci: ");
                    currentPlayer.name = Console.ReadLine();
                    Console.Clear();
                }


                Print("Budzisz się przy wielkim drzewie, pod szałasem, który prawdopdobonie\n");
                Print("ty wybudowałeś. Jedyną rzecz jaką pamiętasz to własne imię " + "(" + currentPlayer.name + ")\n");
                Console.ReadKey();

                Console.Write("Wpisz co chcesz zrobić (wstań/śpij): ");
                string akcja1 = Console.ReadLine();
                Console.Clear();
                if (akcja1.ToLower() == "śpij" || akcja1.ToLower() == "spij")
                {
                    Console.Clear();
                    Print("Postanawiasz położyć się spać...\n Nie mija pół minuty, gdy nagle słyszysz szybkie, zaplanowane kroki\n nim nadążasz zareagować, zimny przedmiot przeszywa ci klatkę piersiową...\n");
                    Console.ReadKey();
                    Console.WriteLine("NIE ŻYJESZ. Zacznij od początku!");
                    Console.ReadKey();
                    Console.Clear();
                    currentPlayer.name = "";
                    goto wyjebka;


                }
                else if (akcja1.ToLower() == "wstan" || akcja1.ToLower() == "wstań")
                {
                    Print("Zmysły spowija ciemność, chwile później nagły szelest za szałasem...\n");
                    Print("nim się orientujesz, wybiega na Ciebie człowiek niskiej postury\n");
                    Print("Sprawia wrażenie rannego. W mngnieniu oka, sprawnym ruchem wyciąga sztylet...\n\n");
                    Console.ReadKey();
                    Console.WriteLine("Ranny Bandyta:");
                    Print("Ehhh... Miałem nadzieję, że będziesz się mniej wiercił niż poprzednik.");
                    Console.ReadKey();
                    Console.Clear();
                    
                    Console.ReadKey();
                }
            }
        }
    }
}
