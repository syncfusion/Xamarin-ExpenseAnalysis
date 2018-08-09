using Syncfusion.SfChart.XForms;
using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace ExpenseAnalysis
{
    public class ChartSelectionChangedBehavior : Behavior<SfChart>
    {
        public static readonly BindableProperty CommandProperty =
            BindableProperty.Create("Command", typeof(ICommand), typeof(ChartSelectionChangedBehavior), null);
        public static readonly BindableProperty InputConverterProperty =
          BindableProperty.Create("Converter", typeof(IValueConverter), typeof(ChartSelectionChangedBehavior), null);

        public IValueConverter Converter
        {
            get { return (IValueConverter)GetValue(InputConverterProperty); }
            set { SetValue(InputConverterProperty, value); }
        }

        public SfChart AssociatedObject { get; private set; }

        public ICommand Command
        {
            get { return (ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }

        private void Bindable_SelectionChanged(object sender, ChartSelectionEventArgs e)
        {
            if (Command == null)
            {
                return;
            }

            object parameter = Converter.Convert(e, typeof(object), null, null);
            if (Command.CanExecute(parameter))
            {
                Command.Execute(parameter);
            }
        }

        void OnBindingContextChanged(object sender, EventArgs e)
        {
            OnBindingContextChanged();
        }

        protected override void OnAttachedTo(SfChart bindable)
        {
            base.OnAttachedTo(bindable);
            AssociatedObject = bindable;
            bindable.BindingContextChanged += OnBindingContextChanged;
            bindable.SelectionChanged += Bindable_SelectionChanged;

        }

        protected override void OnDetachingFrom(SfChart bindable)
        {
            base.OnDetachingFrom(bindable);
            bindable.BindingContextChanged -= OnBindingContextChanged;
            AssociatedObject = null;
        }

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();
            BindingContext = AssociatedObject.BindingContext;
        }
    }
}
