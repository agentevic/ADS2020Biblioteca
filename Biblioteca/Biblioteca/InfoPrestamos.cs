using System;
using System.Windows.Forms;
//Clase necesaria para poder utilizar iTextSharp
using System.IO;
//Clases necesarias de iTextSharp
using iTextSharp;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System.Diagnostics;

namespace Biblioteca
{
    public partial class InfoPrestamos :Form
    {
        public InfoPrestamos()
        {
            InitializeComponent();
        }


        Class_Infoprestamos prestamo = new Class_Infoprestamos();
        
        private void InfoPrestamos_Load(object sender, EventArgs e)
        {

        }

        private void InfoPrestamos_Load_1(object sender, EventArgs e)
        {
            prestamo.consultartodos(dataGridView1);

        }

        private void btnbuscar_Click(object sender, EventArgs e)
        {
            prestamo.Lector = txtbuscar.Text.Trim();
            prestamo.consultar(dataGridView1, txtbuscar.Text);
            if (txtbuscar.Text.Trim() == "")
            {
                errorProvider1.SetError(txtbuscar, "Campo vacio");
            }
            else
            {
                errorProvider1.Clear();
            }
        }
        public void generar_reporte(Document document)
        {

        }
         private void To_pdf()
        {
                    Document doc = new Document(PageSize.A4.Rotate(), 10, 10, 10, 10);
                    SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                    saveFileDialog1.InitialDirectory = @"C:";
                    saveFileDialog1.Title = "Guardar Reporte";
                    saveFileDialog1.DefaultExt = "pdf";
                    saveFileDialog1.Filter = "pdf Files (*.pdf)|*.pdf| All Files (*.*)|*.*";
                    saveFileDialog1.FilterIndex = 2;
                    saveFileDialog1.RestoreDirectory = true;
                    string filename = "";
                    if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        filename = saveFileDialog1.FileName;
                    }

                    if (filename.Trim() != "")
                    {
                        FileStream file = new FileStream(filename,
                        FileMode.OpenOrCreate,
                        FileAccess.ReadWrite,
                        FileShare.ReadWrite);
                        PdfWriter.GetInstance(doc, file);
                        doc.Open();
                        string remito = "MI BIBLIOTECA";
                        string envio = "Fecha:" + DateTime.Now.ToString();

                        Chunk chunk = new Chunk("Reporte de general de prestamos", FontFactory.GetFont("ARIAL", 20, iTextSharp.text.Font.BOLD));
                        doc.Add(new Paragraph(chunk));
                        doc.Add(new Paragraph("                       "));
                        doc.Add(new Paragraph("                       "));
                        doc.Add(new Paragraph("------------------------------------------------------------------------------------------"));
                        doc.Add(new Paragraph(""));
                        doc.Add(new Paragraph(remito));
                        doc.Add(new Paragraph(envio));
                        doc.Add(new Paragraph("------------------------------------------------------------------------------------------"));
                        doc.Add(new Paragraph("                       "));
                        doc.Add(new Paragraph("                       "));
                        doc.Add(new Paragraph("                       "));
                        GenerarDocumento(doc);
                        doc.AddCreationDate();
                        doc.Add(new Paragraph("_________________________________", FontFactory.GetFont("ARIAL", 20, iTextSharp.text.Font.ITALIC)));
                        doc.Add(new Paragraph("Firma", FontFactory.GetFont("ARIAL", 20, iTextSharp.text.Font.BOLD)));
                        doc.Close();
                        Process.Start(filename);//Esta parte se puede omitir, si solo se desea guardar el archivo, y que este no se ejecute al instante
                    }
              
        }
        public void GenerarDocumento(Document document)
        {
            int i, j;
            PdfPTable datatable = new PdfPTable(dataGridView1.ColumnCount);
            datatable.DefaultCell.Padding = 3;
            float[] headerwidths = GetTamañoColumnas(dataGridView1);
            datatable.SetWidths(headerwidths);
            datatable.WidthPercentage = 100;
            datatable.DefaultCell.BorderWidth = 2;
            datatable.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
            for (i = 0; i < dataGridView1.ColumnCount; i++)
            {
                datatable.AddCell(dataGridView1.Columns[i].HeaderText);
            }
            datatable.HeaderRows = 1;
            datatable.DefaultCell.BorderWidth = 1;
            for (i = 0; i < dataGridView1.Rows.Count; i++)
            {
                for (j = 0; j < dataGridView1.Columns.Count; j++)
                {
                    if (dataGridView1[j, i].Value != null)
                    {
                        datatable.AddCell(new Phrase(dataGridView1[j, i].Value.ToString()));//En esta parte, se esta agregando un renglon por cada registro en el datagrid
                    }
                }
                datatable.CompleteRow();
            }
            document.Add(datatable);
        }
        public float[] GetTamañoColumnas(DataGridView dg)
        {
            float[] values = new float[dg.ColumnCount];
            for (int i = 0; i < dg.ColumnCount; i++)
            {
                values[i] = (float)dg.Columns[i].Width;
            }
            return values;

        }

        private void btnreporte_Click(object sender, EventArgs e)
        {
            To_pdf();

        }

        private void txtbuscar_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtbuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (char.IsLetter(e.KeyChar))
                {
                    e.Handled = false;
                }
                else if (char.IsControl(e.KeyChar))
                {
                    e.Handled = false;
                }
                else if (char.IsSeparator(e.KeyChar))
                {
                    e.Handled = false;
                }
                else
                {
                    e.Handled = true;
                }
            }
            catch (Exception)
            {
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Prestamos p = new Prestamos();
            p.Show();
            this.Close();
        }
    }
}
