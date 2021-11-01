//cSpell:disable

using System;


namespace GarbageReport.Domain.DTOS
{
    public record DenunciaResponse(DateTime Fecha, string Motivo, string Descripcion, string Ubicacion, string Colonia);
}