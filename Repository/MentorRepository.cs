using Contracts;
using Entities;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class MentorRepository : RepositoryBase<Mentor>, IMentorRepository
    {
        public MentorRepository(ShoddyWorksContext context) : base(context)
        {

        }
    }
}
