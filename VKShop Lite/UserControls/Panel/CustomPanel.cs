using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;

namespace VKShop_Lite.UserControls.Panel
{
    public class CustomPanel : Windows.UI.Xaml.Controls.Panel
    {

        private double _maxWidth;
        private double _maxHeight;

        protected override Size ArrangeOverride(Size finalSize)
        {
            var x = 0.0;
            var y = 0.0;

            foreach (var child in Children)
            {
                // if there is not enough space left, put in new column
                // si il n'a a pas assez d'espace, crée une nouvelle colonne
                if ((_maxHeight + y) > finalSize.Height)
                {
                    y = 0;
                    x += _maxWidth;
                }

                var newpos = new Rect(x, y, _maxWidth, _maxHeight);

                child.Arrange(newpos);

                y += _maxHeight;
            }
            return finalSize;
        }

        protected override Size MeasureOverride(Size availableSize)
        {
            // check the maximum width/height for all children
            // cherche la largeur/hauteur maximum
            foreach (var child in Children)
            {
                child.Measure(availableSize);

                var desirtedwidth = child.DesiredSize.Width;
                if (desirtedwidth > _maxWidth)
                    _maxWidth = desirtedwidth;

                var desiredheight = child.DesiredSize.Height;
                if (desiredheight > _maxHeight)
                    _maxHeight = desiredheight;
            }

            // take the available height to compute how many items per column
            // utilise la hauteur disponible pour calculer le nombre d'item par colonne
            var itemspercolumn = Math.Floor(availableSize.Height / _maxHeight);


            // compute the number of columns needed
            // calcule le nombre de colonne necessaires
            var columns = Math.Ceiling(Children.Count / itemspercolumn);

            Debug.WriteLine("Max width : " + _maxWidth);
            Debug.WriteLine("Max height : " + _maxHeight);
            Debug.WriteLine("Items per columns : " + itemspercolumn);
            Debug.WriteLine("Columns : " + columns);

            return new Size(_maxWidth * columns, itemspercolumn * _maxHeight);
        }
    }

}
