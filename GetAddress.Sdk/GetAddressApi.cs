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

        public Api(HttpClient httpClient = null) : this(null,null, httpClient: httpClient)
        {
            
        }
        public Api(string apiKey, string administrationKey, HttpClient httpClient = null)
        {
            httpClient = httpClient ?? new GetAddressHttpClient();
            Security = new Security(apiKey, administrationKey, httpClient: httpClient);
            findService = new FindService(apiKey, httpClient: httpClient);
            autocompleteService = new AutocompleteService(apiKey, httpClient: httpClient);
            getService = new GetService(apiKey, httpClient: httpClient);
            typeaheadService = new TypeaheadService(apiKey, httpClient: httpClient);
            EmailNotifications = new EmailNotifications(administrationKey, httpClient: httpClient);
            usageService = new UsageService(administrationKey, httpClient: httpClient);
            distanceService = new DistanceService(apiKey, httpClient: httpClient);
            Subscription = new SubscriptionService(administrationKey, httpClient: httpClient);
            Plans = new PlansService(administrationKey, httpClient: httpClient);
            Webhooks = new Webhooks(administrationKey, httpClient: httpClient);
            Account = new Account(administrationKey, httpClient: httpClient);
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
