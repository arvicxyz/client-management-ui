using Android.Content;
using Android.Graphics.Drawables;
using Android.Views;
using System.ComponentModel;
using XamApp.Droid.Renderers;
using XamApp.Views.Custom;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(SelectableViewCell), typeof(SelectableViewCellRenderer))]
namespace XamApp.Droid.Renderers
{
    public class SelectableViewCellRenderer : ViewCellRenderer
    {
        private Android.Views.View _cellCore;
        private Drawable _unselectedBackground;
        private bool _isSelected;

        protected override Android.Views.View GetCellCore(Cell item, Android.Views.View convertView, ViewGroup parent, Context context)
        {
            _cellCore = base.GetCellCore(item, convertView, parent, context);
            _unselectedBackground = _cellCore.Background;
            _isSelected = false;
            return _cellCore;
        }

        protected override void OnCellPropertyChanged(object sender, PropertyChangedEventArgs args)
        {
            base.OnCellPropertyChanged(sender, args);
            if (args.PropertyName == "IsSelected")
            {
                _isSelected = !_isSelected;
                if (_isSelected)
                {
                    var cell = sender as SelectableViewCell;
                    var cellColor = cell.SelectedItemBackgroundColor;
                    _cellCore.SetBackgroundColor(cellColor.ToAndroid());
                }
                else
                {
                    _cellCore.SetBackground(_unselectedBackground);
                }
            }
        }
    }
}
