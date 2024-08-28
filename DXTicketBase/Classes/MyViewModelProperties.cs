using DataForSolutionNameSpace;
using DevExpress.Mvvm;
using DevExpress.Xpf.Editors;
using DevExpress.Xpf.Grid;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DXTicketBase {
    public partial class MyViewModel :INotifyPropertyChanged, ISupportServices {

        static string totalCmdPath = @"C:\Program Files\totalcmd\TOTALCMD64.EXE";

        public event PropertyChangedEventHandler PropertyChanged;
        public static DXTicketsBaseEntities generalEntity;

        string parentPath;
        string dropBoxPath;
        string solvedPath;
        string solvedPathOld;
        string currentThreadFolder;
        string searchStringVM;

        MyTicket _thisTicket;
        MyTicket _selectedTicket;

        ICommand _windowLoadedCommand;
        ICommand _copyToClipBoardCommand;
        ICommand _addNewTicketCommand;
        ICommand _createAndOpenSolutionCommand;
        ICommand _prepareDataForSolutionCommand;
        ICommand _createSolutionCLICommand;
        ICommand _saveAllCommand;
        ICommand _goToWebCommand;
        ICommand _openFolderCommand;
        ICommand _deleteFoldersCommand;
        ICommand _selectedModulesChangedCommand;

        public ICommand GoToWebCommand {
            get {
                if(_goToWebCommand == null)
                    _goToWebCommand = new DelegateCommand(GoToWeb);
                return _goToWebCommand;
            }
        }
        public ICommand SaveAllCommand {
            get {
                if(_saveAllCommand == null)
                    _saveAllCommand = new DelegateCommand(SaveAll);
                return _saveAllCommand;
            }

        }
        public ICommand CreateAndOpenSolutionCommand {
            get {
                if(_createAndOpenSolutionCommand == null)
                    _createAndOpenSolutionCommand = new DelegateCommand(CreateAndOpenSolution);

                return _createAndOpenSolutionCommand;
            }
        }
        public ICommand PrepareDataForSolutionCommand {
            get {
                if(_prepareDataForSolutionCommand == null)
                    _prepareDataForSolutionCommand = new DelegateCommand(PrepareDataForSolution);

                return _prepareDataForSolutionCommand;
            }
        }
        public ICommand CreateSolutionCLICommand {
            get {
                if(_createSolutionCLICommand == null)
                    _createSolutionCLICommand = new DelegateCommand(CreateSolutionCLI);

                return _createSolutionCLICommand;
            }
        }
        public ICommand AddNewTicketCommand {
            get {
                if(_addNewTicketCommand == null)
                    _addNewTicketCommand = new DelegateCommand(AddNewTicket);
                return _addNewTicketCommand;
            }
        }
        public ICommand WindowLoadedCommand {
            get {
                if(_windowLoadedCommand == null)
                    _windowLoadedCommand = new DelegateCommand(WindowLoaded);
                return _windowLoadedCommand;
            }
        }
        public ICommand CopyToClipBoardCommand {
            get {
                if(_copyToClipBoardCommand == null)
                    _copyToClipBoardCommand = new DelegateCommand<CopyingToClipboardEventArgs>(CopyToClipBoard);
                return _copyToClipBoardCommand;
            }
        }
        public ICommand OpenFolderCommand {
            get {
                if(_openFolderCommand == null)
                    _openFolderCommand = new DelegateCommand(OpenFolder);
                return _openFolderCommand;
            }

        }

        public ICommand DeleteFoldersCommand {
            get {
                if(_deleteFoldersCommand == null)
                    _deleteFoldersCommand = new DelegateCommand(DeleteFolders);
                return _deleteFoldersCommand;
            }

        }
        public ICommand SelectedModulesChangedCommand {
            get {
                if(_selectedModulesChangedCommand == null)
                    _selectedModulesChangedCommand = new DelegateCommand<EditValueChangedEventArgs>(SelectedModulesChanged);
                return _selectedModulesChangedCommand;
            }

        }

        bool _isSecurity;
        public bool IsSecurity {
            get { return _isSecurity; }
            set {
                _isSecurity = value;
                NotifyPropertyChanged();
            }
        }
        bool _hasWebAPI;
        public bool HasWebAPISeparate {
            get { return _hasWebAPI; }
            set {
                _hasWebAPI = value;
                NotifyPropertyChanged();
            }
        }
        ProjectTypeEnum _solutionType;
        public ProjectTypeEnum SolutionType {
            get { return _solutionType; }
            set {
                _solutionType = value;
                NotifyPropertyChanged();
            }
        }
        bool _hasWebAPIIntegrate;
        public bool HasWebAPIIntegrate {
            get { return _hasWebAPIIntegrate; }
            set {
                _hasWebAPIIntegrate = value;
                NotifyPropertyChanged();
            }
        }
        bool _hasMultitenant;
        public bool HasMultitenant {
            get { return _hasMultitenant; }
            set {
                _hasMultitenant = value;
                NotifyPropertyChanged();
            }
        }
        public ObservableCollection<MyTicket> ListTickets { get; set; }

        public List<String> AvailableModules { get; set; }
        public List<object> SelectedModules {
            get { return selectedModules; }
            set {
                selectedModules = value;
                NotifyPropertyChanged("SelectedModules");
            }
        }

        public MyTicket ThisTicket {
            get { return _thisTicket; }
            set {
                _thisTicket = value;
                NotifyPropertyChanged();
            }
        }
        public MyTicket SelectedTicket {
            get { return _selectedTicket; }
            set {
                _selectedTicket = value;
                NotifyPropertyChanged();
            }
        }
        public string SearchStringVM {
            get { return searchStringVM; }
            set {
                searchStringVM = value;
                if(value == null) {
                    MyManageGridControlService.MoveToLastRow();
                }
            }
        }
        IServiceContainer serviceContainer = null;
        protected IServiceContainer ServiceContainer {
            get {
                if(serviceContainer == null)
                    serviceContainer = new ServiceContainer(this);
                return serviceContainer;
            }
        }
        IServiceContainer ISupportServices.ServiceContainer { get { return ServiceContainer; } }
        IManageGridControl MyManageGridControlService { get { return ServiceContainer.GetService<IManageGridControl>(); } }

        const string sourceSolutionPath = @"c:\Dropbox\work\Templates\MainSolution\FilesToCreateSolution\";
        private List<object> selectedModules;
    }
}
