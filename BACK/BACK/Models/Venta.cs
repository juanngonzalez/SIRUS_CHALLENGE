namespace BACK.Models
{
    public class Venta
    {
        public int? Id { get; set; }
        public Vendedor Vendedor { get; set; }
        public List<Articulo> Articulos { get; set; }
    }
}
