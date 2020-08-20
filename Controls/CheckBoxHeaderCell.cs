// Decompiled with JetBrains decompiler
// Type: Delfin.Controls.CheckBoxHeaderCell
// Assembly: Delfin.Controls, Version=3.0.1.3, Culture=neutral, PublicKeyToken=null
// MVID: A4BA2B33-0E71-44B0-9838-A6C1CD0C2B15
// Assembly location: C:\Temp\Delfin.Controls.dll

using System;
using System.Drawing;
using Telerik.WinControls;
using Telerik.WinControls.Enumerations;
using Telerik.WinControls.UI;

namespace Delfin.Controls
{
  public class CheckBoxHeaderCell : GridHeaderCellElement
  {
    private RadCheckBoxElement checkbox;
    private bool suspendProcessingToggleStateChanged;

    protected override Type ThemeEffectiveType
    {
      get
      {
        return typeof (GridHeaderCellElement);
      }
    }

    public CheckBoxHeaderCell(GridViewColumn column, GridRowElement row)
      : base(column, row)
    {
    }

    public override void Initialize(GridViewColumn column, GridRowElement row)
    {
      base.Initialize(column, row);
      column.AllowSort = false;
    }

    public override void SetContent()
    {
    }

    protected override void DisposeManagedResources()
    {
      this.checkbox.ToggleStateChanged -= new StateChangedEventHandler(this.checkbox_ToggleStateChanged);
      base.DisposeManagedResources();
    }

    protected override void CreateChildElements()
    {
      base.CreateChildElements();
      this.checkbox = new RadCheckBoxElement();
      this.checkbox.ToggleStateChanged += new StateChangedEventHandler(this.checkbox_ToggleStateChanged);
      this.Children.Add((RadElement) this.checkbox);
    }

    protected override SizeF ArrangeOverride(SizeF finalSize)
    {
      SizeF sizeF = base.ArrangeOverride(finalSize);
      RectangleF clientRectangle = this.GetClientRectangle(finalSize);
      this.checkbox.Arrange(new RectangleF((float) (((double) finalSize.Width - (double) this.checkbox.DesiredSize.Width) / 2.0), (float) (((double) clientRectangle.Height - 20.0) / 2.0), 20f, 20f));
      return sizeF;
    }

    public override bool IsCompatible(GridViewColumn data, object context)
    {
      if (data.Name == "Agregar" && context is GridTableHeaderRowElement)
        return base.IsCompatible(data, context);
      return false;
    }

    private void checkbox_ToggleStateChanged(object sender, StateChangedEventArgs args)
    {
      if (this.suspendProcessingToggleStateChanged)
        return;
      bool flag = false;
      if (args.ToggleState == ToggleState.On)
        flag = true;
      this.GridViewElement.EditorManager.EndEdit();
      this.TableElement.BeginUpdate();
      for (int index = 0; index < this.ViewInfo.Rows.Count; ++index)
        this.ViewInfo.Rows[index].Cells[this.ColumnIndex].Value = (object) flag;
      this.TableElement.EndUpdate(false);
      this.TableElement.Update(GridUINotifyAction.DataChanged);
    }

    public void SetCheckBoxState(ToggleState state)
    {
      this.suspendProcessingToggleStateChanged = true;
      this.checkbox.ToggleState = state;
      this.suspendProcessingToggleStateChanged = false;
    }

    public override void Attach(GridViewColumn data, object context)
    {
      base.Attach(data, context);
      this.GridControl.ValueChanged += new EventHandler(this.GridControl_ValueChanged);
    }

    public override void Detach()
    {
      if (this.GridControl != null)
        this.GridControl.ValueChanged -= new EventHandler(this.GridControl_ValueChanged);
      base.Detach();
    }

    private void GridControl_ValueChanged(object sender, EventArgs e)
    {
      RadCheckBoxEditor radCheckBoxEditor = sender as RadCheckBoxEditor;
      if (radCheckBoxEditor == null)
        return;
      this.GridViewElement.EditorManager.EndEdit();
      this.TableElement.BeginUpdate();
      if ((ToggleState) radCheckBoxEditor.Value == ToggleState.Off)
        this.SetCheckBoxState(ToggleState.Off);
      else if ((ToggleState) radCheckBoxEditor.Value == ToggleState.On)
      {
        bool flag = false;
        foreach (GridViewRowInfo row in this.ViewInfo.Rows)
        {
          if (row != this.RowInfo && row.Cells[this.ColumnIndex].Value == null || !(bool) row.Cells[this.ColumnIndex].Value)
          {
            flag = true;
            break;
          }
        }
        if (!flag)
          this.SetCheckBoxState(ToggleState.On);
      }
      this.TableElement.EndUpdate(false);
      this.TableElement.Update(GridUINotifyAction.DataChanged);
    }
  }
}
