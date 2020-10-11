
namespace otus_architecture_lab_6
{
    abstract class MatrixWorker
    {
        public abstract void Init(string param);
        public abstract void Compute();
        public abstract void WriteAnswer(string resultPath);
    }
}
