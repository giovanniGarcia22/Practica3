using System.Windows.Forms;

namespace Practica3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void butAbrir_Click(object sender, EventArgs e)
        {
            String nomFile = "";
            DialogResult res = openFileDialog1.ShowDialog();
            if (res == DialogResult.OK)
            {
                nomFile = openFileDialog1.FileName;
                try
                {
                    string read = File.ReadAllText(nomFile);
                    string[] aux1 = read.Split('\n');
                    string[] aux2 = aux1[0].Split(',');
                    int tam = aux2.Length;
                    dataGridView1.ColumnCount = tam;
                    dataGridView1.RowCount = aux1.Length;
                    for (int i = 0; i < tam; i++)
                    {
                        dataGridView1.Rows[0].Cells[i].Value = aux2[i];
                    }

                    for (int i = 1; i < (aux1.Length) - 1; i++)
                    {
                        aux2 = aux1[i].Split(',');
                        for (int j = 0; j < tam; j++)
                        {
                            dataGridView1.Rows[i].Cells[j].Value = aux2[j];
                        }
                    }


                }
                catch (Exception ex)
                {
                    MessageBox.Show("NO SE PUDO ABRIR EL ARCHIVO \n" + ex.Message);
                }
            }
        }
    }
}
