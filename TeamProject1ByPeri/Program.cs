using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamProject1ByPeri
{
    class Program
    {
        static void Main(string[] args)
        {
            var random = new Random();
            var kinoManagement = new KinoManagement();
            Console.Write("Enter number of tickets: ");
            var numberOfPlayers = Int32.Parse(Console.ReadLine());
            var randomPlayers = Player.GetRandomPlayers(numberOfPlayers, random);
            var randomKinoTickets = KinoTicket.GetRandomTickets(randomPlayers, random);
            Console.Write("Enter times to draw: ");
            var timesToDraw = Int32.Parse(Console.ReadLine());

            //for (int i = 0; i < timesToDraw; i++)
            //{
            //    kinoManagement.RunDrawCicle(randomKinoTickets, random);
            //}

            //kinoManagement.ComputeStatistic();
            //Console.WriteLine(kinoManagement.Statistic);

            Console.WriteLine();
            randomKinoTickets.ForEach(x => Console.WriteLine(x));
            
        }
    }
}
