using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NgEventsWebApi.Models
{
    public class Session
    {
        public int Id { get; set; }
        public int EventId { get; set; }
        public string Name { get; set; }
        public string Presenter { get; set; }
        public int Duration { get; set; }
        public string Level { get; set; }
        public string Abstract { get; set; }
        public List<string> Voters { get; set; }
    }
}