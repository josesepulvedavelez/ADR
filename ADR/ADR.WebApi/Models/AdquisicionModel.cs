using System.ComponentModel.DataAnnotations;

namespace ADR.WebApi.Models
{
    public class AdquisicionModel
    {
        public decimal Presupuesto { get; }
        public string Unidad { get; set; }
        public string TipoBien { get; set; }
        public int Cantidad { get; set; }
        public decimal ValorUnitario { get; set; }
        public decimal ValorTotal { get; set; }
        public DateTime FechaAdquisicion { get; set; }                        
        public string Proveedor { get; set; }
        public string Documentacion { get; set; }
        public bool Estado { get; set; }

        [Key]
        public int AdquisicionId { get; set; }
    }
}
