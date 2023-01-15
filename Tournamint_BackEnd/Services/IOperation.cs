﻿namespace Tournamint_BackEnd.Services
{
    public interface IOperation
    {
        string GetOperationId();

    }

    public interface IOperationTransient : IOperation { }
    public interface IOperationScoped : IOperation { }
    public interface IOperationSingleton : IOperation { }

}