using Belleza.Data;
using Belleza.Data.Context;
using Belleza.Interfaces;
using Belleza.Models;
using Belleza.Models.Dto;
using Belleza.Models.Entities;
using System;
using System.Net.Http.Json;

namespace Belleza.Services
{
    public class ClienteServices 
    {
        //private ClienteRepositorioData _clienteData;

        //public ClienteServices()
        //{
        //    _clienteData = new ClienteRepositorioData();
        //}

        //public List<ClienteDto> GetListClientes()
        //{
        //    Task<List<ClienteDto>> list = _clienteData.GetListClientes();
        //    return new List<ClienteDto>();
        //}

        private readonly HttpClient httpClient;
        string _url = ContextPath.urlApi;

        public ClienteServices()
        {
            this.httpClient = new HttpClient();
        }

        public List<ClienteDto> GetList()
        {
            ClientEntities resp = new ClientEntities();
            List<ClientesE> listClientes = resp.GetList();
            return new List<ClienteDto>();
        }

        public List<ClienteDto> GetListClientes()
        {
            ClienteRepositorioData resp = new ClienteRepositorioData();
            List<ClienteDto> list = new List<ClienteDto>();
            var result = httpClient.GetFromJsonAsync<List<ClienteDto>>($"{_url}ObtenerListaClientes");
            
            return list;
        }
    }
}
