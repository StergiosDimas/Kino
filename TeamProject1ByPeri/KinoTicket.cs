using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamProject1ByPeri
{
    public class KinoTicket
    {
        public const int UpperBound = 80;
        public const int LowerBound = 1;
        public const int TotalNumbersToSelect = 6;
        public List<int> SelectedKinoNumbers { get; private set; }
        public int Id { get; set; }
        public Player Player { get; set; }
        public bool PlayKinoBonus { get; set; }

        public KinoTicket(int id, Player player)
        {
            Id = id;
            SelectedKinoNumbers = new List<int>();
            Player = player;
        }

        public bool SelectionIsWithinBoundaries(int number)
        {
            return (number >= LowerBound) && (number <= UpperBound);
        }

        public bool NumberHasAlreadyBeenSelected(int number)
        {
            return SelectedKinoNumbers.Contains(number);
        }

        public bool TrySelectNumber(int number)
        {
            if (SelectionIsWithinBoundaries(number) && !NumberHasAlreadyBeenSelected(number) && (SelectedKinoNumbers.Count < TotalNumbersToSelect))
            {
                SelectedKinoNumbers.Add(number);
                return true;
            }
            return false;
        }

        // Populate kino ticket with random selections
        private void RandomizeSelections(Random random)
        {
            while (TrySelectNumber(random.Next(LowerBound, UpperBound + 1)));
            PlayKinoBonus = Convert.ToBoolean(random.Next(0,2));
        }

        // Creates a list of tickets with random selections (1 ticket/player in list of players)
        public static List<KinoTicket> GetRandomTickets(List<Player> players, Random random)
        {
            if (players == null)
                throw new ArgumentNullException("players");
            KinoTicket kinoTicket = null;
            var randomKinoTickets = new List<KinoTicket>();
            foreach (var player in players)
            {
                kinoTicket = new KinoTicket(random.Next(1, 10001), player);
                kinoTicket.RandomizeSelections(random);
                randomKinoTickets.Add(kinoTicket);
            }
            return randomKinoTickets;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append($"Ticket[{Id}] ");
            SelectedKinoNumbers.ForEach(x => sb.Append(x + " "));
            return sb.ToString();
        }
    }
}
