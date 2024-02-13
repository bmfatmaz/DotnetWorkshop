// See https://aka.ms/new-console-template for more information
using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Services;

//Console.WriteLine("Hello, World!");
Plane p1= new Plane();
p1.PlaneId= 1;
p1.Capacity= 200;
p1.ManufactureDate= new DateTime(2023,01,30);
p1.PlaneType = PlaneType.Boing;

//Plane p2 = new Plane(PlaneType.Boing,5,DateTime.Now);
//Plane p3 = new Plane
//{
//    PlaneType=PlaneType.Airbus,
//    Capacity=1,
//    PlaneId=5,
//    ManufactureDate= DateTime.Now
//};
//Console.WriteLine(p3);
//Passenger pass = new Passenger
//{
//    FirstName="Fatma",
//    LastName="Belhaj",
//    EmailAddress="email@email.com"
//};
//Console.WriteLine(pass);
//Console.WriteLine(pass.CheckProfile("Fatma", "Belhaj"));

//Staff s = new Staff();
//Traveller t= new Traveller();
//Console.WriteLine(pass.PassengerType());
//Console.WriteLine(s.PassengerType());
//Console.WriteLine(t.PassengerType());
FlightMethods fm = new FlightMethods
{
    Flights = TestData.listFlights

};
//fm.GetFlights("Destination", "Paris");
fm.ShowFlightDetails(TestData.BoingPlane);
Console.WriteLine(fm.ProgrammedFlightNumber(new DateTime(2022, 02, 01, 21, 10, 10)));
Console.WriteLine(fm.DurationAverage("Paris"));
foreach(Flight f in fm.OrderedDurationFlights())
{
    Console.WriteLine(f.ToString());
};
foreach (Traveller f in fm.SeniorTravellers(TestData.flight1))
{
    Console.WriteLine(f.ToString());
}