
namespace otus_architecture_lab_6
{
    interface IMatrixWorker
    {
        void Init(string param);
        void Compute();
        void WriteAnswer(string resultPath);
    }
}
