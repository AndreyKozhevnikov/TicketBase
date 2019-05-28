using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Data;

using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Diagnostics;

using System.Text.RegularExpressions;

namespace DXTicketBase {
    public class MyTicket : INotifyPropertyChanged {
        Ticket parentTicketEntity;
        public MyTicket(Ticket tck) {
            parentTicketEntity = tck;
            IsSaved = true;
        }

        public int Id {
            get { return parentTicketEntity.Id; }
            set {
                parentTicketEntity.Id = value;
                NotifyPropertyChanged("Id");
            }
        }
        //    string _number;

        public string Number {
            get { return parentTicketEntity.TicketNo; }
            set {
                parentTicketEntity.TicketNo = value;
                NotifyPropertyChanged("Number");
            }
        }
        public string Subject {
            get { return parentTicketEntity.Subject; }
            set {
                string st = value.Replace("'", "");
                parentTicketEntity.Subject = st;
            }
        }

        string _complexSubject;

        public string ComplexSubject {
            get { return _complexSubject; }
            set {
                _complexSubject = value;
                NotifyPropertyChanged("ComplexSubject");
            }
        }
        public DateTime? AddDate {
            get { return parentTicketEntity.AddDate; }
            set { parentTicketEntity.AddDate = value; }
        }
        public bool IsSaved {
            get { return _isSaved; }
            set {
                _isSaved = value;
                NotifyPropertyChanged("IsSaved");
            }
        }
        public string Comment {
            get { return parentTicketEntity.Comment; }
            set {
                parentTicketEntity.Comment = value;
                NotifyPropertyChanged("Comment");
                IsSaved = false;
            }
        }
        public bool IsToDelete {
            get { return _isToDelete; }
            set {
                _isToDelete = value;
                IsSaved = false;
            }
        }
        public bool IsIsFolderDeleted {
            get {
                return parentTicketEntity.IsFolderDelete;
            }
            set {
                parentTicketEntity.IsFolderDelete = value;
            }
        }

        bool _isMy;
        bool _isConsider;
        bool _isSaved;
        string _comment;

        string _subject;
        DateTime _addDate;
        bool _isToDelete;

        public static bool IsTicketSubject(string input, out string result) {
            Regex reg = new Regex(@"[A,B,E,S,Q,T,K]{1,2}\d{3,6}");
            var res = reg.Match(input.ToUpper());
            result = res.Value;
            return res.Success;
        }


        public void ParseComplexSubject() {
            string st = ComplexSubject;
            // if (st == null)
            //     return;
            // int ind = st.IndexOf('-')-1;
            // if (ind < 0)
            //     return;
            //string tmpSt = st.Substring(0, ind);
            string tmpSt = String.Empty;
            bool isSubj = IsTicketSubject(st,out tmpSt);

            if (!isSubj) {
                return;
            }
           
            var ost = st.Replace(tmpSt, "").Replace("-", "").Trim();
            this.Number = tmpSt;
            this.Subject = ost;
        }


        public void Save() {
            MyViewModel.generalEntity.SaveChanges();
            IsSaved = true;
        }
        public void SaveNewTicket() {
            AddDate = DateTime.Now;
            MyViewModel.generalEntity.Tickets.Add(parentTicketEntity);
            MyViewModel.generalEntity.SaveChanges();
            IsSaved = true;
        }


        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String propertyName) {
            if (PropertyChanged != null) {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }

}
