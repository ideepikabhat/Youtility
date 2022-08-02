using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Youtility_RestAPI.Models;

namespace Youtility_RestAPI.Controllers
{
    public class BookingSystemController : ApiController
    {
        TicketingDataEntities ticketDatas = new TicketingDataEntities();

        // GET: api/BookingSystem
        public IEnumerable<Ticket> Get()
        {
            var t = ticketDatas.Tickets.ToList();
            return ticketDatas.Tickets.ToList();
        }

        [Route("api/BookingSystem/{userId}")]
        // GET: api/BookingSystem/5
        public string Get(int userId)
        {
            Ticket exisingTicket = ticketDatas.Tickets.FirstOrDefault(x => x.user_id == userId);

            if (exisingTicket != null)
                return "User exists and details are : " + exisingTicket.user_id + " " + exisingTicket.user_name + " "
                    + exisingTicket.ticket_id  + " " + exisingTicket.action;
            else
                return "User doesnt exist in our DB";
        }

        // POST: api/BookingSystem
        public string Post(Ticket ticket)
        {
            ticketDatas.Tickets.Add(ticket);
            ticketDatas.SaveChanges();

            return "Ticket added";
        }

        // PUT: api/BookingSystem/5
        public string Put(Ticket ticket)
        {
            Ticket existingTicket = ticketDatas.Tickets.FirstOrDefault(x => x.ticket_id == ticket.ticket_id);
            if(existingTicket != null)
            {
                existingTicket.user_name = ticket.user_name;
                existingTicket.action = ticket.action;
                existingTicket.event_id = ticket.event_id;

                ticketDatas.Entry(existingTicket).State = System.Data.Entity.EntityState.Modified;
                ticketDatas.SaveChanges();

                return "Update successful";
            }
            else
            {
                return "Unable to update as entry doesnt exists in our database";
            }
        }

        // DELETE: api/BookingSystem/5
        public string Delete(int id)
        {
            Ticket ticket = ticketDatas.Tickets.Find(id);
            if (ticket != null)
            {
                ticketDatas.Tickets.Remove(ticket);
                return "Deleted successfully";
            }
            else
                return "Delete was unsuccessful";
        }
    }
}
