using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroSchool
{
    public class School
    {
        private List<Player> players;
        private List<Card> cards;

        public List<Player> Players { get => players; set => players = value; }
        public List<Card> Cards { get => cards; set => cards = value; }


        public School()
        {
            players = new List<Player>();
            cards = new List<Card>();

        }

        /// <summary>
        /// Creates a new card and adds it to the master cards collection 
        /// </summary>
        /// <param name="p_name"></param>
        /// <param name="p_value"></param>
        /// <param name="p_cardType"></param>
        /// <returns></returns>
        public bool CreateCard(string p_name, int p_value, Constants.CardType p_cardType)
        {
            try
            {
                switch (p_cardType)
                {
                    case Constants.CardType.Attack:
                        cards.Add(new AttackCard(p_name, p_value));
                        break;
                    case Constants.CardType.Defense:
                        cards.Add(new DefenseCard(p_name, p_value));
                        break;
                    case Constants.CardType.Modifier:
                        cards.Add(new ModifierCard(p_name, p_value));
                        break;
                    default:
                        return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
                throw;
            }
        }

        /// <summary>
        /// returns all cards matching the name and type passed in 
        /// </summary>
        /// <param name="CardName"></param>
        /// <param name="p_cardType"></param>
        /// <returns></returns>
        public List<Card> GetCard(string CardName, Constants.CardType p_cardType)
        {
            return cards.FindAll(x => x.Name == CardName && x.Type == p_cardType);
        }

        /// <summary>
        /// returns all cards matching the name
        /// </summary>
        /// <param name="CardName"></param>
        /// <returns></returns>
        public List<Card> GetCard(string CardName)
        {
            return cards.FindAll(x => x.Name == CardName);
        }

        /// <summary>
        /// Create a new player object and add it to the players collection
        /// </summary>
        /// <param name="p_Playername"></param>
        /// <returns></returns>
        public Player CreatePlayer(string p_Playername)
        {
            try
            {
                Player newPlayer = null;
                if (players.Exists(c => c.PlayerName == p_Playername))
                {
                    throw new Exception(string.Format("{0} already exists in the player list", p_Playername));
                }
                else
                {
                    newPlayer = new Player(p_Playername);
                    players.Add(newPlayer);
                }
                return newPlayer;
            }
            catch (Exception ex)
            {

                throw;
            }
        }


    }
}
