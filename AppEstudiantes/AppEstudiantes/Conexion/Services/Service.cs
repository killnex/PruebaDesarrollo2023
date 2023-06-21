using AppEstudiantes.Conexion.Models;
using AppEstudiantes.Conexion.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppEstudiantes.Conexion
{
    public class Service : ServicioBase
    {
        public async Task<List<DemoApi>> GetLista()
        {
            return await HttpGet<List<DemoApi>>("/api/listadoEstudiantes");
        }


        public async Task<DemoApi> GetId(int id)
        {
            return await HttpGet<DemoApi>($"/api/listadoEstudiantes/{id}");
        }

        public async Task<DemoApi> Update(int id, DemoApi request)
        {

            return await HttpPut<DemoApi>($"/api/listadoEstudiantes/{id}", request);
        }

        public async Task<DemoApi> New(DemoApi request)
        {

            return await HttpPost<DemoApi>($"/api/listadoEstudiantes/", request);
        }


    }

}
