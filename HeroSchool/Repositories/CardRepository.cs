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
    public class CardRepository : IRepository<ICard>
    {
        public void Add(ICard p_new)
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

        public void Delete(ICard p_del)
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

        public IList<ICard> Get()
        {
            IMongoCollection<BsonDocument> MongoCardCollection = Global.CreateConnection("Card");

            try
            {
                IList<ICard> cardList = new List<ICard>();

                foreach (var item in MongoCardCollection.Find(new BsonDocument()).ToList())
                {
                    cardList.Add(JsonConvert.DeserializeObject<Card>(item.ToJson(), new CardConverter()));
                }
                return cardList;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public ICard Get(ICard p_get)
        {
            IMongoCollection<BsonDocument> MongoCardCollection = Global.CreateConnection("Card");

            try
            {
                var item = MongoCardCollection.Find("{'Name':{'$eq':'" + p_get.Name + "'}}").ToList()[0];
                return JsonConvert.DeserializeObject<Card>(item.ToJson(), new CardConverter());
            }
            catch (Exception ex)
            {
                throw;
            }
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
