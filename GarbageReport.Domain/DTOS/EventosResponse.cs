//cSpell:disable

using System;


namespace GarbageReport.Domain.DTOS
{
    public record EventoResponse(string Nombre, string Descripcion, DateTime Fecha, string Ubicacion, int personalRequerido);
}