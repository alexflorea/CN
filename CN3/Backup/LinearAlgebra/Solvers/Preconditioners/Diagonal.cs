using dnAnalytics.LinearAlgebra;
using dnAnalytics.LinearAlgebra.Solvers.Preconditioners;

namespace dnAnalytics.Examples.LinearAlgebra.Solvers.Preconditioners
{
    public sealed class DiagonalExample
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
        /// The main method that uses the Diagonal preconditioner.
        /// </summary>
        public void UseSolver()
        {
            // Create a sparse matrix. For now the size will be 10 x 10 elements
            Matrix matrix = CreateMatrix(10);

            // Create the right hand side vector. The size is the same as the matrix
            // and all values will be 2.0.
            Vector rightHandSideVector = new DenseVector(10, 2.0);

            // Create the Diagonal preconditioner
            Diagonal preconditioner = new Diagonal();
            
            // Create the actual preconditioner
            preconditioner.Initialize(matrix);

            // Now that all is set we can solve the matrix equation.
            Vector solutionVector = preconditioner.Approximate(rightHandSideVector);

            // Another way to get the values is by using the overloaded solve method
            // In this case the solution vector needs to be of the correct size.
            preconditioner.Approximate(rightHandSideVector, solutionVector);
        }
    }
}