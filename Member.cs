using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SilAssignment
{
    public class Member : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        private string _name;
        private DateTime _joinDate;
        private decimal _fee;
        private PaymentSchedule _paymentType;
        private MemberType _memberType;
        private DateTime _renewalDate;
        private int _daysToRenewal;


        public MemberType Membertype
        {
            get => _memberType;
            set
            {
                _memberType = value;
                OnPropertyChanged("Membertype");
            }
        }

        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged("Name");
            }
        }


        public DateTime JoinDate
        {
            get => _joinDate;
            set { _joinDate = value; OnPropertyChanged("JoinDate"); }
        }


        public decimal Fee
        {
            get => _fee;
            set
            {
                _fee = value;
                OnPropertyChanged("Fee");
            }
        }

        public PaymentSchedule PaymentType
        {
            get => _paymentType;
            set
            {
                _paymentType = value;
                OnPropertyChanged("PaymentSchedule");
            }
        }


        public DateTime RenewalDate
        {
            get
            {
                _renewalDate = JoinDate.AddMonths(1).AddDays(1);
                return _renewalDate;
            }

            set
            {
                _renewalDate = value;
                OnPropertyChanged("RenewalDate");
            }
        }

        public int DaysToRenewal
        {
            get
            {
                _daysToRenewal = (int)(RenewalDate - DateTime.Now).TotalDays;
                return _daysToRenewal;
            }
            set
            {
                _daysToRenewal = value;
                OnPropertyChanged("DaysToRenewal");
            }
        }



        public Member()
        {
            Membertype = MemberType.Regular;
        }

        public decimal CalculateFees()
        {
            switch (PaymentType)
            {
                case (PaymentSchedule.Annual):
                    return Fee;
                case (PaymentSchedule.Biannual):
                    return Fee / 6;
                case (PaymentSchedule.Monthly):
                    return Fee / 12;
            }

            return Fee;
        }
    }
}
