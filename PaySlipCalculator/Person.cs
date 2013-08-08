using System;
using System.Collections.Generic;
using System.Text;

namespace ass1
{
    class Person
    {
        // attribute data

        private string _Name, _StreetNo, _Address, _State, _PostCode, _PhoneNo;
        private int _Salary;


        // property data
        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }
        public string StreetNo
        {
            get { return _StreetNo; }
            set { _StreetNo = value; }
        }
        public string Address
        {
            get { return _Address; }
            set { _Address = value; }
        }
        public string State
        {
            get { return _State; }
            set { _State = value; }
        }
        public string PostCode
        {
            get { return _PostCode; }
            set { _PostCode = value; }
        }
        public string PhoneNo
        {
            get { return _PhoneNo; }
            set { _PhoneNo = value; }
        }
        public int Salary
        {
            get { return _Salary; }
            set { _Salary = value; }
        }

        // constructor - create the object
        public Person() // default - parameter-less constructor
        {
            _Name = "";
            _StreetNo = "";
            _Address = "";
            _State = "";
            _PostCode = "";
            _PhoneNo = "";
            _Salary = 0;


        }
        public override string ToString()
        {
            return string.Format("---\nPersons Details: {0}\n{1} {2}, {3}, {4}\n{5}\n\nAnnual Salary: {6:c}", _Name, _StreetNo, _Address, _State, _PostCode, _PhoneNo, _Salary);
        }
    }
}
