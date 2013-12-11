using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CQRS.Data;
using Autofac;

namespace CQRS.Commanding
{
    public class DefaultCommandBus : ICommandBus
    {
        public void Send<TCommand>(TCommand cmd) where TCommand : ICommand
        {
            try
            {
                var unitOfWork = UnitOfWorkContext.StartUnitOfWork();

                var executor = ObjectContainer.Resolve<ICommandExecutor<TCommand>>();
                executor.Execute(cmd);

                UnitOfWorkContext.Commit();
            }
            finally
            {
                UnitOfWorkContext.Close();
            }
        }
    }
}
