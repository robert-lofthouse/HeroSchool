using HeroSchool.Interface;
using MongoDB.Bson;
using MongoDB.Driver;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HeroSchool.Repository
{
    public class Repository<T> where T : IGame
    {
        public static IMongoCollection<BsonDocument> CreateConnection(string p_collectionName)
        {
            IMongoClient MongoClient;
            IMongoDatabase MongoOvafloDatabase;
            try
            {
                MongoClient = new MongoClient("mongodb://localhost:27017");

                MongoOvafloDatabase = MongoClient.GetDatabase("HeroSchool");

                return MongoOvafloDatabase.GetCollection<BsonDocument>(p_collectionName);
            }
            catch (Exception e)
            {
                throw;
            }
        }

        private string _collectionName = typeof(T).Name;
        public void Add(T p_new)
        {

            IMongoCollection<BsonDocument> MongoCardCollection = CreateConnection(_collectionName);

            try
            {
                var options = new UpdateOptions { IsUpsert = true };

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

        public void Delete(T p_del)
        {
            IMongoCollection<BsonDocument> MongoCardCollection = CreateConnection(_collectionName);

            try
            {
                var item = MongoCardCollection.DeleteOne("{'_id':{'$eq':'" + p_del._id + "'}}");
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public IList<T> Get()
        {
            IMongoCollection<BsonDocument> MongoCardCollection = CreateConnection(_collectionName);

            try
            {
                IList<T> newList = new List<T>();

                foreach (var item in MongoCardCollection.Find(new BsonDocument()).ToList())
                {
                    newList.Add(JsonConvert.DeserializeObject<T>(item.ToJson()));
                }
                return newList;
            }
            catch (Exception ex)
                {
                throw;
            }
        }

        public T Get(Tuple<string, string> p_get)
        {
            IMongoCollection<BsonDocument> MongoCardCollection = CreateConnection(_collectionName);

            try
            {
                var itemlist = MongoCardCollection.Find("{'" + p_get.Item1 + "':{'$eq':'" + p_get.Item2 + "'}}").ToList();

                BsonDocument item = new BsonDocument();
                if (itemlist.Any())
                {
                    item = itemlist[0];
                    return JsonConvert.DeserializeObject<T>(item.ToJson());
                }
                else
                    return default(T);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void Update(T p_upd)
        {
            Add(p_upd);
        }

        public void Update(IList<T> p_upds)
        {
            throw new NotImplementedException();
        }
    }

}
