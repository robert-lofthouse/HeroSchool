using HeroSchool.Interface;
using HeroSchool.Model;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HeroSchool.Repository
{
    public class CardRepository : IRepository<ICard>
    {
        public void Add(ICard p_new)
        {
            switch (p_new.Type)
            {
                case Global.CardType.Attack:
                    var ActionCardRepo = new MongoRepository<ActionCard>();
                    ActionCardRepo.Add((ActionCard)p_new);
                    break;
                case Global.CardType.Defense:
                    var DefenseCardRepo = new MongoRepository<DefenseCard>();
                    DefenseCardRepo.Add((DefenseCard)p_new);
                    break;
                default:
                    var ModifierCardRepo = new MongoRepository<ModifierCard>();
                    ModifierCardRepo.Add((ModifierCard)p_new);
                    break;
            }
        }

        public void Delete(ICard p_del)
        {
            switch (p_del.Type)
            {
                case Global.CardType.Attack:
                    var ActionCardRepo = new MongoRepository<ActionCard>();
                    ActionCardRepo.Add((ActionCard)p_del);
                    break;
                case Global.CardType.Defense:
                    var DefenseCardRepo = new MongoRepository<DefenseCard>();
                    DefenseCardRepo.Add((DefenseCard)p_del);
                    break;
                default:
                    var ModifierCardRepo = new MongoRepository<ModifierCard>();
                    ModifierCardRepo.Add((ModifierCard)p_del);
                    break;
            }
        }

        public IList<ICard> Get()
        {

            try
            {
                var ActionCardRepo = new MongoRepository<ActionCard>();
                var ModifierCardRepo = new MongoRepository<DefenseCard>();
                var DefenseCardRepo = new MongoRepository<ModifierCard>();

                IList<ActionCard> ActionCardlist = ActionCardRepo.Get();
                IList<ModifierCard> DefenseCardlist = DefenseCardRepo.Get();
                IList<DefenseCard> ModifierCardlist = ModifierCardRepo.Get();

                IList<ICard> cardlist = new List<ICard>();
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

        public ICard Get(Tuple<string, string> p_get)
        {
            ICard retcard = null;

            var atkcardRepo = new MongoRepository<ActionCard>();
            ICard atkcard = atkcardRepo.Get(new Tuple<string, string>(p_get.Item1, p_get.Item2));
            if (atkcard != null)
            {
                retcard = atkcard;
            }
            else
            {
                var defcardRepo = new MongoRepository<DefenseCard>();
                ICard defCard = defcardRepo.Get(new Tuple<string, string>(p_get.Item1, p_get.Item2));
                if (defCard != null)
                {
                    retcard = defCard;
                }
                else
                {
                    var modcardRepo = new MongoRepository<ModifierCard>();
                    ICard modCard = modcardRepo.Get(new Tuple<string, string>(p_get.Item1, p_get.Item2));
                    if (modCard != null)
                        retcard = modCard;
                }
            }

            return retcard;
        }

        public void Update(ICard p_upd)
        {
            Add(p_upd);
        }

        public void Update(IList<ICard> p_upds)
        {
            throw new NotImplementedException();
        }
    }
}
