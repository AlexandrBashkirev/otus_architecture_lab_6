using System;


namespace otus_architecture_lab_6
{
    public interface ICommand
    {
        void SetResultCallback(Action<bool, object> callback);
        void Run();
    }
}
