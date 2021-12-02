//cSpell:disable

using System;


namespace GarbageReport.Domain.DTOS
{
    public record DenunciaResponse(string Fecha, string Motivo, string Descripcion, string Ubicacion, string Colonia);
}