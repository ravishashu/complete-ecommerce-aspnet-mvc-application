using ETickets.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ETickets.Data.Base;

namespace ETickets.Data.Services
{
    public class ActorsService : EntityBaseRepository<Actor>,IActorsService
    {

        public ActorsService(AppDbContext context) : base(context) { }
       
    }
}
