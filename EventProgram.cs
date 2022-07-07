using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestoreEventi
{
    internal class EventProgram
    {
        public string Title { get; set; }
        public List<Event> Events { get; set; }

        public EventProgram(string title)
        {
            this.Title = title;
            this.Events = new List<Event>();
        }

        public void AddEvent(string title, DateOnly date, int capacity)
        {
            this.Events.Add(new Event(title, date, capacity));
        }

        public void AddEvent(string title, string date, int capacity)
        {
            this.Events.Add(new Event(title, date, capacity));
        }

        public List<Event> GetEventsByDate(DateOnly date)
        {
            return this.Events.Where(e => e.Date == date).ToList();
        }

        public List<Event> GetEventsByDate(string date) => this.GetEventsByDate(DateOnly.Parse(date));

        public int EventNumber() => this.Events.Count;

        public void PrintEvents()
        {
            Console.WriteLine($"{this.Title}");
            foreach (Event e in this.Events)
                Console.WriteLine(e.ToString());
        }

        public void RemoveAll()
        {
            this.Events.Clear();
        }

        
    }
}
