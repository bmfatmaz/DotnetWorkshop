using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Services
{
    public class FlightMethods:IFlightMethods
    {
        public List<Flight> Flights { get; set; }= new List<Flight> { };

        public double DurationAverage(string destination)
        {
           var query= from f in Flights where f.Destination == destination
                      select f.EstimatedDuration;
           return query.Average();
        }

        public List<DateTime> GetFlightDates(string destination)
        {
            List<DateTime> dates = new List<DateTime>();
            //for (int i = 0; i< Flights.Count(); i++)
            //{
            //    if (Flights[i].Destination == destination)
            //    {
            //        dates.Add(Flights[i].FlightDate);
            //    }
            ////}
            //foreach(Flight f in Flights)
            //{
            //    if (f.Destination == destination)
            //    {
            //        dates.Add(f.FlightDate);

            //    }
           // return dates;
            //}
            var query = from f in Flights 
                        where f.Destination == destination
                        select f.FlightDate;
            return query.ToList();
            
        }

        public void GetFlights(string filterType, string filterValue)
        {
            switch(filterType)
            {
                case "Destination":
                    foreach(Flight f in Flights)
                    {
                        if(f.Destination==filterValue)
                        {
                            Console.WriteLine(f) ;
                        }
                    }
                    break;
                case "Departure":
                    foreach (Flight f in Flights)
                    {
                        if (f.Departure == filterValue)
                        {
                            Console.WriteLine(f);
                        }
                    }
                    break;
                case "FlightDate":
                    foreach (Flight f in Flights)
                    {
                        if (f.FlightDate == DateTime.Parse(filterType))
                        {
                            Console.WriteLine(f);
                        }
                    }
                    break;
                case "EstimatedDuration":
                    foreach (Flight f in Flights)
                    {
                        if (f.EstimatedDuration == int.Parse(filterType))
                        {
                            Console.WriteLine(f);
                        }
                    }
                    break;



            }
        }

        public List<Flight> OrderedDurationFlights()
        {
            var query= from f in Flights orderby f.EstimatedDuration descending
                       select f;
            return query.ToList();
        }

        public int ProgrammedFlightNumber(DateTime startDate)
        {
            DateTime endDate= startDate.AddDays(7);
            var query= from f in Flights where f.FlightDate>=startDate && f.FlightDate<=endDate
                       select f;
            return query.Count();
        }

        public List<Traveller> SeniorTravellers(Flight flight)
        {
            var query = from p in flight.Passengers.OfType<Traveller>()
                        orderby p.BirthDate ascending
                        select p;
                   return    query.Take(3).ToList();
           
               
            

        }

        public void ShowFlightDetails(Plane plane)
        {
           var query = from f in Flights where f.MyPlane== plane
                       select new { f.FlightDate, f.Destination };

            foreach (var f in query)
            {
                Console.WriteLine("Destination: " + f.Destination + " Date: " + f.FlightDate);
            }

        }
    }
}
