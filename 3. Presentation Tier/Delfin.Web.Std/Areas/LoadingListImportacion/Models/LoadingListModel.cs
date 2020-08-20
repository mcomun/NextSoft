using System;
//using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Globalization;
using System.Web.Security;

using Delfin.Entities;
using Delfin.ServiceProxy;
using Microsoft.Practices.Unity;
using System.Web.Mvc;
using System.Collections.ObjectModel;
using System.Web;
using System.Linq;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ComponentModel;

namespace Delfin.Web.Std.Areas.LoadingListImportacion.Models
{
   public class LoadingListModel : INotifyPropertyChanged 
   {
      #region [ Variables ]

      private String m_load_shipper;
      private String m_load_consignee;
      private String m_load_notify;
      private String m_load_carrier;
      private String m_load_booking;
      private String m_load_mbl;
      private String m_load_hbl;
      private Nullable<DateTime> m_load_eta;
      private Nullable<DateTime> m_load_etd;
      private String m_load_payment;
      private String m_load_naveviaje;
      private Nullable<Int32> m_load_codigo;
      private Nullable<Int32> m_ccot_numero;
      private Nullable<Int16> m_ccot_tipo;
      private String m_load_contractnro;
      private String m_load_primerusuario;
      private Nullable<Boolean> m_load_segundook;
      private String m_load_segundousuario;
      private String m_load_cargausuario;
      private Nullable<Boolean> m_load_primerok;
      private Nullable<Boolean> m_load_error;
      private Nullable<Boolean> m_load_enviocorreo;
      private Nullable<DateTime> m_load_enviocorreofecha;
      private String m_load_enviocorreousuario;
      private String m_load_errordescripcion;
      private Nullable<DateTime> m_load_cargafecha;
      private Nullable<Int32> m_puer_codorigen;
      private Nullable<Int32> m_puer_coddestino;
      private Nullable<DateTime> m_load_fecprimerok;
      private Nullable<DateTime> m_load_fecsegundook;
      private Int32 m_nvia_codigo;
      private Nullable<DateTime> m_load_fecdevolucion;

      #endregion

      #region [ Constructores ]

      /// <summary>
      /// Inicializar una nueva instancia de la clase LoadingList.
      /// </summary>
      public LoadingListModel()
      {
      }

      #endregion

      #region [ Propiedades ]

      /// <summary>
      /// Gets or sets el valor de: LOAD_Shipper.
      /// </summary>
      [DataMember]
      [Display(Name = "Shipper")]
      public String LOAD_Shipper
      {
         get { return m_load_shipper; }
         set
         {
            if (m_load_shipper != value)
            {
               m_load_shipper = value;
               OnPropertyChanged("LOAD_Shipper");
            }
         }
      }

      /// <summary>
      /// Gets or sets el valor de: LOAD_Consignee.
      /// </summary>
      [DataMember]
      [Display(Name = "Consignee")]
      public String LOAD_Consignee
      {
         get { return m_load_consignee; }
         set
         {
            if (m_load_consignee != value)
            {
               m_load_consignee = value;
               OnPropertyChanged("LOAD_Consignee");
            }
         }
      }

      /// <summary>
      /// Gets or sets el valor de: LOAD_Notify.
      /// </summary>
      [DataMember]
      [Display(Name = "Notify")]
      public String LOAD_Notify
      {
         get { return m_load_notify; }
         set
         {
            if (m_load_notify != value)
            {
               m_load_notify = value;
               OnPropertyChanged("LOAD_Notify");
            }
         }
      }

      /// <summary>
      /// Gets or sets el valor de: LOAD_Carrier.
      /// </summary>
      [DataMember]
      [Display(Name = "Carrier")]
      public String LOAD_Carrier
      {
         get { return m_load_carrier; }
         set
         {
            if (m_load_carrier != value)
            {
               m_load_carrier = value;
               OnPropertyChanged("LOAD_Carrier");
            }
         }
      }

      /// <summary>
      /// Gets or sets el valor de: LOAD_Booking.
      /// </summary>
      [DataMember]
      [Display(Name = "Booking")]
      public String LOAD_Booking
      {
         get { return m_load_booking; }
         set
         {
            if (m_load_booking != value)
            {
               m_load_booking = value;
               OnPropertyChanged("LOAD_Booking");
            }
         }
      }

      /// <summary>
      /// Gets or sets el valor de: LOAD_MBL.
      /// </summary>
      [DataMember]
      [Display(Name = "MBL")]
      public String LOAD_MBL
      {
         get { return m_load_mbl; }
         set
         {
            if (m_load_mbl != value)
            {
               m_load_mbl = value;
               OnPropertyChanged("LOAD_MBL");
            }
         }
      }

      /// <summary>
      /// Gets or sets el valor de: LOAD_HBL.
      /// </summary>
      [DataMember]
      [Display(Name = "HBL")]
      public String LOAD_HBL
      {
         get { return m_load_hbl; }
         set
         {
            if (m_load_hbl != value)
            {
               m_load_hbl = value;
               OnPropertyChanged("LOAD_HBL");
            }
         }
      }

      /// <summary>
      /// Gets or sets el valor de: LOAD_ETA.
      /// </summary>
      [DataMember]
      [Display(Name = "ETA")]
      public Nullable<DateTime> LOAD_ETA
      {
         get { return m_load_eta; }
         set
         {
            if (m_load_eta != value)
            {
               m_load_eta = value;
               OnPropertyChanged("LOAD_ETA");
            }
         }
      }

      /// <summary>
      /// Gets or sets el valor de: LOAD_ETD.
      /// </summary>
      [DataMember]
      [Display(Name = "ETD")]
      public Nullable<DateTime> LOAD_ETD
      {
         get { return m_load_etd; }
         set
         {
            if (m_load_etd != value)
            {
               m_load_etd = value;
               OnPropertyChanged("LOAD_ETD");
            }
         }
      }

      /// <summary>
      /// Gets or sets el valor de: LOAD_Payment.
      /// </summary>
      [DataMember]
      [Display(Name = "Payment")]
      public String LOAD_Payment
      {
         get { return m_load_payment; }
         set
         {
            if (m_load_payment != value)
            {
               m_load_payment = value;
               OnPropertyChanged("LOAD_Payment");
            }
         }
      }

      /// <summary>
      /// Gets or sets el valor de: LOAD_NaveViaje.
      /// </summary>
      [DataMember]
      [Display(Name = "Viaje")]
      public String LOAD_NaveViaje
      {
         get { return m_load_naveviaje; }
         set
         {
            if (m_load_naveviaje != value)
            {
               m_load_naveviaje = value;
               OnPropertyChanged("LOAD_NaveViaje");
            }
         }
      }

      /// <summary>
      /// Gets or sets el valor de: LOAD_Codigo.
      /// </summary>
      [DataMember]
      [Display(Name = "Código")]
      public Nullable<Int32> LOAD_Codigo
      {
         get { return m_load_codigo; }
         set
         {
            if (m_load_codigo != value)
            {
               m_load_codigo = value;
               OnPropertyChanged("LOAD_Codigo");
            }
         }
      }

      /// <summary>
      /// Gets or sets el valor de: CCOT_Numero.
      /// </summary>
      [DataMember]
      [Display(Name = "Código Orden Venta")]
      public Nullable<Int32> CCOT_Numero
      {
         get { return m_ccot_numero; }
         set
         {
            if (m_ccot_numero != value)
            {
               m_ccot_numero = value;
               OnPropertyChanged("CCOT_Numero");
            }
         }
      }

      /// <summary>
      /// Gets or sets el valor de: CCOT_Tipo.
      /// </summary>
      [DataMember]
      [Display(Name = "Tipo Orden Venta")]
      public Nullable<Int16> CCOT_Tipo
      {
         get { return m_ccot_tipo; }
         set
         {
            if (m_ccot_tipo != value)
            {
               m_ccot_tipo = value;
               OnPropertyChanged("CCOT_Tipo");
            }
         }
      }

      /// <summary>
      /// Gets or sets el valor de: LOAD_ContractNRO.
      /// </summary>
      [DataMember]
      [Display(Name = "Nro. Contrato")]
      public String LOAD_ContractNRO
      {
         get { return m_load_contractnro; }
         set
         {
            if (m_load_contractnro != value)
            {
               m_load_contractnro = value;
               OnPropertyChanged("LOAD_ContractNRO");
            }
         }
      }

      /// <summary>
      /// Gets or sets el valor de: LOAD_PrimerUsuario.
      /// </summary>
      [DataMember]
      [Display(Name = "Usuario Primer OK")]
      public String LOAD_PrimerUsuario
      {
         get { return m_load_primerusuario; }
         set
         {
            if (m_load_primerusuario != value)
            {
               m_load_primerusuario = value;
               OnPropertyChanged("LOAD_PrimerUsuario");
            }
         }
      }

      /// <summary>
      /// Gets or sets el valor de: LOAD_SegundoOK.
      /// </summary>
      [DataMember]
      [Display(Name = "Segundo OK")]
      public Nullable<Boolean> LOAD_SegundoOK
      {
         get { return m_load_segundook; }
         set
         {
            if (m_load_segundook != value)
            {
               m_load_segundook = value;
               OnPropertyChanged("LOAD_SegundoOK");
            }
         }
      }

      /// <summary>
      /// Gets or sets el valor de: LOAD_SegundoUsuario.
      /// </summary>
      [DataMember]
      [Display(Name = "Usuario Segundo OK")]
      public String LOAD_SegundoUsuario
      {
         get { return m_load_segundousuario; }
         set
         {
            if (m_load_segundousuario != value)
            {
               m_load_segundousuario = value;
               OnPropertyChanged("LOAD_SegundoUsuario");
            }
         }
      }

      /// <summary>
      /// Gets or sets el valor de: LOAD_CargaUsuario.
      /// </summary>
      [DataMember]
      [Display(Name = "Usuario Carga")]
      public String LOAD_CargaUsuario
      {
         get { return m_load_cargausuario; }
         set
         {
            if (m_load_cargausuario != value)
            {
               m_load_cargausuario = value;
               OnPropertyChanged("LOAD_CargaUsuario");
            }
         }
      }

      /// <summary>
      /// Gets or sets el valor de: LOAD_PrimerOK.
      /// </summary>
      [DataMember]
      [Display(Name = "OK")]
      public Nullable<Boolean> LOAD_PrimerOK
      {
         get { return m_load_primerok; }
         set
         {
            if (m_load_primerok != value)
            {
               m_load_primerok = value;
               OnPropertyChanged("LOAD_PrimerOK");
            }
         }
      }

      /// <summary>
      /// Gets or sets el valor de: LOAD_Error.
      /// </summary>
      [DataMember]
      [Display(Name = "Error")]
      public Nullable<Boolean> LOAD_Error
      {
         get { return m_load_error; }
         set
         {
            if (m_load_error != value)
            {
               m_load_error = value;
               OnPropertyChanged("LOAD_Error");
            }
         }
      }

      /// <summary>
      /// Gets or sets el valor de: LOAD_EnvioCorreo.
      /// </summary>
      [DataMember]
      [Display(Name = "Envió Correo")]
      public Nullable<Boolean> LOAD_EnvioCorreo
      {
         get { return m_load_enviocorreo; }
         set
         {
            if (m_load_enviocorreo != value)
            {
               m_load_enviocorreo = value;
               OnPropertyChanged("LOAD_EnvioCorreo");
            }
         }
      }

      /// <summary>
      /// Gets or sets el valor de: LOAD_EnvioCorreoFecha.
      /// </summary>
      [DataMember]
      [Display(Name = "Fecha Envió Correo")]
      public Nullable<DateTime> LOAD_EnvioCorreoFecha
      {
         get { return m_load_enviocorreofecha; }
         set
         {
            if (m_load_enviocorreofecha != value)
            {
               m_load_enviocorreofecha = value;
               OnPropertyChanged("LOAD_EnvioCorreoFecha");
            }
         }
      }

      /// <summary>
      /// Gets or sets el valor de: LOAD_EnvioCorreoUsuario.
      /// </summary>
      [DataMember]
      [Display(Name = "Correo")]
      public String LOAD_EnvioCorreoUsuario
      {
         get { return m_load_enviocorreousuario; }
         set
         {
            if (m_load_enviocorreousuario != value)
            {
               m_load_enviocorreousuario = value;
               OnPropertyChanged("LOAD_EnvioCorreoUsuario");
            }
         }
      }

      /// <summary>
      /// Gets or sets el valor de: LOAD_ErrorDescripcion.
      /// </summary>
      [DataMember]
      [Display(Name = "Descripción Error")]
      public String LOAD_ErrorDescripcion
      {
         get { return m_load_errordescripcion; }
         set
         {
            if (m_load_errordescripcion != value)
            {
               m_load_errordescripcion = value;
               OnPropertyChanged("LOAD_ErrorDescripcion");
            }
         }
      }

      /// <summary>
      /// Gets or sets el valor de: LOAD_CargaFecha.
      /// </summary>
      [DataMember]
      [Display(Name = "Fecha Carga")]
      [DataType(DataType.Date)]
      [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
      public Nullable<DateTime> LOAD_CargaFecha
      {
         get { return m_load_cargafecha; }
         set
         {
            if (m_load_cargafecha != value)
            {
               m_load_cargafecha = value;
               OnPropertyChanged("LOAD_CargaFecha");
            }
         }
      }

      /// <summary>
      /// Gets or sets el valor de: PUER_CodOrigen.
      /// </summary>
      [DataMember]
      [Display(Name = "Código Puerto Origen")]
      public Nullable<Int32> PUER_CodOrigen
      {
         get { return m_puer_codorigen; }
         set
         {
            if (m_puer_codorigen != value)
            {
               m_puer_codorigen = value;
               OnPropertyChanged("PUER_CodOrigen");
            }
         }
      }

      /// <summary>
      /// Gets or sets el valor de: PUER_CodDestino.
      /// </summary>
      [DataMember]
      [Display(Name = "Código Puerto Destino")]
      public Nullable<Int32> PUER_CodDestino
      {
         get { return m_puer_coddestino; }
         set
         {
            if (m_puer_coddestino != value)
            {
               m_puer_coddestino = value;
               OnPropertyChanged("PUER_CodDestino");
            }
         }
      }

      /// <summary>
      /// Gets or sets el valor de: LOAD_FecPrimerOK.
      /// </summary>
      [DataMember]
      [Display(Name = "Fecha Primer OK")]
      public Nullable<DateTime> LOAD_FecPrimerOK
      {
         get { return m_load_fecprimerok; }
         set
         {
            if (m_load_fecprimerok != value)
            {
               m_load_fecprimerok = value;
               OnPropertyChanged("LOAD_FecPrimerOK");
            }
         }
      }

      /// <summary>
      /// Gets or sets el valor de: LOAD_FecSegundoOK.
      /// </summary>
      [DataMember]
      [Display(Name = "Fecha Segundo OK")]
      public Nullable<DateTime> LOAD_FecSegundoOK
      {
         get { return m_load_fecsegundook; }
         set
         {
            if (m_load_fecsegundook != value)
            {
               m_load_fecsegundook = value;
               OnPropertyChanged("LOAD_FecSegundoOK");
            }
         }
      }

      /// <summary>
      /// Gets or sets el valor de: NVIA_Codigo.
      /// </summary>
      [DataMember]
      [Display(Name = "Recalada")]
      public Int32 NVIA_Codigo
      {
         get { return m_nvia_codigo; }
         set
         {
            if (m_nvia_codigo != value)
            {
               m_nvia_codigo = value;
               OnPropertyChanged("NVIA_Codigo");
            }
         }
      }

      /// <summary>
      /// Gets or sets el valor de: LOAD_FecDevolucion.
      /// </summary>
      [DataMember]
      [Display(Name = "Fecha Devolución")]
      public Nullable<DateTime> LOAD_FecDevolucion
      {
         get { return m_load_fecdevolucion; }
         set
         {
            if (m_load_fecdevolucion != value)
            {
               m_load_fecdevolucion = value;
               OnPropertyChanged("LOAD_FecDevolucion");
            }
         }
      }

      /// <summary>
      /// Gets or sets el valor de: CCOT_NumDoc.
      /// </summary>
      [DataMember]
      [Display(Name = "Nro. Orden Venta")]
      public String CCOT_NumDoc { get; set; }
      /// <summary>
      /// Gets or sets el valor de: NVIA_NroViaje.
      /// </summary>
      [DataMember]
      [Display(Name = "Nro. Viaje")]
      public String NVIA_NroViaje { get; set; }
      /// <summary>
      /// Gets or sets el valor de: NVIA_NroManifiesto.
      /// </summary>
      [DataMember]
      [Display(Name = "Nro. Manifiesto")]
      public String NVIA_NroManifiesto { get; set; }
      /// <summary>
      /// Gets or sets el valor de: PUER_NomOrigen.
      /// </summary>
      [DataMember]
      [Display(Name = "Puerto Origen")]
      public String PUER_NomOrigen { get; set; }
      /// <summary>
      /// Gets or sets el valor de: PUER_NomDestino.
      /// </summary>
      [DataMember]
      [Display(Name="Puerto Destino")]
      public String PUER_NomDestino { get; set; }
      #endregion

      #region [ INotifyPropertyChanged ]
      public event PropertyChangedEventHandler PropertyChanged;
      protected virtual void OnPropertyChanged(String propertyName)
      {
         if (PropertyChanged != null)
         { PropertyChanged(null, new PropertyChangedEventArgs(propertyName)); }
      }
      #endregion

      

      public Boolean LoadingListAsociado
      {
         get { return (LOAD_Codigo.HasValue && CCOT_Numero.HasValue); }
      }
      public Boolean LoadingListNoAsociado
      {
         get { return (LOAD_Codigo.HasValue && !CCOT_Numero.HasValue); }
      }
      public Boolean OrdenVentaAsociada
      {
         get { return (!LOAD_Codigo.HasValue && CCOT_Numero.HasValue); }
      }


      private HttpPostedFileBase m_archivo;

      [Required]
      [Display(Name = "Archivo")]
      public HttpPostedFileBase Archivo 
      {
         get { return m_archivo; }
         set { m_archivo = value; }
      }
   }
}
