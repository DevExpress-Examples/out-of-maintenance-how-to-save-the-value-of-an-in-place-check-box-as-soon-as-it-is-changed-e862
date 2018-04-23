using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CheckEditAutoSave {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        const string DataFileName = "data.xml";

        private void Form1_Load(object sender, System.EventArgs e) {
            if(System.IO.File.Exists(DataFileName))
                dataSet1.ReadXml(DataFileName);
            else {
                dataTable1.Rows.Add(new object[] { 1, "Item A", true });
                dataTable1.Rows.Add(new object[] { 2, "Item B", false });
                dataTable1.AcceptChanges();
            }
        }

        private void Form1_Closing(object sender, System.ComponentModel.CancelEventArgs e) {
            // Save data to a persistent storage
            gridView1.CloseEditor();
            gridView1.UpdateCurrentRow();
            dataTable1.AcceptChanges();
            dataSet1.WriteXml(DataFileName);
        }

        private void repositoryItemCheckEdit1_EditValueChanged(object sender, EventArgs e) {
            gridView1.PostEditor();

            // The UpdateCurrentRow method call is optional for CheckEditor.
            // Don't call it for Text editors!
            // gridView1.UpdateCurrentRow();   

            // TEST:
            Console.WriteLine(gridView1.GetDataRow(gridView1.FocusedRowHandle)[gridView1.FocusedColumn.FieldName]);
        }

        private void repositoryItemTextEdit1_EditValueChanged(object sender, EventArgs e) {
            gridView1.PostEditor();

            // TEST:
            Console.WriteLine(gridView1.GetDataRow(gridView1.FocusedRowHandle)[gridView1.FocusedColumn.FieldName]);
        }
    }
}