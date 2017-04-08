using HeroSchool.Converters;
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
            IMongoCollection<BsonDocument> MongoCardCollection = Global.CreateConnection("Card");

            try
            {
                UpdateOptions options = new UpdateOptions { IsUpsert = true };

                FilterDefinition<BsonDocument> filter = new BsonDocument("_id", p_new._id);

                var jsonobject = BsonDocument.Parse(JsonConvert.SerializeObject(p_new));
                jsonobject.Remove("_id");

                UpdateDefinition<BsonDocument> update = new BsonDocument("$set", jsonobject );

                MongoCardCollection.UpdateOne(filter, update, options);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void Delete(Card p_del)
        {
            IMongoCollection<BsonDocument> MongoCardCollection = Global.CreateConnection("Card");

            try
            {
                var item = MongoCardCollection.DeleteOne("{'_id':{'$eq':'" + p_del._id + "'}}");
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public IList<Card> Get()
        {
            IMongoCollection<BsonDocument> MongoCardCollection = Global.CreateConnection("Card");

            try
            {
                IList<Card> cardList = new List<Card>();

                foreach (var item in MongoCardCollection.Find(new BsonDocument()).ToList())
                {
                    int.TryParse(item["Type"].ToString(), out int icardtype);

                    switch ((Global.CardType)icardtype)
                    {
                        case Global.CardType.Modifier:
                            cardList.Add(JsonConvert.DeserializeObject<ModifierCard>(item.ToJson()));
                            break;
                        case Global.CardType.Defense:
                            cardList.Add(JsonConvert.DeserializeObject<DefenseCard>(item.ToJson()));
                            break;
                        default:
                            cardList.Add(JsonConvert.DeserializeObject<ActionCard>(item.ToJson()));
                            break;
                    }
                    
                }
                return cardList;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public Card Get(KeyValuePair<string, string> p_get)
        {
            IMongoCollection<BsonDocument> MongoCardCollection = Global.CreateConnection("Card");

            try
            {
                var item = MongoCardCollection.Find("{'"+ p_get.Key +"':{'$eq':'" + p_get.Value + "'}}").ToList()[0];
                return JsonConvert.DeserializeObject<Card>(item.ToJson(), new CardConverter());
            }
            catch (Exception ex)
            {
                throw;
            }
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
