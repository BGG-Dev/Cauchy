namespace CauchyLib
{
    /// <summary>
    /// Euler (advanced) 
    /// Cauchy problem solution implementation
    /// </summary>
    public class EulerCauchyProblem : AbstractCauchyProblem
    {
        /// <summary>
        /// Advanced Euler solve iteration implementation
        /// </summary>
        /// <param name="i"> index of current iteration </param>
        /// <param name="f"> right side function </param>
        /// <param name="h"> step </param>
        /// <param name="x"> x array </param>
        /// <param name="y"> y array </param>
        protected override void RunSolveIteration(int i, 
                                                  Func<double, double, double> f, double h, 
                                                  double[] x, double[] y)
        {
            x[i + 1] = x[i] + h;
            y[i + 1] = y[i] + (h / 2.0) * (f.Invoke(x[i], y[i]) + f.Invoke(x[i + 1], y[i] + h * f.Invoke(x[i], y[i])));
        }
    }
}
