using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

using NextAdmin.Entities;
using NextAdmin.ServiceContracts;
using NextAdmin.ServiceImplementations;
using Infrastructure.Aspect;
using Delfin.Web.Areas.Autenticacion.Contexts;

namespace Delfin.Web.Areas.Autenticacion.Providers
{
   public class NextAdminMembershipProvider : MembershipProvider
   {
      #region [ Variables ]
      
      #endregion

      #region [ Constructor ]
      
      #endregion

      #region [ Propiedades ]
      public override string ApplicationName
      {
         get
         {
            throw new NotImplementedException();
         }
         set
         {
            throw new NotImplementedException();
         }
      }
      
      public override bool EnablePasswordReset
      {
         get { throw new NotImplementedException(); }
      }

      public override bool EnablePasswordRetrieval
      {
         get { throw new NotImplementedException(); }
      }

      public override bool RequiresQuestionAndAnswer
      {
         get { throw new NotImplementedException(); }
      }

      public override bool RequiresUniqueEmail
      {
         get { return true; }
      }

      public override int MaxInvalidPasswordAttempts
      {
         get { throw new NotImplementedException(); }
      }

      public override int MinRequiredNonAlphanumericCharacters
      {
         get { throw new NotImplementedException(); }
      }

      public override int MinRequiredPasswordLength
      {
         get { return 6; }
      }

      public override int PasswordAttemptWindow
      {
         get { throw new NotImplementedException(); }
      }

      public override MembershipPasswordFormat PasswordFormat
      {
         get { throw new NotImplementedException(); }
      }

      public override string PasswordStrengthRegularExpression
      {
         get { throw new NotImplementedException(); }
      }
      #endregion

      #region [ Metodos ]

      #region [ User ]
      public override MembershipUser CreateUser(string username, string password, string email, string passwordQuestion, string passwordAnswer, bool isApproved, object providerUserKey, out MembershipCreateStatus status)
      {
         var args = new ValidatePasswordEventArgs(username, password, true);
         OnValidatingPassword(args);

         if (args.Cancel)
         {
            status = MembershipCreateStatus.InvalidPassword;
            return null;
         }

         if (RequiresUniqueEmail && GetUserNameByEmail(email) != string.Empty)
         {
            status = MembershipCreateStatus.DuplicateEmail;
            return null;
         }

         var user = GetUser(username, true);

         if (user == null)
         {
            var userObj = new Usuarios { USUA_Codigo = 0, USUA_CodUsr = username, USUA_Pass = Infrastructure.Aspect.Cryptography.EncryptMD5.Encriptar(username.ToLower() + password + username.ToLower()), USUA_Nombres = username, USUA_Email = email, USUA_CambiarPassword = RequiresQuestionAndAnswer, USUA_Pregunta = passwordQuestion, USUA_Respuesta = passwordAnswer, USUA_Estado = true, USUA_Administrador = false, AUDI_UsrCrea = "", AUDI_FecCrea = DateTime.Now, Instance = global::Infrastructure.Aspect.BusinessEntity.InstanceEntity.Added };

            using (var usersContext = new AccountContext())
            {
               if (usersContext.InsertarUsuario(userObj))
               { status = MembershipCreateStatus.Success; }
               else
               { status = MembershipCreateStatus.UserRejected; }
            }

            return GetUser(username, true);
         }
         status = MembershipCreateStatus.DuplicateUserName;

         return null;
      }

      public override void UpdateUser(MembershipUser user)
      {
         throw new NotImplementedException();
      }

      public override bool DeleteUser(string username, bool deleteAllRelatedData)
      {
         throw new NotImplementedException();
      }

      public override bool ValidateUser(string username, string password)
      {
         using (var usersContext = new AccountContext())
         {
            var _isCorrect = usersContext.Autenticar(username, password);
            return _isCorrect;
         }
      }

      public override bool UnlockUser(string userName)
      {
         throw new NotImplementedException();
      }

      public override MembershipUserCollection GetAllUsers(int pageIndex, int pageSize, out int totalRecords)
      {
         throw new NotImplementedException();
      }

      public override MembershipUserCollection FindUsersByEmail(string emailToMatch, int pageIndex, int pageSize, out int totalRecords)
      {
         throw new NotImplementedException();
      }

      public override MembershipUserCollection FindUsersByName(string usernameToMatch, int pageIndex, int pageSize, out int totalRecords)
      {
         throw new NotImplementedException();
      }

      public override MembershipUser GetUser(string username, bool userIsOnline)
      {
         var usersContext = new AccountContext();
         var user = usersContext.ConsultarUsuario(username);
         if (user != null)
         {
            var memUser = new MembershipUser("CustomMembershipProvider", username, user.USUA_Codigo, user.USUA_Email,
                                                        string.Empty, string.Empty,
                                                        true, false, DateTime.MinValue,
                                                        DateTime.MinValue,
                                                        DateTime.MinValue,
                                                        DateTime.Now, DateTime.Now);
            return memUser;
         }
         return null;
      }

      public override MembershipUser GetUser(object providerUserKey, bool userIsOnline)
      {
         throw new NotImplementedException();
      }

      public override string GetUserNameByEmail(string email)
      {
         throw new NotImplementedException();
      }

      public override int GetNumberOfUsersOnline()
      {
         throw new NotImplementedException();
      }
      #endregion

      #region [ Password ]
      public override bool ChangePassword(string username, string oldPassword, string newPassword)
      {
         throw new NotImplementedException();
      }
      public override bool ChangePasswordQuestionAndAnswer(string username, string password, string newPasswordQuestion, string newPasswordAnswer)
      {
         throw new NotImplementedException();
      }

      public override string ResetPassword(string username, string answer)
      {
         throw new NotImplementedException();
      }

      public override string GetPassword(string username, string answer)
      {
         throw new NotImplementedException();
      }
      #endregion
      
      #endregion
   }
}