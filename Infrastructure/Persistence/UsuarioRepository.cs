using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;

namespace Infrastructure.Persistence
{
    public class UsuarioRepository : IUsuarioRepository
    {

        private readonly IRepository<Users> repository;

        public UsuarioRepository(IRepository<Users> repository)
        {
            this.repository = repository;
        }

        public async Task Create(Users objeto)
        {
            await repository.Insert(objeto);
        }  
    }
}
