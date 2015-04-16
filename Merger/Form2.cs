using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Merger
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void save_Click(object sender, EventArgs e)
        {
            Array[] rows = new Array[this.tableRows.Rows.Count - 1];

            for (int i = 0; i < this.tableRows.Rows.Count - 1; i++ )
            {
                string[] cells = new string[this.tableRows.Rows[i].Cells.Count];

                cells[0] = this.tableRows.Rows[i].Cells[0].Value.ToString();
                cells[1] = this.tableRows.Rows[i].Cells[1].Value.ToString();

                rows[i] = cells;
            }

            XMLWorker a = new XMLWorker();
            a.updateCols(rows, 0, 1);
        }
    }
}
