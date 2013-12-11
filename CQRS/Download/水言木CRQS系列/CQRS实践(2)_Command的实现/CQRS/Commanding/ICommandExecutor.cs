using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CQRS.Commanding
{
    public interface ICommandExecutor<TCommand>
        where TCommand : ICommand
    {
        void Execute(TCommand cmd);
    }
}
