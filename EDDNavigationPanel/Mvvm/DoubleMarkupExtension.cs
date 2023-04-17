using System;
using System.Windows.Markup;

namespace EDDNavigationPanel.Mvvm
{
    internal class DoubleMarkupExtension : MarkupExtension
    {
        private double _value;

        public DoubleMarkupExtension(double value)
        {
            _value = value;
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return _value;
        }
    }
}
