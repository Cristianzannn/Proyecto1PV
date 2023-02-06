using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProyectoApi.DataAccess.Models;

public partial class ParametrosSensibilidad
{
    [Required(AllowEmptyStrings = false, ErrorMessage = "El nombre es requerido")]
    public string NombreParametro { get; set; } = null!;

    [Required(AllowEmptyStrings = false, ErrorMessage = "El rango es requeridos")]
    public string Rango { get; set; } = null!;

    public virtual ICollection<Servidor> Servidors { get; } = new List<Servidor>();
}
