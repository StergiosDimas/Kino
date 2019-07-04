using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamProject1ByPeri
{
    public class Draw
    {
        public const decimal CharityDonationPercentage = 0.07m;
        private const decimal InitialAmount = 100000m;
        private const int LowerBound = 1;
        private const int UpperBound = 80;
        private const int TimesToDraw = 12;

        public List<KinoTicket> KinoTickets { get; set; }
        public int Id { get; private set; }
        public DateTime DateAndTimeOfDraw { get; set; }

        public decimal Amount { get; set; }
        private readonly List<int> numbersDrawn;


        public int KinoBonus
        {
            get
            {
                return numbersDrawn.Count == TimesToDraw ? numbersDrawn.Last() : 0;
            }
        }

        public List<int> KinoNumbers
        {
            get
            {
                return numbersDrawn.Count == TimesToDraw ? numbersDrawn.GetRange(0, numbersDrawn.Count - 1) : null;
            }
        }

        public Draw(int id, List<KinoTicket> kinoTickets, Random random)
        {
            if (kinoTickets == null)
                throw new ArgumentNullException("kinotickets");
            Id = id;
            Amount = InitialAmount;
            numbersDrawn = new List<int>();
            KinoTickets = kinoTickets;
        }

        public void DrawNumbers(Random random)
        {
            while (numbersDrawn.Count < TimesToDraw)
            {
                var randomNumber = random.Next(LowerBound, UpperBound + 1);
                if (numbersDrawn.Contains(randomNumber))
                    continue;
                numbersDrawn.Add(randomNumber);
            }
            DateAndTimeOfDraw = DateTime.Now;
        }
        public void IncreaseAmount(decimal amountToAdd)
        {
            Amount += amountToAdd;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"Draw[Id:{Id}] ");
            foreach (var kinoNumber in KinoNumbers)
            {
                sb.Append($"{kinoNumber} ");
            }
            sb.Append($"({KinoBonus}) Amount: {Amount.ToString("C")}");
            return sb.ToString();
        }

        public override bool Equals(object obj)
        {
            if (obj is Draw && ((Draw)obj).Id == Id)
                return true;
            return false;
        }
    }
}
