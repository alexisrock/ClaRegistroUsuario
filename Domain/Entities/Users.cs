namespace Domain.Entities
{
    public class Users
    {
        public Users(string nombre, string email, string password, string celular, DateTime fecha_registro, bool estado)
        {
            Nombre = nombre;
            Email = email;
            Password = password;
            Celular = celular;
            Fecha_registro = fecha_registro;
            Estado = estado;
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Celular { get; set; }
        public DateTime Fecha_registro { get; set; }
        public bool Estado { get; set; }







        
    }
}
