using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiPractica2Azure_DiegoSanchezCanamero.Data;
using ApiPractica2Azure_DiegoSanchezCanamero.Models;

namespace ApiPractica2Azure_DiegoSanchezCanamero.Repositories
{
   
    public class TicketsRepository
    {
        private TicketsContext context;
        public TicketsRepository(TicketsContext context)
        {
            this.context = context;
        }
        public List<Ticket> GetTicketsUsuario(int idusuario)
        {
            var consulta = from datos in this.context.Tickets
                           where datos.IdUsuario == idusuario
                           select datos;
            return consulta.ToList();
        }
        public Ticket FindTicket(int idticket)
        {
            return this.context.Tickets.FirstOrDefault(z => z.IdTicket == idticket);
        }
    }
}
