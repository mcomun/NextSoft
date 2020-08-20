using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Delfin.Principal
{
   public partial class DOC000MView : Form,IDOC000MView
   {
       #region [ Formulario ]
       public DOC000MView()
      {
         InitializeComponent();
      }
       #endregion

       #region [ Propiedades ]
       public DOC000Presenter Presenter { get; set; }
       private bool Closing = false;
       private System.Collections.Hashtable HashFormulario { get; set; }
       #endregion

       #region [ IDOC000MView ]
       public void LoadView()
       { }
       public void ClearItem()
       { }
       public void GetItem()
       {}
       public void SetItem()
       { }
       public void ShowValidation()
       { }

       #endregion
   }
}
