using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Entidades
{
    public class Marca
    {
        public int ID { get; set; }
        public string nombre { get; set; }
        public string pais { get; set; }
        public List<Celular> celular { get; set; }
    }
}
