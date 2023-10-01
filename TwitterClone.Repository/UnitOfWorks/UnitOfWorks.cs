using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwitterClone.Core.UnitOfWorks;

namespace TwitterClone.Repository.UnitOfWorks
{
    public class UnitOfWorks : IUnitOfWorks
    {
        private readonly AppDbContext _appDbContext;

        public UnitOfWorks(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public void Commit()
        {
            _appDbContext.SaveChanges();
        }

        public async Task CommitAsync()
        {
            await _appDbContext.SaveChangesAsync();
        }
    }
}
