using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using otus_architecture_lab_6;

namespace otus_architecture_lab_6_tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TranspondMatrixCmdTest()
        {
            Matrix matrix = FetchMatrixA();

            ICommand cmd = new TranspondMatrixCmd(matrix);
            cmd.SetResultCallback((sucess, _result) =>
            {
                Assert.IsTrue(sucess);

                Matrix result = (Matrix)_result;
                for (int i = 0; i < matrix.Rows; i++)
                {
                    for (int j = 0; j < matrix.Columns; j++)
                    {
                        Assert.AreEqual(matrix[i, j], result[j, i], 0.001, "Values computed wrong");
                    }
                }
            });
            cmd.Run();
        }


        [TestMethod]
        public void MatrixDeterminantCmdTest()
        {
            Matrix matrix = new Matrix(3, 3);

            matrix[0, 0] = 1;
            matrix[0, 1] = -2;
            matrix[0, 2] = 3;

            matrix[1, 0] = 4;
            matrix[1, 1] = 0;
            matrix[1, 2] = 6;

            matrix[2, 0] = -7;
            matrix[2, 1] = 8;
            matrix[2, 2] = 9;

            ICommand cmd = new MatrixDeterminantCmd(matrix);
            cmd.SetResultCallback((sucess, result) =>
            {
                Assert.AreEqual((float)result, 204.0f, 0.001f, "Values computed wrong");
            });
            cmd.Run();
        }


        [TestMethod]
        public void MatrixSumCmdTest()
        {
            Matrix matrixA = FetchMatrixA();
            Matrix matrixB = FetchMatrixB();

            Matrix matrixExpected = FetchMatrixAMulB();

            ICommand mulCmd = new MatrixSumCmd(matrixA, matrixB);
            mulCmd.SetResultCallback((isSucced, result) =>
            {
                Matrix matrixActual = result as Matrix;

                Assert.AreEqual(matrixExpected.Rows, matrixActual.Rows);
                Assert.AreEqual(matrixExpected.Columns, matrixActual.Columns);

                for (int i = 0; i < matrixExpected.Rows; i++)
                {
                    for (int j = 0; j < matrixExpected.Columns; j++)
                    {
                        Assert.AreEqual(matrixExpected[i, j], matrixActual[i, j], 0.001, "Values computed wrong");
                    }
                }

            });

            mulCmd.Run();

        }


        private Matrix FetchMatrixA()
        {
            Matrix matrix = new Matrix(3, 3);

            matrix[0, 0] = 1;
            matrix[0, 1] = 2;
            matrix[0, 2] = 3;

            matrix[1, 0] = 4;
            matrix[1, 1] = 5;
            matrix[1, 2] = 6;

            matrix[2, 0] = 7;
            matrix[2, 1] = 8;
            matrix[2, 2] = 9;

            return matrix;
        }


        private Matrix FetchMatrixB()
        {
            Matrix matrix = new Matrix(3, 3);

            matrix[0, 0] = 9;
            matrix[0, 1] = 8;
            matrix[0, 2] = 7;

            matrix[1, 0] = 6;
            matrix[1, 1] = 5;
            matrix[1, 2] = 4;

            matrix[2, 0] = 3;
            matrix[2, 1] = 2;
            matrix[2, 2] = 1;

            return matrix;
        }


        private Matrix FetchMatrixAMulB()
        {
            Matrix A = FetchMatrixA();
            Matrix B = FetchMatrixB();

            Matrix matrix = new Matrix(3, 3);

            matrix[0, 0] = A[0, 0] + B[0, 0];
            matrix[0, 1] = A[0, 1] + B[0, 1];
            matrix[0, 2] = A[0, 2] + B[0, 2];

            matrix[1, 0] = A[1, 0] + B[1, 0];
            matrix[1, 1] = A[1, 1] + B[1, 1];
            matrix[1, 2] = A[1, 2] + B[1, 2];

            matrix[2, 0] = A[2, 0] + B[2, 0];
            matrix[2, 1] = A[2, 1] + B[2, 1];
            matrix[2, 2] = A[2, 2] + B[2, 2];

            return matrix;
        }
    }
}
