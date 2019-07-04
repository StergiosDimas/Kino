using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamProject1ByPeri
{
    public class Results
    {
        private readonly Dictionary<string, int> Scores;
        public Draw Draw { get; set; }

        public Results(Draw draw)
        {
            Scores = new Dictionary<string, int>()
            {
                { "6of6", 0 },
                { "6of6+", 0 },
                { "5of6", 0 },
                { "5of6+", 0 },
                { "4of6", 0 },
                { "4of6+", 0},
                { "3of6", 0 },
                { "3of6+", 0 },
                { "2of6", 0 },
                { "2of6+", 0 },
                { "1of6", 0 },
                { "1of6+", 0 },
                { "0of6", 0 },
                { "0of6+", 0 }
            };

            Draw = draw;
        }

        public int this[string key]
        {
            get { return Scores[key]; }

            set { Scores[key] = value; }
        }

        public void PrintData()
        {
            for (int i = KinoTicket.TotalNumbersToSelect; i >= 0; i--)
            {
                Console.WriteLine($"{Scores[$"{i}of6"]} tickets have scored {$"{i} of {KinoTicket.TotalNumbersToSelect}"} numbers ({Scores[$"{i}of6+"]} + KinoBonus)");
            }
            Console.WriteLine();
        }

    }
}
