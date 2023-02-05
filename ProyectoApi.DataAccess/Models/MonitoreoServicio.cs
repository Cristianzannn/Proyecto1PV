﻿using System;
using System.Collections.Generic;

namespace ProyectoApi.DataAccess.Models;

public partial class MonitoreoServicio
{
    public bool? Estado { get; set; }

    public int CodigoServicios { get; set; }

    public virtual Servicio CodigoServiciosNavigation { get; set; } = null!;
}
