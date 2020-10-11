using System;


namespace otus_architecture_lab_6
{
    public class MatrixSumCmd : CommandBase
    {
        #region Variables

        Matrix matrixA = null;
        Matrix matrixB = null;

        #endregion



        #region Class lifecycle

        public MatrixSumCmd(Matrix matrixA, Matrix matrixB)
        {
            if (matrixA.Columns != matrixB.Columns ||
                matrixA.Rows != matrixB.Rows)
            {
                throw new Exception("Can't sum matrix");
            }

            this.matrixA = matrixA;
            this.matrixB = matrixB;
        }

        #endregion



        #region Methods

        public override void Run()
        {
            Matrix result = new Matrix(matrixA.Rows, matrixA.Columns);

            for (int row = 0; row < result.Rows; row++)
            {
                for (int column = 0; column < result.Columns; column++)
                {
                    result[row, column] = matrixA[row, column] + matrixB[row, column];
                }
            }

            callback?.Invoke(true, result);
        }

        #endregion
    }
}
