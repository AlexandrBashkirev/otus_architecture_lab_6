
namespace otus_architecture_lab_6
{
    class Program
    {
        static void Main(string[] args)
        {
            CmdParser cmds = new CmdParser().Init(args);

            string inPath = cmds.GetValue("-ip");
            string outPath = cmds.GetValue("-op");
            string method = cmds.GetValue("-m");

            IMatrixWorker matrixWorker = new MatrixWorkerBuilder().Construct(method);

            matrixWorker.Init(inPath);
            matrixWorker.Compute();
            matrixWorker.WriteAnswer(outPath);
        }
    }
}
