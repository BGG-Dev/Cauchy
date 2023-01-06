namespace CauchyLib
{
    /// <summary>
    /// Abstract class to do common
    /// Cauchy problem solve implementation
    /// </summary>
    public abstract class AbstractCauchyProblem : ICauchyProblem
    {
        /// <summary>
        /// Common solve implementation
        /// </summary>
        /// <param name="f"> right side function </param>
        /// <param name="a"> interval start </param>
        /// <param name="b"> interval end </param>
        /// <param name="h"> step </param>
        /// <param name="y0"> y value in x0 (a) </param>
        /// <returns> Array of tuples, each tuple represents solution node </returns>
        public Tuple<double, double>[] Solve(Func<double, double, double> f, double a, double b, double h, double y0)
        {
            // Calculating intervals count
            int n = (int)((b - a) / h) + 1;

            // Creating arrays
            double[] x = new double[n];
            double[] y = new double[n];

            // Storing zero step values
            x[0] = a;
            y[0] = y0;

            // Iterating
            for (int i = 0; i < n - 1; i++)
            {
                RunSolveIteration(i, f, h, x, y);
            }

            // Returning
            Tuple<double, double>[] result = new Tuple<double, double>[n];
            for (int i = 0; i < n; i++)
            {
                result[i] = new Tuple<double, double>(Math.Round(x[i], 8), Math.Round(y[i], 8));
            }
            return result;
        }

        /// <summary>
        /// Template method
        /// to implement single solve iteration
        /// </summary>
        /// <param name="i"> index of current iteration </param>
        /// <param name="f"> right side function </param>
        /// <param name="h"> step </param>
        /// <param name="x"> x array </param>
        /// <param name="y"> y array </param>
        protected abstract void RunSolveIteration(int i,
                                                  Func<double, double, double> f, double h,
                                                  double[] x, double[] y);
    }
}
