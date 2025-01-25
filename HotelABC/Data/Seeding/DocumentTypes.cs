using HotelABC.Models.Parameters;
using Microsoft.CodeAnalysis.Elfie.Diagnostics;

namespace HotelABC.Data.Seeding;

public static class DocumentTypes
{
    public static readonly DocumentType[] AllDocumentTypes = 
    {
        new DocumentType {Id = Guid.NewGuid(), Name = "Cedula", Code = "CC"},
        new DocumentType {Id = Guid.NewGuid(), Name = "Cedula Extranjeria", Code = "CE"},
        new DocumentType {Id = Guid.NewGuid(), Name = "Tarjeta Identidad", Code = "TI"},
        new DocumentType {Id = Guid.NewGuid(), Name = "Registro Civil", Code = "RC"},
        new DocumentType {Id = Guid.NewGuid(), Name = "Pasaporte", Code = "PP"},
        new DocumentType {Id = Guid.NewGuid(), Name = "Numero de Identificacion Tributario", Code = "NIT"},
        new DocumentType {Id = Guid.NewGuid(), Name = "Licencia de Conduccion", Code = "LC"}
    };
}
