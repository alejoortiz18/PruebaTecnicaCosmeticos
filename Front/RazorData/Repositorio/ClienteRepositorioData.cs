using RestSharp;
using System.Net;
using System.Net.Http;

namespace RazorData.Repositorio
{
    public class ClienteRepositorioData
    {
        private string _url = "";
        private readonly HttpClient _httpClient;
        private HttpClient httpClient;
        public ClienteRepositorioData()
        {
            _url = ContextPath.urlApi;
            _httpClient = new HttpClient();
            httpClient = new HttpClient();
        }

        //public async Task<List<ClienteDto>> GetListClientes()
        //{

        //    //string apiUrl = $"{_url}ObtenerListaClientes";
        //    //HttpResponseMessage response = await httpClient.GetAsync(apiUrl);
        //    //if (response.IsSuccessStatusCode)
        //    //{
        //    //    var result = await response.Content.ReadAsStringAsync();
        //    //}



        //    var url = $"{_url}ObtenerListaClientes";
        //    var request = httpClient.GetAsync($"{_url}ObtenerListaClientes");

        //    try
        //    {
                
        //            //using (Stream strReader = WebResponse.IsSuccessStatusCode)
        //            //{
        //            //    if (strReader == null)
        //            //        return null;
        //            //    using (StreamReader objReader = new StreamReader(strReader))
        //            //    {
        //            //        string responseBody = objReader.ReadToEnd();
        //            //        // Do something with responseBody
        //            //    }
        //            //}
                
        //    }
        //    catch (WebException ex)
        //    {
        //        // Handle error
        //    }
        //    throw new NotImplementedException();
        //}
    }
}
