using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiPractica2Azure_DiegoSanchezCanamero.Models;
using ApiPractica2Azure_DiegoSanchezCanamero.Repositories;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Text;

namespace ApiPractica2Azure_DiegoSanchezCanamero.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EmpresaController : ControllerBase
    {
        private MediaTypeWithQualityHeaderValue Header;
        private TicketsRepository repo;
        public EmpresaController(TicketsRepository repo)
        {
            this.repo = repo;
            this.Header = new MediaTypeWithQualityHeaderValue("application/json");
        }
        [HttpGet]
        [Route("{idusuario}")]
        public ActionResult<List<Ticket>> TicketUsuario(int idusuario)
        {
            List<Ticket> ticketsUsuario =
                this.repo.GetTicketsUsuario(idusuario);
            return ticketsUsuario;
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult<Ticket> FindTicket(int id)
        {
            Ticket ticket = this.repo.FindTicket(id);
            return ticket;
        }
        [HttpPost]
        public async Task<ActionResult> CreateTicket(Ticket ticket)
        {
            string urlFlowInsertarTicket =
                "https://prod-147.westeurope.logic.azure.com:443/workflows/ebf3147ded1146b6ac0787168fece23e/triggers/manual/paths/invoke?api-version=2016-06-01&sp=%2Ftriggers%2Fmanual%2Frun&sv=1.0&sig=ZRd_JEi9C5Zk3UVmTUvVT7AoGz0vEBDLamNt74scEPw";
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(this.Header);
                string json = JsonConvert.SerializeObject(ticket);
                StringContent content =
                    new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage response =
                    await client.PostAsync(urlFlowInsertarTicket, content);

            }
                
            return Ok();
        }
        [HttpPost]
        public async Task<ActionResult> ProccesTicket(Ticket ticket)
        {
            string urlFlowProccesTicket =
                "";
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(this.Header);
                string json = JsonConvert.SerializeObject(ticket);
                StringContent content =
                    new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage response =
                    await client.PostAsync(urlFlowProccesTicket, content);

            }

            return Ok();
        }


    }
}
