using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GeoShapes
{
    public partial class GeoShapesMainForm : Form
    {
        public GeoShapesMainForm()
        {
            InitializeComponent();
        }

        private void GeoShapesMainForm_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "geoShapesDBDataSet.Table". При необходимости она может быть перемещена или удалена.
            this.tableTableAdapter.Fill(this.geoShapesDBDataSet.Table);

        }

        private void addShapeButton_Click(object sender, EventArgs e)
        {
            DataRow row = geoShapesDBDataSet.Table.NewRow();
            row["type"] = this.comboBox1.Text;
            row["size"] = this.textBox1.Text;
            row["perimetr"] = this.get_perimetr(row["type"].ToString(), Convert.ToDouble(row["size"]));
            this.geoShapesDBDataSet.Table.Rows.Add(row);
        }

        private void deleteShapeButton_Click(object sender, EventArgs e)
        {
            
        }

        public double get_perimetr(string type, double size)
        {
            double perimetr = 0.0;
            if (type == "square") {
                perimetr = size * 4; 
            } else if (type == "triangle") {
                perimetr = size * 3; 
            } else if (type == "circle") {
                perimetr = size * 3.14; 
            };
            return perimetr;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            this.dataGridView1.Rows.RemoveAt(index);
        }
    }
}
