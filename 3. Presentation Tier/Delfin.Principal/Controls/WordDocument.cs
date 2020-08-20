// Decompiled with JetBrains decompiler
// Type: Delfin.Controls.WordDocument
// Assembly: Delfin.Controls, Version=3.0.1.3, Culture=neutral, PublicKeyToken=null
// MVID: A4BA2B33-0E71-44B0-9838-A6C1CD0C2B15
// Assembly location: C:\Temp\Delfin.Controls.dll

using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace Delfin.Principal
{
  public class WordDocument
  {
    private object missing = (object) Missing.Value;
    private Microsoft.Office.Interop.Word.Application wordApp;
    private Document aDoc;
    private object filename;

    public WordDocument(string docPath, string _ruta)
    {
      try
      {
        File.Copy(docPath, Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), _ruta), true);
        this.wordApp = (Microsoft.Office.Interop.Word.Application) Activator.CreateInstance(Type.GetTypeFromCLSID(new Guid("000209FF-0000-0000-C000-000000000046")));
        this.filename = (object) Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), _ruta);
        if (File.Exists((string) this.filename))
        {
          object ReadOnly = (object) false;
          object Visible = (object) false;
          this.wordApp.Visible = false;
          // ISSUE: reference to a compiler-generated method
          this.aDoc = this.wordApp.Documents.Open(ref this.filename, ref this.missing, ref ReadOnly, ref this.missing, ref this.missing, ref this.missing, ref this.missing, ref this.missing, ref this.missing, ref this.missing, ref this.missing, ref Visible, ref this.missing, ref this.missing, ref this.missing, ref this.missing);
          // ISSUE: reference to a compiler-generated method
          this.aDoc.Activate();
        }
        else
        {
          int num = (int) MessageBox.Show("El archivo no existe.", "Sin archivo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }
      }
      catch (Exception ex)
      {
        this.CloseDocument();
        int num = (int) MessageBox.Show("Error durante el proceso. Descripcion: " + ex.Message, "Error Interno", MessageBoxButtons.OK, MessageBoxIcon.Hand);
      }
    }

    public void SaveDocument(bool Editable)
    {
      try
      {
        // ISSUE: reference to a compiler-generated method
        this.aDoc.Save();
        if (Editable)
          return;
        object FileName = (object) this.aDoc.FullName.Replace(".docx", ".pdf");
        object FileFormat = (object) WdSaveFormat.wdFormatPDF;
        // ISSUE: reference to a compiler-generated method
        this.aDoc.SaveAs(ref FileName, ref FileFormat, ref this.missing, ref this.missing, ref this.missing, ref this.missing, ref this.missing, ref this.missing, ref this.missing, ref this.missing, ref this.missing, ref this.missing, ref this.missing, ref this.missing, ref this.missing, ref this.missing);
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show("Error durante el proceso. Descripcion: " + ex.Message, "Error Interno", MessageBoxButtons.OK, MessageBoxIcon.Hand);
      }
    }

    public void CloseDocument()
    {
      if (this.wordApp == null)
        return;
      object SaveChanges = (object) WdSaveOptions.wdSaveChanges;
      // ISSUE: reference to a compiler-generated method
      this.aDoc.Close(ref SaveChanges, ref this.missing, ref this.missing);
      // ISSUE: reference to a compiler-generated method
      this.wordApp.Quit(ref SaveChanges, ref this.missing, ref this.missing);
      this.aDoc = (Document) null;
      this.wordApp = (Microsoft.Office.Interop.Word.Application) null;
    }

    public void OpenDocument(string _ruta)
    {
      string str = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), _ruta);
      if (!File.Exists(str))
        return;
      Process.Start("WINWORD.EXE", str);
    }

    public void FillTable(List<string> records, int table, int rows)
    {
      this.fillTable(this.wordApp, records, table, rows);
    }

    public void FillTableNew(List<string> records, int table, int rows, bool ultimo)
    {
      this.fillTableNew(this.wordApp, records, table, rows, ultimo);
    }

    public void fillTable(Microsoft.Office.Interop.Word.Application wordApp, List<string> records, int table, int rows)
    {
      try
      {
        // ISSUE: variable of a compiler-generated type
        Table table1 = this.aDoc.Tables[table];
        // ISSUE: variable of a compiler-generated type
        Rows rows1 = table1.Rows;
        object BeforeRow = (object) Missing.Value;
        // ISSUE: reference to a compiler-generated method
        rows1.Add(ref BeforeRow);
        table1.Range.Font.Size = 8f;
        if (records.Count > 1)
        {
          // ISSUE: reference to a compiler-generated method
          table1.Columns.DistributeWidth();
          table1.Rows.Alignment = WdRowAlignment.wdAlignRowCenter;
        }
        else
          table1.Borders.Enable = 0;
        int Column = 1;
        int Row = 2 + rows;
        foreach (string record in records)
        {
          // ISSUE: reference to a compiler-generated method
          table1.Cell(Row, Column).Range.Text = record;
          ++Column;
        }
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show("Error durante el proceso de la tabla . Descripcion: " + ex.Message, "Error Interno", MessageBoxButtons.OK, MessageBoxIcon.Hand);
      }
    }

    public void fillTableNew(Microsoft.Office.Interop.Word.Application wordApp, List<string> records, int table, int rows, bool ultimo)
    {
      try
      {
        // ISSUE: variable of a compiler-generated type
        Table table1 = this.aDoc.Tables[table];
        table1.Range.Font.Size = 8f;
        table1.Borders.Enable = 0;
        int Column = 1;
        int Row = 1 + rows;
        if (Row == 1)
        {
          foreach (string record in records)
          {
            // ISSUE: reference to a compiler-generated method
            table1.Cell(Row, Column).Range.Text = record;
            // ISSUE: reference to a compiler-generated method
            table1.Cell(Row, Column).Range.Font.Bold = 1;
            ++Column;
          }
          // ISSUE: variable of a compiler-generated type
          Rows rows1 = table1.Rows;
          object BeforeRow = (object) Missing.Value;
          // ISSUE: reference to a compiler-generated method
          rows1.Add(ref BeforeRow);
        }
        else if (!ultimo)
        {
          foreach (string record in records)
          {
            // ISSUE: reference to a compiler-generated method
            table1.Cell(Row, Column).Range.Text = record;
            // ISSUE: reference to a compiler-generated method
            table1.Cell(Row, Column).Range.Font.Bold = 0;
            ++Column;
          }
          // ISSUE: variable of a compiler-generated type
          Rows rows1 = table1.Rows;
          object BeforeRow = (object) Missing.Value;
          // ISSUE: reference to a compiler-generated method
          rows1.Add(ref BeforeRow);
        }
        else
        {
          foreach (string record in records)
          {
            // ISSUE: reference to a compiler-generated method
            table1.Cell(Row, Column).Range.Text = record;
            // ISSUE: reference to a compiler-generated method
            table1.Cell(Row, Column).Range.Font.Bold = 1;
            // ISSUE: reference to a compiler-generated method
            table1.Cell(Row, Column).Range.Borders[WdBorderType.wdBorderTop].LineStyle = WdLineStyle.wdLineStyleSingle;
            ++Column;
          }
        }
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show("Error durante el proceso de la tabla . Descripcion: " + ex.Message, "Error Interno", MessageBoxButtons.OK, MessageBoxIcon.Hand);
      }
    }

    public void FindAndReplace(object findText, object replaceText)
    {
      this.findAndReplace(this.wordApp, findText, replaceText);
    }

    public void FindAndReplaceTwo(object findText, object replaceText)
    {
      object MatchCase = (object) true;
      object MatchWholeWord = (object) true;
      object MatchWildcards = (object) false;
      object MatchSoundsLike = (object) false;
      object MatchAllWordForms = (object) false;
      object Forward = (object) true;
      object Format = (object) false;
      object MatchKashida = (object) false;
      object MatchDiacritics = (object) false;
      object MatchAlefHamza = (object) false;
      object MatchControl = (object) false;
      object Replace = (object) 2;
      object Wrap = (object) 1;
      // ISSUE: reference to a compiler-generated method
      this.wordApp.Selection.Find.Execute(ref findText, ref MatchCase, ref MatchWholeWord, ref MatchWildcards, ref MatchSoundsLike, ref MatchAllWordForms, ref Forward, ref Wrap, ref Format, ref replaceText, ref Replace, ref MatchKashida, ref MatchDiacritics, ref MatchAlefHamza, ref MatchControl);
    }

    public void findAndReplace(Microsoft.Office.Interop.Word.Application wordApp, object findText, object replaceText)
    {
      object MatchCase = (object) true;
      object MatchWholeWord = (object) true;
      object MatchWildcards = (object) false;
      object MatchSoundsLike = (object) false;
      object MatchAllWordForms = (object) false;
      object Forward = (object) true;
      object Format = (object) false;
      object MatchKashida = (object) false;
      object MatchDiacritics = (object) false;
      object MatchAlefHamza = (object) false;
      object MatchControl = (object) false;
      object Replace = (object) 2;
      object Wrap = (object) 1;
      // ISSUE: reference to a compiler-generated method
      wordApp.Selection.Find.Execute(ref findText, ref MatchCase, ref MatchWholeWord, ref MatchWildcards, ref MatchSoundsLike, ref MatchAllWordForms, ref Forward, ref Wrap, ref Format, ref replaceText, ref Replace, ref MatchKashida, ref MatchDiacritics, ref MatchAlefHamza, ref MatchControl);
    }
  }
}
