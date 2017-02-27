using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Routing;
using NgEventsWebApi.Models;

namespace NgEventsWebApi.Controllers
{
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    public class SessionsController : ApiController
    {
        public IEnumerable<Session> Get(string term)
        {
            return
                Event.EVENTS.SelectMany(
                    e => e.Sessions.Where(s => s.Name.ToLowerInvariant().IndexOf(term.ToLowerInvariant(), StringComparison.Ordinal) != -1));
        }

        [HttpPost]
        [Route("api/events/{eventId}/sessions/{sessionId}/voters")]
        public Session AddVoter([FromUri]int eventId, [FromUri]int sessionId, [FromUri]string newVoter)
        {
            var eventData = Event.EVENTS.FirstOrDefault(e => e.Id == eventId);
            var session = eventData.Sessions.FirstOrDefault(s => s.Id == sessionId);
            session.Voters.Add(newVoter);

            return session;
        }

        [HttpDelete]
        [Route("api/events/{eventId}/sessions/{sessionId}/voters/{voter}")]
        public Session DeleteVoter([FromUri]int eventId, [FromUri]int sessionId, [FromUri]string voter)
        {
            var eventData = Event.EVENTS.FirstOrDefault(e => e.Id == eventId);
            var session = eventData.Sessions.FirstOrDefault(s => s.Id == sessionId);
            var index = session.Voters.IndexOf(voter);

            if(index != -1)
                session.Voters.RemoveAt(index);

            return session;
        }

        [Route("api/events/{eventId}/sessions/{sessionId}/voters")]
        public IEnumerable<string> GetVoters([FromUri] int eventId, [FromUri] int sessionId)
        {
            var eventData = Event.EVENTS.FirstOrDefault(e => e.Id == eventId);
            var session = eventData.Sessions.FirstOrDefault(s => s.Id == sessionId);
            return session.Voters;
        }
    }
}