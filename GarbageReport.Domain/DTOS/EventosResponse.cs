//cSpell:disable

using System;


namespace GarbageReport.Domain.DTOS
{
    public record EventoResponse(string Nombre, string Descripcion, string Fecha, string Ubicacion, string personalRequerido);
}