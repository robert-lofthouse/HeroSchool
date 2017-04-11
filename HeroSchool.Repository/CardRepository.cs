using HeroSchool.Interface;
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
                    var ActionCardRepo = new Repository<IActionable>();
                    ActionCardRepo.Add((IActionable)p_new);
                    break;
                case Global.CardType.Defense:
                    var DefenseCardRepo = new Repository<IDefendable>();
                    DefenseCardRepo.Add((IDefendable)p_new);
                    break;
                default:
                    var ModifierCardRepo = new Repository<IModifier>();
                    ModifierCardRepo.Add((IModifier)p_new);
                    break;
            }
        }

        public void Delete(ICard p_del)
        {
            switch (p_del.Type)
            {
                case Global.CardType.Attack:
                    var ActionCardRepo = new Repository<IActionable>();
                    ActionCardRepo.Add((IActionable)p_del);
                    break;
                case Global.CardType.Defense:
                    var DefenseCardRepo = new Repository<IDefendable>();
                    DefenseCardRepo.Add((IDefendable)p_del);
                    break;
                default:
                    var ModifierCardRepo = new Repository<IModifier>();
                    ModifierCardRepo.Add((IModifier)p_del);
                    break;
            }
        }

        public IList<ICard> Get()
        {

            try
            {
                var ActionCardRepo = new Repository<IActionable>();
                var ModifierCardRepo = new Repository<IModifier>();
                var DefenseCardRepo = new Repository<IDefendable>();

                IList<IActionable> ActionCardlist = ActionCardRepo.Get();
                IList<IModifier> ModifierCardlist = ModifierCardRepo.Get();
                IList<IDefendable> DefenseCardlist = DefenseCardRepo.Get();

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

        public ICard Get(KeyValuePair<string, string> p_get)
        {
            ICard retcard = null;

            var atkcardRepo = new Repository<IActionable>();
            ICard atkcard = atkcardRepo.Get(new Tuple<string, string>(p_get.Key, p_get.Value));
            if (atkcard != null)
            {
                retcard = atkcard;
            }
            else
            {
                var defcardRepo = new Repository<IDefendable>();
                ICard defCard = defcardRepo.Get(new Tuple<string, string>(p_get.Key, p_get.Value));
                if (defCard != null)
                {
                    retcard = defCard;
                }
                else
                {
                    var modcardRepo = new Repository<IModifier>();
                    ICard modCard = modcardRepo.Get(new Tuple<string, string>(p_get.Key, p_get.Value));
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
