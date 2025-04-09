using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.UseCases.RegistroUsuario;
using FluentValidation;

namespace Application.UseCases.RegistroUsuario
{
    public class UsuarioValidator : AbstractValidator<UsuarioRequest>
    {


        public UsuarioValidator() {
            RuleFor(x => x.Name)
                 .NotEmpty().WithMessage("El nombre es obligatorio")
                 .MinimumLength(2).WithMessage("El nombre debe tener al menos 2 caracteres");
            RuleFor(x => x.Email)
                 .NotEmpty().WithMessage("El correo es obligatorio")
                 .EmailAddress().WithMessage("el correo debe ser una direccion de correo valida")
                 .MinimumLength(2).WithMessage("El correo debe tener al menos 2 caracteres");
            RuleFor(x => x.Password)
               .NotEmpty().WithMessage("La contraseña es obligatorio")
               .MinimumLength(2).WithMessage("La contraseña debe tener al menos 2 caracteres");


        }


    }
}
