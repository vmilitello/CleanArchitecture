using CleanArchitecture.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CleanArchitecture.Infrastructure.Data
{
   public class GuestBookRepository:EfRepository<GuestBook>
    {
        public GuestBookRepository(AppDbContext dbContext):base(dbContext)
        {
        }

        public override  GuestBook GetById(int id) {
            return _dbContext.GuestBooks.Include(g => g.Entries).FirstOrDefault(g => g.Id == id);
        }
    }
}
