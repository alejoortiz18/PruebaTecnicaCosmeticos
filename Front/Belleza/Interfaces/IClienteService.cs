using Belleza.Models.Dto;

namespace Belleza.Interfaces
{
    public interface IClienteService2
    {
        public Task<List<ClienteDto>> GetListClientes();

    }
}
