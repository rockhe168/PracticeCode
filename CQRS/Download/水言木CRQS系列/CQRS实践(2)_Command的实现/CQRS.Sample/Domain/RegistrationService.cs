using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics.Contracts;

using CQRS.Data;

namespace CQRS.Sample.Domain
{
    public class RegistrationService
    {
        private IRepository<User> _repository;

        public RegistrationService(IRepository<User> repository)
        {
            _repository = repository;
        }

        public void Register(string email, string nickName, string password)
        {
            if (_repository.Query().Any(it => it.Email == email))
                throw new InvalidOperationException("Emails is used by other user. Please choose a new email.");

            _repository.Add(new User
            {
                Email = email,
                NickName = nickName,
                Password = password
            });
        }
    }
}
