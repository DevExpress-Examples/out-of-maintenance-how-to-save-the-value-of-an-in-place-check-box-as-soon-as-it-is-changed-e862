Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms

Namespace CheckEditAutoSave
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Const DataFileName As String = "data.xml"

		Private Sub Form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
			If System.IO.File.Exists(DataFileName) Then
				dataSet1.ReadXml(DataFileName)
			Else
				dataTable1.Rows.Add(New Object() { 1, "Item A", True })
				dataTable1.Rows.Add(New Object() { 2, "Item B", False })
				dataTable1.AcceptChanges()
			End If
		End Sub

		Private Sub Form1_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs)
			' Save data to a persistent storage
			gridView1.CloseEditor()
			gridView1.UpdateCurrentRow()
			dataTable1.AcceptChanges()
			dataSet1.WriteXml(DataFileName)
		End Sub

		Private Sub repositoryItemCheckEdit1_EditValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles repositoryItemCheckEdit1.EditValueChanged
			gridView1.PostEditor()

			' The UpdateCurrentRow method call is optional for CheckEditor.
			' Don't call it for Text editors!
			' gridView1.UpdateCurrentRow();   

			' TEST:
			Console.WriteLine(gridView1.GetDataRow(gridView1.FocusedRowHandle)(gridView1.FocusedColumn.FieldName))
		End Sub

		Private Sub repositoryItemTextEdit1_EditValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles repositoryItemTextEdit1.EditValueChanged
			gridView1.PostEditor()

			' TEST:
			Console.WriteLine(gridView1.GetDataRow(gridView1.FocusedRowHandle)(gridView1.FocusedColumn.FieldName))
		End Sub
	End Class
End Namespace