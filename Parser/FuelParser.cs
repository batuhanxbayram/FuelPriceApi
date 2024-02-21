using FuelPriceApi.Model;
using HtmlAgilityPack;
using System;

namespace FuelPriceApi.Parser
{
    public class FuelParser
    {
       
      

        public FuelParser()
        {
            
        }
        string petrol;
        string diesel;
        string lpg;
        public async Task<Fuel> ParseWebAsync(string webUrl)
        {
          

            HttpClient client = new HttpClient { Timeout = TimeSpan.FromSeconds(30) };
            var response =  client.GetAsync(webUrl).Result;

            if(response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                HtmlDocument document = new HtmlDocument();
                document.LoadHtml(responseBody);

                //HtmlNodeCollection data = document.DocumentNode.SelectNodes(".table.table-prices.fw-semibold.mt-6.table-with-tax tbody tr:nth-child(1)");
                HtmlNodeCollection data = document.DocumentNode.SelectNodes("/html/body/section[2]/div/div/div[2]/ul/li[1]");

                if (data is not null)
                {
                    foreach (var item in data)
                    {
                        //petrol = item.SelectSingleNode("/html/body/section[2]/div/div/div[2]/ul/li[1]/div/div[1]/text()").InnerText.Trim();
                        petrol = item.ChildNodes[1].ChildNodes[1].InnerText.ToString().Replace("\r\n","---").Replace(" ","").Trim();
                        diesel = item.ChildNodes[1].ChildNodes[3].InnerText.ToString().Replace("\r\n", "---").Replace(" ", "").Trim();
                        lpg = item.ChildNodes[1].ChildNodes[7].InnerText.ToString().Replace("\r\n", "---").Replace(" ", "").Trim();
                    }

                }

            }

            


            return new Fuel()
            {
                Petrol=petrol,
                Diesel=diesel,
                Lpg=lpg,
                CurrentDate=DateTime.Now,
                City= await GetCityNameFromUrl(webUrl),
            };
        }
        public async Task<string> GetCityNameFromUrl(string webUrl)
        {

            string[] city = webUrl.Split("/");
            string lastitem = city[^1];

            if (lastitem.Contains("istanbul")) return "İstanbul";
            else if (lastitem.Contains("izmir")) return "İzmir";
            else if (lastitem.Contains("ankara")) return "Ankara";
            else return "Unknow";
           

        }

    }
}
