using SCRA.Data.Clinical.Entities;
using SCRA.Data.Common.Models;
using SCRA.Data.Common.Repositories;

namespace SCRA.Data.Clinical.Repositories
{
    public class RulePbpRepository : Repository<RulePbpEntity>
    {
        internal RulePbpRepository(DatabaseContext context)
           : base(context)
        {
        }
    }
}
