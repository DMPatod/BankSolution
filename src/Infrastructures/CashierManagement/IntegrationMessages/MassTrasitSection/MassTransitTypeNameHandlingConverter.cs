using Newtonsoft.Json;
using System;

namespace CashierManagementInfractureLayer.IntegrationMessages.MassTrasitSection
{
    internal class MassTransitTypeNameHandlingConverter : JsonConverter
    {
        private readonly TypeNameHandling typeNameHandling;
        public MassTransitTypeNameHandlingConverter(TypeNameHandling typeNameHandling)
        {
            this.typeNameHandling = typeNameHandling;
        }
        private static bool IsMassTransitOrSystemType(Type objectType)
        {
            return objectType.Assembly == typeof(MassTransit.IConsumer).Assembly ||
                objectType.Assembly.IsDynamic ||
                objectType.Assembly == typeof(object).Assembly;
        }
        public override bool CanConvert(Type objectType)
        {
            return !IsMassTransitOrSystemType(objectType);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var obj = new JsonSerializer
            {
                TypeNameHandling = typeNameHandling
            }
            .Deserialize(reader, objectType);
            return obj;
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            new JsonSerializer
            {
                TypeNameHandling = typeNameHandling
            }
            .Serialize(writer, value);
        }
    }
}
