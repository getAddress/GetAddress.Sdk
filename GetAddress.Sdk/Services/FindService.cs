﻿using System;
using System.Collections.Specialized;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace GetAddress.Sdk.Services
{
    public class AutocompleteService: ApiKeyService
    {
        public AutocompleteService(string apiKey, HttpClient httpClient = null) : base(apiKey, httpClient)
        {
        }

        public async Task<Result<SuccessfulAutocomplete>> Autocomplete(string term,
            AutocompleteOptions options = default, AccessToken accessToken = default, CancellationToken cancellationToken = default)
        {
            options = options ?? new AutocompleteOptions();

            var path = GetAutocompletePath(term);

            var requestUri = GetUri(path);

            var response = await HttpPost(requestUri, 
                httpContent: options.ToHttpContent(),
                administrationOrApiKey: ApiKey, 
                token: accessToken, cancellationToken: cancellationToken);

            return await response.ToResult<SuccessfulAutocomplete>();
        }

        

        private string GetAutocompletePath(string term)
        {
            return $"Autocomplete/{term}";
        }
    }

    public class FindService : ApiKeyService
    {
        public FindService(string apiKey, HttpClient httpClient = null) : base(apiKey, httpClient)
        {
        }

        public async Task<Result<SuccessfulFind>> Find(string postcode,
            FindOptions options = default, AccessToken accessToken = default, CancellationToken cancellationToken = default)
        {
            options = options ?? new FindOptions();

            var requestUri = GetFindUri(postcode, options);

            var response = await HttpGet(requestUri, administrationOrApiKey:ApiKey, token: accessToken, cancellationToken: cancellationToken);

            return await response.ToResult<SuccessfulFind>();
        }

        private Uri GetFindUri(string postcode, FindOptions options)
        {
            var nameValues = new NameValueCollection();

            nameValues.Add("api-version", options.Version);

            nameValues.Add("expand", true.ToString());

            var path = GetPath(postcode, options);

            return GetUri(path, nameValues);
        }

        private string GetPath(string postcode, FindOptions options)
        {
            if (string.IsNullOrWhiteSpace(options.HouseNameOrNumber))
            {
                return $"Find/{postcode}";
            }

            return $"Find/{postcode}/{options.HouseNameOrNumber}";
        }


    }
}