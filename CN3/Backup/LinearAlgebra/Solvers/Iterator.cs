using System;
using dnAnalytics.LinearAlgebra;
using dnAnalytics.LinearAlgebra.Solvers;
using System.Collections.Generic;

namespace dnAnalytics.Examples.LinearAlgebra.Solvers
{
    /// <summary>
    /// Provides an example of the use of the Iterator
    /// </summary>
    public sealed class IteratorExample
    {
        /// <summary>
        /// Creates a convergence monitor.
        /// </summary>
        public void UseMonitor()
        {
            // Set the maximum increase in residual that we allow before 
            // stopping the iteration because of divergence.
            double maximumIncrease = 0.1;

            // Set the maximum number of iterations that the convergence monitor
            // will allow before indicating that the iteration must be stopped.
            int maximumNumberOfIterations = 100;

            // Set the value the residual must maximally have before the 
            // convergence monitor will declare that the iteration has converged.
            // Note that this residual is relative to the starting point which is
            // determined by the matrix norm.
            double minimumResidual = 1E-5;

            List<IIterationStopCriterium> criteria = new List<IIterationStopCriterium>();
            criteria.Add(new FailureStopCriterium());
            criteria.Add(new DivergenceStopCriterium(maximumIncrease));
            criteria.Add(new IterationCountStopCriterium(maximumNumberOfIterations));
            criteria.Add(new ResidualStopCriterium(minimumResidual));
            
            // Create the iterator
            Iterator monitor = new Iterator(criteria);

            // To be able to use the convergence monitor we'll need a solution vector and
            // a residual vector. For now fill both with silly numbers.
            Vector sourceVector = new DenseVector(10, 3.5);
            Vector solutionVector = new DenseVector(10, 2.5);
            Vector residualVector = new DenseVector(10, 1.5);
            
            // Check the solution status. There should not be a real status because
            // we haven't done anything yet
            Console.WriteLine("Solution status: " + monitor.Status.ToString());

            // Now use the monitor in a fake iteration. If all goes well this iteration should
            // stop because the number of iterations becomes larger than the number of iterations
            // we allow.
            int currentIteration = 0;
            while ((monitor.Status is CalculationRunning) || (monitor.Status is CalculationIndetermined))
            {                
                currentIteration++;
                Console.WriteLine("Working. Iteration no: " + currentIteration.ToString());
                monitor.DetermineStatus(currentIteration, solutionVector, sourceVector, residualVector);
            }

            // Indicate that we exited the loop
            Console.WriteLine("Stopped working.");
            // Indicate why we exited the loop. Note that this should say
            // SolutionStatus.IterationBoundsReached.
            Console.WriteLine("Stop reason: " + monitor.Status.ToString());
        }
    }
}