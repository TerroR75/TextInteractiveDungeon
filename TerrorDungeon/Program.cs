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
        // KONSOLA
        static void Main(string[] args)
        {
            Start();
        }




        // FABUŁA 
        static void Start()
        {
            Console.WriteLine("Terror Dungeon!");
            Console.Write("Nazwa postaci: ");
            currentPlayer.name = Console.ReadLine();
            Console.Clear();
            if (currentPlayer.name == "")
            {
                Print("Nic nie pamiętasz, twoje oczy uszy i nos spowija ciemność. Nie żyjesz.");
            }
            else
                Print("Budzisz się przy wielkim drzewie, pod szałasem, który prawdopdobonie\n");
            Print("ty wybudowałeś. Jedyną rzecz jaką pamiętasz to własne imię " + "(" + currentPlayer.name + ")\n");
            Console.ReadKey();

            Console.Write("Wpisz co chcesz zrobić (wstań/śpij): ");
                string akcja1 = Console.ReadLine();
            if (akcja1 == "śpij")
            {
                Console.Clear();
                Print("Postanawiasz położyć się spać...\n Nie mija pół minuty, gdy nagle słyszysz szybkie, zaplanowane kroki\n nim nadążasz zareagować, zimny przedmiot przeszywa ci klatkę piersiową...\n");
                Console.ReadKey();
                Console.WriteLine("NIE ŻYJESZ");
            }

            Print("Wstajesz i wychodzisz z szałasu aalbalbalbabalball");
            Console.ReadKey();
            Console.Clear();
            encounters.Encounter1();
        }
    }
}
