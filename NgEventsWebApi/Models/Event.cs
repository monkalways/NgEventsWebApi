using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Razor.Text;

namespace NgEventsWebApi.Models
{
    public class Event
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public string Time { get; set; }
        public double Price { get; set; }
        public string ImageUrl { get; set; }
        public Location Location { get; set; }
        public string OnlineUrl { get; set; }
        public List<Session> Sessions { get; set; }

        #region Events Data
        public static List<Event> EVENTS = new List<Event>
        {
            new Event
            {
                Id = 1,
                Name = "Angular Connect",
                Date = new DateTime(2036, 9, 26),
                Time = "10:00 am",
                Price = 599.99,
                ImageUrl = "/assets/images/angularconnect-shield.png",
                Location = new Location {
                    Address = "1057 DT",
                    City = "London",
                    Country = "England"
                },
                Sessions = new List<Session>
                {
                    new Session()
                    {
                        Id = 1,
                        EventId = 1,
                        Name = "Using Angular 4 Pipes",
                        Presenter = "Peter Bacon Darwin",
                        Duration = 1,
                        Level = "Intermediate",
                        Abstract = "Learn all about the new pipes in Angular 4, both how to write them, and how to get the new AI CLI to write them for you.Given by the famous PBD, president of Angular University(formerly Oxford University)",
                        Voters = new [] {"bradgreen", "igorminar", "martinfowler"}.ToList()
                    },
                    new Session()
                    {
                        Id = 2,
                        EventId = 1,
                        Name = "Getting the most out of your dev team",
                        Presenter = "Jeff Cross",
                        Duration = 1,
                        Level = "Intermediate",
                        Abstract = "We all know that our dev teams work hard, but with the right management they can be even more productive, without overworking them. In this session I'll show you how to get the best results from the talent you already have on staff.",
                        Voters = new [] { "johnpapa", "bradgreen", "igorminar", "martinfowler"}.ToList()
                    },
                }
            },
            new Event()
            {
                Id = 2,
                Name = "ng-nl",
                Date = new DateTime(2037, 4, 15),
                Time = "9:00 am",
                Price = 950.00,
                ImageUrl = "/assets/images/ng-nl.png",
                OnlineUrl = "http://ng-nl.org",
                Sessions = new List<Session>
                {
                    new Session()
                    {
                        Id= 1,
                        EventId = 2,
                        Name = "Testing Angular 4 Workshop",
                        Presenter = "Pascal Precht & Christoph Bergdorf",
                        Duration = 4,
                        Level = "Beginner",
                        Abstract = "In this 6 hour workshop you will learn not only how to test Angular 4, you will also learn how to make the most of your team's efforts. Other topics will be convincing your manager that testing is a good idea, and using the new protractor tool for end to end testing.",
                        Voters = new [] {"bradgreen", "igorminar"}.ToList()
                    },
                    new Session()
                    {
                        Id= 2,
                        EventId = 2,
                        Name = "Angular 4 and Firebase",
                        Presenter = "David East",
                        Duration = 3,
                        Level = "Intermediate",
                        Abstract = "In this workshop, David East will show you how to use Angular with the new ultra-real-time 5D Firebase back end, hosting platform, and wine recommendation engine.",
                        Voters = new [] { "bradgreen", "igorminar", "martinfowler"}.ToList()
                    },
                }
            }
        };
        #endregion
    }

    public class Location
    {
        public string Address { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
    }


}