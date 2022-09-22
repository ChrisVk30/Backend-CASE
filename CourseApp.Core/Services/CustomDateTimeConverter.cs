﻿using Newtonsoft.Json.Converters;
using Newtonsoft.Json;
using System.Globalization;

namespace CourseEnv.Core.Services
{
    public class CustomDateTimeConverter : DateTimeConverterBase
    {
        private const string Format = "dd/MM/yyyy";

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            writer.WriteValue(((DateTime)value).ToString(Format));
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.Value == null)
            {
                return null;
            }

            var s = reader.Value.ToString();
            DateTime result;
            if (DateTime.TryParseExact(s, Format, CultureInfo.InvariantCulture, DateTimeStyles.None, out result))
            {
                return result;
            }
            return null;
        }
    }
}