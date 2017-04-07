using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroSchool.Converters
{
    class BattleConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return (objectType == typeof(Battle));
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JObject jo = JObject.Load(reader);
            string _id = (string)jo["_id"];
            string hero1playerid = (string)jo["Hero1PlayerID"];
            string hero2playerid = (string)jo["Hero2PlayerID"];
            string hero1schoolid = (string)jo["Hero1SchoolID"];
            string hero2schoolid = (string)jo["Hero2SchoolID"];
            string hero1id = (string)jo["Hero1ID"];
            string hero2id = (string)jo["Hero2ID"];
            string winningheroid = (string)jo["WinningHeroID"];
            return new Battle(_id, hero1schoolid, hero1playerid, hero1id, hero2schoolid, hero2playerid, hero2id, winningheroid);
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
