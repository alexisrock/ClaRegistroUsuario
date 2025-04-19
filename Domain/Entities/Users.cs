namespace Domain.Entities
{
    public class Users
    {
        public Users(string nombre, string email, string password, string celular, DateTime fecharegistro, bool estado)
        {
            Nombre = nombre;
            Email = email;
            Password = password;
            Celular = celular;
            Fecharegistro = fecharegistro;
            Estado = estado;
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Celular { get; set; }
        public DateTime Fecharegistro { get; set; }
        public bool Estado { get; set; }







        
    }
}
