
using System.Collections.Generic;


namespace tar3.BL
{
    public class Flat
    {
        private string _id;
        private string _city;
        private string _address;
        private double _price;
        private int _numberOfRooms;

        private static List<Flat> _flatsList = new List<Flat>();

        public Flat() { }

        public Flat(string id, string city, string address, double price, int numberOfRooms)
        {
            _id = id;
            _city = city;
            _address = address;
            _price = price;
            _numberOfRooms = numberOfRooms;
        }

        public string Id { get => _id; set => _id = value; }
        public string City { get => _city; set => _city = value; }
        public string Address { get => _address; set => _address = value; }
        public double Price { get => _price; set => _price = Discount(value); }
        public int NumberOfRooms { get => _numberOfRooms; set => _numberOfRooms = value; }

        public int Insert()
        {
            foreach (Flat item in _flatsList)
            {
                if (item._id == _id)
                {
                    return 0;
                }
            }

            this._price = Discount(this._price);
            _flatsList.Add(this);
            //return true;

            FlatsDBservices FDBservices = new FlatsDBservices();
            return FDBservices.Insert(this);
        }

        static public List<Flat> Read()
        {
            FlatsDBservices FDBservices = new FlatsDBservices();
            return FDBservices.Read(); 

        }

        //public List<Flat> Read() => _flatsList;

        private double Discount(double price)
        {
            if (_numberOfRooms > 1 && price > 100)
            {
                return price * 0.9; // Apply discount
            }
            return price;
        }
        public List<Flat> GetByCityAndPrice(string city, double price)
        {
           List <Flat> flat = new List<Flat>();
            foreach (Flat item in _flatsList)
            {
                if(item._city == city && item._price < price)
                {
                    flat.Add(item);
                }
            }
            return flat;

        }

        
    }
}




