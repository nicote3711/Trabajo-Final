using ENTITY;
using ENTITY.Enum;
using iText.IO.Font; // For StandardFonts (if you use them)
using iText.IO.Font.Constants;
using iText.IO.Image;
using iText.Kernel.Colors; // For colors
using iText.Kernel.Font; // For fonts
using iText.Kernel.Geom;
using iText.Kernel.Pdf; // Core PDF functionality
using iText.Layout;     // Layout elements like Paragraph, Table, Image
using iText.Layout.Borders;
using iText.Layout.Element; // Specific elements
using iText.Layout.Properties; // For alignment properties
using System;
using System.Collections.Generic;
using System.IO;        // For FileStream
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using Document = iText.Layout.Document;


namespace Helper
{
    public static class HelperFacturas
    {
        #region GENERACION PDF
        const string fileName = "F_{NumeroFactura}.pdf";
        const string filePath = "\\Facturas\\{TipoFactura}\\";

        public static Resultado EliminarFacturaPDF(int tipoFactura,int nroFactura) 
        {
            Resultado result = new Resultado();
            try
            {
                string directorio = AppDomain.CurrentDomain.BaseDirectory; // Starting Dir
                FileInfo fileInfo = new FileInfo(directorio.Substring(0, (directorio.Split("UI\\")[0] + "UI\\").Length));
                string baseDirNombre = fileInfo.Directory.FullName;
                string pathDocumento = baseDirNombre + filePath.Replace("{TipoFactura}", EnumTiposFactura.GetName((EnumTiposFactura)tipoFactura)) + fileName.Replace("{NumeroFactura}", nroFactura.ToString());

                File.Delete(pathDocumento);
                result.Success = true;
                result.Message = "PDF Factura Eliminado exitosamente";
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error al eliminar PDF Factura: " + ex.Message;
            }
            return result;
        }

        public static Resultado GenerarFacturaPDF(Factura factura) 
        {
            try
            {
                string directorio = AppDomain.CurrentDomain.BaseDirectory; // Starting Dir
                FileInfo fileInfo = new FileInfo(directorio.Substring(0, (directorio.Split("UI\\")[0] + "UI\\").Length));
                string baseDirNombre = fileInfo.Directory.FullName;
                string pathDocumento = baseDirNombre + filePath.Replace("{TipoFactura}", EnumTiposFactura.GetName((EnumTiposFactura)factura.TipoFactura.IdTipoFactura)) + fileName.Replace("{NumeroFactura}", factura.NroFactura.ToString());

                using (var writer = new PdfWriter(pathDocumento))
                {
                    using (var pdf = new PdfDocument(writer))
                    {
                        // Margenes del documento (top, right, bottom, left)
                        var document = new Document(pdf, iText.Kernel.Geom.PageSize.A4, true);
                        document.SetMargins(30, 30, 30, 30);

                        // --- Configuración de Fuentes ---
                        PdfFont fontNormal = PdfFontFactory.CreateFont(StandardFonts.HELVETICA);
                        PdfFont fontBold = PdfFontFactory.CreateFont(StandardFonts.HELVETICA_BOLD);
                        PdfFont fontItalic = PdfFontFactory.CreateFont(StandardFonts.HELVETICA_OBLIQUE);

                        // --- Encabezado de la Factura (Datos de la Empresa Emisora) ---
                        Table headerTable = new Table(UnitValue.CreatePercentArray(new float[] { 1, 1 }))
                                               .SetWidth(UnitValue.CreatePercentValue(100));

                        // Columna Izquierda: Logo y Datos de la Empresa
                        Cell datosEmisor = new Cell().Add(new Paragraph("")); // Placeholder para el logo

                        // Intenta cargar un logo (opcional)
                        
                        
                        Persona cliente = factura.DatosCliente();
                        
                        Persona emisor = factura.DatosEmisor();

                        datosEmisor
                            .Add(new Paragraph(emisor.Nombre + " " + emisor.Apellido).SetFont(fontBold).SetFontSize(12))
                            .Add(new Paragraph("CUIT: " + emisor.CuitCuil).SetFont(fontNormal).SetFontSize(10))
                            //.Add(new Paragraph("Domicilio: ").SetFont(fontNormal).SetFontSize(10))
                            .Add(new Paragraph("Ingresos Brutos: XX-XXXXXXXX-X").SetFont(fontNormal).SetFontSize(10))
                            .Add(new Paragraph("Inicio de Actividades: 10/09/1992").SetFont(fontNormal).SetFontSize(10))
                            .SetBorder(Border.NO_BORDER); // Quitar borde por defecto

                        headerTable.AddCell(datosEmisor);

                        Table tablaComprobante = new Table(UnitValue.CreatePercentArray(new float[] { 1 }));
                        tablaComprobante.SetWidth(UnitValue.CreatePercentValue(100));

                        // Datos Título de Factura (A/B/C)
                        tablaComprobante.AddCell(new Cell()
                            .Add(new Paragraph("F A C T U R A").SetFont(fontBold).SetFontSize(24).SetFontColor(DeviceRgb.BLACK).SetTextAlignment(TextAlignment.CENTER))
                            .Add(new Paragraph("A").SetFont(fontBold).SetFontSize(48).SetFontColor(DeviceRgb.RED).SetTextAlignment(TextAlignment.CENTER).SetVerticalAlignment(VerticalAlignment.MIDDLE))
                            .SetPadding(5)
                            .SetBorder(new SolidBorder(DeviceRgb.BLACK, 1))); // Borde para el tipo de factura

                        tablaComprobante.AddCell(new Cell()
                            .Add(new Paragraph("Nro. " + factura.NroFactura).SetFont(fontBold).SetFontSize(12).SetTextAlignment(TextAlignment.RIGHT))
                            .Add(new Paragraph("Fecha: " + factura.FechaFactura.ToString("dd/MM/yyyy")).SetFont(fontNormal).SetFontSize(10).SetTextAlignment(TextAlignment.RIGHT))
                            .SetBorder(Border.NO_BORDER));

                        headerTable.AddCell(new Cell().Add(tablaComprobante).SetBorder(Border.NO_BORDER));

                        document.Add(headerTable);
                        document.Add(new Paragraph("\n").SetFontSize(8)); // Espacio

                        // --- Datos del Cliente ---
                        Table clienteTabla = new Table(UnitValue.CreatePercentArray(new float[] { 0.2f, 0.8f }))
                                              .SetWidth(UnitValue.CreatePercentValue(100))
                                              .SetBorder(new SolidBorder(DeviceRgb.BLACK, 0.5f));

                        clienteTabla.AddCell(CreateLabelCell("Cliente:").SetFont(fontBold));
                        clienteTabla.AddCell(CreateDataCell(cliente.Nombre + " " + cliente.Apellido));

                        clienteTabla.AddCell(CreateLabelCell("CUIT/CUIL:").SetFont(fontBold));
                        clienteTabla.AddCell(CreateDataCell(cliente.CuitCuil));

                        clienteTabla.AddCell(CreateLabelCell("Domicilio:").SetFont(fontBold));
                        clienteTabla.AddCell(CreateDataCell("Calle Principal 456, Otra Ciudad, Otra Provincia"));

                        clienteTabla.AddCell(CreateLabelCell("IVA:").SetFont(fontBold));
                        clienteTabla.AddCell(CreateDataCell("Responsable Inscripto")); // Ejemplo: Responsable Inscripto, Consumidor Final, Monotributista

                        document.Add(clienteTabla);
                        document.Add(new Paragraph("\n").SetFontSize(8)); // Espacio

                        // --- Detalle de Productos/Servicios ---
                        List<LiquidacionDetalle> facturaDetalle = factura.FacturaDetalles();
                        
                        Table productsTable = new Table(UnitValue.CreatePercentArray(new float[] { 0.2f,0.3f, 0.15f, 0.15f,0.2f }))
                                                  .SetWidth(UnitValue.CreatePercentValue(100))
                                                  .SetBorder(new SolidBorder(DeviceRgb.MakeLighter((DeviceRgb)DeviceRgb.BLACK), 0.5f));

                        productsTable.SetFixedLayout();

                        // Encabezados del detalle
                        productsTable.AddHeaderCell((CreateHeaderCell("Fecha").SetFont(fontNormal).SetFontSize(8).SetTextAlignment(TextAlignment.CENTER)));
                        productsTable.AddHeaderCell((CreateHeaderCell("Descripcion").SetFont(fontNormal).SetFontSize(8).SetTextAlignment(TextAlignment.LEFT)));
                        productsTable.AddHeaderCell((CreateHeaderCell("Cantidad").SetFont(fontNormal).SetFontSize(8).SetTextAlignment(TextAlignment.RIGHT)));
                        productsTable.AddHeaderCell((CreateHeaderCell("Precio").SetFont(fontNormal).SetFontSize(8).SetTextAlignment(TextAlignment.RIGHT)));
                        productsTable.AddHeaderCell((CreateHeaderCell("Total").SetFont(fontNormal).SetFontSize(8).SetTextAlignment(TextAlignment.RIGHT)));
                       

                        foreach (LiquidacionDetalle detalle in facturaDetalle)
                        {
                            productsTable.AddCell((CreateProductCell(detalle.FechaLiquidacion.ToShortDateString()).SetFontSize(7).SetTextAlignment(TextAlignment.CENTER)));
                            productsTable.AddCell((CreateProductCell(detalle.Descripcion).SetFontSize(7).SetTextAlignment(TextAlignment.LEFT)));
                            productsTable.AddCell((CreateProductCell(detalle.Cantidad.ToString()).SetFontSize(7).SetTextAlignment(TextAlignment.RIGHT)));
                            productsTable.AddCell((CreateProductCell(detalle.Valor.ToString()).SetFontSize(7).SetTextAlignment(TextAlignment.RIGHT)));
                            productsTable.AddCell((CreateProductCell(detalle.MontoTotal.ToString("N2")).SetFontSize(7).SetTextAlignment(TextAlignment.RIGHT)));
                        }


                        document.Add(productsTable);

                        // --- Resumen de Totales ---
                        Table totalsTable = new Table(UnitValue.CreatePercentArray(new float[] { 0.7f, 0.3f }))
                                              .SetWidth(UnitValue.CreatePercentValue(100))
                                              .SetHorizontalAlignment(HorizontalAlignment.RIGHT); // Alinear la tabla a la derecha
                        
                        double totalFinal = Convert.ToDouble(factura.MontoTotal);
                        double subtotalFactura = totalFinal / 1.21;
                        double ivaMonto = totalFinal - subtotalFactura;

                        //totalsTable.AddCell(CreateLabelCell("Subtotal:").SetTextAlignment(TextAlignment.RIGHT).SetBorder(Border.NO_BORDER));
                        //totalsTable.AddCell(CreateDataCell("$ " + subtotalFactura.ToString("N2")).SetTextAlignment(TextAlignment.RIGHT).SetBorder(Border.NO_BORDER));

                        //totalsTable.AddCell(CreateLabelCell("IVA 21%:").SetTextAlignment(TextAlignment.RIGHT).SetBorder(Border.NO_BORDER));
                        //totalsTable.AddCell(CreateDataCell("$ " + ivaMonto.ToString("N2")).SetTextAlignment(TextAlignment.RIGHT).SetBorder(Border.NO_BORDER));

                        totalsTable.AddCell(CreateLabelCell("TOTAL:").SetFont(fontBold).SetFontSize(14).SetTextAlignment(TextAlignment.RIGHT).SetBorder(Border.NO_BORDER));
                        totalsTable.AddCell(CreateDataCell("$ " + totalFinal.ToString("N2")).SetFont(fontBold).SetFontSize(14).SetTextAlignment(TextAlignment.RIGHT).SetBorder(Border.NO_BORDER));

                        document.Add(totalsTable);

                        // --- Pie de página (ej. Leyendas legales, datos de imprenta si aplica) ---
                        document.Add(new Paragraph("\n\n").SetFontSize(8)); // Espacio

                        document.Add(new Paragraph("Condición de Venta: CONTADO / CTA. CTE.")
                            .SetFont(fontNormal).SetFontSize(9).SetTextAlignment(TextAlignment.LEFT));
                        document.Add(new Paragraph($"CUIT del emisor en AFIP: {emisor.CuitCuil}") // Reemplazar con el CUIT real de tu empresa
                            .SetFont(fontNormal).SetFontSize(8).SetTextAlignment(TextAlignment.CENTER));

                        
                        document.Add(new Paragraph("\n")
                            .Add(new Text("Impreso por: Imprenta XYZ S.A. | ").SetFont(fontNormal).SetFontSize(7))
                            .Add(new Text("Habilitación AFIP: XXXX | ").SetFont(fontNormal).SetFontSize(7))
                            .Add(new Text($"Fecha Impresión: {factura.FechaFactura} | ").SetFont(fontNormal).SetFontSize(7))
                            .Add(new Text("Desde Nro.: 0001-00000001 Hasta Nro.: 0001-99999999").SetFont(fontNormal).SetFontSize(7))
                            .SetTextAlignment(TextAlignment.CENTER));


                        document.Close();

                        return new Resultado() { Success = true, Message = "PDF factura creado exitosamente en: " + filePath };
                    }
                }
            }
            catch (Exception ex)
            {
                return new Resultado() { Success = false, Message = "Error creado PDF factura: " + ex.Message };
            }
        }

        // --- Métodos Auxiliares para crear celdas de tabla ---
        private static Cell CreateLabelCell(string text)
        {
            return new Cell()
                .Add(new Paragraph(text).SetFontSize(10).SetMargin(2))
                .SetPadding(2)
                .SetBorder(Border.NO_BORDER);
        }

        private static Cell CreateDataCell(string text)
        {
            return new Cell()
                .Add(new Paragraph(text).SetFontSize(10).SetMargin(2))
                .SetPadding(2)
                .SetBorder(Border.NO_BORDER);
        }

        private static Cell CreateHeaderCell(string text)
        {
            return new Cell()
                .Add(new Paragraph(text).SetFont(PdfFontFactory.CreateFont(StandardFonts.HELVETICA_BOLD)).SetFontSize(10).SetFontColor(DeviceRgb.WHITE))
                .SetBackgroundColor(DeviceRgb.BLACK)
                .SetPadding(5)
                .SetTextAlignment(TextAlignment.CENTER);
        }

        private static Cell CreateProductCell(string text)
        {
            return new Cell()
                .Add(new Paragraph(text).SetFontSize(9))
                .SetPadding(3);
        }

        #endregion

    }
}
