using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestoreEventi
{
    internal class Event
    {
        private string title;
        private DateOnly date;
        private int capacity;
        
        public Event(string title, DateOnly date, int capacity)
        {
            this.Title = title;
            this.Date = date;
            this.Capacity = capacity;
            this.Reserved = 0;                
        }
        public string Title
        {
            get => this.title;
            
            set
            {
                if (value == "")
                    throw new ArgumentException("Title cannot be null or empty");                
                this.title = value;
            }
        }
        public DateOnly Date
        {
            get => this.date;
            
            set
            {
                if (value < DateOnly.FromDateTime(DateTime.Now))
                    throw new ArgumentException("Date cannot be in the past");                
                this.date = value;
            }
        }
        public int Capacity
        {
            get => this.capacity;
            
            protected set
            {
                if (value < 0)
                    throw new ArgumentException("Capacity cannot be negative");                
                this.capacity = value;
            }
        }
        public int Reserved { get; private set;  }

        public void Book()
        {
            if (Reserved >= Capacity)
                throw new Exception("Event is full");            
            this.Reserved++;
        }

        public void Cancel()
        {
            if (Reserved == 0)
                throw new Exception("Event is empty");            
            this.Reserved--;
        }

        public override string ToString()
        {
            return $"{Date:dd/MM/yyyy} - {Title}";
        }
    }
}
