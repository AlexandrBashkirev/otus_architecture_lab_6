using System;


namespace otus_architecture_lab_6
{
    public class MatrixDeterminantCmd : CommandBase
    {
        #region Variables

        Matrix matrix = null;

        #endregion



        #region Class lifecycle

        public MatrixDeterminantCmd(Matrix matrix)
        {
            this.matrix = matrix;
        }

        #endregion



        #region Methods

        public override void Run()
        {
            if (matrix.Rows != matrix.Columns)
            {
                callback?.Invoke(false, 0.0f);
                return;
            }

            float result = SumDiogonals() - SumPseudoDiogonals();

            callback?.Invoke(true, result);
        }


        private float SumDiogonals()
        {
            float result = 0.0f;

            for (int i = 0; i < matrix.Rows; i++)
            {
                float tmp = 1.0f;
                for (int j = 0; j < matrix.Rows; j++)
                {
                    int actualI = i + j < matrix.Rows ? i + j : i + j - matrix.Rows;
                    tmp *= matrix[actualI, j];
                }
                result += tmp;
            }

            return result;
        }


        private float SumPseudoDiogonals()
        {
            float result = 0.0f;

            for (int i = 0; i < matrix.Rows; i++)
            {
                float tmp = 1.0f;
                for (int j = 0; j < matrix.Rows; j++)
                {
                    int actualI = i - j >= 0 ? i - j : i - j + matrix.Rows;
                    tmp *= matrix[actualI, j];
                }
                result += tmp;
            }

            return result;
        }

        #endregion
    }
}
