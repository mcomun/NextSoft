using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;

namespace Delfin.Web.Areas.Autenticacion.Services
{
   public interface IAccountMembershipService
   {
      int MinPasswordLength { get; }

      bool ValidateUser(string userName, string password);
      MembershipCreateStatus CreateUser(string userName, string password, string email);
      bool ChangePassword(string userName, string oldPassword, string newPassword);
   }
}
