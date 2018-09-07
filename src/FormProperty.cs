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
    public partial class FormProperty : Form
    {
        public FormProperty()
        {
            InitializeComponent();
        }

        public void AddValuesToDataGrid(string name, string header="")
        {
            int n = this.dataGridViewProperty.Rows.Add();
            this.dataGridViewProperty.Rows[n].Cells[0].Value = "Row " + (n + 1).ToString();
            this.dataGridViewProperty.Rows[n].Cells[1].Value = name;
            if (n == 0) this.dataGridViewProperty.Rows[n].HeaderCell.Value = "Stiffness";
        }

        // add following code for paste
        private void dataGridViewProperty_KeyDown(object sender, KeyEventArgs e)
        {
            {
                try
                {
                    if (e.Modifiers == Keys.Control)
                    {
                        switch (e.KeyCode)
                        {
                            case Keys.C:
                                CopyToClipboard();
                                break;

                            case Keys.V:
                                PasteClipboard();
                                break;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Copy/paste operation failed. " + ex.Message, "Copy/Paste", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
        private void CopyToClipboard()
        {
            //Copy to clipboard
            DataObject dataObj = dataGridViewProperty.GetClipboardContent();
            if (dataObj != null)
                Clipboard.SetDataObject(dataObj);
        }

        private void PasteClipboard()
        {
            try
            {
                string s = Clipboard.GetText();
                string[] lines = s.Split('\n');

                int iRow = dataGridViewProperty.CurrentCell.RowIndex;
                int iCol = dataGridViewProperty.CurrentCell.ColumnIndex;
                DataGridViewCell oCell;
                if (iRow + lines.Length > dataGridViewProperty.Rows.Count - 1)
                {
                    bool bFlag = false;
                    foreach (string sEmpty in lines)
                    {
                        if (sEmpty == "")
                        {
                            bFlag = true;
                        }
                    }

                    int iNewRows = iRow + lines.Length - dataGridViewProperty.Rows.Count;
                    if (iNewRows > 0)
                    {
                        if (bFlag)
                            dataGridViewProperty.Rows.Add(iNewRows);
                        else
                            dataGridViewProperty.Rows.Add(iNewRows + 1);
                    }
                    else
                        dataGridViewProperty.Rows.Add(iNewRows + 1);
                }
                foreach (string line in lines)
                {
                    if (iRow < dataGridViewProperty.RowCount && line.Length > 0)
                    {
                        string[] sCells = line.Split('\t');
                        for (int i = 0; i < sCells.GetLength(0); ++i)
                        {
                            if (iCol + i < this.dataGridViewProperty.ColumnCount)
                            {
                                oCell = dataGridViewProperty[iCol + i, iRow];
                                oCell.Value = Convert.ChangeType(sCells[i].Replace("\r", ""), oCell.ValueType);
                            }
                            else
                            {
                                break;
                            }
                        }
                        iRow++;
                    }
                    else
                    {
                        break;
                    }
                }
                Clipboard.Clear();
            }
            catch (FormatException)
            {
                MessageBox.Show("The data you pasted is in the wrong format for the cell");
                return;
            }
        }

        private void dataGridViewProperty_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
