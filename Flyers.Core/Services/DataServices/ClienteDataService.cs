using Flyers.Core.Entities;
using Flyers.Core.Interfaces.DataRepositories;
using Flyers.Core.Interfaces.DataServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace Flyers.Core.Services.DataServices
{
    public class ClienteDataService : BaseDataService<ClienteEntity>, IClienteDataService
    {
        public ClienteDataService(IDataRepository dataRepository) 
            : base(dataRepository)
        {
        }
    }
}
