using ETickets.Data.Base;
using ETickets.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ETickets.Data.Services
{
    public class CinemasService : EntityBaseRepository<Cinema>, ICinemasService
    {

        public CinemasService(AppDbContext context) : base(context)
        {
        }
    }
}
