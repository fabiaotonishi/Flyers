using Flyers.Core.Entities;
using Flyers.Core.Interfaces.DataRepositories;
using Flyers.Core.Interfaces.DataServices;

namespace Flyers.Core.Services.DataServices
{
    public class DominioDataService : BaseDataService<DominioEntity>, IDominioDataService
    {
        public DominioDataService(IDataRepository dataRepository)
            : base(dataRepository)
        {
        }
    }
}
