using GetAddress.Sdk.Services;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace GetAddress.Sdk
{
    public class GetAddressApi
    {

        private readonly FindService findService;
        private readonly AutocompleteService autocompleteService;
        private readonly GetService getService;
        private readonly TypeaheadService typeaheadService;
        public GetAddressApi(HttpClient httpClient = null) : this(null,null, httpClient: httpClient)
        {
            
        }
        public GetAddressApi(string apiKey, string administrationKey, HttpClient httpClient = null)
        {
            httpClient = httpClient ?? new GetAddressHttpClient();
            Security = new Security(apiKey, administrationKey, httpClient: httpClient);
            findService = new FindService(apiKey, httpClient: httpClient);
            autocompleteService = new AutocompleteService(apiKey, httpClient: httpClient);
            getService = new GetService(apiKey, httpClient: httpClient);
            typeaheadService = new TypeaheadService(apiKey, httpClient: httpClient);
            InvoiceEmailRecipient = new InvoiceEmailRecipientService(administrationKey, httpClient: httpClient);
        }
        public InvoiceEmailRecipientService InvoiceEmailRecipient
        {
            get;
        }

        public Security Security
        {
            get;
        }
        public async Task<Result<SuccessfulFind>> Find(string postcode, FindOptions options =null, AccessToken  accessToken = null, CancellationToken cancellationToken = default)
        {
            return await findService.Find(postcode, options: options, accessToken: accessToken, cancellationToken: cancellationToken);
        }

        public async Task<Result<SuccessfulAutocomplete>> Autocomplete(string term, AutocompleteOptions options = null, AccessToken accessToken = null, CancellationToken cancellationToken = default)
        {
            return await autocompleteService.Autocomplete(term, options: options, accessToken: accessToken, cancellationToken: cancellationToken);
        }

        public async Task<Result<SuccessfulGet>> Get(Suggestion  suggestion, AccessToken accessToken = null, CancellationToken cancellationToken = default)
        {
            return await getService.Get(suggestion,accessToken: accessToken, cancellationToken: cancellationToken);
        }

        public async Task<Result<string[]>> Typeahead(string term, TypeaheadOptions options = null, AccessToken accessToken = null, CancellationToken cancellationToken = default)
        {
            return await typeaheadService.Typeahead(term, options:options, accessToken: accessToken, cancellationToken: cancellationToken);
        }

    }
}
