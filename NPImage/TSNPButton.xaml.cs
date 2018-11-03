using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NPImage
{
    /// <summary>
    /// Three states nine patch button.
    /// </summary>
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TSNPButton : ContentView
    {
        /// <summary>
        /// Button click event.
        /// </summary>
        public event EventHandler Clicked;
        /// <summary>
        /// 9.png resource path.
        /// </summary>
        public string Source
        {
            get { return imageView.Source; }
            set { imageView.Source = value; }
        }
        /// <summary>
        /// 9.png resource path.
        /// </summary>
        public string SourcePressed
        {
            get { return imageView.SourcePressed; }
            set { imageView.SourcePressed = value; }
        }
        /// <summary>
        /// 9.png resource path.
        /// </summary>
        public string SourceDisabled
        {
            get { return imageView.SourceDisabled; }
            set { imageView.SourceDisabled = value; }
        }
        /// <summary>
        /// Button text.
        /// </summary>
        public string Text
        {
            get { return button.Text; }
            set { button.Text = value; }
        }
        /// <summary>
        /// Button text color.
        /// </summary>
        public Color TextColor
        {
            get { return button.TextColor; }
            set { button.TextColor = value; }
        }

        public TSNPButton()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Clicked?.Invoke(this, e);
        }

        private void Button_Pressed(object sender, EventArgs e)
        {
            imageView.IsPressed = true;
        }

        private void Button_Released(object sender, EventArgs e)
        {
            imageView.IsPressed = false;
        }
    }
}