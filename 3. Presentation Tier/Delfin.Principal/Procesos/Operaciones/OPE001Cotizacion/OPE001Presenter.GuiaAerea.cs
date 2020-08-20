using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace Delfin.Principal
{
   public partial class OPE001Presenter
   {
      public void ImprimirGuiaAerea(Entities.Entidad ItemShipper, Entities.Entidad ItemConsignee, Entities.Entidad ItemAgente, Entities.Entidad ItemTransportista, Entities.Entidad ItemEmpresa, Entities.Puerto ItemPuertoOrigen, Entities.Puerto ItemPuertoDestino, Entities.NaveViaje ItemNaveViaje, String DatosShipper, String DatosConsignee)
      {
         try
         {

            StringBuilder _writer = new StringBuilder();

            String _linea = "";

            Int32 _margenleft = 9;
            Int32 _maxlength = 135;

            //_writer.AppendLine("        10        20        30        40        50        60        70        80        90       100       110       120       130       140       150");
            //_writer.AppendLine("123456789|123456789|123456789|123456789|123456789|123456789|123456789|123456789|123456789|123456789|123456789|123456789|123456789|123456789|123456789|");

            //_writer.AppendLine();
            LineasEnBlanco(7, ref _writer);

            _linea = "";
            _linea += "".PadRight(_margenleft);
            _linea += "".PadRight(12);
            _linea += (!String.IsNullOrEmpty(Item.DOOV_MBL) ? Item.DOOV_MBL : "").PadRight(90);
            _linea = _linea.Substring(0, 75);
            _linea += (!String.IsNullOrEmpty(Item.DOOV_HBL) ? Item.DOOV_HBL : "");
            _linea += "".PadRight(_maxlength);
            _linea = _linea.Substring(0, _maxlength);
            _writer.AppendLine(_linea);

            LineasEnBlanco(1, ref _writer);

            int _cont = 0;

            /* Shipper  & Empresa */
            String DatosEmpresa = (ItemEmpresa != null ? ItemEmpresa.ENTC_NomCompleto : "") + "\n";
            List<String> x_DireccionEmpresa = ObtenerLineas(ItemEmpresa.DIRE_Direccion, 40);
            foreach (String x_Cadena in x_DireccionEmpresa)
            { DatosEmpresa += x_Cadena + "\n"; }
            DatosEmpresa += (ItemEmpresa != null && ItemEmpresa.DIRE_Ubigeo != null ? ItemEmpresa.DIRE_Ubigeo : "");
            String[] _DatosEmpresa = ObtenerArray(DatosEmpresa, 40, 5);
            String[] _DatosShipper = ObtenerArray(DatosShipper, 50, 5);
            _cont = 0;
            for (int i = 0; i < _DatosEmpresa.Count(); i++)
            {
               _linea = "";
               _linea += "".PadRight(_margenleft);
               _linea += (_DatosShipper[i] != null ? _DatosShipper[i] : "");
               _linea += "".PadRight(90);
               _linea = _linea.Substring(0, 90);
               _linea += (_DatosEmpresa[i] != null ? _DatosEmpresa[i] : "");
               _linea += "".PadRight(_maxlength);
               _linea = _linea.Substring(0, _maxlength);
               _writer.AppendLine(_linea);
               _cont++;
            }

            LineasEnBlanco(8 - _cont, ref _writer);

            /* Consigne */
            String[] _DatosConsignee = ObtenerArray(DatosConsignee, 50, 5);
            _cont = 0;
            for (int i = 0; i < _DatosConsignee.Count(); i++)
            {
               _linea = "";
               _linea += "".PadRight(_margenleft);
               _linea += (_DatosConsignee[i] != null ? _DatosConsignee[i] : "");
               _linea += "".PadRight(_maxlength);
               _linea = _linea.Substring(0, _maxlength);
               _writer.AppendLine(_linea);
               _cont++;
            }

            LineasEnBlanco(16 - _cont, ref _writer);

            _linea = "";
            _linea += "".PadRight(_margenleft);
            _linea += (ItemPuertoOrigen != null ? ItemPuertoOrigen.PUER_Nombre : "");
            _linea += "".PadRight(76);
            _linea = _linea.Substring(0, 76);
            _linea += "";
            _linea += "".PadRight(_maxlength);
            _linea = _linea.Substring(0, _maxlength);
            _writer.AppendLine(_linea);

            LineasEnBlanco(2, ref _writer);

            _linea = "";
            _linea += "".PadRight(_margenleft);
            _linea += (ItemPuertoDestino != null ? ItemPuertoDestino.PUER_CodEstandar : "");
            _linea += "".PadRight(20);
            _linea = _linea.Substring(0, 20);
            _linea += (ItemTransportista != null ? ItemTransportista.ENTC_NomCompleto : "");
            _linea += "".PadRight(48);
            _linea = _linea.Substring(0, 48);
            _linea += "".PadRight(75);
            _linea = _linea.Substring(0, 75);
            _linea += Item.TIPO_DescCMND;
            _linea += "".PadRight(82);
            _linea = _linea.Substring(0, 82);
            _linea += (Item.CCOT_PagoHBL == "P" ? "X" : "");
            _linea += "".PadRight(90);
            _linea = _linea.Substring(0, 88);
            _linea += (Item.CCOT_PagoHBL == "C" ? "X" : "");
            _linea += "".PadRight(102);
            _linea = _linea.Substring(0, 102);
            _linea += "NVD";
            _linea += "".PadRight(122);
            _linea = _linea.Substring(0, 122);
            _linea += "NCV";
            _linea += "".PadRight(_maxlength);
            _linea = _linea.Substring(0, _maxlength);
            _writer.AppendLine(_linea);

            LineasEnBlanco(2, ref _writer);

            _linea = "";
            _linea += "".PadRight(_margenleft);
            _linea += (ItemPuertoDestino != null ? ItemPuertoDestino.PUER_Nombre : "");
            _linea += "".PadRight(45);
            _linea = _linea.Substring(0, 45);
            _linea += (ItemNaveViaje != null ? ItemNaveViaje.NVIA_NroViaje : "");
            _linea += "".PadRight(72);
            _linea = _linea.Substring(0, 72);
            _linea += "NIV";
            _linea += "".PadRight(_maxlength);
            _linea = _linea.Substring(0, _maxlength);
            _writer.AppendLine(_linea);

            LineasEnBlanco(2, ref _writer);

            String Observaciones = String.Empty;
            List<String> x_Observaciones = ObtenerLineas(Item.CCOT_Observaciones, 125);
            foreach (String x_Cadena in x_Observaciones)
            { Observaciones += x_Cadena + "\n"; }
            String[] _Observaciones = ObtenerArray(Observaciones, 125, 2);
            for (int i = 0; i < _Observaciones.Count(); i++)
            {
               _linea = "";
               _linea += "".PadRight(_margenleft);
               _linea += (_Observaciones[i] != null ? _Observaciones[i] : "");
               _linea += "".PadRight(_maxlength);
               _linea = _linea.Substring(0, _maxlength);
               _writer.AppendLine(_linea);
            }

            LineasEnBlanco(6, ref _writer);

            Int32 _lineas = 0;
            String DescProducto = String.Empty;
            List<String> x_DescProducto = ObtenerLineas(Item.ItemsDet_CNTR[0].DHBL_DescProducto, 25);
            foreach (String x_Cadena in x_DescProducto)
            { DescProducto += x_Cadena + "\n"; }
            String[] _DescProducto = ObtenerArray(DescProducto, 30, 15);
            for (int i = 0; i < _DescProducto.Count(); i++)
            {

               if (_lineas == 0)
               {
                  _linea = "";
                  _linea += "".PadRight(_margenleft);
                  _linea += Convert.ToInt32(Item.ItemsDet_CNTR.Sum(dcot => dcot.DHBL_CantBultos)).ToString();
                  _linea += "".PadRight(17);
                  _linea = _linea.Substring(0, 17);
                  _linea += Item.ItemsDet_CNTR.Sum(dcot => dcot.DHBL_PesoBruto).ToString();
                  _linea += "".PadRight(48);
                  _linea = _linea.Substring(0, 48);

                  _linea += Item.ItemsFlete.Sum(dcot => dcot.DCOT_Cantidad).ToString();//Peso Total del Flete 
                  _linea += "".PadRight(65);
                  _linea = _linea.Substring(0, 65);
                  _linea += Item.ItemsFlete.Sum(dcot => dcot.DCOT_Bultos).ToString();// Cantidad de bultos del Flete 
                  _linea += "".PadRight(81);
                  _linea = _linea.Substring(0, 81);
                  _linea += Item.ItemsFlete.Sum(dcot => dcot.DCOT_TotalUniVenta).ToString();// Total Venta Flete 
                  _linea += "".PadRight(100);
                  _linea = _linea.Substring(0, 100);
               }
               else
               {
                  _linea = "";
                  _linea += "".PadRight(_margenleft);
                  _linea += "";
                  _linea += "".PadRight(17);
                  _linea = _linea.Substring(0, 17);
                  _linea += "";
                  _linea += "".PadRight(48);
                  _linea = _linea.Substring(0, 48);

                  _linea += "";//Peso Total del Flete 
                  _linea += "".PadRight(65);
                  _linea = _linea.Substring(0, 65);
                  _linea += "";// Cantidad de bultos del Flete 
                  _linea += "".PadRight(81);
                  _linea = _linea.Substring(0, 81);
                  _linea += "";// Total Venta Flete 
                  _linea += "".PadRight(100);
                  _linea = _linea.Substring(0, 100);
               }

               String _DescProductoFinal = (_DescProducto[i] != null ? _DescProducto[i] : "") + "".PadRight(30);
               _linea += _DescProductoFinal.Substring(0, 30);

               _linea += "".PadRight(_maxlength);
               _linea = _linea.Substring(0, _maxlength);
               _writer.AppendLine(_linea);

               _lineas += 1;
            }

            for (int i = 0; i < 15 - _lineas; i++)
            { _writer.AppendLine(); }

            _linea = "";
            _linea += "".PadRight(_margenleft);
            _linea += Convert.ToInt32(Item.ItemsDet_CNTR.Sum(dcot => dcot.DHBL_CantBultos)).ToString();
            _linea += "".PadRight(17);
            _linea = _linea.Substring(0, 17);
            _linea += Item.ItemsDet_CNTR.Sum(dcot => dcot.DHBL_PesoBruto).ToString();
            _linea += "".PadRight(81);
            _linea = _linea.Substring(0, 81);
            _linea += Item.ItemsFlete.Sum(dcot => dcot.DCOT_TotalUniVenta).ToString();
            _linea += "".PadRight(_maxlength);
            _linea = _linea.Substring(0, _maxlength);
            _writer.AppendLine(_linea);

            LineasEnBlanco(2, ref _writer);

            _linea = "";
            _linea += "".PadRight(_margenleft);
            _linea += Item.ItemsFlete.Sum(dcot => dcot.DCOT_TotalUniVenta).ToString();
            _writer.Append(_linea);

            LineasEnBlanco(0, ref _writer);

            ObservableCollection<Entities.Det_Cotizacion_OV_Servicio> _ServiciosCliente = new ObservableCollection<Entities.Det_Cotizacion_OV_Servicio>();
            Int32 _lineasservicios = 0;
            foreach (Entities.Det_Cotizacion_OV_Servicio _itemDet_Cotizacion_OV_Servicio in Item.ItemsServicio)
            {
               if (_lineasservicios < 5)
               {
                  if (_itemDet_Cotizacion_OV_Servicio.TIPE_Codigo == Convert.ToInt16(Delfin.Controls.TiposEntidad.TIPE_Cliente))
                  {
                     if (_itemDet_Cotizacion_OV_Servicio.CCOT_IngresoGasto == "I" && !_itemDet_Cotizacion_OV_Servicio.SERV_AfeIgv && !_itemDet_Cotizacion_OV_Servicio.SCOT_Exonerado)
                     {
                        _linea = "";
                        _linea += "".PadRight(_margenleft);
                        _linea += "".PadRight(60);
                        _linea = _linea.Substring(0, 60);
                        String _Servico = _itemDet_Cotizacion_OV_Servicio.SERV_Nombre + "".PadRight(30);
                        _linea += _Servico.Substring(0, 30);
                        _linea += "".PadRight(5) + "USD";
                        _linea += "".PadRight(5) + _itemDet_Cotizacion_OV_Servicio.SCOT_Importe_Ingreso.ToString("#,##,##.000");
                        _linea += "".PadRight(_maxlength);
                        _linea = _linea.Substring(0, _maxlength);
                        _writer.AppendLine(_linea);
                        _lineasservicios += 1;
                        _ServiciosCliente.Add(_itemDet_Cotizacion_OV_Servicio);
                     }
                  }
               }
               else
               { break; }
            }

            for (int i = 0; i < 9 - _lineasservicios; i++)
            { _writer.AppendLine(); }

            _linea = "";
            _linea += "".PadRight(_margenleft);
            _linea += (_ServiciosCliente.Sum(scot => (scot.SCOT_Importe_Egreso * -1) + scot.SCOT_Importe_Ingreso) > 0 ? _ServiciosCliente.Sum(scot => (scot.SCOT_Importe_Egreso * -1) + scot.SCOT_Importe_Ingreso).ToString("#,##,##.000") : "");
            _linea += "".PadRight(61);
            _linea = _linea.Substring(0, 61);
            _linea += Centrar((ItemEmpresa != null ? ItemEmpresa.ENTC_NomCompleto : ""), 75);
            _linea += "".PadRight(_maxlength);
            _linea = _linea.Substring(0, _maxlength);
            _writer.AppendLine(_linea);

            LineasEnBlanco(2, ref _writer);

            _linea = "";
            _linea += "".PadRight(_margenleft);
            _linea += (Item.CCOT_PagoHBL == "P" && (Item.ItemsFlete.Sum(dcot => dcot.DCOT_TotalUniVenta) + _ServiciosCliente.Sum(scot => (scot.SCOT_Importe_Egreso * -1) + scot.SCOT_Importe_Ingreso)) > 0 ? (Item.ItemsFlete.Sum(dcot => dcot.DCOT_TotalUniVenta) + _ServiciosCliente.Sum(scot => (scot.SCOT_Importe_Egreso * -1) + scot.SCOT_Importe_Ingreso)).ToString("#,##,##.000") : "");
            _linea += "".PadRight(61);
            _linea = _linea.Substring(0, 61);
            _linea += (Item.CCOT_PagoHBL == "C" && (Item.ItemsFlete.Sum(dcot => dcot.DCOT_TotalUniVenta) + _ServiciosCliente.Sum(scot => (scot.SCOT_Importe_Egreso * -1) + scot.SCOT_Importe_Ingreso)) > 0 ? (Item.ItemsFlete.Sum(dcot => dcot.DCOT_TotalUniVenta) + _ServiciosCliente.Sum(scot => (scot.SCOT_Importe_Egreso * -1) + scot.SCOT_Importe_Ingreso)).ToString("#,##,##.000") : "");
            _linea += "".PadRight(_maxlength);
            _linea = _linea.Substring(0, _maxlength);

            LineasEnBlanco(3, ref _writer);

            _linea = "";
            _linea += "".PadRight(_margenleft);
            _linea += "".PadRight(63);
            _linea = _linea.Substring(0, 63);
            if (Item.CONS_CodRGM == Delfin.Controls.variables.CONSRGM_Importacion && Item.DDOV_FecEmbarque.HasValue)
            { _linea += Item.DDOV_FecEmbarque.Value.ToString("dd MMMM yyyy"); }
            if (Item.CONS_CodRGM == Delfin.Controls.variables.CONSRGM_Exportacion && ItemNaveViaje.NVIA_FecETA_IMPO_ETD_EXPO.HasValue)
            { _linea += ItemNaveViaje.NVIA_FecETA_IMPO_ETD_EXPO.Value.ToString("dd MMMM yyyy"); }
            _linea += "".PadRight(88);
            _linea = _linea.Substring(0, 88);
            _linea += ItemPuertoOrigen.TIPO_DescPais + " " + ItemPuertoOrigen.PUER_Nombre;
            _linea += "".PadRight(_maxlength);
            _linea = _linea.Substring(0, _maxlength);
            _writer.AppendLine(_linea);

            LineasEnBlanco(2, ref _writer);

            _linea = "";
            _linea += "".PadRight(_margenleft);
            _linea += "".PadRight(85);
            _linea = _linea.Substring(0, 85);
            _linea += Item.DOOV_HBL;
            _linea += "".PadRight(_maxlength);
            _linea = _linea.Substring(0, _maxlength);
            _writer.AppendLine(_linea);

            String _printername = "";

            //string text = "A class is the most powerful data type in C#. Like a structure, " +
            //                         "a class defines the data and behavior of the data type. ";
            //// WriteAllText creates a file, writes the specified string to the file,
            //// and then closes the file.    You do NOT need to call Flush() or Close().
            //System.IO.File.WriteAllText(@"D:\WriteText.txt", _writer.ToString());

            System.Windows.Forms.PrintDialog printDialog = new System.Windows.Forms.PrintDialog();

            if (printDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
               _printername = printDialog.PrinterSettings.PrinterName;
               Print(_printername, _writer, Impresion.InterEspaciado.Ocho, 78);
            }
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Title, "Ha ocurrido un error al imprimir la Guía Aérea.", ex); }
      }
      private string Centrar(String text, Int32 length)
      {
         Int32 _spaces = Convert.ToInt32((length - text.Length) / 2);
         return "".PadLeft(_spaces) + text + "".PadRight(_spaces);
      }

      private void LineasEnBlanco(int x_lineas, ref StringBuilder _writer)
      {
         for (int i = 0; i < x_lineas; i++)
         { _writer.AppendLine(); }
      }

      private List<String> ObtenerLineas(String x_cadena, int x_ancho)
      {
         try
         {
            x_cadena = x_cadena != null ? x_cadena : String.Empty;
            String[] _cad = x_cadena.Split(' ');
            String _linea = "";
            List<String> x_lineas = new List<String>();
            foreach (String iCad in _cad)
            {
               _linea += iCad + " ";
               if (_linea.Length >= x_ancho)
               { x_lineas.Add(_linea); _linea = ""; }
            }
            x_lineas.Add(_linea);
            return x_lineas;
         }
         catch (Exception)
         { return null; }
      }

      private string[] ObtenerArray(string x_Cadena, int x_Ancho, int x_Lineas)
      {
         try
         {
            x_Cadena = x_Cadena != null ? x_Cadena : string.Empty;
            string[] _CadenasFinales = new string[x_Lineas];
            string[] _Cadenas = x_Cadena.Split(new char[] { '\n' });
            int _CantCadenas = _Cadenas.Count();
            for (int i = 0; i < x_Lineas; i++)
            {
               string _Linea = string.Empty;
               if (i < _CantCadenas)
               {
                  _Linea = _Cadenas[i] != null ? _Cadenas[i] : string.Empty;
                  _Linea = _Linea.Replace("\r", "");
                  _Linea = _Linea + "".PadRight(x_Ancho);
                  _Linea = _Linea.Substring(0, x_Ancho);
               }
               else
               { _Linea = string.Empty; }
               _CadenasFinales[i] = _Linea;
            }
            return _CadenasFinales;
         }
         catch (Exception)
         { return null; }
      }

      private void Print(String x_printername, StringBuilder x_file, Impresion.InterEspaciado x_interlineado, Int16 x_lineas = 78)
      {
         try
         {
            Impresion.Imprimir.Inicializar(x_printername);
            Impresion.Imprimir.SendStringToPrinter(Convert.ToChar(18).ToString());
            Impresion.Imprimir.SendStringToPrinter(Impresion.FuncImpresion.NumeroLineas(x_lineas));
            Impresion.Imprimir.SendStringToPrinter(Impresion.FuncImpresion.Negrita(false));
            Impresion.Imprimir.SendStringToPrinter(Impresion.FuncImpresion.Fuente(Impresion.Fuentes.Draft));
            Impresion.Imprimir.SendStringToPrinter(string.Format("{0}{1}", Convert.ToChar(27), Convert.ToChar(15)));
            Impresion.Imprimir.SendStringToPrinter(Impresion.FuncImpresion.FuenteDraft(Impresion.Drafts.Draft10PCI).ToString());
            Impresion.Imprimir.SendStringToPrinter(Impresion.FuncImpresion.Condensado(false));
            Impresion.Imprimir.SendStringToPrinter(Impresion.FuncImpresion.Interespaciado(x_interlineado));
            Impresion.Imprimir.SendStringToPrinter(x_file.ToString());
         }
         catch (Exception)
         { throw; }
      }
   }
}
