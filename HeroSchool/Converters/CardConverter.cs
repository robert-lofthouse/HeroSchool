using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroSchool.Converters
{
    class CardConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return (objectType == typeof(Card));
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JObject jo = JObject.Load(reader);
            string name = (string)jo["Name"];
            string id = (string)jo["_id"];
            int.TryParse(jo["Value"].ToString(), out int value);
            int.TryParse(jo["Type"].ToString(),out int icardtype);
            Global.CardType cardType = (Global.CardType)icardtype;
            int.TryParse(jo["Energy"].ToString(), out int energy);
            int returnEnergy = jo["ReturnEnergy"] != null ? int.Parse(jo["ReturnEnergy"].ToString()) : 0;
            switch (cardType)
            {
                case Global.CardType.Modifier:
                    return new ModifierCard(name, value, energy,id, cardType);
                default:
                    return new ActionCard(name, value, energy, cardType, returnEnergy,id);
            }
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
