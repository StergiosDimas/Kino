using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamProject1ByPeri
{
    public class Statistic
    {
        public int FirstMostCommonlyDrawnNumber { get; set; }
        public int SecondMostCommonlyDrawnNumber{ get; set; }
        public int ThirdMostCommonlyDrawnNumber { get; set; }
        public int FirstLeastCommonlyDrawnNumber { get; set; }
        public int SecondLeastCommonlyDrawnNumber { get; set; }
        public int ThirdLeastCommonlyDrawnNumber { get; set; }
        public int MostCommonlyDrawnKinoBonus { get; set; }
        public int LeastCommonlyDrawnKinoBonus { get; set; }

        public Statistic(KinoManagement kinoManagement)
        {
            kinoManagement.
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"First most common drawn number: {FirstMostCommonlyDrawnNumber}")
                .AppendLine($"Second most common drawn number: {SecondMostCommonlyDrawnNumber}")
                .AppendLine($"Third most common drawn number: {ThirdMostCommonlyDrawnNumber}")
                .AppendLine($"First least commonly drawn number: {FirstLeastCommonlyDrawnNumber}")
                .AppendLine($"Second least commonly drawn number: {SecondLeastCommonlyDrawnNumber}")
                .AppendLine($"Third least commonly drawn number: {ThirdLeastCommonlyDrawnNumber}")
                .AppendLine($"Most commonly drawn kino bonus: {MostCommonlyDrawnKinoBonus}")
                .AppendLine($"Least commonly drawn kino bonus: {LeastCommonlyDrawnKinoBonus}");
            return sb.ToString();
        }
    }
}
