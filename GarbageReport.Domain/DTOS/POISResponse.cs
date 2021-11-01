//cSpell:disable

using System;


namespace GarbageReport.Domain.DTOS
{
    public record POISResponse(string nombre, string PoiDescripcion, string ubicacion, string caracteristica);
}

