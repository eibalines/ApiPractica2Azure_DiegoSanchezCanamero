using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiPractica2Azure_DiegoSanchezCanamero.Models;

namespace ApiPractica2Azure_DiegoSanchezCanamero.Data
{
    public class TicketsContext : DbContext
    {
        public TicketsContext(DbContextOptions<TicketsContext> options) : base(options) { }
        public DbSet<Ticket> Tickets { get;set;}
        public DbSet<Usuario> Usuarios { get; set; }

    }
}
