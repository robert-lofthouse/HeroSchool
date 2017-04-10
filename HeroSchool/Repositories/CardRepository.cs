using HeroSchool.Converters;
using HeroSchool.Factories;
using HeroSchool.Interfaces;
using MongoDB.Bson;
using MongoDB.Driver;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroSchool.Repositories
{
    public class CardRepository : IRepository<Card>
    {
        public void Add(Card p_new)
        {
            switch (p_new.Type)
            {
                case Global.CardType.Attack:
                    var ActionCardRepo = new Repository<ActionCard>();
                    ActionCardRepo.Add((ActionCard)p_new);
                    break;
                case Global.CardType.Defense:
                    var DefenseCardRepo = new Repository<DefenseCard>();
                    DefenseCardRepo.Add((DefenseCard)p_new);
                    break;
                default:
                    var ModifierCardRepo = new Repository<ModifierCard>();
                    ModifierCardRepo.Add((ModifierCard)p_new);
                    break;
            }
        }

        public void Delete(Card p_del)
        {
            switch (p_del.Type)
            {
                case Global.CardType.Attack:
                    var ActionCardRepo = new Repository<ActionCard>();
                    ActionCardRepo.Add((ActionCard)p_del);
                    break;
                case Global.CardType.Defense:
                    var DefenseCardRepo = new Repository<DefenseCard>();
                    DefenseCardRepo.Add((DefenseCard)p_del);
                    break;
                default:
                    var ModifierCardRepo = new Repository<ModifierCard>();
                    ModifierCardRepo.Add((ModifierCard)p_del);
                    break;
            }
        }

        public IList<Card> Get()
        {

            try
            {
                Repository<ActionCard> ActionCardRepo = new Repository<ActionCard>();
                Repository<ModifierCard> ModifierCardRepo = new Repository<ModifierCard>();
                Repository<DefenseCard> DefenseCardRepo = new Repository<DefenseCard>();

                IList<ActionCard> ActionCardlist = ActionCardRepo.Get();
                IList<ModifierCard> ModifierCardlist = ModifierCardRepo.Get();
                IList<DefenseCard> DefenseCardlist = DefenseCardRepo.Get();

                IList<Card> cardlist = new List<Card>();
                cardlist = cardlist.Concat(ActionCardlist).ToList();
                cardlist = cardlist.Concat(DefenseCardlist).ToList();
                cardlist = cardlist.Concat(ModifierCardlist).ToList();

                return cardlist;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public Card Get(KeyValuePair<string, string> p_get)
        {
            Card retcard = null;

            Repository<ActionCard> atkcardRepo = new Repository<ActionCard>();
            Card atkcard = atkcardRepo.Get(new Tuple<string, string>(p_get.Key, p_get.Value));
            if (atkcard != null)
            {
                retcard = atkcard;
            }
            else
            {
                Repository<DefenseCard> defcardRepo = new Repository<DefenseCard>();
                Card defCard = defcardRepo.Get(new Tuple<string, string>(p_get.Key, p_get.Value));
                if (defCard != null)
                {
                    retcard = defCard;
                }
                else
                {
                    Repository<ModifierCard> modcardRepo = new Repository<ModifierCard>();
                    Card modCard = modcardRepo.Get(new Tuple<string, string>(p_get.Key, p_get.Value));
                    if (modCard != null)
                        retcard = modCard;
                }
            }

            return retcard;
        }

        public void Update(Card p_upd)
        {
            Add(p_upd);
        }

        public void Update(IList<Card> p_upds)
        {
            throw new NotImplementedException();
        }
    }
}
