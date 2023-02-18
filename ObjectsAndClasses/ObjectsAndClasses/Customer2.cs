using System.Runtime.CompilerServices;

namespace ObjectsAndClasses
{
    public class Customer2
    {
        private string _City;
        private string _Country = "UK";
        private string _CustomerID;
        private string _CutomerName;
        private string _PostalCode;
        private string _Region;

        public override string ToString()
        {
            return string.Format("{0} ({1})", _CutomerName, _Country);
        }

        /// <param name="CustomerID">ID for the new customer</param>
        public Customer2(string CustomerID)
        {
            _CustomerID = CustomerID;
        }

        public string CustomerID
        {
            get
            {
                return _CustomerID;
            }
        }

        public string City
        {
            get
            {
                return _City;
            }
            set
            {
                _City = value;
            }
        }

        public string Country
        {
            get
            {
                return _Country;
            }
            set
            {
                _Country = value;
            }
        }

        public string CutomerName
        {
            get
            {
                return _CutomerName;
            }
            set
            {
                _CutomerName = value;
            }
        }

        public string PostalCode
        {
            get
            {
                return _PostalCode;
            }
            set
            {
                _PostalCode = value;
            }
        }

        public string Region
        {
            get
            {
                return _Region;
            }
            set
            {
                _Region = value;
            }
        }

        public void UpdateLocation(string NewCity, string NewRegion, string NewPostalCode)
        {
            _City = NewCity;
            _Region = NewRegion;
            _PostalCode = NewPostalCode;
        }

        public void UpdateLocation(string NewCity, string NewRegion, string NewPostalCode, string NewCountry)
        {
            _City = NewCity;
            _Region = NewRegion;
            _PostalCode = NewPostalCode;
            _Country = NewCountry;
        }

        //Method
        public string GetLocation()
        {
            return string.Format("{0} {1} {2}", _City, _Region, _PostalCode);
        }

        //Property
        public string Location
        {
            get
            {
                return string.Format("{0} {1} {2}", _City, _Region, _PostalCode);
            }
        }
    }
}