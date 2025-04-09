using System;
using System.Collections.Generic;
using Domain.Enums;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Application.Common;
using Domain.Entities;
using Domain.Exceptions;
using Domain.Interfaces;
using FluentValidation;
using MediatR;

namespace Application.UseCases.RegistroUsuario
{
    public class RegistroUsuarioComandHandler : IRequestHandler<UsuarioRequest, BaseResponse>
    {
        private readonly IValidator<UsuarioRequest> validator;
        private readonly IUsuarioRepository repository;
        private readonly ISetupRepository configurationRepository;



        public RegistroUsuarioComandHandler(IValidator<UsuarioRequest> validator, IUsuarioRepository productoRepository, ISetupRepository configurationRepository)
        {
            this.validator = validator;
            this.repository = productoRepository;
            this.configurationRepository = configurationRepository;
        }

        public async Task<BaseResponse> Handle(UsuarioRequest request, CancellationToken cancellationToken)
        {
            
            try
            {
                var result = await validator.ValidateAsync(request);
                if (!result.IsValid)
                {
                    throw new ApiException(result.Errors.ToString(), (int)System.Net.HttpStatusCode.BadRequest);
                }

                var password =  await EncryptedPassword(DecodeBase64Password(request.Password));
                var producto = new Users(request.Name, request.Email, password,request.CelPhoneNumber, DateTime.Now, true);
                await repository.Create(producto);
                return new BaseResponse()
                {
                    message = "Producto registrado con exito"
                };
            }
            catch (Exception ex) when (ex is ApiException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new ApiException("Ocurrió un error inesperado", (int)System.Net.HttpStatusCode.InternalServerError);
            }
        }

        private static string DecodeBase64Password(string password)
        {
            var base64EncodedBytes = System.Convert.FromBase64String(password);
            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        }

        private async Task<string> EncryptedPassword(string password)
        {
            var keyEncrypted = (await configurationRepository.GetByParam(x => x.Id.Equals(ParamConfig.KeyEncrypted.ToString())))?.Value ?? string.Empty;
            var iVEncrypted = (await configurationRepository.GetByParam(x => x.Id.Equals(ParamConfig.IVEncrypted.ToString())))?.Value ?? string.Empty;


            byte[] key = Encoding.UTF8.GetBytes(keyEncrypted);
            byte[] iv = Encoding.UTF8.GetBytes(iVEncrypted);

            using (TripleDES aes = TripleDES.Create())
            {


                ICryptoTransform encryptor = aes.CreateEncryptor(key, iv);

                byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
                byte[] encryptedPasswordBytes = encryptor.TransformFinalBlock(passwordBytes, 0, passwordBytes.Length);

                string encryptedPassword = Convert.ToBase64String(encryptedPasswordBytes);
                return encryptedPassword;
            }
        }
    }
}
