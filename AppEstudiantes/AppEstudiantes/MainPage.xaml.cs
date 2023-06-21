using AppEstudiantes.Conexion;
using AppEstudiantes.Conexion.Models;
using AppEstudiantes.Popup;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

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
            Result = await service.GetLista();
            collection.ItemsSource = Result;
            sindatos.IsVisible = !Result.Any();
            
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
