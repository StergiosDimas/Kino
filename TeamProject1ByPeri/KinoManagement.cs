using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamProject1ByPeri
{
    public class KinoManagement
    {
        public List<Draw> Draws { get; set; }
        public Statistic Statistic { get; set; }

        public KinoManagement()
        {
            Draws = new List<Draw>();
        }



        public int GenerateUniqueDrawId(Random random)
        {
            int id = 0;
            do
            {
                id = random.Next(1, 10001);
            } while (Draws.Exists(x => x.Id == id));
            return id;
        }

        public void RunDrawCicle(List<KinoTicket> kinoTickets, Random random)
        {
            Draw draw = new Draw(GenerateUniqueDrawId(random), kinoTickets, random);
            ResultProcessor resultProcessor = new ResultProcessor(draw);
            if (Draws.Count != 0)
            {
                Draw previousDraw = Draws.Last();
                draw.IncreaseAmount(previousDraw.ResultProcessor.ComputeRemainingAmountOfDraw());
            }
            draw.DrawNumbers(random);
            resultProcessor.ComputeResults();
            Console.WriteLine(draw);
            draw.Results.PrintData();
            resultProcessor.ComputeWinnings();
            Console.WriteLine(draw);
            Console.WriteLine(draw.Winnings);
            Draws.Add(draw);
        }

        public void ComputeStatistic()
        {
            Dictionary<string, int> drawsPerNumber = new Dictionary<string, int>();
            Statistic statistic = new Statistic();
            int firstMostCommonlyDrawnNumber = 0;
            int secondMostCommonlyDrawnNumber = 0;
            int thirdMostCommonlyDrawnNumber = 0;
            int firstLeastCommonlyDrawnNumber = 0;
            int secondLeastCommonlyDrawnNumber = 0;
            int thirdLeastCommonlyDrawnNumber = 0;


            foreach (var draw in Draws)
            {
                foreach (var kinoNumber in draw.KinoNumbers)
                {
                    if (!drawsPerNumber.ContainsKey($"{kinoNumber}"))
                        drawsPerNumber.Add($"{kinoNumber}", 1);
                    else
                        drawsPerNumber[$"{kinoNumber}"]++;
                }
            }

            for (int i = 0; i < 3; i++)
            {
                KeyValuePair<string, int> mostCommonKinoNumberKVPair = new KeyValuePair<string, int>("0", 0);
                KeyValuePair<string, int> leastCommonKinoNumberKVPair = new KeyValuePair<string, int>("0", Draws.Count);

                foreach (KeyValuePair<string, int> kinoNumberFrequencyKVPair in drawsPerNumber)
                {
                    if (kinoNumberFrequencyKVPair.Value > mostCommonKinoNumberKVPair.Value)
                        mostCommonKinoNumberKVPair = kinoNumberFrequencyKVPair;

                    if (kinoNumberFrequencyKVPair.Value < leastCommonKinoNumberKVPair.Value)
                        leastCommonKinoNumberKVPair = kinoNumberFrequencyKVPair;
                }

                if (i == 0)
                {
                    firstMostCommonlyDrawnNumber = Int32.Parse(mostCommonKinoNumberKVPair.Key);
                    firstLeastCommonlyDrawnNumber = Int32.Parse(leastCommonKinoNumberKVPair.Key);
                }
                else if (i == 1)
                {
                    secondMostCommonlyDrawnNumber = Int32.Parse(mostCommonKinoNumberKVPair.Key);
                    secondLeastCommonlyDrawnNumber = Int32.Parse(leastCommonKinoNumberKVPair.Key);
                }
                else
                {
                    thirdMostCommonlyDrawnNumber = Int32.Parse(mostCommonKinoNumberKVPair.Key);
                    thirdLeastCommonlyDrawnNumber = Int32.Parse(leastCommonKinoNumberKVPair.Key);
                }

                drawsPerNumber.Remove(mostCommonKinoNumberKVPair.Key);
                drawsPerNumber.Remove(leastCommonKinoNumberKVPair.Key);
            }

            statistic.FirstMostCommonlyDrawnNumber = firstMostCommonlyDrawnNumber;
            statistic.SecondMostCommonlyDrawnNumber = secondMostCommonlyDrawnNumber;
            statistic.ThirdMostCommonlyDrawnNumber = thirdMostCommonlyDrawnNumber;
            statistic.FirstLeastCommonlyDrawnNumber = firstLeastCommonlyDrawnNumber;
            statistic.SecondLeastCommonlyDrawnNumber = secondLeastCommonlyDrawnNumber;
            statistic.ThirdLeastCommonlyDrawnNumber = thirdLeastCommonlyDrawnNumber;
            Statistic = statistic;
        }

    }
}
