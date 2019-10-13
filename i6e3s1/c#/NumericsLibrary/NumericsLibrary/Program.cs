using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;
using MathNet.Numerics.Optimization;
using System;


namespace NumericsLibrary
{
    public class Program
    {
        static void Main(string[] args)
        {

            // First, let's define the function and its gradient.
            var f = new Func<Vector<double>, double>(v => Math.Pow(v[0], 2) + Math.Pow(v[1], 4) + Math.Pow(v[2], 6));              // define function
            var g = new Func<Vector<double>, Vector<double>>(v => new DenseVector(new[] { 2.0 * v[0], 4.0 * v[1], 6.0 * v[2] }));  // define grandient
            var obj = ObjectiveFunction.Gradient(f, g);

            // Second, let's use BFGS algorithm which is an iterative method for solving unconstrained nonlinear optimization problems.
            // BfgsMinimizer(double gradientTolerance, double parameterTolerance, double functionProgressTolerance, int maximumIterations)
            var solver = new BfgsMinimizer(1e-5, 1e-5, 1e-5, 1000);
            var result = solver.FindMinimum(obj, new DenseVector(new[] { 15.0, 15.0, 15.0 })); // initial estimate = (15,15,15)

            Console.WriteLine(result.Iterations);

            Console.WriteLine(result.MinimizingPoint);

            Console.WriteLine(result.FunctionInfoAtMinimum.Gradient);

        }
    }
}
