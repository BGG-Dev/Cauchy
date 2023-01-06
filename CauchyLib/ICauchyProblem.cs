namespace CauchyLib
{
    /// <summary>
    /// Cauchy problem interface
    /// </summary>
    public interface ICauchyProblem
    {
        /// <summary>
        /// Solves Cauchy problem
        /// </summary>
        /// <param name="f"> right side function </param>
        /// <param name="a"> interval start </param>
        /// <param name="b"> interval end </param>
        /// <param name="h"> step </param>
        /// <param name="y0"> y value in x0 (a) </param>
        /// <returns></returns>
        public abstract Tuple<double, double>[] Solve(Func<double, double, double> f, double a, double b, double h, double y0);
    }
}
