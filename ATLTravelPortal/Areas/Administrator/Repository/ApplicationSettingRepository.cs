using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using TravelPortalEntity;
using ATLTravelPortal.Areas.Administrator.Models;
using ATLTravelPortal.Models;
using System.Web.Mvc;

namespace ATLTravelPortal.Areas.Administrator.Repository
{
    public class ApplicationSettingRepository
    {
        TravelPortalEntity.EntityModel _ent = new TravelPortalEntity.EntityModel();
        ActionResponse _res = new ATLTravelPortal.Models.ActionResponse();
        ApplicationSettingViewModel _model = new ApplicationSettingViewModel();
        public ApplicationSettingViewModel Edit(ApplicationSettingViewModel model,out ActionResponse _ores)
        {
            int ProductId = model.HFProductId;
            bool flag;
            flag = CheckProductId(model.HFProductId);
            if (flag == true)
            {
                model.ProductId = model.HFProductId;
                model.ProductId = Create(model);
                _res.ActionMessage = String.Format(Resources.Message.SuccessfullyCreated, "Application Setting");
                _res.ErrNumber = 0;
                _res.ErrSource = "DataBase";
                _res.ErrType = "App";
                _res.ResponseStatus = true;
            }
            else
            {
                model.ProductId = ProductId;
                model = Update(model, out _res);
                model.Flag = true;
            }
            model.ProductId = model.HFProductId;
            _ores = _res;
            return model;
        }
        public int Create(ApplicationSettingViewModel model)
        {
            AppSettings obj = new AppSettings
            {
                ProductId = model.ProductId,
                EnablePasswordRetrieval = model.EnablePasswordRetrieval,
                EnablePasswordReset = model.EnablePasswordReset,
                RequiresQuestionAndAnswer = model.RequiresQuestionAndAnswer,
                RequiresUniqueEmail = model.RequiresUniqueEmail,
                MaxInvalidPasswordAttempts = model.MaxInvalidPasswordAttempts,
                MinRequiredPasswordLength = model.MinRequiredPasswordLength,
                MinRequiredNonalphanumericCharacters = model.MinRequiredNonalphanumericCharacters,
                PasswordAttemptWindow = model.PasswordAttemptWindow,
                AppDateFormat = model.AppDateFormat,
                SMTPServer = model.SMTPServer,
                SMTPPort = model.SMTPPort,
                SMTPUsername = model.SMTPUsername,
                SMTPPassword = model.SMTPPassword,
                EnableExpirePasswordWhenUserNotLoginFromDays = model.EnableExpirePasswordWhenUserNotLoginFromDays,
                EnableAutoExpirePassword = model.EnableAutoExpirePassword,
                AutoPasswordExpiryInDays = model.AutoPasswordExpiryInDays,
                ShowPassowrdExpireNotificationBeforeDays = model.ShowPassowrdExpireNotificationBeforeDays,
                Paggination = model.Paggination,
            };
            _ent.AddToAppSettings(obj);
            _ent.SaveChanges();
            return obj.ProductId;
        }

        public List<Core_Products> GetProductList()
        {
            List<Core_Products> ProductList = _ent.Core_Products.Where(ii => ii.isActive == true).ToList();
            return (ProductList);
        }
        private bool IsExists(int id)
        {
           var obj= _ent.Core_Products.Where(ii => ii.isActive == true).FirstOrDefault();
           if (obj == null)
               return false;
           else
               return true;
        }
        public ApplicationSettingViewModel Get(int? id, out ActionResponse _ores)
        {
            if (id != null)
            {
                if(IsExists(id.Value)==true)
                {
                
                var model = (from aa in _ent.AppSettings.Where(ii => ii.ProductId == id)
                             select new ApplicationSettingViewModel
                             {
                                 AppSettingId = aa.AppSettingId,
                                 ProductId = aa.ProductId,
                                 HFProductId = aa.ProductId,
                                 EnablePasswordRetrieval = aa.EnablePasswordRetrieval,
                                 EnablePasswordReset = aa.EnablePasswordReset,
                                 RequiresQuestionAndAnswer = aa.RequiresQuestionAndAnswer,
                                 RequiresUniqueEmail = aa.RequiresUniqueEmail,
                                 MaxInvalidPasswordAttempts = aa.MaxInvalidPasswordAttempts,
                                 MinRequiredPasswordLength = aa.MinRequiredPasswordLength,
                                 MinRequiredNonalphanumericCharacters = aa.MinRequiredNonalphanumericCharacters,
                                 PasswordAttemptWindow = aa.PasswordAttemptWindow,
                                 AppDateFormat = aa.AppDateFormat,
                                 SMTPServer = aa.SMTPServer,
                                 SMTPPort = aa.SMTPPort,
                                 SMTPUsername = aa.SMTPUsername,
                                 SMTPPassword = aa.SMTPPassword,
                                 EnableExpirePasswordWhenUserNotLoginFromDays = aa.EnableExpirePasswordWhenUserNotLoginFromDays,
                                 EnableAutoExpirePassword = aa.EnableAutoExpirePassword,
                                 AutoPasswordExpiryInDays = aa.AutoPasswordExpiryInDays,
                                 ShowPassowrdExpireNotificationBeforeDays = aa.ShowPassowrdExpireNotificationBeforeDays,
                                 Paggination = aa.Paggination,
                             }).SingleOrDefault();  
                    _ores = _res;
                    if (model != null)
                    {
                        
                        model.Flag = true;
                        model.ddlProductList = new SelectList(GetProductList(), "ProductId", "ProductName", 0);
                        return model;
                    }
                    else
                    {
                    _model.Flag = true;
                    _model.ddlProductList = new SelectList(GetProductList(), "ProductId", "ProductName", 0);
                    return _model;
                    }
                    
                }
                else
                {
                    _res.ActionMessage = String.Format(Resources.Message.InvalidOperation, "Application Setting");
                    _res.ErrNumber = 1005;
                    _res.ErrSource = "DataBase";
                    _res.ErrType = "App";
                    _res.ResponseStatus = true;
                    _ores = _res;
                    return _model;
                }

            }
            else
            {
                _res.ActionMessage = String.Format(Resources.Message.InvalidOperation, "Application Setting");
                _res.ErrNumber = 1005;
                _res.ErrSource = "DataBase";
                _res.ErrType = "App";
                _res.ResponseStatus = true;
                _ores = _res;
                return _model;
            }
            //_ores = _res;
            //return null;

        }

        public ApplicationSettingViewModel Update(ApplicationSettingViewModel model,out ActionResponse _ores)
        {
            if (model.ProductId != null)
            {
                AppSettings obj = _ent.AppSettings.Where(u => u.ProductId == model.ProductId).FirstOrDefault();
                if (obj != null)
                {
                    obj.ProductId = model.ProductId;
                    obj.EnablePasswordRetrieval = model.EnablePasswordRetrieval;
                    obj.EnablePasswordReset = model.EnablePasswordReset;
                    obj.RequiresQuestionAndAnswer = model.RequiresQuestionAndAnswer;
                    obj.RequiresUniqueEmail = model.RequiresUniqueEmail;
                    obj.MaxInvalidPasswordAttempts = model.MaxInvalidPasswordAttempts;
                    obj.MinRequiredPasswordLength = model.MinRequiredPasswordLength;
                    obj.MinRequiredNonalphanumericCharacters = model.MinRequiredNonalphanumericCharacters;
                    obj.PasswordAttemptWindow = model.PasswordAttemptWindow;
                    obj.AppDateFormat = model.AppDateFormat;
                    obj.SMTPServer = model.SMTPServer;
                    obj.SMTPPort = model.SMTPPort;
                    obj.SMTPUsername = model.SMTPUsername;
                    obj.SMTPPassword = model.SMTPPassword;
                    obj.EnableExpirePasswordWhenUserNotLoginFromDays = model.EnableExpirePasswordWhenUserNotLoginFromDays;
                    obj.EnableAutoExpirePassword = model.EnableAutoExpirePassword;
                    obj.AutoPasswordExpiryInDays = model.AutoPasswordExpiryInDays;
                    obj.ShowPassowrdExpireNotificationBeforeDays = model.ShowPassowrdExpireNotificationBeforeDays;
                    obj.Paggination = model.Paggination;

                    _ent.ApplyCurrentValues(obj.EntityKey.EntitySetName, obj);
                    _ent.SaveChanges();
                    _res.ActionMessage = String.Format(Resources.Message.SuccessfullyUpdated, "Application Setting");
                    _res.ErrNumber = 0;
                    _res.ErrSource = "DataBase";
                    _res.ErrType = "App";
                    _res.ResponseStatus = true;
                }
                else
                {
                    _res.ActionMessage = String.Format(Resources.Message.InvalidOperation, "Application Setting");
                    _res.ErrNumber = 1005;
                    _res.ErrSource = "DataBase";
                    _res.ErrType = "App";
                    _res.ResponseStatus = true;
                }
            }
            else
            {
                _res.ActionMessage = String.Format(Resources.Message.InvalidOperation, "Application Setting");
                _res.ErrNumber = 1005;
                _res.ErrSource = "DataBase";
                _res.ErrType = "App";
                _res.ResponseStatus = true;
            }
            _ores = _res;
            return model;
            /////
        }
        public bool CheckProductId(int HFProductId)
        {
            AppSettings Appsetting = _ent.AppSettings.Where(ii => ii.ProductId == HFProductId).FirstOrDefault();
            if (Appsetting != null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }


    }
}