using HeroSchool.Interfaces;
using HeroSchool.Repositories;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroSchool.Converters
{
    class PlayerConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return (objectType == typeof(Player));
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            IRepository<Card> cardRepo = new CardRepository();

            JObject jo = JObject.Load(reader);
            string name = (string)jo["Name"];
            string id = (string)jo["_id"];
            JArray CardCollection = (JArray)jo["CardCollection"];
            JArray Heroes = (JArray)jo["Heroes"];

            IPlayer player = new Player(name, cardRepo, id);

            foreach (var item in CardCollection)
            {
                Card playersCard = (Card)cardRepo.Get(new KeyValuePair<string, string>("_id", (string)item["_id"]));
                player.AddCardtoCollection(playersCard);
            }

            return player;

        }

        public override bool CanWrite
        {
            get { return false; }
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
