using JAPChallenge.Models;
using Microsoft.EntityFrameworkCore;
using JAPChallenge.RepositoryInterfaces;

namespace JAPChallenge.Repositories

{
    public class ClientRepository :IClientRepository
    {
        private readonly JapChallengeDbContext context;
        public ClientRepository(JapChallengeDbContext context)
        {
            this.context = context;
        }
        public void AddClient(ClientModel client)
        {         
            if (context.Client.Any(c => c.Email == client.Email))
            {
                throw new Exception("Email must be unique.");
            }
            context.Client.Add(client);
            context.SaveChanges();
            
        }

        public IEnumerable<ClientModel> ListClients()
        {
            
                return context.Client.ToList();
           
        }
    }
}
