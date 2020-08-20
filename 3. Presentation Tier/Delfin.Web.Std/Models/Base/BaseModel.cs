using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Delfin.Web.Std.Models.Base
{
   public class BaseModel
   {
      public BaseModel()
      {
         this.Error = new ErrorModel();
      }

      public string LabelEstadoRegistro { get; set; }

      public ErrorModel Error { get; set; }
   }

   public class ErrorModel
   {
      public int Code { get; set; }
      public string Message { get; set; }
   }

   public abstract class Control
   {
      public string ID { get; set; }
      public string Text { get; set; }
      public bool Visible { get; set; }
      public bool Enabled { get; set; }
      public string ClassName { get; set; }
   }

   public class ButtonControl : Control
   {
      public string Name { get; set; }
   }

   public class LinkControl : Control
   {

   }

   public class TextBoxControl : Control
   {

   }

   public class SelectType
   {
      public string Id { get; set; }
      public string Name { get; set; }
      public string Type { get; set; }
   }

   public class SelectDisplay : Base.SelectType
   {
      public string Display { get; set; }
   }

   public class ImageControl : Control
   {

   }  
}