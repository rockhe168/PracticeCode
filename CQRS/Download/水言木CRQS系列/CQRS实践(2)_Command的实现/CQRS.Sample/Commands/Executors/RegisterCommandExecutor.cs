using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using CQRS.Data;
using CQRS.Commanding;
using CQRS.Sample.Domain;

namespace CQRS.Sample.Commands.Executors
{
    class RegisterCommandExecutor : ICommandExecutor<RegisterCommand>
    {
        public IRepository<User> _repository;

        public RegisterCommandExecutor(IRepository<User> repository)
        {
            _repository = repository;
        }

        public void Execute(RegisterCommand cmd)
        {
            if (String.IsNullOrEmpty(cmd.Email))
                throw new ArgumentException("Email is required.");

            if (cmd.Password != cmd.ConfirmPassword)
                throw new ArgumentException("Password not match.");

            // other command validation logics

            var service = new RegistrationService(_repository);
            service.Register(cmd.Email, cmd.NickName, cmd.Password);
        }
    }
}
