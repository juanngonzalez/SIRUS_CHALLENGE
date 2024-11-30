using BACK.Interfaces;
using BACK.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Xml;

namespace BACK.Services
{
    public class VentasService : IVentasService
    {
        private readonly string _filePath;

        public VentasService()
        {
            _filePath = Path.Combine(Directory.GetCurrentDirectory(), "data", "ventas.json");

            // Si no existe el archivo, inicializa con una lista vacía.
            if (!File.Exists(_filePath))
            {
                File.WriteAllText(_filePath, JsonConvert.SerializeObject(new List<Venta>()));
            }
        }

        public async Task<ActionResult<Venta>> PostVenta(Venta nuevaVenta)
        {
            try
            {
                // Leer las ventas existentes.
                var ventas = JsonConvert.DeserializeObject<List<Venta>>(await File.ReadAllTextAsync(_filePath)) ?? new List<Venta>();

                // Asignar un nuevo Id.
                nuevaVenta.Id = ventas.Count > 0 ? ventas[^1].Id + 1 : 1;

                // Agregar la nueva venta.
                ventas.Add(nuevaVenta);

                // Guardar las ventas actualizadas.
                await File.WriteAllTextAsync(_filePath, JsonConvert.SerializeObject(ventas, Newtonsoft.Json.Formatting.Indented));

                return nuevaVenta;
            }
            catch
            {
                return new BadRequestResult();
            }
        }
    }
}

