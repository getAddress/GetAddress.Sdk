namespace GetAddress
{
    public class ApiKeys
    {
        public AddressLookupKey AddressLookupKey { get; set; }
        public AdministrationKey AdministrationKey { get; set; }

        public ApiKeys(string addressLookupKey, string administrationKey)
        {
            AddressLookupKey = new AddressLookupKey { Key = addressLookupKey };
            AdministrationKey = new AdministrationKey { Key = administrationKey };
        }
    }

    public class AddressLookupKey
    {
        public string Key { get; set; }
    }
    public class AdministrationKey
    {
        public string Key { get; set; }
    }
}
