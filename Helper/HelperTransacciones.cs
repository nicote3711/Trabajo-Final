using ENTITY;
using ENTITY.Enum;

using iText.IO.Font.Constants;
using iText.Kernel.Colors;
using iText.Kernel.Font;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Borders;
using iText.Layout.Element;
using iText.Layout.Properties;

using System;
using System.IO;

namespace Helper
{
    public class HelperTransacciones
    {
        const string fileName = "T_{IdTransaccion}.pdf";
        const string filePath = "\\Transacciones\\{TipoTransaccion}\\";


        public static Resultado EliminarTransaccionPDF(int tipoTransaccion, int idTransaccion)
        {
            Resultado result = new Resultado();
            try
            {
                string directorio = AppDomain.CurrentDomain.BaseDirectory;
                FileInfo fileInfo = new FileInfo(directorio.Substring(0, (directorio.Split("UI\\")[0] + "UI\\").Length));
                string baseDirNombre = fileInfo.Directory.FullName;

                string tipoTransaccionStr = Enum.GetName(typeof(EnumTipoTransaccion), tipoTransaccion);
                if (string.IsNullOrEmpty(tipoTransaccionStr)) throw new Exception("Tipo de transacción inválido.");

                string pathDocumento = baseDirNombre +
                                       "\\Transacciones\\" +
                                       tipoTransaccionStr +
                                       "\\T_" + idTransaccion + ".pdf";

                if (File.Exists(pathDocumento))
                {
                    File.Delete(pathDocumento);
                    result.Success = true;
                    result.Message = "PDF de transacción eliminado exitosamente.";
                }
                else
                {
                    result.Success = false;
                    result.Message = "El archivo PDF no existe.";
                }
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error al eliminar PDF de transacción: " + ex.Message;
            }

            return result;
        }


        public static Resultado GenerarTransaccionPDF(TransaccionFinanciera transaccion)
        {
            try
            {
                string directorio = AppDomain.CurrentDomain.BaseDirectory;
                FileInfo fileInfo = new FileInfo(directorio.Substring(0, (directorio.Split("UI\\")[0] + "UI\\").Length));
                string baseDirNombre = fileInfo.Directory.FullName;

                string tipoTransaccionStr = Enum.GetName(typeof(EnumTipoTransaccion), (int)transaccion.TipoTransaccion.IdTipoTransaccion);
                string pathDocumento = baseDirNombre + filePath.Replace("{TipoTransaccion}", tipoTransaccionStr) + fileName.Replace("{IdTransaccion}", transaccion.IdTransaccionFinanciera.ToString());

                using (var writer = new PdfWriter(pathDocumento))
                using (var pdf = new PdfDocument(writer))
                {
                    var document = new Document(pdf, iText.Kernel.Geom.PageSize.A4, true);
                    document.SetMargins(30, 30, 30, 30);

                    PdfFont fontNormal = PdfFontFactory.CreateFont(StandardFonts.HELVETICA);
                    PdfFont fontBold = PdfFontFactory.CreateFont(StandardFonts.HELVETICA_BOLD);

                    // Título
                    string descripcionTipo = Enum.GetName(typeof(EnumTipoTransaccion), (int)transaccion.TipoTransaccion.IdTipoTransaccion)?.Replace('_', ' ') ?? "Transacción";
                    document.Add(new Paragraph($"Comprobante de {descripcionTipo}")
                        .SetFont(fontBold).SetFontSize(20).SetTextAlignment(TextAlignment.CENTER));
                    document.Add(new Paragraph($"Fecha de Transacción: {transaccion.FechaTransaccion:dd/MM/yyyy}")
                        .SetFont(fontNormal).SetFontSize(12).SetTextAlignment(TextAlignment.CENTER));

                    document.Add(new Paragraph("\n"));

                    Persona cliente = transaccion.Factura?.DatosCliente() ?? throw new Exception("Factura sin emisor asociado.");
                    string formaPagoDesc = transaccion.FormaPago?.Descripcion ?? "N/A";

                    Table tabla = new Table(UnitValue.CreatePercentArray(new float[] { 0.3f, 0.7f }))
                        .SetWidth(UnitValue.CreatePercentValue(100));

                    tabla.AddCell(CreateLabelCell("Emisor del Pago:"));
                    tabla.AddCell(CreateDataCell($"{cliente.Nombre} {cliente.Apellido}"));

                    tabla.AddCell(CreateLabelCell("Forma de Pago:"));
                    tabla.AddCell(CreateDataCell(formaPagoDesc));

                    if (transaccion.FormaPago.IdFormaPago != (int)EnumFormaPago.Efectivo && transaccion.ReferenciaExterna != null)
                    {
                        tabla.AddCell(CreateLabelCell("Referencia Externa:"));
                        tabla.AddCell(CreateDataCell(transaccion.ReferenciaExterna.ToString()));
                    }

                    tabla.AddCell(CreateLabelCell("Monto Total:"));
                    tabla.AddCell(CreateDataCell($"$ {transaccion.MontoTransaccion.ToString("N2")}"));

                    document.Add(tabla);

                    document.Close();

                    return new Resultado() { Success = true, Message = "PDF de transacción generado correctamente." };
                }
            }
            catch (Exception ex)
            {
                return new Resultado() { Success = false, Message = "Error al generar PDF de transacción: " + ex.Message };
            }
        }

        private static Cell CreateLabelCell(string text)
        {
            return new Cell()
                .Add(new Paragraph(text).SetFontSize(10))
                .SetBorder(Border.NO_BORDER)
                ;
        }

        private static Cell CreateDataCell(string text)
        {
            return new Cell()
                .Add(new Paragraph(text).SetFontSize(10))
                .SetBorder(Border.NO_BORDER);
        }
    }
}
