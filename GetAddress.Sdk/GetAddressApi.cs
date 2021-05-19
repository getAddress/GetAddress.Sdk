using GetAddress.Services;
using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace GetAddress
{
    public class Api
    {

        private readonly FindService findService;
        private readonly AutocompleteService autocompleteService;
        private readonly GetService getService;
        private readonly TypeaheadService typeaheadService;
        private readonly UsageService usageService;
        private readonly DistanceService distanceService;
        private readonly InvoiceService invoiceService;


        public Api(ApiKeys apiKeys, HttpClient httpClient)
        {
            Security = new Security(apiKeys, httpClient: httpClient);
            findService = new FindService(apiKeys.AddressLookupKey, httpClient: httpClient);
            autocompleteService = new AutocompleteService(apiKeys.AddressLookupKey, httpClient: httpClient);
            getService = new GetService(apiKeys.AddressLookupKey, httpClient: httpClient);
            typeaheadService = new TypeaheadService(apiKeys.AddressLookupKey, httpClient: httpClient);
            EmailNotifications = new EmailNotifications(apiKeys.AdministrationKey, httpClient: httpClient);
            usageService = new UsageService(apiKeys.AdministrationKey, httpClient: httpClient);
            distanceService = new DistanceService(apiKeys.AddressLookupKey, httpClient: httpClient);
            Subscription = new SubscriptionService(apiKeys.AdministrationKey, httpClient: httpClient);
            Plans = new PlansService(apiKeys.AdministrationKey, httpClient: httpClient);
            Webhooks = new Webhooks(apiKeys.AdministrationKey, httpClient: httpClient);
            Account = new Account(apiKeys.AdministrationKey, httpClient: httpClient);
            invoiceService = new InvoiceService(apiKeys.AdministrationKey, httpClient: httpClient);
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

        public async Task<Result<Distance>> Distance(string postcodeFrom, string postcodeTo,
            AccessToken accessToken = default, CancellationToken cancellationToken = default)
        {
            return await distanceService.Distance(postcodeFrom, postcodeTo, accessToken: accessToken, cancellationToken: cancellationToken);
        }

        public async Task<Result<Invoice[]>> Invoice(AccessToken accessToken = default, CancellationToken cancellationToken = default)
        {
            return await invoiceService.Get(accessToken: accessToken, cancellationToken: cancellationToken);
        }
        public async Task<Result<Invoice>> Invoice(string number,AccessToken accessToken = default, CancellationToken cancellationToken = default)
        {
            return await invoiceService.Get(number, accessToken: accessToken, cancellationToken: cancellationToken);
        }

        public async Task<Result<Invoice[]>> Invoice(DateTimeOffset from, DateTimeOffset to,
            AccessToken accessToken = default, CancellationToken cancellationToken = default)
        {
            return await  invoiceService.Get(from, to, accessToken: accessToken, cancellationToken: cancellationToken);
        }

        public Webhooks Webhooks
        {
            get;
        }

        public PlansService Plans
        {
            get;
        }

        public Account Account
        {
            get;
        }

        public EmailNotifications EmailNotifications
        {
            get;
        }

        public SubscriptionService Subscription
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

        public async Task<Result<SuccessfulGet>> Get(string id, AccessToken accessToken = null, CancellationToken cancellationToken = default)
        {
            return await getService.Get(id, accessToken: accessToken, cancellationToken: cancellationToken);
        }

        public async Task<Result<string[]>> Typeahead(string term, TypeaheadOptions options = null, AccessToken accessToken = null, CancellationToken cancellationToken = default)
        {
            return await typeaheadService.Typeahead(term, options:options, accessToken: accessToken, cancellationToken: cancellationToken);
        }

    }
}
