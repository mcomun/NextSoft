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
    public partial class MAN010MView : Form, IMAN010MView
    {
        #region [ Variables ]

        #endregion

        #region [ Formulario ]
        public MAN010MView()
        {
            InitializeComponent();
            try
            {
                this.FormClosing += new FormClosingEventHandler(MView_FormClosing);
                btnMAN_guardar.Click += btnGuardar_Click;
                btnMAN_salir.Click += btnSalir_Click;
            }
            catch (Exception ex)
            { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al inicializar el formulario MView.", ex); }
        }
        #endregion

        #region [ Propiedades ]
        public MAN010Presenter Presenter { get; set; }
        private bool Closing = false;
        private System.Collections.Hashtable HashFormulario { get; set; }
        #endregion

        #region [ ICUS007MView ]
        public void LoadView()
        {
            try
            {
               CONS_CodVia.LoadControl(Presenter.ContainerService, "Constantes Vías", "VIA", "< Seleccionar Vía >", ListSortDirection.Ascending);
               CONS_CodEnt.LoadControl(Presenter.ContainerService, "Constantes Entidad Emisora", "CEM", "< Seleccionar Entidad Emisora >", ListSortDirection.Ascending);
            }
            catch (Exception ex)
            { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error cargando la vista.", ex); }
        }

        public void ClearItem()
        {
            try
            {
                 NAVE_Codigo.Text = string.Empty;
                 NAVE_Nombre.Text = string.Empty;
                 NAVE_Matricula.Text = string.Empty;
                 CONS_CodVia.SelectedIndex = 0;
                 CONS_CodEnt.SelectedIndex = 0;
            }
            catch (Exception ex)
            { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error limpiando el item.", ex); }
        }
        public void GetItem()
        {
            try
            {
                if (Presenter != null && Presenter.Item != null)
                {
                    if (NAVE_Codigo.Text.ToString() == "")
                    { Presenter.Item.NAVE_Codigo = 0; }
                    else { Presenter.Item.NAVE_Codigo = Convert.ToInt16( NAVE_Codigo.Text) ; }
                    Presenter.Item.NAVE_Nombre = NAVE_Nombre.Text;
                    Presenter.Item.CONS_CodVia = CONS_CodVia.SelectedValue.ToString() ;
                    Presenter.Item.NAVE_EntidadEmisora = CONS_CodEnt.SelectedValue.ToString();
                    Presenter.Item.CONS_TabVia = "VIA";
                    Presenter.Item.CONS_TabEntEmi = "CEM";
                    Presenter.Item.NAVE_Matricula = NAVE_Matricula.Text;

                }
            }
            catch (Exception ex)
            { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error obteniendo el item.", ex); }
        }
        public void SetItem()
        {
            try
            {
                if (Presenter != null && Presenter.Item != null)
                {
                    NAVE_Codigo.Text = Presenter.Item.NAVE_Codigo.ToString();
                    NAVE_Nombre.Text = Presenter.Item.NAVE_Nombre;
                    NAVE_Matricula.Text = Presenter.Item.NAVE_Matricula;
                    if (Presenter.Item.CONS_CodVia != null)
                    { CONS_CodVia.SelectedValue = Presenter.Item.CONS_CodVia; }
                    else { CONS_CodVia.SelectedIndex =0; }

                    if (Presenter.Item.NAVE_EntidadEmisora != null)
                    { CONS_CodEnt.SelectedValue = Presenter.Item.NAVE_EntidadEmisora; }
                    else { CONS_CodEnt.SelectedIndex = 0; }


                    //ENTC_CodTransportista = Presenter.Item.ENTC_CodTransportista;
                }
                HashFormulario = Infrastructure.Client.FormClose.FormValidateChanges.iniciarComparacionFormulario(this);
            }
            catch (Exception ex)
            { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error seteando el item.", ex); }
        }

        public void ShowValidation()
        {
            try
            {
                Infrastructure.Client.FormClose.FormShowErrorProvider<Entities.Nave>.Validate(Presenter.Item, this, errorProvider1);
            }
            catch (Exception ex)
            { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error mostrando la validación", ex); }
        }
        #endregion

        #region [ Metodos ]

        #endregion

        #region [ Eventos ]
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (Presenter.Guardar())
                {
                    this.FormClosing -= MView_FormClosing;
                    errorProvider1.Dispose();
                    //'Presenter.Actualizar(); ya esta actualizando al btnGuardar_Click en else presenter
                    this.Close();
                }
            }
            catch (Exception ex)
            { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al Guardar.", ex); }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            try
            {
                this.FormClosing -= MView_FormClosing;
                errorProvider1.Dispose();
                if (Infrastructure.Client.FormClose.FormValidateChanges.verificarCambioFormulario(this, HashFormulario))
                {
                    if (Presenter.GuardarCambios() != System.Windows.Forms.DialogResult.Cancel)
                    { this.Close(); }
                    else
                    { this.FormClosing += MView_FormClosing; }
                }
                else
                { this.Close(); }
                Closing = true;
            }
            catch (Exception ex)
            { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al cerrar el formulario.", ex); }
        }

        private void MView_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (Closing != true)
                {
                    this.FormClosing -= MView_FormClosing;
                    if (Infrastructure.Client.FormClose.FormValidateChanges.verificarCambioFormulario(this, HashFormulario))
                    {
                        if (Presenter.GuardarCambios() == System.Windows.Forms.DialogResult.Cancel)
                        {
                            e.Cancel = true;
                            this.FormClosing += new FormClosingEventHandler(MView_FormClosing);
                        }
                    }
                }
                else
                { Closing = false; e.Cancel = true; }
            }
            catch (Exception ex)
            { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al cerrar el formulario.", ex); }
        }

        #endregion



    }
}

