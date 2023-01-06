using CauchyLib;
using System;
using System.Windows;

namespace CauchyDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void CauchyButton_Click(object sender, RoutedEventArgs e)
        {
            // Getting f, a, b
            Func<double, double, double> f;
            double a = 0;
            double b = 0;
            double h = 0;
            double y0 = 0;
            try
            {
                a = Convert.ToDouble(StartTextBox.Text); 
                b = Convert.ToDouble(EndTextBox.Text);
                h = Convert.ToDouble(StepTextBox.Text);
                y0 = Convert.ToDouble(Y0TextBox.Text);
                f = FunctionService.CreateFunctionFromString(FunctionTextBox.Text);
            }
            catch
            {
                ShowErrorMessageBox("Something went wrong during evaluating function, min, max. Please check input.");
                return;
            }

            // Checking b > a
            if (a >= b)
            {
                ShowErrorMessageBox("max should be BIGGER than min.");
                return;
            }

            // Solving with Euler
            ICauchyProblem problem = new EulerCauchyProblem();
            var eulerNodes = problem.Solve(f, a, b, h, y0);

            // Solving with Runge-Kutt
            problem = new RungeKuttCauchyProblem();
            var rungeKuttNodes = problem.Solve(f, a, b, h, y0);

            // Displaying
            String display = "Euler x    |    y\n";
            foreach (Tuple<double, double> node in eulerNodes) 
            {
                display += node.Item1.ToString();
                display += " ";
                display += node.Item2.ToString();
                display += "\n";
            }
            display += "\nRunge-Kutt x    |    y\n";
            foreach (Tuple<double, double> node in rungeKuttNodes) 
            {
                display += node.Item1.ToString();
                display += " ";
                display += node.Item2.ToString();
                display += "\n";
            }
            Result.Text = display;
        }

        private void ShowErrorMessageBox(String msg)
        {
            MessageBox.Show(msg, "Oops!");
        }
    }
}
