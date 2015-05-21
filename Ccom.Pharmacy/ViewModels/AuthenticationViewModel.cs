using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Ccom.Common.Utils;
using Ccom.Pharmacy.API;
using Ccom.Pharmacy.DAL.Entity;
using Ccom.Pharmacy.Delegates;
using Ccom.Pharmacy.Managers;

namespace Ccom.Pharmacy.ViewModels
{
    public class AuthenticationViewModel : INPCBase
    {
        //private readonly IPharmacyServiceAgent _serviceAgent;

        #region Authentication Properties
        private ObservableCollection<UserRoleEntity> _userRoleList = new ObservableCollection<UserRoleEntity>();
        public ObservableCollection<UserRoleEntity> UserRoleList
        {
            get { return _userRoleList; }
            set
            {
                _userRoleList = value;
                NotifyPropertyChanged(ConstantManager.UserRoleList);
            }
        }

        private UserRoleEntity _selectedUserRole = new UserRoleEntity();
        public UserRoleEntity SelectedUserRole
        {
            get { return _selectedUserRole; }
            set
            {
                _selectedUserRole = value;
                NotifyPropertyChanged(ConstantManager.SelectedUserRole);
            }
        }

        private ObservableCollection<ModuleEntity> _moduleList = new ObservableCollection<ModuleEntity>();
        public ObservableCollection<ModuleEntity> ModuleList
        {
            get { return _moduleList; }
            set
            {
                _moduleList = value;
                NotifyPropertyChanged(ConstantManager.ModuleList);
            }
        }

        private ObservableCollection<ModuleEntity> _assignedModuleList = new ObservableCollection<ModuleEntity>();
        public ObservableCollection<ModuleEntity> AssignedModuleList
        {
            get { return _assignedModuleList; }
            set
            {
                _assignedModuleList = value;
                NotifyPropertyChanged(ConstantManager.AssignedModuleList);
            }
        }

        private bool _btnAddSelectedEnabled;
        public bool BtnAddSelectedEnabled
        {
            get { return _btnAddSelectedEnabled; }
            set
            {
                _btnAddSelectedEnabled = value;
                NotifyPropertyChanged(ConstantManager.BtnAddSelectedEnabled);
            }
        }

        private bool _btnRemoveSelectedEnabled;
        public bool BtnRemoveSelectedEnabled
        {
            get { return _btnRemoveSelectedEnabled; }
            set
            {
                _btnRemoveSelectedEnabled = value;
                NotifyPropertyChanged(ConstantManager.BtnRemoveSelectedEnabled);
            }
        }
        #endregion

        public ICommand ChangeUserRoleComand { get; set; }
        public ICommand ModuleSelectionCommand { get; set; }
        public ICommand AssignedModuleSelectionCommand { get; set; }
        public ICommand ResetAuthenticationCommand { get; set; }
        public ICommand SaveAuthenticationCommand { get; set; }
        //public ICommand AddAllCommand { get; set; }
        public ICommand AddSelectedCommand { get; set; }
        public ICommand RemoveSelectedCommand { get; set; }
        //public ICommand RemoveAllCommand { get; set; }

        public AuthenticationViewModel()
        {
            //_serviceAgent = new PharmacyServiceAgent();
            ChangeUserRoleComand = new DelegateCommand<object, object>(ExecuteChangeUserRoleComand);
            ModuleSelectionCommand = new DelegateCommand<object, object>(ExecuteModuleSelectionCommand);
            AssignedModuleSelectionCommand = new DelegateCommand<object, object>(ExecuteAssignedModuleSelectionCommand);
            ResetAuthenticationCommand = new DelegateCommand<object, object>(ExecuteResetAuthenticationCommand);
            SaveAuthenticationCommand = new DelegateCommand<object, object>(ExecuteSaveAuthenticationCommand);
            //AddAllCommand = new DelegateCommand<object, object>(ExecuteAddAllCommand);
            AddSelectedCommand = new DelegateCommand<object, object>(ExecuteAddSelectedCommand);
            RemoveSelectedCommand = new DelegateCommand<object, object>(ExecuteRemoveSelectedCommand);
            //RemoveAllCommand = new DelegateCommand<object, object>(ExecuteRemoveAllCommand);
            GetUserRoles();
            GetAllModules();
        }

        private async void GetUserRoles()
        {
            UserRoleList = new ObservableCollection<UserRoleEntity>(await PharmacyAPI.GetUserRolesAsync());
            //_serviceAgent.GetUserRoles((s, e) =>
            //{
            //    if (e.Error == null)
            //    {
            //        UserRoleList = e.Result;
            //    }
            //});
        }

        private async void GetAllModules()
        {
            ModuleList = new ObservableCollection<ModuleEntity>(await PharmacyAPI.GetAllModulesAsync());
            //_serviceAgent.GetAllModules((s, e) =>
            //{
            //    if (e.Error == null)
            //    {
            //        ModuleList = e.Result;
            //    }
            //});
        }

        private void ExecuteChangeUserRoleComand(object obj)
        {
            Task<List<UserRoleEntity>> modulesByUserRoleIdAsync = PharmacyAPI.GetModulesByUserRoleIdAsync(SelectedUserRole.Id);
            AssignedModuleList = new ObservableCollection<ModuleEntity>(modulesByUserRoleIdAsync.Result.First().ModuleEntities);
            //_serviceAgent.GetModulesByUserRoleId(SelectedUserRole.Id, (s, e) =>
            //{
            //    if (e.Error == null)
            //    {
            //        AssignedModuleList = e.Result.First().ModuleEntities;
            //    }
            //});
        }

        private void ExecuteModuleSelectionCommand(object obj)
        {
            BtnAddSelectedEnabled = true;
        }

        private void ExecuteAssignedModuleSelectionCommand(object obj)
        {
            BtnRemoveSelectedEnabled = true;
        }

        private void ExecuteResetAuthenticationCommand(object obj)
        {

        }

        private void ExecuteSaveAuthenticationCommand(object obj)
        {

        }

        private void ExecuteAddSelectedCommand(object obj)
        {
            if (obj != null)
            {
                ModuleEntity moduleEntity = obj as ModuleEntity;
                AssignedModuleList.Add(moduleEntity);
                ModuleList.Remove(moduleEntity);
            }
        }

        private void ExecuteRemoveSelectedCommand(object obj)
        {
            if (obj != null)
            {
                ModuleEntity moduleEntity = obj as ModuleEntity;
                ModuleList.Add(moduleEntity);
                AssignedModuleList.Remove(moduleEntity);
            }
        }
    }
}
