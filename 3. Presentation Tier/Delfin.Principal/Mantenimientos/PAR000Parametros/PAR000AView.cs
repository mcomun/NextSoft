using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Delfin.Principal
{
    public partial class PAR000AView : Form
    {
        #region [ Variables ]
        public enum TAyuda
        {
            TEntidad = 0, TDocumentos = 1, Entidad = 2, CuentasContables = 3
        }
        String m_resultado;
        TAyuda m_tAyuda;
        #endregion

        #region [ Constructores ]
        public PAR000AView(String x_Title, ObservableCollection<Entities.TiposEntidad> x_ListTiposEntidad, String x_Seleccionados, TAyuda x_TipoAyuda)
        {
            InitializeComponent();

            this.Text = x_Title;
            this.m_tAyuda = x_TipoAyuda;
            Char[] delimiterChars = { '|' };
            String[] m_itemsSeleccionados = null;
            if (!String.IsNullOrEmpty(x_Seleccionados))
            { m_itemsSeleccionados = x_Seleccionados.Split(delimiterChars); }

            clbList_Codigo.Items.Clear();
            clbList_Codigo.View = View.List;
            clbList_Codigo.CheckBoxes = true;
            foreach (Entities.TiposEntidad TipoEntidad in x_ListTiposEntidad)
            {
                Boolean boolean = false;
                ListViewItem item = new ListViewItem(String.Format("{0} - [{1}]", TipoEntidad.TIPE_Descripcion, TipoEntidad.TIPE_Codigo)) { Tag = TipoEntidad };
                if (m_itemsSeleccionados == null || m_itemsSeleccionados.Length == 0)
                { item.Checked = false; }
                else
                {
                    foreach (String seleccionado in m_itemsSeleccionados)
                    {
                        if (!boolean)
                        {
                            Int16 x;
                            if (Int16.TryParse(seleccionado, out x))
                            {
                                if (TipoEntidad.TIPE_Codigo == x)
                                { item.Checked = true; boolean = true; }
                                else
                                { item.Checked = false; }
                            }
                            else
                            { item.Checked = false; }
                        }
                    }
                }
                clbList_Codigo.Items.Add(item);
            }

            btnAceptar.Click += btnAceptar_Click;
            btnCancelar.Click += btnCancelar_Click;
        }

        public PAR000AView(String x_Title, ObservableCollection<Entities.Tipos> x_ListTipos, String x_Seleccionados, TAyuda x_TipoAyuda)
        {
            InitializeComponent();

            this.Text = x_Title;
            this.m_tAyuda = x_TipoAyuda;
            Char[] delimiterChars = { '|' };
            String[] m_itemsSeleccionados = null;
            if (!String.IsNullOrEmpty(x_Seleccionados))
            { m_itemsSeleccionados = x_Seleccionados.Split(delimiterChars); }

            clbList_Codigo.Items.Clear();
            clbList_Codigo.View = View.List;
            clbList_Codigo.CheckBoxes = true;
            foreach (Entities.Tipos Tipo in x_ListTipos)
            {
                Boolean boolean = false;
                ListViewItem item = new ListViewItem(String.Format("{0} - [{1}]", Tipo.TIPO_Desc1, Tipo.TIPO_CodTipo)) { Tag = Tipo };
                if (m_itemsSeleccionados == null || m_itemsSeleccionados.Length == 0)
                { item.Checked = false; }
                else
                {
                    foreach (String seleccionado in m_itemsSeleccionados)
                    {
                        if (!boolean)
                        {
                            if (!string.IsNullOrEmpty(seleccionado))
                            {
                                if (x_TipoAyuda == TAyuda.CuentasContables)
                                {
                                    if (Tipo.TIPO_Desc1 == seleccionado)
                                    { item.Checked = true; boolean = true; }
                                    else
                                    { item.Checked = false; }
                                }
                                else
                                {
                                    if (Tipo.TIPO_CodTipo == seleccionado)
                                    { item.Checked = true; boolean = true; }
                                    else
                                    { item.Checked = false; }
                                }
                            }
                            else
                            { item.Checked = false; }
                        }
                    }
                }
                clbList_Codigo.Items.Add(item);
            }

            btnAceptar.Click += btnAceptar_Click;
            btnCancelar.Click += btnCancelar_Click;
        }
        public PAR000AView(String x_Title, ObservableCollection<Entities.Entidad> x_ListEntidad, String x_Seleccionados, TAyuda x_TipoAyuda)
        {
            InitializeComponent();

            this.Text = x_Title;
            this.m_tAyuda = x_TipoAyuda;
            Char[] delimiterChars = { '-' };
            String[] m_itemsSeleccionados = null;
            if (!String.IsNullOrEmpty(x_Seleccionados))
            { m_itemsSeleccionados = x_Seleccionados.Split(delimiterChars); }

            clbList_Codigo.Items.Clear();
            clbList_Codigo.View = View.List;
            clbList_Codigo.CheckBoxes = true;
            foreach (Entities.Entidad Entidad in x_ListEntidad)
            {
                Boolean boolean = false;
                ListViewItem item = new ListViewItem(String.Format("{0} - [{1}]", Entidad.ENTC_Codigo, Entidad.ENTC_NomCompleto)) { Tag = Entidad };
                if (m_itemsSeleccionados == null || m_itemsSeleccionados.Length == 0)
                { item.Checked = false; }
                else
                {
                    foreach (String seleccionado in m_itemsSeleccionados)
                    {
                        if (!boolean)
                        {
                            Int16 x;
                            if (Int16.TryParse(seleccionado, out x))
                            {
                                if (Entidad.ENTC_Codigo == x)
                                { item.Checked = true; boolean = true; }
                                else
                                { item.Checked = false; }
                            }
                            else
                            { item.Checked = false; }
                        }
                    }
                }
                clbList_Codigo.Items.Add(item);
            }

            btnAceptar.Click += btnAceptar_Click;
            btnCancelar.Click += btnCancelar_Click;
            this.Width = this.Width * 2;
        }
        #endregion

        #region [ Eventos ]
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            int pos = 1;
            m_resultado = String.Empty;
            foreach (ListViewItem item in clbList_Codigo.Items)
            {
                if (item.Checked)
                {
                    switch (m_tAyuda)
                    {
                        case TAyuda.TEntidad:
                            m_resultado += String.Format("{0}|", ((Entities.TiposEntidad)item.Tag).TIPE_Codigo);
                            break;
                        case TAyuda.TDocumentos:
                            m_resultado += String.Format("{0}|", ((Entities.Tipos)item.Tag).TIPO_CodTipo);
                            break;
                        case TAyuda.Entidad:
                            m_resultado += String.Format("-{0}", ((Entities.Entidad)item.Tag).ENTC_Codigo);
                            break;
                        case TAyuda.CuentasContables:
                            m_resultado += String.Format("{0}|", ((Entities.Tipos)item.Tag).TIPO_Desc1);
                            break;
                    }
                }
                if (clbList_Codigo.Items.Count == pos)
                {
                    switch (m_tAyuda)
                    {
                        case TAyuda.TEntidad:
                        case TAyuda.TDocumentos:
                            if (!String.IsNullOrEmpty(m_resultado))
                            { m_resultado = m_resultado.Remove(m_resultado.Length - 1); }
                            break;
                        case TAyuda.Entidad:
                            m_resultado += "-";
                            break;
                    }

                }
                pos++;
            }
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }
        #endregion

        #region [ Propiedades ]
        public String Texto { get { return m_resultado; } }
        #endregion
    }
}