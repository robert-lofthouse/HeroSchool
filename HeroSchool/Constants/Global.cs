using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;

namespace HeroSchool
{
    public static class Global
    {
        public enum HeroClass
        {
            Strength,
            Elemental,
            Technology,
            Telekenesis,
            Magic
        }
        public enum ModifierType
        {
            Value,
            Action
        }

        public enum ModifierScope
        {
            OneOff,
            Permanent
        }

        public enum ModifierIgnoreDefenseType
        {
            FirstDefenseCard,
            AllDefenseCards
        }
        public enum CardType
        {
            Attack = 1,
            Defense = 2,
            Modifier = 3,
            Hero = 4
        }

        public enum AttackResult
        {
            AttackSuccededDamagedNotKilled,
            AttackSuccededDamagedAndKilled,
            AttackSuccededNotDamaged,
            AttackFailed
        }

        public enum RepositoryType
        {
            Player,
            Card
        }

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
    }
}
