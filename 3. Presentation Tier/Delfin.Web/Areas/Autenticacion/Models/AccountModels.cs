using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Globalization;
using System.Web.Security;

namespace Delfin.Web.Areas.Autenticacion.Models
{
   [Table("UserProfile")]
   public class UserProfile
   {
      [Key]
      [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
      public int UserId { get; set; }
      public string UserName { get; set; }
   }

   public class RegisterExternalLoginModel
   {
      [Required]
      [Display(Name = "User name")]
      public string UserName { get; set; }

      public string ExternalLoginData { get; set; }
   }

   public class LocalPasswordModel
   {
      [Required]
      [DataType(DataType.Password)]
      [Display(Name = "Contraseña Actual")]
      public string OldPassword { get; set; }

      [Required]
      [StringLength(100, ErrorMessage = "La {0} debe tener por lo menos {2} caracteres de longitud.", MinimumLength = 6)]
      [DataType(DataType.Password)]
      [Display(Name = "Nueva Contraseña")]
      public string NewPassword { get; set; }

      [DataType(DataType.Password)]
      [Display(Name = "Confirmar Contraseña")]
      [Compare("NewPassword", ErrorMessage = "La nueva contraseña y la confirmación de la misma no coinciden.")]
      public string ConfirmPassword { get; set; }
   }

   public class LoginModel
   {
      [Required]
      [Display(Name = "Usuario")]
      public string UserName { get; set; }

      [Required]
      [DataType(DataType.Password)]
      [Display(Name = "Contraseña")]
      public string Password { get; set; }

      [Display(Name = "Recordarme?")]
      public bool RememberMe { get; set; }
   }

   public class RegisterModel
   {
      [Required]
      [Display(Name = "Usuario")]
      public string UserName { get; set; }

      [Required]
      [StringLength(100, ErrorMessage = "La {0} debe tener por lo menos {2} caracteres de longitud.", MinimumLength = 6)]
      [DataType(DataType.Password)]
      [Display(Name = "Contraseña")]
      public string Password { get; set; }

      [DataType(DataType.Password)]
      [Display(Name = "Confirmar Contraseña")]
      [Compare("Password", ErrorMessage = "La contraseña y la confirmación de la misma no coinciden.")]
      public string ConfirmPassword { get; set; }
   }

   public class ExternalLogin
   {
      public string Provider { get; set; }
      public string ProviderDisplayName { get; set; }
      public string ProviderUserId { get; set; }
   }
}
