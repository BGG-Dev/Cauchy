namespace CauchyLib
{
    /// <summary>
    /// Runge-Kutt 
    /// Cauchy problem solution implementation
    /// </summary>
    public class RungeKuttCauchyProblem : AbstractCauchyProblem
    {
        /// <summary>
        /// Runge-Kutt solve iteration implementation
        /// </summary>
        /// <param name="i"> index of current iteration </param>
        /// <param name="f"> right side function </param>
        /// <param name="h"> step </param>
        /// <param name="x"> x array </param>
        /// <param name="y"> y array </param>
        protected override void RunSolveIteration(int i, Func<double, double, double> f, double h, double[] x, double[] y)
        {
            x[i + 1] = x[i] + h;
            double[] k = new double[4];
            k[0] = f.Invoke(x[i], y[i]);
            k[1] = f.Invoke(x[i] + h / 2.0, y[i] + h * k[0] / 2.0);
            k[2] = f.Invoke(x[i] + h / 2.0, y[i] + h * k[1] / 2.0);
            k[3] = f.Invoke(x[i] + h, y[i] + h * k[2]);
            y[i + 1] = y[i] + (h / 6.0) * (k[0] + 2.0 * k[1] + 2.0 * k[2] + k[3]);
        }
    }
}
