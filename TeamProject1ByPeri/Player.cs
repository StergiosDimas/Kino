using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamProject1ByPeri
{
    public class Player
    {
        public int Id { get; set; }

        public Player(int id)
        {
            Id = id;
        }

        public static List<Player> GetRandomPlayers(int numbersOfPlayers, Random random)
        {
            Player randomPlayer = null;
            var randomPlayers = new List<Player>();
            for (int i = 0; i < numbersOfPlayers; i++)
            {
                randomPlayer = new Player(random.Next(1, 10001));
                randomPlayers.Add(randomPlayer);
            }
            return randomPlayers;
        }
    }
}
