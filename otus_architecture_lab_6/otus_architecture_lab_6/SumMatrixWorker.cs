﻿using System;


namespace otus_architecture_lab_6
{
    class SumMatrixWorker : IMatrixWorker
    {
        #region Variables

        private Matrix matrixA = null;
        private Matrix matrixB = null;
        private Matrix result = null;

        #endregion



        #region Methods

        public void Init(string param)
        {
            string[] paths = param.Split(',');

            if(paths.Length != 2)
            {
                throw new Exception("Wrong path to matrix");
            }

            matrixA = new MatrixReaderTextFile(paths[0]).Read();
            matrixB = new MatrixReaderTextFile(paths[1]).Read();
        }


        public void Compute()
        {
            ICommand cmd = new MatrixSumCmd(matrixA, matrixB);
            cmd.SetResultCallback((sucess, result) =>
            {
                this.result = (Matrix)result;
            });
            cmd.Run();
        }


        public void WriteAnswer(string resultPath)
        {
            IMatrixWriter matrixWriter = new MatrixWriterTextFile(resultPath);
            matrixWriter.Write(result);
        }

        #endregion
    }
}
