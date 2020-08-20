using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delfin.Web.Areas.Autenticacion.Services
{
   public interface IFormsAuthenticationService
   {
      void SignIn(string userName, bool createPersistentCookie);
      void SignOut();
   }
}
