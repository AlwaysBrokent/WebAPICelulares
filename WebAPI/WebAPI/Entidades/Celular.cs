namespace WebAPI.Entidades
{
    public class Celular
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int MarcaID { get; set; }
        public Marca marca { get; set; }
    }
}
