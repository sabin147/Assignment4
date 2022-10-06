using Assignment1;
using System.Xml.Linq;

namespace Assignment4.Managers
{
    public class FootballPlayersManager
    {
        private static int _nextID = 1;
        private static readonly List<FootballPlayer> Data = new List<FootballPlayer>()
        {
            new FootballPlayer(){Id = _nextID++, Name="Sabin", Age=21, ShirtNumber= 1 },
            new FootballPlayer(){Id = _nextID++, Name="Adeel", Age=22, ShirtNumber= 2 },
            new FootballPlayer(){Id = _nextID++, Name="Saugat", Age=23, ShirtNumber= 3 },
            new FootballPlayer(){Id = _nextID++, Name="Ravi", Age=24, ShirtNumber= 4 }
        };

        //public IEnumerable<FootballPlayer> GetAll(string? nameFilter)
        //{
        //    List<FootballPlayer> result = new List<FootballPlayer>(Data);
        //    if (nameFilter != null)
        //    {
        //        result = result.FindAll(player => player.Name.Contains(nameFilter, StringComparison.InvariantCultureIgnoreCase));
        //    } 
         
        //    return result;
        //}

        public List<FootballPlayer> GetAll()
        {
            return new List<FootballPlayer>(Data);
        }

        public FootballPlayer? GetById(int id)
        {
            return Data.Find(football => football.Id == id);
        }

        public FootballPlayer Add(FootballPlayer newFootballPlayer)
        {
           newFootballPlayer.Id = _nextID++;
            Data.Add(newFootballPlayer);
            return newFootballPlayer;
        }

        public FootballPlayer? Delete(int id)
        {
            FootballPlayer? player = Data.Find(player1 => player1.Id == id);
            if (player == null) return null;
            Data.Remove(player);
            return player;
        }

        public FootballPlayer? Update(int id, FootballPlayer updates)
        {

            FootballPlayer? player = Data.Find(player1 => player1.Id == id);
            if (player == null) return null;
            player.Name = updates.Name;
            player.Age = updates.Age;
            player.ShirtNumber = updates.ShirtNumber;
            return player;
        }
    }
}
