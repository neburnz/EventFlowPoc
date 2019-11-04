using System;
using System.ComponentModel.DataAnnotations;

namespace poc.eventflow.api
{
    public class ProcesoData
    {
        [Required]
        public DateTime FechaCorte { get; set; }
    }
}