using JAPChallenge.Models;

namespace JAPChallenge.RepositoryInterfaces
{
    public interface IClientRepository
    {
        IEnumerable<ClientModel> ListClients();
       
        void AddClient(ClientModel client);
       
    }
}
