using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NS_HoogoComposite
{
    public partial class mainForm : Form
    {
        public mainForm()
        {
            InitializeComponent();
        }

        private void anotherFromToolStripMenuItem_Click(object sender, EventArgs e)
        {

            displayFiberProperty();

            //for (int i = 0; i < name.Length; i++)
            //{ 
            //     int n = this.dgvProperty.Rows.Add();
            //     this.dgvProperty.Rows[n].Cells[0].Value = "Row " + n.ToString();
            //     this.dgvProperty.Rows[n].Cells[1].Value = name[n];
            //     if (n == 0) this.dgvProperty.Rows[n].HeaderCell.Value = "Stiffness";
            //}
        }

        private void form3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = 10;
         }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //this.treeView1.Nodes["Fiber"].Nodes.Add("New Fiber");
            if (treeViewProperty.SelectedNode != null)
            {
                string yourChildNode;
                yourChildNode = "New " + treeViewProperty.SelectedNode.Text; //treeView1.Text.Trim();
                treeViewProperty.SelectedNode.Nodes.Add(yourChildNode);
                treeViewProperty.ExpandAll();

                switch (treeViewProperty.SelectedNode.Text)
                {
                    case "Fiber":
                        displayFiberProperty();
                        break;
                    case "Matrix":
                        displayMatrixProperty();
                        break;
                    case "Ply":
                        displayLaminaProperty();
                        break;
                    case "Laminate":
                        displayLaminateProperty();
                        break;
                    default:
                        MessageBox.Show("Invalid selection. Please select 1, 2, or 3.");
                        break;
                }
            }
        }

        private void statusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (treeViewProperty.SelectedNode != null)
            {
                DialogResult result = MessageBox.Show("Do you want to delete "+ treeViewProperty.SelectedNode.Text+"? ", "Confirmation", MessageBoxButtons.YesNoCancel);
                if (result == DialogResult.Yes)
                {
                    treeViewProperty.Nodes.Remove(treeViewProperty.SelectedNode);
                    treeViewProperty.ExpandAll();
                }
                else if (result == DialogResult.No)
                {
                    //...
                }
                else
                {
                    //...
                }

            }
        }

        private void trvProperty_DoubleClick(object sender, EventArgs e)
        {

        }

        private void dgvProperty_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            
            //MessageBox.Show("Row " + e.RowIndex.ToString() + " is clicked");
            if (e.RowIndex == 0)  // click the first row only
            {
                //int n = this.dataGridViewProperty.Rows.Add();
                //this.dataGridViewProperty.Rows[n].Cells[0].Value = "Dade";
                //this.dataGridViewProperty.Rows[n].Cells[0].ReadOnly = true;
                //this.dataGridViewProperty.Rows[n].Cells[1].Value = "Huang";
                //if (n == 0)
                //    this.dataGridViewProperty.Rows[n].HeaderCell.Value = "Stiffness";
                //else
                //    this.dataGridViewProperty.Rows[n].HeaderCell.Value = "";
            }
        }

        private void displayFiberProperty()
        {
            string[] name = { 
                 "E11     ", 
                 "E22     ", 
                 "G12     ", 
                 "G23     ", 
                 "NU12    ", 
                 "S11T    ", 
                 "S11C    ", 
                 "RHO     ", 
                 "ALPHA11 ", 
                 "ALPHA22 ", 
                 "ALPHA33 ", 
                 "K11     ", 
                 "K22     ", 
                 "K33     ", 
                 "HC      ", 
                 "D11     ", 
                 "D22     ", 
                 "D33     ", 
                 "BETA11  ", 
                 "BETA22  ", 
                 "BETA33  ", 
                 "KE11    ", 
                 "KE22    ", 
                 "KE33    ", 
                 "GAMMA11 ", 
                 "GAMMA22 ", 
                 "GAMMA33 ", 
                 "SE11    ", 
                 "SE22    ", 
                 "SE33    ", 
                 "DAMP11  ", 
                 "DAMP22  ", 
                 "DAMP33  ", 
                 "DAMP12  ", 
                 "DAMP23  ", 
                 "DAMP13  " 
            };

            FormProperty form = new FormProperty();
            form.Text = "Fiber";
            form.MdiParent = this;
            form.Show();
            this.splitContainer1.Panel2.Controls.Add(form);
            for (int i = 0; i < name.Length; i++)
            {
                form.AddValuesToDataGrid(name[i], "Stiffness");
                //int n = form.dataGridViewProperty.Rows.Add();
                //form.dataGridViewProperty.Rows[n].Cells[0].Value = "Row " + (n+1).ToString();
                //form.dataGridViewProperty.Rows[n].Cells[1].Value = name[i];
                //if (n == 0) form.dataGridViewProperty.Rows[n].HeaderCell.Value = "Stiffness";
            }
        }


        private void displayLaminaProperty()
        {
            string[] name = {
                 "E11     ",
                 "E22     ",
                 "E33     ",
                 "G12     ",
                 "G23     ",
                 "G13     ",
                 "NU12    ",
                 "NU23    ",
                 "NU13    ",
                 "S11T    ",
                 "S11C    ",
                 "S22T    ",
                 "S22C    ",
                 "S33T    ",
                 "S33C    ",
                 "S12S    ",
                 "S23S    ",
                 "S13S    ",
                 "RHO     ",
                 "ALPHA11 ",
                 "ALPHA22 ",
                 "ALPHA33 ",
                 "K11     ",
                 "K22     ",
                 "K33     ",
                 "HC      ",
                 "D11     ",
                 "D22     ",
                 "D33     ",
                 "BETA11  ",
                 "BETA22  ",
                 "BETA33  ",
                 "SSID    ",
                 "TEMP    ",
                 "SNID    ",
                 "DFACT   ",
                 "FFACT   ",
                 "KE11    ",
                 "KE22    ",
                 "KE33    ",
                 "GAMMA11 ",
                 "GAMMA22 ",
                 "GAMMA33 ",
                 "SE11    ",
                 "SE22    ",
                 "SE33    ",
                 "MUP     ",
                 "DAMP11  ",
                 "DAMP22  ",
                 "DAMP33  ",
                 "DAMP12  ",
                 "DAMP23  ",
                 "DAMP13  ",
                 "DFACTT  ",
                 "DFACTC  ",
                 "DFACTS  "
            };

            FormProperty form = new FormProperty();
            form.MdiParent = this;
            form.Show();
            this.splitContainer1.Panel2.Controls.Add(form);
            for (int i = 0; i < name.Length; i++)
            {
                form.AddValuesToDataGrid(name[i], "Stiffness");
                //int n = form.dataGridViewProperty.Rows.Add();
                //form.dataGridViewProperty.Rows[n].Cells[0].Value = "Row " + (n+1).ToString();
                //form.dataGridViewProperty.Rows[n].Cells[1].Value = name[i];
                //if (n == 0) form.dataGridViewProperty.Rows[n].HeaderCell.Value = "Stiffness";
            }
        }

        private void displayMatrixProperty()
        {
            string[] name = {
                   "E       ",
                   "NU      ",
                   "ST      ",
                   "SC      ",
                   "SS      ",
                   "RHO     ",
                   "ALPHA   ",
                   "K       ",
                   "HC      ",
                   "EPST    ",
                   "EPSC    ",
                   "EPSS    ",
                   "D       ",
                   "BETA    ",
                   "SSID    ",
                   "TEMP    ",
                   "SNID    ",
                   "DFACT   ",
                   "FFACT   ",
                   "FACET   ",
                   "FACES   ",
                   "KE      ",
                   "GAMMA   ",
                   "SE      ",
                   "MUP     ",
                   "DAMPN   ",
                   "DAMPS   ",
                   "DFACTT  ",
                   "DFACTC  ",
                   "DFACTS  ",
            };

            for (int i = 0; i < name.Length; i++)
            {
                //int n = this.dataGridViewProperty.Rows.Add();
                //this.dataGridViewProperty.Rows[n].Cells[0].Value = "Row " + (n+1).ToString();
                //this.dataGridViewProperty.Rows[n].Cells[1].Value = name[i];
                //if (n == 0) this.dataGridViewProperty.Rows[n].HeaderCell.Value = "Stiffness";
            }
        }

        private void displayLaminateProperty()
        {
            string[] name = {
                   "E       ",
                   "NU      ",
                   "ST      ",
                   "SC      ",
                   "SS      ",
                   "RHO     ",
                   "ALPHA   ",
                   "K       ",
                   "HC      ",
                   "EPST    ",
                   "EPSC    ",
                   "EPSS    ",
                   "D       ",
                   "BETA    ",
                   "SSID    ",
                   "TEMP    ",
                   "SNID    ",
                   "DFACT   ",
                   "FFACT   ",
                   "FACET   ",
                   "FACES   ",
                   "KE      ",
                   "GAMMA   ",
                   "SE      ",
                   "MUP     ",
                   "DAMPN   ",
                   "DAMPS   ",
                   "DFACTT  ",
                   "DFACTC  ",
                   "DFACTS  ",
            };

            for (int i = 0; i < name.Length; i++)
            {
                //int n = this.dataGridViewProperty.Rows.Add();
                //this.dataGridViewProperty.Rows[n].Cells[0].Value = "Row " + (n+1).ToString();
                //this.dataGridViewProperty.Rows[n].Cells[1].Value = name[i];
                //if (n == 0) this.dataGridViewProperty.Rows[n].HeaderCell.Value = "Stiffness";
            }
        }
        private void trvProperty_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void treeViewProperty_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                //// Select the clicked node
                //if (treeViewProperty.SelectedNode != null)
                //{
                //    ContextMenu.Show(treeViewProperty, e.Location);
                //}
            }
        }
    }
}
