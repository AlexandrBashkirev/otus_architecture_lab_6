
namespace otus_architecture_lab_6
{
    class TranspondMatrixWorker : MatrixWorker
    {
        #region Variables

        private Matrix matrix = null;
        private Matrix result = null;

        #endregion



        #region Methods

        public override void Init(string path)
        {
            IMatrixReader matrixReader = new MatrixReaderTextFile(path);
            matrix = matrixReader.Read();
        }


        public override void Compute()
        {
            ICommand cmd = new TranspondMatrixCmd(matrix);
            cmd.SetResultCallback((sucess, result) =>
            {
                this.result = (Matrix)result;
            });
            cmd.Run();
        }


        public override void WriteAnswer(string resultPath)
        {
            IMatrixWriter matrixWriter = new MatrixWriterTextFile(resultPath);
            matrixWriter.Write(result);
        }

        #endregion
    }
}
