using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Sudoku_Solver {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        const int SQUARE_SIZE = 50;

        public MainWindow() {
            InitializeComponent();
        }

        private void Window_Loaded( object sender, RoutedEventArgs e ) {
            GenerateControls();
        }

        private void GenerateControls() {
            for ( int row = 0; row < 9; row++ ) {
                for ( int col = 0; col < 9; col++ ) {
                    AddTextBox( row, col );
                }
            }
        }

        private void AddTextBox( int row, int col ) {
            TextBox textBox = new TextBox();
            textBox.VerticalContentAlignment = System.Windows.VerticalAlignment.Center;
            textBox.HorizontalContentAlignment = System.Windows.HorizontalAlignment.Center;
            textBox.FontSize = 28;
            textBox.FontWeight = FontWeights.Bold;
            textBox.Text = row + "," + col;
            textBox.Width = SQUARE_SIZE;
            textBox.Height = SQUARE_SIZE;
            textBox.VerticalAlignment = System.Windows.VerticalAlignment.Top;
            textBox.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;

            Thickness margin = textBox.Margin;
            margin.Left = row * SQUARE_SIZE;
            margin.Top = col * SQUARE_SIZE;
            textBox.Margin = margin;

            Border border = new Border();
            border.CornerRadius = new CornerRadius( 0 );

            textBox.BorderThickness = new Thickness( 1, 1, 1, 1 );
            textBox.BorderBrush = Brushes.Black;

            if ( row == 2 || row == 5 ) {
                textBox.BorderThickness = new Thickness( 1, 1, 5, 1 );
                textBox.BorderBrush = Brushes.Black;
            }

            if ( col == 2 || col == 5 ) {
                textBox.BorderThickness = new Thickness( 1, 1, 1, 5 );
                textBox.BorderBrush = Brushes.Black;
            }
            
            if ((row == 2 && col == 2) || (row == 2 && col == 5) ||
                (row == 5 && col == 2) || (row == 5 && col == 5)) {
                textBox.BorderThickness = new Thickness( 1, 1, 5, 5 );
                textBox.BorderBrush = Brushes.Black;
            }

            GameBoard.Children.Add( textBox );
        }
    }
}
