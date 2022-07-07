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
        public List<Event> Events { get; private set; }

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

        public void AddEvent(Event ev)
        {
            this.Events.Add(ev);
        }

        public List<Event> GetEventsByDate(DateOnly date)
        {
            return this.Events.Where(e => e.Date == date).ToList();
        }

        public List<Event> GetEventsByDate(string date) => this.GetEventsByDate(DateOnly.Parse(date));

        public int EventNumber() => this.Events.Count;

        public static void PrintEvents(List<Event> events)
        {
            foreach (Event e in events)
                Console.WriteLine(" - " + e.ToString());
        }
        public void Print()
        {
            Console.WriteLine($"{this.Title}:");
            EventProgram.PrintEvents(this.Events);
        }

        public void RemoveAll()
        {
            this.Events.Clear();
        }
    }
}
