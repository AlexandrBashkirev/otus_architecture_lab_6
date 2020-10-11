
namespace otus_architecture_lab_6
{
    public class TranspondMatrixCmd : CommandBase
    {
        #region Variables

        Matrix matrix = null;

        #endregion



        #region Class lifecycle

        public TranspondMatrixCmd(Matrix matrix)
        {
            this.matrix = matrix;
        }

        #endregion



        #region Methods

        public override void Run()
        {
            Matrix result = new Matrix(matrix.Columns, matrix.Rows);

            for (int i = 0; i < matrix.Rows; i++)
            {
                for(int j = 0; j < matrix.Columns; j++)
                {
                    result[j, i] = matrix[i, j];
                }
            }

            callback?.Invoke(true, result);
        }

        #endregion
    }
}
