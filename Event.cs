using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestoreEventi
{
    internal class Event
    {
        public Event(string title, DateOnly date, int capacity)
        {
            try
            {
                Title = title;
                Date = date;
                Capacity = capacity;
                Reserved = 0;                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new Exception("Error in Event constructor", ex);
            }
        }
        public string Title
        {
            get => Title;
            
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException("Title cannot be null or empty");
                Title = value;
            }
        }
        public DateOnly Date
        {
            get => Date;
            
            set
            {
                if (value < DateOnly.FromDateTime(DateTime.Now))
                    throw new ArgumentException("Date cannot be in the past");
                Date = value;
            }
        }
        public int Capacity
        {
            get => Capacity;
            
            protected set
            {
                if (value < 0)
                    throw new ArgumentException("Capacity cannot be negative");
                Capacity = value;
            }
        }
        public int Reserved { get; private set;  }

        public void Book()
        {
            if (Reserved >= Capacity)
                throw new Exception("Event is full");
            Reserved++;
        }

        public void Cancel()
        {
            if (Reserved == 0)
                throw new Exception("Event is empty");
            Reserved--;
        }

        public override string ToString()
        {
            return $"{Date.ToString("dd/MM/yyyy")} - {Title}";
        }
    }
}
