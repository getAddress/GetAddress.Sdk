using GetAddress.Sdk.Services;
using System;
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
        private readonly UsageService usageService;
        private readonly DistanceService distanceService;

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
            usageService = new UsageService(administrationKey, httpClient: httpClient);
            distanceService = new DistanceService(apiKey, httpClient: httpClient);
            ExpiredEmailRecipient = new ExpiredEmailRecipientService(administrationKey, httpClient: httpClient);
            Email = new EmailService(administrationKey, httpClient: httpClient);
        }

        public async Task<Result<Usage>> Usage(AccessToken accessToken = default, CancellationToken cancellationToken = default)
        {
            return await usageService.Get(accessToken: accessToken, cancellationToken: cancellationToken);
        }

        public async Task<Result<Usage>> Usage(DateTimeOffset datetime, AccessToken accessToken = default, CancellationToken cancellationToken = default)
        {
            return await usageService.Get(datetime, accessToken: accessToken, cancellationToken: cancellationToken);
        }

        public async Task<Result<Usage[]>> Usage(DateTimeOffset from, DateTimeOffset to, 
            AccessToken accessToken = default, CancellationToken cancellationToken = default)
        {
            return await usageService.Get(from,to, accessToken: accessToken, cancellationToken: cancellationToken);
        }

        public async Task<Result<SuccessfulDistance>> Distance(string postcodeFrom, string postcodeTo,
            AccessToken accessToken = default, CancellationToken cancellationToken = default)
        {
            return await distanceService.Distance(postcodeFrom, postcodeTo, accessToken: accessToken, cancellationToken: cancellationToken);
        }

        public EmailService Email
        {
            get;
        }

        public ExpiredEmailRecipientService ExpiredEmailRecipient
        {
            get;
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
