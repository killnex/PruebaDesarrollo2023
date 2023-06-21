using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Net;
using System.Net.Http;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using Rg.Plugins.Popup.Services;
using AppEstudiantes.Popup;
using AppEstudiantes.Conexion.Models;
using AppEstudiantes.Conexion;

namespace AppEstudiantes
{
    public partial class MainPage : ContentPage
    {
        List<DemoApi> Result;
        public MainPage()
        {
            InitializeComponent();

            llenadoDatos();

        }


        public async void llenadoDatos()
        {

                Service service = new Service();
                Result= await service.GetLista();
                collection.ItemsSource = Result;
            //HttpClientHandler insecureHandler = GetInsecureHandler();
            //HttpClient client = new HttpClient(insecureHandler);
            //client.BaseAddress = new Uri("https://192.168.1.18:45457");
            //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //HttpResponseMessage response = await client.GetAsync("/api/listadoEstudiantes");
            //Console.WriteLine(response);
            //if (response.StatusCode == HttpStatusCode.OK)
            //{
            //    string content = await response.Content.ReadAsStringAsync();
            //    var resultado = JsonConvert.DeserializeObject<List<DemoApi>>(content);
            //    collection.ItemsSource = resultado;
            //    Result = resultado;
            //}


        }





        private async void Detalle_Clicked(object sender, EventArgs e)
        {
            var boton = sender as Button;
            var Iddetalle = (int)boton.CommandParameter;
            await PopupNavigation.Instance.PushAsync(new PopDetalle(Iddetalle));
        }

        private async void Modificar_Clicked_1(object sender, EventArgs e)
        {
            var boton = sender as Button;
            int Idmodificar = (int)boton.CommandParameter;
            PopModificar popmodificar = new PopModificar(Idmodificar);
            popmodificar.OnSuccess += Popmodificar_OnSuccess;
            await PopupNavigation.Instance.PushAsync(popmodificar);
        }

        private void Popmodificar_OnSuccess(object sender, EventArgs e)
        {
            llenadoDatos();
        }

        private async void guardar_Clicked(object sender, EventArgs e)
        {
            PopNuevo popnuevo = new PopNuevo();
            popnuevo.OnSuccess += Popmodificar_OnSuccess;
            await PopupNavigation.Instance.PushAsync(popnuevo);
        }
    }
}
