using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Net.Http;
using System.Threading.Tasks;

namespace SchoolBusRouteTrack.Service
{
    //Patricia
    public class MapsService
    {
        private const string googleApiKey = "AIzaSyCArvLZgooiF9BKD-2WlIZPdtHhbnYcDno";
        public async Task<List<string>> GetAddressSuggestions(string input)
        {
            string encodedInput = Uri.EscapeDataString(input);
            string apiUrl =
                            "https://maps.googleapis.com/maps/api/place/autocomplete/json" +
                            $"?input={encodedInput}" +
                            $"&types=address" +             // only addresses
                            $"&language=en" +               // language
                            $"&components=country:ca" +     // limit to Canada
                            $"&key={googleApiKey}";

            Debug.WriteLine("URL call: " + apiUrl); // just for debugging

            List<string> results = new List<string>();

            HttpClient client = new HttpClient();
            try
            {
                var response = await client.GetAsync(apiUrl);
                response.EnsureSuccessStatusCode();

                string json = await response.Content.ReadAsStringAsync();
                JObject data = JObject.Parse(json);

                string status = data["status"]?.ToString() ?? "NO_STATUS";

                if (data["status"].ToString() == "OK")
                {
                    foreach (var item in data["predictions"])
                    {
                        string address = item["description"].ToString();
                        results.Add(address);
                    }
                }
                else
                {
                    string errorMessage = data["error_message"]?.ToString() ?? "(without message)";
                    Debug.WriteLine($"Places AUTOCOMPLETE status: {status} | error: {errorMessage}");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Autocomplete error: " + ex.Message);
            }

            return results;
        }

        // Search list of addresses through typed text
        public async Task<List<string>> GetAddressListAsync(string address)
        {
            List<string> list = new List<string>();

            string encodedAddress = Uri.EscapeDataString(address);

            string apiUrl = $"https://maps.googleapis.com/maps/api/geocode/json" +
                            $"?address={encodedAddress}" +
                            $"&components=country:ca" +
                            $"&language=en" +
                            $"&key={googleApiKey}";

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    HttpResponseMessage response = await client.GetAsync(apiUrl);
                    string responseBody = await response.Content.ReadAsStringAsync();

                    JObject json = JObject.Parse(responseBody);

                    if (json["status"]?.ToString() == "OK")
                    {
                        foreach (var r in json["results"])
                        {
                            string formatted =
                                r["formatted_address"]?.ToString();

                            if (!string.IsNullOrWhiteSpace(formatted)
                                && !list.Contains(formatted))
                            {
                                list.Add(formatted);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("GetAddressListAsync ERROR: " + ex.Message);
            }
            return list;
        }


        public async Task<GeocodeResult> GetCoordinatesFromAddress(string address)
        {
            string encodedAddress = Uri.EscapeDataString(address);
            string apiUrl = $"https://maps.googleapis.com/maps/api/geocode/json" +
                $"?address={encodedAddress}" +
                $"&components=country:ca" +
                $"&language=en" +
                $"&key={googleApiKey}";

            HttpClient client = new HttpClient();

            try
            {
                HttpResponseMessage response = await client.GetAsync(apiUrl);
                response.EnsureSuccessStatusCode();

                string responseBody = await response.Content.ReadAsStringAsync();
                JObject jsonResponse = JObject.Parse(responseBody);

                Console.WriteLine(jsonResponse);

                if (jsonResponse["status"]?.ToString() == "OK")
                {
                    var firstResult = jsonResponse["results"][0];

                    string formattedAddress = firstResult["formatted_address"]?.ToString();
                    double latitude = (double)firstResult["geometry"]["location"]["lat"];
                    double longitude = (double)firstResult["geometry"]["location"]["lng"];

                    return new GeocodeResult
                    {
                        FormattedAddress = formattedAddress,
                        Latitude = latitude,
                        Longitude = longitude
                    };
                }
                else
                {
                    // Handle error cases (e.g., address not found)
                    return null;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error fetching coordinates: {ex.Message}");
                return null;
            }
        }
    }
}