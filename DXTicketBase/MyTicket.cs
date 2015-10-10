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
            set { _complexSubject = value;
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
    




        bool _isMy;
        bool _isConsider;
        bool _isSaved;
        string _comment;
        
        string _subject;
        DateTime _addDate;
        bool _isToDelete;



      public  void ParseComplexSubject() {
          string st = ComplexSubject;
          if (st == null)
              return;
          int ind = st.IndexOf(':');
          if (ind < 0)
              return;
         string tmpSt = st.Substring(0, ind);
          Regex reg = new Regex(@".\d{4,6}");

          var isNum = reg.IsMatch(tmpSt);
          if (!isNum) {
              return;
             
          }
          this.Number = tmpSt;
          this.Subject = st.Substring(ind+2, st.Length-ind-2);
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
