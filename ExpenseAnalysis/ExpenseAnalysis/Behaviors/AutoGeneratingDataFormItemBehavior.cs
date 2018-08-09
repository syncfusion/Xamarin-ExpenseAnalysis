using System;
using System.Reflection;
using System.Windows.Input;
using Syncfusion.XForms.DataForm;
using Xamarin.Forms;

namespace ExpenseAnalysis
{
    public class AutoGeneratingDataFormItemBehavior : Behavior<SfDataForm>
    {
        public static readonly BindableProperty CommandProperty =
            BindableProperty.Create("Command", typeof(ICommand), typeof(AutoGeneratingDataFormItemBehavior), null);
        public static readonly BindableProperty InputConverterProperty =
          BindableProperty.Create("Converter", typeof(IValueConverter), typeof(AutoGeneratingDataFormItemBehavior), null);

        public IValueConverter Converter
        {
            get { return (IValueConverter)GetValue(InputConverterProperty); }
            set { SetValue(InputConverterProperty, value); }
        }

        public SfDataForm AssociatedObject { get; private set; }

        public ICommand Command
        {
            get { return (ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }

        void OnBindingContextChanged(object sender, EventArgs e)
        {
            OnBindingContextChanged();
        }

        void Bindable_AutoGeneratingDataFormItem(object sender, AutoGeneratingDataFormItemEventArgs e)
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

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();
            BindingContext = AssociatedObject.BindingContext;
        }

        protected override void OnAttachedTo(SfDataForm bindable)
        {
            base.OnAttachedTo(bindable);
            AssociatedObject = bindable;
            bindable.BindingContextChanged += OnBindingContextChanged;
            bindable.AutoGeneratingDataFormItem += Bindable_AutoGeneratingDataFormItem;
        }

        protected override void OnDetachingFrom(SfDataForm bindable)
        {
            base.OnDetachingFrom(bindable);
            bindable.BindingContextChanged -= OnBindingContextChanged;
            bindable.AutoGeneratingDataFormItem -= Bindable_AutoGeneratingDataFormItem;
            AssociatedObject = null;
        }
    }
}
