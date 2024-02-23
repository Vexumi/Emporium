using System.Windows.Controls;

namespace Emporium.Views.Components
{
    /// <summary>
    /// Логика взаимодействия для LabelTextboxComponent.xaml
    /// </summary>
    public partial class LabelTextboxComponent : UserControl
    {
        public LabelTextboxComponent()
        {
            InitializeComponent();
            DataContext = this;
        }
        public string LabelText { get; set; } = "Label";
        public string TextBoxText { get; set; } = "TextBox";
    }
}
