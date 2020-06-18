using System.Collections.Generic;

namespace Hateoas.Models
{

    public class Resource
    {
        public List<LinkDTO> _links { get; set; } = new List<LinkDTO>();
    }

    public class ResourceCollection<T> : Resource where T : Resource
    {
        public List<T> Values { get; set; }
        public ResourceCollection(List<T> values)
        {
            Values = values;
        }
    }
}