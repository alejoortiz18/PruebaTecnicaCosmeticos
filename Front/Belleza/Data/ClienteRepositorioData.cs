using Belleza.Data.Context;
using Belleza.Models.Dto;
using web = System.Net.Http;

namespace Belleza.Data
{
    public class ClienteRepositorioData
    {
        private string _url = "";
        private web.HttpClient _httpClient;
        public ClienteRepositorioData()
        {
            _url = ContextPath.urlApi;
            _httpClient = new HttpClient();
        }

      

        public async Task<ClienteDto> GetProductAsync()
        {
            ClienteDto product = null;
            HttpResponseMessage response = await _httpClient.GetAsync($"{_url}ObtenerListaClientes");
            if (response.IsSuccessStatusCode)
            {
              var oduct = response.Content;
            }
            return product;
        }

        public  List<ClienteDto> GetListClientes()
        {
            GetProductAsync();
            //string apiUrl = $"{_url}ObtenerListaClientes";
            ////if (response.IsSuccessStatusCode)
            ////{
            ////    var result =  response.Content.ReadAsStringAsync();
            ////}
            //_httpClient.BaseAddress = new Uri($"{_url}");
            //var response = _httpClient.GetAsync("ObtenerListaClientes");

            //if (response.IsCompleted)
            //{
            //    var jsonResponse = await response.Content.ReadAsStringAsync();
            //}

            //HttpResponseMessage request = httpClient.GetAsync($"{_url}ObtenerListaClientes");

            //try
            //{

            //    using (Stream strReader = WebResponse(request))
            //    {
            //        if (strReader == null)
            //            return null;
            //        using (StreamReader objReader = new StreamReader(strReader))
            //        {
            //            string responseBody = objReader.ReadToEnd();
                        
            //            }
            //    }

            //}
            //catch (WebException ex)
            //{
            //    // Handle error
            //}
            throw new NotImplementedException();
        }
    }

}
