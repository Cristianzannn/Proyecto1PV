using System;
using System.Collections.Generic;

namespace Proyecto1PrograV.Models;

public partial class ParametrosSensibilidad
{
    public string NombreParametro { get; set; } = null!;

    public string Rango { get; set; } = null!;

    public virtual ICollection<Servidor> Servidors { get; } = new List<Servidor>();
}
