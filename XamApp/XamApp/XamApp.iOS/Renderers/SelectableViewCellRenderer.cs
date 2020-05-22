using UIKit;
using XamApp.iOS.Renderers;
using XamApp.Views.Custom;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(SelectableViewCell), typeof(SelectableViewCellRenderer))]
namespace XamApp.iOS.Renderers
{
    public class SelectableViewCellRenderer : ViewCellRenderer
    {
        public override UITableViewCell GetCell(Cell item, UITableViewCell reusableCell, UITableView tv)
        {
            var cell = base.GetCell(item, reusableCell, tv);
            var view = item as SelectableViewCell;
            cell.SelectedBackgroundView = new UIView
            {
                BackgroundColor = view.SelectedItemBackgroundColor.ToUIColor(),
            };
            return cell;
        }
    }
}
