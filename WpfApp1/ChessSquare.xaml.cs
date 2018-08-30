using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace ChessDisplay
{
    /// <summary>
    /// Interaction logic for ChessSquare.xaml
    /// </summary>
    public partial class ChessSquare : UserControl
    {
        public static readonly DependencyProperty IsSelectedProperty = DependencyProperty.Register("IsSelected", typeof(bool),
            typeof(ChessSquare), new PropertyMetadata(false, IsSelectedPropertyChanged, NonNullItems));

        public readonly SolidColorBrush DefaultBackground;

        public static readonly SolidColorBrush SelectedBackground = new SolidColorBrush(Colors.Green);

        public static readonly SolidColorBrush HoverBackground = new SolidColorBrush(Colors.Blue);

        private bool isSelected = false;

        public bool IsSelected {
            get { return (bool)GetValue(IsSelectedProperty); }
            set {SetValue(IsSelectedProperty, value); }
        }

        public int XPos { get { return (int)GetValue(Grid.ColumnProperty); }
            set {
                SetValue(Grid.ColumnProperty, value);
            } }

        public int YPos
        {
            get { return (int)GetValue(Grid.RowProperty); }
            set
            {
                SetValue(Grid.RowProperty, value);
            }
        }

        public ChessBoardControl Control { get; private set; }

        public ChessSquare(bool grey, ChessBoardControl control)
        {
            InitializeComponent();
            DefaultBackground = new SolidColorBrush(grey ? Colors.Gray : Colors.White);
            Square.Background = DefaultBackground;
            this.MouseEnter += Square_Enter;
            this.MouseLeave += Square_Leave;
            this.MouseDoubleClick += Square_MouseDown;
            this.Control = control;

        }

        public void ToggleIsSelected() {
            IsSelected = !IsSelected;
        }

        public void SetPicture(BitmapImage image)
        {
            ChessPieceImage.Source = image;
        }

        private void Square_MouseDown(object sender, MouseEventArgs e) {
            if (!Control.SelectingMove)
            {
                ToggleIsSelected();
                Control.ToggleSelectingMove(this);
                Square_Enter(sender, e);
            }
        }

        private void Square_Enter(object sender, MouseEventArgs e) {
            Square.Background = IsSelected ? SelectedBackground : HoverBackground;
        }

        private void Square_Leave(object sender, MouseEventArgs e) {
            //return to default value
            Square.Background = IsSelected ? SelectedBackground : DefaultBackground;
        }

        private static ChessSquare PropertyChanged<T>(DependencyObject source, DependencyPropertyChangedEventArgs e, out T value)
        {
            ChessSquare control = source as ChessSquare;
            T newValue = (T)e.NewValue;
            value = newValue;
            return control;
        }

        private static void IsSelectedPropertyChanged(DependencyObject source, DependencyPropertyChangedEventArgs e)
        {
            ChessSquare control = PropertyChanged<bool>(source, e, out bool isSelected);
            control.isSelected = isSelected;
        }

        private static object NonNullItems(DependencyObject source, object newValue)
        {
            bool isSelected = (source as ChessSquare).IsSelected;
            if (newValue != null)
            {
                return (bool)newValue;
            }
            return isSelected;
        }

    }
}
