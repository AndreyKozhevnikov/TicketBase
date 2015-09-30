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
using DophinMSSQLConnector;
using System.Text.RegularExpressions;

namespace DXTicketBase {
    public class MyTicket : INotifyPropertyChanged {
        //public MyTicket(DataRow row) {
        //    Id = int.Parse(row["Id"].ToString());
        //    Number = row["TicketNo"].ToString();
        //    Subject = row["Subject"].ToString();
        //    _isMy = bool.Parse(row["IsMy"].ToString());
        //    _isConsider = bool.Parse(row["IsConsider"].ToString());
        //    _comment = row["Comment"].ToString();
        //    _isToDelete = bool.Parse(row["IsToDelete"].ToString());
        //    ListTags = new MyListTag(row["Tags"]);
        //   // AddDate = DateTime.Parse(row["AddDate"].ToString());
        //    DateTime _d;
        //    DateTime.TryParse(row["AddDate"].ToString(), out _d);
        //    if (_d != null)
        //        AddDate = _d;
        //    _isSaved = true;
        //}
        Ticket parentTicketEntity;
        public MyTicket(Ticket tck) {
            parentTicketEntity = tck;
        }
        //public MyTicket() {
        // //   ListTags = new MyListTag();
        //}
        //int _id;

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
        //public MyListTag ListTags { get; set; }
        //public string ListTagsString {
        //    get {
        //        return ListTags.ToString();
        //    }
        //}
        //public bool IsMy {
        //    get { return _isMy; }
        //    set {
        //        _isMy = value;
        //        IsSaved = false;
        //        Change();
        //    }
        //}
        //public bool IsConsider {
        //    get { return _isConsider; }
        //    set {
        //        _isConsider = value;
        //        IsSaved = false;
        //    }
        //}
        public bool IsSaved {
            get { return _isSaved; }
            set {
                _isSaved = value;
                NotifyPropertyChanged("IsSaved");
                Change();
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
        public bool BChange {
            get { return _bChange; }
            set {
                _bChange = value;
                NotifyPropertyChanged("BChange");
            }
        }




        bool _isMy;
        bool _isConsider;
        bool _isSaved;
        string _comment;
        bool _bChange;
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


        //public void AddTag(Tag tg) {
        //    ListTags.Add(tg);
        //    NotifyPropertyChanged("ListTagsString");
        //    IsSaved = false;
        //}
        public void Save() {
          //  parentTicketEntity.sa
          //if (IsSaved) return;
          //string quer = string.Format("update tickets set tags='{1}',IsMy='{2}', IsConsider='{3}',Comment='{4}' where id={0}", Id, ListTags.StringToSave, IsMy, IsConsider, Comment);
          //MsSqlConnector.MakeNonQuery(quer);
          //Debug.Print(Id.ToString());
          
            MainWindow.generalEntity.SaveChanges();
            IsSaved = true;
        }
        public void SaveNewTicket() {
            AddDate = DateTime.Now;
            //string st = string.Format("insert into tickets ([TicketNo],[Subject],[IsMy],[IsConsider],[IsToDelete],[AddDate]) values('{0}','{1}','0','0','0','{2}');select SCOPE_IDENTITY()", Number, Subject, AddDate);
            //Id = int.Parse(MsSqlConnector.ExecuteScalar(st).ToString());
            MainWindow.generalEntity.Tickets.Add(parentTicketEntity);
            MainWindow.generalEntity.SaveChanges();
            IsSaved = true;
        }
        public void Change() {
            BChange = !BChange;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String propertyName) {
            if (PropertyChanged != null) {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }

    //public class Tag {
    //    public Tag() {
    //        if (TagsDictionary == null)
    //            TagsDictionary = new Dictionary<int, string>();
    //    }
    //    public Tag(DataRow row)
    //        : this() {
    //        Id = (int)row["Id"];
    //        Name = row["name"].ToString();

    //        TagsDictionary.Add(Id, Name);
    //    }
    //    public Tag(string nm)
    //        : this() {
    //        Name = nm;
    //        Save();
    //        TagsDictionary.Add(Id, Name);
    //    }
    //    public Tag(int _id)
    //        : this() {
    //        Id = _id;
    //        Name = TagsDictionary[Id];
    //    }

    //    public static Dictionary<int, string> TagsDictionary { get; set; }

    //    public int Id { get; set; }
    //    public string Name { get; set; }

    //    public void Save() {
    //        if (Id == 0) {
    //            string quer = string.Format("insert into tags ([name]) values ('{0}');select SCOPE_IDENTITY()", Name);
    //            Id = (int.Parse(MsSqlConnector.ExecuteScalar(quer).ToString()));
    //        }
    //    }
    //}


    //public class MyListTag {
    //    public MyListTag() {
    //        ListTags = new ObservableCollection<Tag>();
    //    }
    //    public MyListTag(object o)
    //        : this() {
    //        string st = o.ToString();
    //        string[] arr = st.Split(';');
    //        foreach (string s in arr) {
    //            int id;
    //            if (int.TryParse(s, out id)) {
    //                ListTags.Add(new Tag(id));
    //            }
    //        }
    //    }
    //    public ObservableCollection<Tag> ListTags { get; set; }
    //    public string StringToSave {
    //        get {
    //            string st = "";
    //            List<int> tmpList = new List<int>();
    //            foreach (Tag tg in ListTags)
    //                tmpList.Add(tg.Id);
    //            st = string.Join(";", tmpList);
    //            return st;
    //        }
    //    }

    //    public void Add(Tag tg) {
    //        ListTags.Add(tg);
    //    }

    //    public override string ToString() {
    //        string st = "";
    //        List<string> tmpList = new List<string>();
    //        foreach (Tag tg in ListTags)
    //            tmpList.Add(tg.Name);
    //        st = string.Join(";", tmpList);
    //        return st;
    //    }
    //}
}
