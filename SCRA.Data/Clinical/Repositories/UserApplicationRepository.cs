using SCRA.Data.Common.Models;
using SCRA.Data.Common.Repositories;
using SCRA.Data.Clinical.Entities;


namespace SCRA.Data.Clinical.Repositories
{
    public class UserApplicationRepository : Repository<UserApplicationEntity>
    {
        internal UserApplicationRepository(DatabaseContext context)
            : base(context)
        {
        }
    }
}
