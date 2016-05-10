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
        const int GRID_SIZE = 3,
                  SQUARE_SIZE = 50;

        public MainWindow() {
            InitializeComponent();
        }

        private void Window_Loaded( object sender, RoutedEventArgs e ) {
            GenerateControls();
        }

        private void GenerateControls() {
            // Add 9 inner grids
            for ( int i = 0; i < GRID_SIZE * GRID_SIZE; i++ ) {
                WrapPanel innerGrid = new WrapPanel();
                Border innerGridBorder = new Border();

                innerGridBorder.Width = 154;
                innerGridBorder.Height = 154;
                innerGridBorder.BorderThickness = new Thickness( 2 );
                innerGridBorder.BorderBrush = Brushes.Black;

                // Add 9 cells to each inner grid
                for ( int col = 0; col < GRID_SIZE; col++ ) {
                    for ( int row = 0; row < GRID_SIZE; row++ ) {
                        innerGrid.Children.Add( GenerateTextBox( row, col ) );
                    }
                }

                innerGridBorder.Child = innerGrid;
                GameBoard.Children.Add( innerGridBorder );
            }
        }

        private TextBox GenerateTextBox( int row, int col ) {
            TextBox textBox = new TextBox();
            textBox.Width = SQUARE_SIZE;
            textBox.Height = SQUARE_SIZE;
            textBox.FontSize = 28;
            textBox.FontWeight = FontWeights.Bold;
            textBox.BorderBrush = Brushes.DimGray;

            textBox.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
            textBox.HorizontalContentAlignment = System.Windows.HorizontalAlignment.Center;
            textBox.VerticalAlignment = System.Windows.VerticalAlignment.Top;
            textBox.VerticalContentAlignment = System.Windows.VerticalAlignment.Center;

            textBox.Text = ((col * GRID_SIZE + row) + 1).ToString();

            return textBox;
        }
    }
}
