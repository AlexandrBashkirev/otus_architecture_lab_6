using System;


namespace otus_architecture_lab_6
{
    class MatrixWorkerBuilder
    {
        public MatrixWorker Construct(string t)
        {
            switch(t)
            {
                case "determinant":
                    return new DeterminantMatrixWorker();
                case "transpond":
                    return new TranspondMatrixWorker();
                case "sum":
                    return new SumMatrixWorker();
                default:
                    throw new Exception("Unknown matrix worker type");
            }
        }
    }
}
