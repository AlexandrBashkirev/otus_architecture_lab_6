# otus_architecture_lab_6

IMatrixWorker предоставляет три шаблонных метода ( Init, Compute, WriteAnswer ). 
Эти методы реализуются классами SumMatrixWorker, TranspondMatrixWorker, DeterminantMatrixWorker.
Реализации создаються билдером MatrixWorkerBuilder, таким образом клиент в лице Program не знает с какой реализацией он работает.

![alt text](https://github.com/AlexandrBashkirev/otus_architecture_lab_6/blob/master/class_diagram.png?raw=true)
