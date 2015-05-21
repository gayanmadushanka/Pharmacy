using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using Ccom.Common.Utils;
using Ccom.ExceptionHandling.ExceptionHandlers;
using Ccom.Pharmacy.API;
using Ccom.Pharmacy.Core.Enums;
using Ccom.Pharmacy.DAL.Entity;
using Ccom.Pharmacy.Delegates;
using Ccom.Pharmacy.Managers;
using Ccom.Pharmacy.Views;

namespace Ccom.Pharmacy.ViewModels
{
    public class LoggingViewModel : INPCBase
    {
        //private readonly IPharmacyServiceAgent _serviceAgent;

        private UserEntity _userDetails;
        private List<UserRoleEntity> _modulesByUserRoleId;

        #region Properties
        private UserEntity _userEntity = new UserEntity();
        public UserEntity UserEntity
        {
            get { return _userEntity; }
            set
            {
                _userEntity = value;
                NotifyPropertyChanged(ConstantManager.UserEntity);
            }
        }
        #endregion

        public ICommand LoggingUserCommand { get; private set; }

        public LoggingViewModel()
        {
            //_serviceAgent = new PharmacyServiceAgent();
            LoggingUserCommand = new DelegateCommand<object, object>(ExecuteLoggingUserCommand);
        }

        private async void ExecuteLoggingUserCommand(object parameter)
        {
            try
            {
                PopUpManager.LoadProgressBar("");
                RunBackgroundWorkerOne();
                //UserEntity userDetails = await PharmacyAPI.GetUserDetailsByPasswordUsernameAsync(UserEntity.UserName, UserEntity.Password);
                //if (userDetails != null)
                //{
                //    GetModulesByUserRoleId(userDetails.UserRoleId);
                //}
                //else
                //{
                //    NavigationManager.GoBack();
                //    PopUpManager.ShowPharmacyMessageView("Wrong Password", MessageTypes.Warning);
                //}

                //_serviceAgent.GetUserDetailsByPasswordUsername(UserEntity.UserName, UserEntity.Password, (s, e) =>
                //{
                //    if (e.Error == null)
                //    {
                //        GetModulesByUserRoleId(e.Result.UserRoleId);
                //    }
                //    else
                //    {
                //        NavigationManager.GoBack();
                //        PopUpManager.ShowPharmacyMessageView("Wrong Password", MessageTypes.Warning);
                //    }
                //});
            }
            catch (Exception ex)
            {
                UserInterfaceExceptionHandler.HandleExcetion(ref ex);
            }
        }

        public async void GetModulesByUserRoleId(int userRoleId)
        {
            try
            {
                List<UserRoleEntity> modulesByUserRoleId = await PharmacyAPI.GetModulesByUserRoleIdAsync(userRoleId);


                //_serviceAgent.GetModulesByUserRoleId(userRoleId, (s, e) =>
                //{
                //    NavigationManager.GoBack();
                //    if (e.Error == null)
                //    {
                //        GeneralDataHome operation = new GeneralDataHome(e.Result.First().ModuleEntities);
                //        NavigationManager.AddView(operation);
                //        StaticDataManager.Window.ViewModel.LogOutBtnVisibility = Visibility.Visible;
                //    }
                //    else
                //    {
                //        PopUpManager.ShowPharmacyMessageView("Wrong Password", MessageTypes.Warning);
                //    }
                //});
            }
            catch (Exception ex)
            {
                UserInterfaceExceptionHandler.HandleExcetion(ref ex);
            }
        }

        private void RunBackgroundWorkerOne()
        {
            BackgroundWorker worker = new BackgroundWorker();
            worker.DoWork += worker_DoWork;
            worker.RunWorkerCompleted += worker_RunWorkerCompleted;
            worker.RunWorkerAsync();
        }

        async void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                _userDetails = await PharmacyAPI.GetUserDetailsByPasswordUsernameAsync(UserEntity.UserName, UserEntity.Password);
            }
            catch (Exception ex)
            {
                UserInterfaceExceptionHandler.HandleExcetion(ref ex);
            }
        }

        void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                if (_userDetails != null)
                {
                    RunBackgroundWorkerTwo();
                }
                else
                {
                    NavigationManager.GoBack();
                    PopUpManager.ShowPharmacyMessageView("Wrong Password", MessageTypes.Warning);
                }
            }
            catch (Exception ex)
            {
                UserInterfaceExceptionHandler.HandleExcetion(ref ex);
            }
        }

        private void RunBackgroundWorkerTwo()
        {
            BackgroundWorker worker = new BackgroundWorker();
            worker.DoWork += workerTwo_DoWork;
            worker.RunWorkerCompleted += workerTwo_RunWorkerCompleted;
            worker.RunWorkerAsync();
        }

        async void workerTwo_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                _modulesByUserRoleId = await PharmacyAPI.GetModulesByUserRoleIdAsync(_userDetails.UserRoleId);
            }
            catch (Exception ex)
            {
                UserInterfaceExceptionHandler.HandleExcetion(ref ex);
            }
        }

        void workerTwo_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                NavigationManager.GoBack();
                if (_modulesByUserRoleId != null)
                {
                    GeneralDataHome operation = new GeneralDataHome(new ObservableCollection<ModuleEntity>(_modulesByUserRoleId.First().ModuleEntities));
                    NavigationManager.AddView(operation);
                    StaticDataManager.Window.ViewModel.LogOutBtnVisibility = Visibility.Visible;
                }
                else
                {
                    PopUpManager.ShowPharmacyMessageView("Wrong Password", MessageTypes.Warning);
                }
            }
            catch (Exception ex)
            {
                UserInterfaceExceptionHandler.HandleExcetion(ref ex);
            }
        }
    }
}
