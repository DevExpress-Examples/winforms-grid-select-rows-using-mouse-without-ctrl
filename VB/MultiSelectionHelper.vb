Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid.Views.Grid.ViewInfo
Imports DevExpress.Utils

Namespace WindowsApplication1
	Public Class MultiSelectionHelper

		Private _GridView As GridView
		Public Sub New(ByVal gridView As GridView)
			_GridView = gridView
			InitProperties()
			SubscribeEvents()
		End Sub
		Private Sub InitProperties()
			_GridView.OptionsBehavior.Editable = False
			_GridView.OptionsSelection.MultiSelect = True
			_GridView.OptionsSelection.EnableAppearanceFocusedCell = False
			_GridView.FocusRectStyle = DrawFocusRectStyle.None
		End Sub
		Private Sub SubscribeEvents()
			AddHandler _GridView.MouseDown, AddressOf _GridView_MouseDown
		End Sub

		Private Sub _GridView_MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs)
			OnMouseDown(e)
		End Sub
		Private Sub OnMouseDown(ByVal e As MouseEventArgs)
			Dim hi As GridHitInfo = _GridView.CalcHitInfo(e.Location)
			If (Not hi.InRow) Then
				Return
			End If
			_GridView.FocusedRowHandle = hi.RowHandle
			_GridView.FocusedColumn = hi.Column
			_GridView.InvertRowSelection(hi.RowHandle)
			DXMouseEventArgs.GetMouseArgs(e).Handled = True

		End Sub

	End Class
End Namespace
