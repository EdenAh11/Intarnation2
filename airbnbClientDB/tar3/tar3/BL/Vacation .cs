using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Q1.BL
{
    public class Vacation
    {
        private string _id;
        private string _userId;
        private string _flatId;
        private DateTime _startDate;
        private DateTime _endDate;

        static List<Vacation> _vacationList = new List<Vacation>();

        public Vacation() { }

        public Vacation(string id, string userId, string flatId, DateTime startDate, DateTime endDate)
        {
            _id = id;
            _userId = userId;
            _flatId = flatId;
            _startDate = startDate;
            _endDate = endDate;
        }

        public string Id { get => _id; set => _id = value; }
        public string UserId { get => _userId; set => _userId = value; }
        public string FlatId { get => _flatId; set => _flatId = value; }

        [DataType(DataType.Date)]

        public DateTime StartDate { get => _startDate; set => _startDate = value; }

        [DataType(DataType.Date)]
        public DateTime EndDate { get => _endDate; set => _endDate = value; }

        public int Insert()
        {
            if (_vacationList.Count == 0)
            {
                _vacationList.Add(this);
                VacationDBservices VCDBservices = new VacationDBservices();
                return VCDBservices.Insert(this);
            }
            foreach (Vacation item in _vacationList)
            {
                if (item._id == _id)
                {
                    return 0;
                }
            }
            foreach (Vacation item2 in _vacationList)
            {
                if ((item2._endDate >= _endDate && item2.StartDate <= _endDate) || (item2._startDate <= _startDate && item2._endDate >= _startDate))
                {
                    return 0;
                }
            }
            _vacationList.Add(this);
            VacationDBservices VDBservices = new VacationDBservices();
            return VDBservices.Insert(this);


        }
        static public List<Vacation> Read()
        {
            VacationDBservices VDBservices = new VacationDBservices();
            return VDBservices.Read();

        }

        //public List<Vacation> Read() => _vacationList;
        public List<Vacation> GetByStartAndEndDate(DateTime start, DateTime end)
        {
            List<Vacation> v2 = new List<Vacation>();

            foreach (var item in _vacationList)
            {
                if (item._startDate <= start && item._endDate >= end)
                {
                    v2.Add(item);
                }
            }
            return v2;
        }
        public List<Vacation> GetByFlatId(string flatId)
        {
            List<Vacation> v2 = new List<Vacation>();

            foreach (var item in _vacationList)
            {
                if (item._flatId == flatId)
                {
                    v2.Add(item);
                }
            }
            return v2;
        }






    }
}
