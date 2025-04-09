using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Common;
using MediatR;

namespace Application.UseCases.RegistroUsuario
{
    public class UsuarioRequest : IRequest<BaseResponse>    {

    
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string CelPhoneNumber { get; set; } = string.Empty;


    }
}
