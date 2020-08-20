// Decompiled with JetBrains decompiler
// Type: Delfin.Controls.ImportarExcel
// Assembly: Delfin.Controls, Version=3.0.1.3, Culture=neutral, PublicKeyToken=null
// MVID: A4BA2B33-0E71-44B0-9838-A6C1CD0C2B15
// Assembly location: C:\Temp\Delfin.Controls.dll

using System;
using System.Data;
using System.Data.Odbc;
using System.Windows.Forms;

namespace Delfin.Controls
{
  public class ImportarExcel
  {
    private string x_ruta;

    public DataTable Excel()
    {
      try
      {
        OpenFileDialog openFileDialog = new OpenFileDialog();
        openFileDialog.Title = "Seleccionar Archivos";
        openFileDialog.Filter = "Todos los archivos  (*.xlsx)|*.xlsx";
        openFileDialog.Multiselect = false;
        if (openFileDialog.ShowDialog() != DialogResult.OK)
          return (DataTable) null;
        Label label = new Label();
        label.Text = openFileDialog.FileName;
        this.RutaExcel = label.Text;
        using (OdbcConnection odbcConnection = new OdbcConnection("Driver={Microsoft Excel Driver (*.xls, *.xlsx, *.xlsm, *.xlsb)};dbq=" + label.Text + ";"))
        {
          odbcConnection.Open();
          using (OdbcCommand command = odbcConnection.CreateCommand())
          {
            command.CommandText = "SELECT * FROM [Datos$]";
            OdbcDataAdapter odbcDataAdapter = new OdbcDataAdapter(command);
            DataSet dataSet = new DataSet();
            odbcDataAdapter.Fill(dataSet);
            return dataSet.Tables[0];
          }
        }
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }

    public string RutaExcel
    {
      get
      {
        return this.x_ruta;
      }
      set
      {
        this.x_ruta = value;
      }
    }
  }
}
