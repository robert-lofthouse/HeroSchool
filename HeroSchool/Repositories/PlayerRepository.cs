using HeroSchool.Converters;
using HeroSchool.Interfaces;
using MongoDB.Bson;
using MongoDB.Driver;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroSchool.Repositories
{
    public class PlayerRepository : IRepository<IPlayer>
    {
        public void Add(IPlayer p_new)
        {
            IMongoCollection<BsonDocument> MongoCardCollection = Global.CreateConnection("Player");

            try
            {
                UpdateOptions options = new UpdateOptions { IsUpsert = true };

                FilterDefinition<BsonDocument> filter = new BsonDocument("_id", p_new._id);

                var jsonobject = BsonDocument.Parse(JsonConvert.SerializeObject(p_new));
                jsonobject.Remove("_id");

                UpdateDefinition<BsonDocument> update = new BsonDocument("$set", jsonobject);

                MongoCardCollection.UpdateOne(filter, update, options);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void Delete(IPlayer p_del)
        {
            IMongoCollection<BsonDocument> MongoCardCollection = Global.CreateConnection("Player");

            try
            {
                var item = MongoCardCollection.DeleteOne("{'_id':{'$eq':'" + p_del._id + "'}}");
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public IList<IPlayer> Get()
        {
            IMongoCollection<BsonDocument> MongoCardCollection = Global.CreateConnection("Player");

            try
            {
                IList<IPlayer> playerList = new List<IPlayer>();

                foreach (var item in MongoCardCollection.Find(new BsonDocument()).ToList())
                {
                    playerList.Add(JsonConvert.DeserializeObject<Player>(item.ToJson()));
                }
                return playerList;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public IPlayer Get(KeyValuePair<string,string> p_get)
        {
            IMongoCollection<BsonDocument> MongoCardCollection = Global.CreateConnection("Player");

            try
            {
                var item = MongoCardCollection.Find("{'" + p_get.Key + "':{'$eq':'" + p_get.Value + "'}}").ToList()[0];
                return JsonConvert.DeserializeObject<Player>(item.ToJson(), new PlayerConverter());
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void Update(IPlayer p_upd)
        {
            Add(p_upd);
        }

        public void Update(IList<IPlayer> p_upds)
        {
            throw new NotImplementedException();
        }
    }
}
