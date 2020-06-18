
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Hateoas.Models
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum RestMehods
    {
        GET = 1,
        POST,
        PUT,
        PATCH,
        DELETE,
    }

    public class LinkDTO
    {
        public string Href { get; private set; }
        public string Rel { get; private set; }
        public RestMehods Method { get; private set; }
        public LinkDTO(string href, string rel, RestMehods method)
        {
            Href = href;
            Rel = rel;
            Method = method;
        }
    }
}