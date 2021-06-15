using System.Collections.Specialized;

namespace GetAddress
{
    public class FindOptions: Options
    {
        public string HouseNameOrNumber { get; set; }

        public NameValueCollection Parameters { get; set; } = new NameValueCollection();
    }
}
