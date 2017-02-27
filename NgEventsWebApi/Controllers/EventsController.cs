using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using NgEventsWebApi.Models;

namespace NgEventsWebApi.Controllers
{
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    public class EventsController : ApiController
    {
        public IEnumerable<Event> Get(string term = null)
        {
            if (string.IsNullOrEmpty(term))
                return Event.EVENTS;

            return Event.EVENTS.Where(e => e.Name.ToLowerInvariant().IndexOf(term.ToLowerInvariant(), StringComparison.Ordinal) != -1);
        }

        public Event Get(int id)
        {
            return Event.EVENTS.FirstOrDefault(e => e.Id == id);
        }

        // POST api/values
        public Event Post([FromBody]Event newEvent)
        {
            newEvent.Id = Event.EVENTS.Max(e => e.Id) + 1;
            Event.EVENTS.Add(newEvent);

            return newEvent;
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]Event eventData)
        {
            var existingEvent = Event.EVENTS.FirstOrDefault(e => e.Id == id);
            if (existingEvent != null)
            {
                existingEvent.Name = eventData.Name;
                existingEvent.Date = eventData.Date;
                existingEvent.Time = eventData.Time;
                existingEvent.ImageUrl = eventData.ImageUrl;
                existingEvent.Location = eventData.Location;
                existingEvent.OnlineUrl = eventData.OnlineUrl;
                existingEvent.Price = eventData.Price;
            }
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
