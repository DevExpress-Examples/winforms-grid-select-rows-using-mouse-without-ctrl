using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.Utils;

namespace WindowsApplication1
{
	public class MultiSelectionHelper
	{

		private GridView _GridView;
		public MultiSelectionHelper(GridView gridView)
		{
			_GridView = gridView;
			InitProperties();
			SubscribeEvents();
		}
		private void InitProperties()
		{
			_GridView.OptionsBehavior.Editable = false;
			_GridView.OptionsSelection.MultiSelect = true;
			_GridView.OptionsSelection.EnableAppearanceFocusedCell = false;
			_GridView.FocusRectStyle = DrawFocusRectStyle.None;
		}
		private void SubscribeEvents()
		{
			_GridView.MouseDown += _GridView_MouseDown;
		}

		private void _GridView_MouseDown(object sender, MouseEventArgs e)
		{
			OnMouseDown(e);
		}
		private void OnMouseDown(MouseEventArgs e)
		{
			GridHitInfo hi = _GridView.CalcHitInfo(e.Location);
			if (!hi.InRow)
			{
				return;
			}
			_GridView.FocusedRowHandle = hi.RowHandle;
			_GridView.FocusedColumn = hi.Column;
			_GridView.InvertRowSelection(hi.RowHandle);
			DXMouseEventArgs.GetMouseArgs(e).Handled = true;

		}

	}
}
