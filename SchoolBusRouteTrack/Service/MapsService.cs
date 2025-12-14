using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;

namespace SchoolBusRouteTrack.Service
{
    public class MapsService // original
    {
        private const string googleApiKey = "AIzaSyCArvLZgooiF9BKD-2WlIZPdtHhbnYcDno";

        // Calgary, Alberta coordinates for location bias
        private const double calgaryLat = 51.0447;
        private const double calgaryLng = -114.0719;
        private const int searchRadiusMeters = 50000; // 50km radius around Calgary

        public async Task<GeocodeResult> GetCoordinatesFromAddress(string address)
        {
            string encodedAddress = Uri.EscapeDataString(address);
            // Bounds for Calgary area (SW corner to NE corner)
            string calgaryBounds = "50.8,-114.3|51.2,-113.9";

            string apiUrl = $"https://maps.googleapis.com/maps/api/geocode/json" +
                $"?address={encodedAddress}" +
                $"&bounds={calgaryBounds}" +
                $"&components=country:ca|administrative_area:AB" +
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

        public async Task<List<string>> GetAddressSuggestions(string input)
        {
            string encodedInput = Uri.EscapeDataString(input);

            // Location bias for Calgary, Alberta
            string apiUrl =
                            "https://maps.googleapis.com/maps/api/place/autocomplete/json" +
                            $"?input={encodedInput}" +
                            $"&types=address" +
                            $"&language=en" +
                            $"&components=country:ca" +
                            $"&location={calgaryLat},{calgaryLng}" +
                            $"&radius={searchRadiusMeters}" +
                            $"&strictbounds=false" +
                            $"&key={googleApiKey}";

            Debug.WriteLine("URL chamada: " + apiUrl);

            List<string> results = new List<string>();

            HttpClient client = new HttpClient();

            try
            {
                var response = await client.GetAsync(apiUrl);
                response.EnsureSuccessStatusCode();

                string json = await response.Content.ReadAsStringAsync();
                JObject data = JObject.Parse(json);

                string status = data["status"]?.ToString() ?? "SEM_STATUS";

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
                    string errorMessage = data["error_message"]?.ToString() ?? "(sem mensagem)";
                    Debug.WriteLine($"Places AUTOCOMPLETE status: {status} | erro: {errorMessage}");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Autocomplete error: " + ex.Message);
            }

            return results;
        }

        // 1) MÉTODO: busca lista de endereços pelo texto digitado
        public async Task<List<string>> GetAddressListAsync(string address)
        {
            List<string> list = new List<string>();

            string encodedAddress = Uri.EscapeDataString(address);
            // Bounds for Calgary area (SW corner to NE corner)
            string calgaryBounds = "50.8,-114.3|51.2,-113.9";

            string apiUrl = $"https://maps.googleapis.com/maps/api/geocode/json" +
                $"?address={encodedAddress}" +
                $"&bounds={calgaryBounds}" +
                $"&components=country:ca|administrative_area:AB" +
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

    }

}
