using SCRA.Data.Common.Models;
using SCRA.Data.Common.Repositories;
using SCRA.Data.Clinical.Entities;


namespace SCRA.Data.Clinical.Repositories
{
    public class UserRuleRepository : Repository<UserRuleEntity>
    {
        internal UserRuleRepository(DatabaseContext context)
            : base(context)
        {
        }
    }
}
