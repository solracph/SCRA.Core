using SCRA.Data.Clinical.Entities;
using SCRA.Data.Common.Models;
using SCRA.Data.Common.Repositories;

namespace SCRA.Data.Clinical.Repositories
{
    public class ContractPbpRepository : Repository<ContractPbpEntity>
    {
        internal ContractPbpRepository(DatabaseContext context)
           : base(context)
        {
        }
    }
}
