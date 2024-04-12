using System.Dynamic;
using CleanArchitecture.Domain.Abstractions;


namespace CleanArchitecture.Domain.Vehicles;

    public sealed class Vehicle : Entity
    {



        public Vehicle(Guid id,
                    Model model,
                    Vin vin,
                    Currency price,
                    Currency maintenance,
                    DateTime? lastRentDate,
                    List<Extra> extras,
                    Address? address           
        ) : base (id){
            Model = model;
            Vin = vin;
            Price = price;
            Maintenance = maintenance;
            LastRentDate = lastRentDate;
            Extras = extras;
            Address = address;

        }   

        public Model? Model {get; private set;}

        public Vin? Vin {get; private set;}

        public Address? Address {get; private set;}

        public Currency Price {get; private set;}

        public Currency Maintenance {get; private set;}

        public DateTime? LastRentDate{get; internal set;}

        public List<Extra> Extras {get; private set;} = new ();
    }