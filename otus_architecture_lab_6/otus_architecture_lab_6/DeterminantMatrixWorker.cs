using System.IO;


namespace otus_architecture_lab_6
{
    class DeterminantMatrixWorker : IMatrixWorker
    {
        #region Variables

        private Matrix matrix = null;
        private float result = 0.0f;

        #endregion



        #region Methods

        public void Init(string path)
        {
            IMatrixReader matrixReader = new MatrixReaderTextFile(path);
            matrix = matrixReader.Read();
        }


        public void Compute()
        {
            ICommand cmd = new MatrixDeterminantCmd(matrix);
            cmd.SetResultCallback((sucess, result) =>
            {
                this.result = (float)result;
            });
            cmd.Run();
        }


        public void WriteAnswer(string resultPath)
        {
            using (StreamWriter file = new StreamWriter(resultPath))
            {
                file.WriteLine(result.ToString("f2"));
            }
        }

        #endregion
    }
}
