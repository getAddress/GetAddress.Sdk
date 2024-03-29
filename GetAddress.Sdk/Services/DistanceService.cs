﻿using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace GetAddress.Services
{
    public class DistanceService : AddressService
    {
        public DistanceService(AddressLookupKey addressLookupKey, HttpClient httpClient = null) : base(addressLookupKey?.Key, httpClient)
        {

        }

        public async Task<Result<Distance>> Distance(
            string postcodeFrom,
            string postcodeTo,
            AccessToken accessToken = default, 
            CancellationToken cancellationToken = default)
        {
            var path = GetPath(postcodeFrom,postcodeTo);

            var requestUri = GetUri(path);

            return await HttpGet<Distance>(requestUri, administrationOrApiKey: AddressLookupKey,
               token: accessToken, cancellationToken: cancellationToken);
        }

        private string GetPath(string postcodeFrom, string postcodeTo)
        {
            return $"Distance/{postcodeFrom}/{postcodeTo}";
        }
    }
}
