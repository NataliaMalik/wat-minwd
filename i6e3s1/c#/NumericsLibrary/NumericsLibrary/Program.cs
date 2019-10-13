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

            // Example with explicit objective function and gradient
            // Function f = function to be minimized evaluated at a point (v)
            // Gradient g = vector of partial derivatives evaluated a point (v)

            var f = new Func<Vector<double>, double>(v => Math.Pow(v[0], 2) + Math.Pow(v[1], 4) + Math.Pow(v[2], 6));              // define function
            var g = new Func<Vector<double>, Vector<double>>(v => new DenseVector(new[] { 2.0 * v[0], 4.0 * v[1], 6.0 * v[2] }));  // define grandient
            var obj = ObjectiveFunction.Gradient(f, g);
            var solver = new BfgsMinimizer(1e-5, 1e-5, 1e-5, 1000);
            var result = solver.FindMinimum(obj, new DenseVector(new[] { 15.0, 15.0, 15.0 })); // initial estimate = (15,15,15)

            Console.WriteLine(result.Iterations);
            // output = 8

            Console.WriteLine(result.MinimizingPoint);
            //DenseVector 3 - Double
            //  4.99304E-07
            //- 1.43819E-06
            //- 1.21743E-06

            Console.WriteLine(result.FunctionInfoAtMinimum.Gradient);
            //DenseVector 3 - Double
            //  9.98607E-07
            //- 5.75278E-06
            //- 7.30457E-06

            // note: failed for initial points too far from zero, i.e. much larger than (20,20,20)

        }
    }
}
