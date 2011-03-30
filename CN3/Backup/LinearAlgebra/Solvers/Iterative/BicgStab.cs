using System;
using dnAnalytics.LinearAlgebra;
using dnAnalytics.LinearAlgebra.Solvers;
using dnAnalytics.LinearAlgebra.Solvers.Preconditioners;
using dnAnalytics.LinearAlgebra.Solvers.Iterative;

namespace dnAnalytics.Examples.LinearAlgebra.Solvers.Iterative
{
    /// <summary>
    /// Provides an example of the creation and use of the BiCGStab iterative solver
    /// </summary>
    public sealed class BicgstabExample
    {
        /// <summary>
        /// Creates a new sparse matrix with zero values everywhere except
        /// on the diagonal where the values are equal to 1.0.
        /// </summary>
        private Matrix CreateMatrix(int size)
        {
            // Create the sparse matrix with the specified size
            Matrix matrix = new SparseMatrix(size);
            // Add values to the matrix. For now we'll make the matrix
            // a unit matrix.
            for (int i = 0; i < size; i++)
            {
                matrix[i, i] = 1.0;
            }

            return matrix;
        }

        /// <summary>
        /// The main method that runs the BiCGStab iterative solver.
        /// </summary>
        public void UseSolver()
        {
            // Create a sparse matrix. For now the size will be 10 x 10 elements
            Matrix matrix = CreateMatrix(10);

            // Create the right hand side vector. The size is the same as the matrix
            // and all values will be 2.0.
            Vector rightHandSideVector = new DenseVector(10, 2.0);

            // Create a preconditioner. The possibilities are:
            // 1) No preconditioner - Simply do not provide the solver with a preconditioner.
            // 2) A simple diagonal preconditioner - Create an instance of the Diagonal class.
            // 3) A ILU preconditioner - Create an instance of the IncompleteLu class.
            // 4) A ILU preconditioner with pivoting and drop tolerances - Create an instance of the Ilutp class.

            // Here we'll use the simple diagonal preconditioner.
            // We need a link to the matrix so the pre-conditioner can do it's work.
            IPreConditioner preconditioner = new Diagonal();

            // Create a new iterator. This checks for convergence of the results of the
            // iterative matrix solver.
            // In this case we'll create the default iterator
            IIterator iterator = Iterator.CreateDefault();

            // Create the solver
            BiCgStab solver = new BiCgStab(preconditioner, iterator);

            // Now that all is set we can solve the matrix equation.
            Vector solutionVector = solver.Solve(matrix, rightHandSideVector);

            // Another way to get the values is by using the overloaded solve method
            // In this case the solution vector needs to be of the correct size.
            solver.Solve(matrix, rightHandSideVector, solutionVector);

            // Finally you can check the reason the solver finished the iterative process
            // by calling the SolutionStatus property on the iterator
            ICalculationStatus status = iterator.Status;
            if (status is CalculationCancelled)
                Console.WriteLine("The user cancelled the calculation.");
            
            if (status is CalculationIndetermined)
                Console.WriteLine("Oh oh, something went wrong. The iterative process was never started.");

            if (status is CalculationConverged)
                Console.WriteLine("Yippee, the iterative process converged.");
    
            if (status is CalculationDiverged)
                Console.WriteLine("I'm sorry the iterative process diverged.");

            if (status is CalculationFailure)
                Console.WriteLine("Oh dear, the iterative process failed.");

            if (status is CalculationStoppedWithoutConvergence)
                Console.WriteLine("Oh dear, the iterative process did not converge.");
        }
    }
}