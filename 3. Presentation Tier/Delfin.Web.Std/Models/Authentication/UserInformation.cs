using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Delfin.Web.Std.Models.Authentication
{
   [Serializable]
   public class UserInformation
   {
      public string tokenSecurity;

      public DateTime tokenExpirationTime;

      public string systemCode;

      public string user;

      public string userFirstName;

      public string roleCode;

      public string Language;
   }
}