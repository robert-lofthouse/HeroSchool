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
    public class BattleRepository : IRepository<IBattle>
    {
        public void Add(IBattle p_new)
        {
            IMongoCollection<BsonDocument> MongoCardCollection = Global.CreateConnection("Battle");

            try
            {
                UpdateOptions options = new UpdateOptions { IsUpsert = true };

                FilterDefinition<BsonDocument> filter = new BsonDocument("_id", p_new._id);

                var jsonobject = BsonDocument.Parse(JsonConvert.SerializeObject(p_new.GetSaveableVersion()));
                jsonobject.Remove("_id");

                UpdateDefinition<BsonDocument> update = new BsonDocument("$set", jsonobject);

                MongoCardCollection.UpdateOne(filter, update, options);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void Delete(IBattle p_del)
        {
            throw new NotImplementedException();
        }

        public IList<IBattle> Get()
        {
            IMongoCollection<BsonDocument> MongoCardCollection = Global.CreateConnection("Battle");

            try
            {
                IList<IBattle> battleList = new List<IBattle>();

                foreach (var item in MongoCardCollection.Find(new BsonDocument()).ToList())
                {
                    battleList.Add(JsonConvert.DeserializeObject<Battle>(item.ToJson(), new BattleConverter()));
                }
                return battleList;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public IBattle Get(KeyValuePair<string, string> p_get)
        {
            throw new NotImplementedException();
        }

        public void Update(IBattle p_upd)
        {
            throw new NotImplementedException();
        }

        public void Update(IList<IBattle> p_upds)
        {
            throw new NotImplementedException();
        }
    }
}
