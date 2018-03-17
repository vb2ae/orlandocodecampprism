// To parse this JSON data, add NuGet 'Newtonsoft.Json' then do:
//
//    using OrlandoDemo.Models;
//
//    var welcome = Welcome.FromJson(jsonString);

namespace OrlandoDemo.Models
{
    using System;
    using System.Collections.Generic;
    using System.Net;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class Welcome
    {
        [JsonProperty("took")]
        public long Took { get; set; }

        [JsonProperty("timed_out")]
        public bool TimedOut { get; set; }

        [JsonProperty("_shards")]
        public Shards Shards { get; set; }

        [JsonProperty("hits")]
        public Hits Hits { get; set; }
    }

    public partial class Hits
    {
        [JsonProperty("total")]
        public long Total { get; set; }

        [JsonProperty("max_score")]
        public object MaxScore { get; set; }

        [JsonProperty("hits")]
        public Hit[] HitsHits { get; set; }
    }

    public partial class Hit
    {
        [JsonProperty("_index")]
        public Index Index { get; set; }

        [JsonProperty("_type")]
        public HitType Type { get; set; }

        [JsonProperty("_id")]
        public string Id { get; set; }

        [JsonProperty("_score")]
        public object Score { get; set; }

        [JsonProperty("_source")]
        public Source Source { get; set; }

        [JsonProperty("sort")]
        public long[] Sort { get; set; }
    }

    public partial class Source
    {
        [JsonProperty("event-date-count")]
        public long EventDateCount { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("nid")]
        public string Nid { get; set; }

        [JsonProperty("type")]
        public SourceType Type { get; set; }

        [JsonProperty("changed")]
        public string Changed { get; set; }

        [JsonProperty("uuid")]
        public string Uuid { get; set; }

        [JsonProperty("name")]
        public Name Name { get; set; }

        [JsonProperty("uri")]
        public string Uri { get; set; }

        [JsonProperty("additional-link1")]
        public AdditionalLink1[] AdditionalLink1 { get; set; }

        [JsonProperty("calendar-name")]
        public CalendarName[] CalendarName { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("event-date")]
        public EventDate[] EventDate { get; set; }

        [JsonProperty("master-image")]
        public MasterImage MasterImage { get; set; }

        [JsonProperty("date-format")]
        public string[] DateFormat { get; set; }

        [JsonProperty("is-all-day")]
        public bool? IsAllDay { get; set; }
    }

    public partial class AdditionalLink1
    {
        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("title")]
        public Title Title { get; set; }

        [JsonProperty("attributes")]
        public object[] Attributes { get; set; }
    }

    public partial class EventDate
    {
        [JsonProperty("value")]
        public System.DateTimeOffset Value { get; set; }

        [JsonProperty("value2")]
        public System.DateTimeOffset Value2 { get; set; }

        [JsonProperty("rrule")]
        public object Rrule { get; set; }

        [JsonProperty("timezone")]
        public Timezone Timezone { get; set; }

        [JsonProperty("timezone_db")]
        public TimezoneDb TimezoneDb { get; set; }

        [JsonProperty("date_type")]
        public DateType DateType { get; set; }
    }

    public partial class MasterImage
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("fid")]
        public string Fid { get; set; }

        [JsonProperty("uri")]
        public string Uri { get; set; }

        [JsonProperty("width")]
        public string Width { get; set; }

        [JsonProperty("height")]
        public string Height { get; set; }
    }

    public partial class Shards
    {
        [JsonProperty("total")]
        public long Total { get; set; }

        [JsonProperty("successful")]
        public long Successful { get; set; }

        [JsonProperty("failed")]
        public long Failed { get; set; }
    }

    public enum Index { NasaBluePublic };

    public enum Title { FullDetails };

    public enum CalendarName { The6089, The6090 };

    public enum DateType { Date };

    public enum Timezone { AmericaNewYork };

    public enum TimezoneDb { Utc };

    public enum Name { SarahLoff };

    public enum SourceType { CalendarEvent };

    public enum HitType { CalendarEvent };

    public partial class Welcome
    {
        public static Welcome FromJson(string json) => JsonConvert.DeserializeObject<Welcome>(json, OrlandoDemo.Models.Converter.Settings);
    }

    static class IndexExtensions
    {
        public static Index? ValueForString(string str)
        {
            switch (str)
            {
                case "nasa-blue-public": return Index.NasaBluePublic;
                default: return null;
            }
        }

        public static Index ReadJson(JsonReader reader, JsonSerializer serializer)
        {
            var str = serializer.Deserialize<string>(reader);
            var maybeValue = ValueForString(str);
            if (maybeValue.HasValue) return maybeValue.Value;
            throw new Exception("Unknown enum case " + str);
        }

        public static void WriteJson(this Index value, JsonWriter writer, JsonSerializer serializer)
        {
            switch (value)
            {
                case Index.NasaBluePublic: serializer.Serialize(writer, "nasa-blue-public"); break;
            }
        }
    }

    static class TitleExtensions
    {
        public static Title? ValueForString(string str)
        {
            switch (str)
            {
                case "Full Details": return Title.FullDetails;
                default: return null;
            }
        }

        public static Title ReadJson(JsonReader reader, JsonSerializer serializer)
        {
            var str = serializer.Deserialize<string>(reader);
            var maybeValue = ValueForString(str);
            if (maybeValue.HasValue) return maybeValue.Value;
            throw new Exception("Unknown enum case " + str);
        }

        public static void WriteJson(this Title value, JsonWriter writer, JsonSerializer serializer)
        {
            switch (value)
            {
                case Title.FullDetails: serializer.Serialize(writer, "Full Details"); break;
            }
        }
    }

    static class CalendarNameExtensions
    {
        public static CalendarName? ValueForString(string str)
        {
            switch (str)
            {
                case "6089": return CalendarName.The6089;
                case "6090": return CalendarName.The6090;
                default: return null;
            }
        }

        public static CalendarName ReadJson(JsonReader reader, JsonSerializer serializer)
        {
            var str = serializer.Deserialize<string>(reader);
            var maybeValue = ValueForString(str);
            if (maybeValue.HasValue) return maybeValue.Value;
            throw new Exception("Unknown enum case " + str);
        }

        public static void WriteJson(this CalendarName value, JsonWriter writer, JsonSerializer serializer)
        {
            switch (value)
            {
                case CalendarName.The6089: serializer.Serialize(writer, "6089"); break;
                case CalendarName.The6090: serializer.Serialize(writer, "6090"); break;
            }
        }
    }

    static class DateTypeExtensions
    {
        public static DateType? ValueForString(string str)
        {
            switch (str)
            {
                case "date": return DateType.Date;
                default: return null;
            }
        }

        public static DateType ReadJson(JsonReader reader, JsonSerializer serializer)
        {
            var str = serializer.Deserialize<string>(reader);
            var maybeValue = ValueForString(str);
            if (maybeValue.HasValue) return maybeValue.Value;
            throw new Exception("Unknown enum case " + str);
        }

        public static void WriteJson(this DateType value, JsonWriter writer, JsonSerializer serializer)
        {
            switch (value)
            {
                case DateType.Date: serializer.Serialize(writer, "date"); break;
            }
        }
    }

    static class TimezoneExtensions
    {
        public static Timezone? ValueForString(string str)
        {
            switch (str)
            {
                case "America/New_York": return Timezone.AmericaNewYork;
                default: return null;
            }
        }

        public static Timezone ReadJson(JsonReader reader, JsonSerializer serializer)
        {
            var str = serializer.Deserialize<string>(reader);
            var maybeValue = ValueForString(str);
            if (maybeValue.HasValue) return maybeValue.Value;
            throw new Exception("Unknown enum case " + str);
        }

        public static void WriteJson(this Timezone value, JsonWriter writer, JsonSerializer serializer)
        {
            switch (value)
            {
                case Timezone.AmericaNewYork: serializer.Serialize(writer, "America/New_York"); break;
            }
        }
    }

    static class TimezoneDbExtensions
    {
        public static TimezoneDb? ValueForString(string str)
        {
            switch (str)
            {
                case "UTC": return TimezoneDb.Utc;
                default: return null;
            }
        }

        public static TimezoneDb ReadJson(JsonReader reader, JsonSerializer serializer)
        {
            var str = serializer.Deserialize<string>(reader);
            var maybeValue = ValueForString(str);
            if (maybeValue.HasValue) return maybeValue.Value;
            throw new Exception("Unknown enum case " + str);
        }

        public static void WriteJson(this TimezoneDb value, JsonWriter writer, JsonSerializer serializer)
        {
            switch (value)
            {
                case TimezoneDb.Utc: serializer.Serialize(writer, "UTC"); break;
            }
        }
    }

    static class NameExtensions
    {
        public static Name? ValueForString(string str)
        {
            switch (str)
            {
                case "Sarah Loff": return Name.SarahLoff;
                default: return null;
            }
        }

        public static Name ReadJson(JsonReader reader, JsonSerializer serializer)
        {
            var str = serializer.Deserialize<string>(reader);
            var maybeValue = ValueForString(str);
            if (maybeValue.HasValue) return maybeValue.Value;
            throw new Exception("Unknown enum case " + str);
        }

        public static void WriteJson(this Name value, JsonWriter writer, JsonSerializer serializer)
        {
            switch (value)
            {
                case Name.SarahLoff: serializer.Serialize(writer, "Sarah Loff"); break;
            }
        }
    }

    static class SourceTypeExtensions
    {
        public static SourceType? ValueForString(string str)
        {
            switch (str)
            {
                case "calendar_event": return SourceType.CalendarEvent;
                default: return null;
            }
        }

        public static SourceType ReadJson(JsonReader reader, JsonSerializer serializer)
        {
            var str = serializer.Deserialize<string>(reader);
            var maybeValue = ValueForString(str);
            if (maybeValue.HasValue) return maybeValue.Value;
            throw new Exception("Unknown enum case " + str);
        }

        public static void WriteJson(this SourceType value, JsonWriter writer, JsonSerializer serializer)
        {
            switch (value)
            {
                case SourceType.CalendarEvent: serializer.Serialize(writer, "calendar_event"); break;
            }
        }
    }

    static class HitTypeExtensions
    {
        public static HitType? ValueForString(string str)
        {
            switch (str)
            {
                case "calendar-event": return HitType.CalendarEvent;
                default: return null;
            }
        }

        public static HitType ReadJson(JsonReader reader, JsonSerializer serializer)
        {
            var str = serializer.Deserialize<string>(reader);
            var maybeValue = ValueForString(str);
            if (maybeValue.HasValue) return maybeValue.Value;
            throw new Exception("Unknown enum case " + str);
        }

        public static void WriteJson(this HitType value, JsonWriter writer, JsonSerializer serializer)
        {
            switch (value)
            {
                case HitType.CalendarEvent: serializer.Serialize(writer, "calendar-event"); break;
            }
        }
    }

    public static class Serialize
    {
        public static string ToJson(this Welcome self) => JsonConvert.SerializeObject(self, OrlandoDemo.Models.Converter.Settings);
    }

    internal class Converter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(Index) || t == typeof(Title) || t == typeof(CalendarName) || t == typeof(DateType) || t == typeof(Timezone) || t == typeof(TimezoneDb) || t == typeof(Name) || t == typeof(SourceType) || t == typeof(HitType) || t == typeof(Index?) || t == typeof(Title?) || t == typeof(CalendarName?) || t == typeof(DateType?) || t == typeof(Timezone?) || t == typeof(TimezoneDb?) || t == typeof(Name?) || t == typeof(SourceType?) || t == typeof(HitType?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (t == typeof(Index))
                return IndexExtensions.ReadJson(reader, serializer);
            if (t == typeof(Title))
                return TitleExtensions.ReadJson(reader, serializer);
            if (t == typeof(CalendarName))
                return CalendarNameExtensions.ReadJson(reader, serializer);
            if (t == typeof(DateType))
                return DateTypeExtensions.ReadJson(reader, serializer);
            if (t == typeof(Timezone))
                return TimezoneExtensions.ReadJson(reader, serializer);
            if (t == typeof(TimezoneDb))
                return TimezoneDbExtensions.ReadJson(reader, serializer);
            if (t == typeof(Name))
                return NameExtensions.ReadJson(reader, serializer);
            if (t == typeof(SourceType))
                return SourceTypeExtensions.ReadJson(reader, serializer);
            if (t == typeof(HitType))
                return HitTypeExtensions.ReadJson(reader, serializer);
            if (t == typeof(Index?))
            {
                if (reader.TokenType == JsonToken.Null) return null;
                return IndexExtensions.ReadJson(reader, serializer);
            }
            if (t == typeof(Title?))
            {
                if (reader.TokenType == JsonToken.Null) return null;
                return TitleExtensions.ReadJson(reader, serializer);
            }
            if (t == typeof(CalendarName?))
            {
                if (reader.TokenType == JsonToken.Null) return null;
                return CalendarNameExtensions.ReadJson(reader, serializer);
            }
            if (t == typeof(DateType?))
            {
                if (reader.TokenType == JsonToken.Null) return null;
                return DateTypeExtensions.ReadJson(reader, serializer);
            }
            if (t == typeof(Timezone?))
            {
                if (reader.TokenType == JsonToken.Null) return null;
                return TimezoneExtensions.ReadJson(reader, serializer);
            }
            if (t == typeof(TimezoneDb?))
            {
                if (reader.TokenType == JsonToken.Null) return null;
                return TimezoneDbExtensions.ReadJson(reader, serializer);
            }
            if (t == typeof(Name?))
            {
                if (reader.TokenType == JsonToken.Null) return null;
                return NameExtensions.ReadJson(reader, serializer);
            }
            if (t == typeof(SourceType?))
            {
                if (reader.TokenType == JsonToken.Null) return null;
                return SourceTypeExtensions.ReadJson(reader, serializer);
            }
            if (t == typeof(HitType?))
            {
                if (reader.TokenType == JsonToken.Null) return null;
                return HitTypeExtensions.ReadJson(reader, serializer);
            }
            throw new Exception("Unknown type");
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var t = value.GetType();
            if (t == typeof(Index))
            {
                ((Index)value).WriteJson(writer, serializer);
                return;
            }
            if (t == typeof(Title))
            {
                ((Title)value).WriteJson(writer, serializer);
                return;
            }
            if (t == typeof(CalendarName))
            {
                ((CalendarName)value).WriteJson(writer, serializer);
                return;
            }
            if (t == typeof(DateType))
            {
                ((DateType)value).WriteJson(writer, serializer);
                return;
            }
            if (t == typeof(Timezone))
            {
                ((Timezone)value).WriteJson(writer, serializer);
                return;
            }
            if (t == typeof(TimezoneDb))
            {
                ((TimezoneDb)value).WriteJson(writer, serializer);
                return;
            }
            if (t == typeof(Name))
            {
                ((Name)value).WriteJson(writer, serializer);
                return;
            }
            if (t == typeof(SourceType))
            {
                ((SourceType)value).WriteJson(writer, serializer);
                return;
            }
            if (t == typeof(HitType))
            {
                ((HitType)value).WriteJson(writer, serializer);
                return;
            }
            throw new Exception("Unknown type");
        }

        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters = {
                new Converter(),
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }
}
