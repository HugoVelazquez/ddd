using System.Threading.Tasks;
using Example.Domain.IRepositories;
using Example.Domain.IServices;

namespace Example.Service
{
    public class ServiceUser : IServiceUser
    {
        private readonly IRepositoryUser repositoryUser;

        public ServiceUser(IRepositoryUser repositoryUser)
        {
            this.repositoryUser = repositoryUser;
        }

        public async Task<string> Get()
        {
            return await this.repositoryUser.Get();
        }
    }
}
