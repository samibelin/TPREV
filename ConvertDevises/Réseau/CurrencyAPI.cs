using ConvertDevises.Métier;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ConvertDevises.Réseau
{
    public class CurrencyAPI : IServiceWeb
    {
        private HttpClient client;

        public CurrencyAPI()
        {
            client = new HttpClient();
        }
        public async Task<Devises> Lister()
        {
            Devises devises = new Devises();
            try
            {
                var codes = await GetCurrencies();

                var reponse = await client.GetAsync("https://api.currencyapi.com/v3/latest?apikey=cur_live_9FxYG9rF2diJlyp7vCPu1M5sNYddpA9w04LoaR8E&base_currency=EUR");
                if (reponse.IsSuccessStatusCode)
                {
                    string json = await reponse.Content.ReadAsStringAsync();
                    JObject jobj = JObject.Parse(json);
                    foreach (var value in jobj["data"].Values())
                    {
                        string code = value["code"].ToString();
                        double valeur = Convert.ToDouble(value["value"]);
                        if(codes.ContainsKey(code))
                        {
                            string name = codes[code];
                            Devise d = new Devise(name, valeur);
                            devises.Ajouter(d);
                        }                        
                    }
                }
            }
            catch
            {
                throw new ErreurServiceWeb();
            }
            return devises;
        }

        private async Task<Dictionary<string,string>> GetCurrencies()
        {
            Dictionary<string,string> codesAndNames = new Dictionary<string,string>();
            var reponse = await client.GetAsync("https://api.currencyapi.com/v3/currencies?apikey=cur_live_9FxYG9rF2diJlyp7vCPu1M5sNYddpA9w04LoaR8E");
            if (reponse.IsSuccessStatusCode)
            {
                string json = await reponse.Content.ReadAsStringAsync();
                JObject jobj = JObject.Parse(json);
                foreach (var value in jobj["data"].Values())
                {
                    string code = value["code"].ToString();
                    string name = value["name"].ToString();
                    codesAndNames[code] = name;
                }
            }
            return codesAndNames;
        }
    }
}
