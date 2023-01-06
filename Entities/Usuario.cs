namespace Entities
{
    public class Usuario
    {
        public long Id { set; get; }
        public string Username { set; get; }
        public string Nombres { set; get; }
        public string Apellidos { set; get; }
        public string Genero { set; get; }
        public string Telefono { set; get; }
        public int Edad { set; get; }
        public string Email { set; get; }
        public string Password { set; get; }

        public Usuario() { }

    }
}
