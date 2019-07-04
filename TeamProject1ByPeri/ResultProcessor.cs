using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamProject1ByPeri
{
    public class ResultProcessor
    {
        public Draw Draw { get; set; }

        public ResultProcessor(Draw draw)
        {
            if (draw == null)
                throw new ArgumentNullException("draw");
            Draw = draw;
        }

        public List<int> GetTicketWinningNumbers(KinoTicket kinoTicket)
        {
            if (kinoTicket == null)
                throw new ArgumentNullException("kinoticket");
            if (kinoTicket.SelectedKinoNumbers.Count != 6)
                throw new InvalidOperationException("Kino ticket has incomplete selections.");
            var drawnKinoNumbers = Draw.KinoNumbers;
            return kinoTicket.SelectedKinoNumbers.Where(x => Draw.KinoNumbers.Contains(x)).ToList();
        }

        public bool HasWonKinoBonus(KinoTicket kinoTicket)
        {
            if (kinoTicket == null)
                throw new ArgumentNullException("kinoticket");


            //if (kinoTicket.PlayKinoBonus)
            //{
            //    if (kinoTicket.SelectedKinoNumbers.Contains(Draw.KinoBonus))
            //        return true;
            //}
            //return false;
        }

        public void ComputeResults()
        {
            if (Draw.KinoTickets == null)
                throw new ArgumentNullException("kinotickets");
            Results results = new Results(Draw);
            int ticketScore = 0;

            foreach (var kinoTicket in Draw.KinoTickets)
            {
                ticketScore = GetTicketWinningNumbers(kinoTicket);
                if (kinoTicket.PlayKinoBonus && HasWonKinoBonus(kinoTicket))
                    results[$"{ticketScore}of6+"]++;
                else
                    results[$"{ticketScore}of6"]++;
            }
        }

        public void ComputeWinnings()
        {
            Results results = Draw.Results;
            if (results == null)
                throw new InvalidOperationException("Cannot compute winnings without results.");
            Winnings winnings = new Winnings();
            winnings["6of6+"] = results["6of6+"] == 0 ? 0 : 0.35m * Draw.Amount;
            winnings["6of6"] = results["6of6"] == 0 ? 0 : 0.23m * Draw.Amount;
            winnings["5of6+"] = results["5of6+"] == 0 ? 0 : 0.15m * Draw.Amount;
            winnings["5of6"] = results["5of6"] == 0 ? 0 : 0.07m * Draw.Amount;
            winnings["4of6+"] = results["4of6+"] == 0 ? 0 : 0.05m * Draw.Amount;
            winnings["4of6"] = results["4of6"] == 0 ? 0 : 0.03m * Draw.Amount;
            winnings["3of6+"] = results["3of6+"] == 0 ? 0 : 0.02m * Draw.Amount;
            winnings["3of6"] = results["3of6"] == 0 ? 0 : 0.01m * Draw.Amount;
            winnings["2of6+"] = results["2of6+"] == 0 ? 0 : 0.008m * Draw.Amount;
            winnings["2of6"] = results["2of6"] == 0 ? 0 : 0.006m * Draw.Amount;
            winnings["1of6+"] = results["1of6+"] == 0 ? 0 : 0.004m * Draw.Amount;
            winnings["1of6"] = results["1of6"] == 0 ? 0 : 0.002m * Draw.Amount;
            Draw.Winnings = winnings;
        }

        public decimal ComputeRemainingAmountOfDraw()
        {
            if (Draw.Winnings == null)
                throw new InvalidOperationException("Cannot compute remaining amount of draw without the winnings data");
            return Draw.Amount - Draw.Winnings.GetTotalAmount() - Draw.CharityDonationPercentage * Draw.Amount;
        }
    }
}
