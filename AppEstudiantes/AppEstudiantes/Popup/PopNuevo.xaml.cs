using AppEstudiantes.Conexion;
using AppEstudiantes.Conexion.Models;
using Rg.Plugins.Popup.Services;
using System;
using Xamarin.Forms.Xaml;

namespace AppEstudiantes.Popup
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PopNuevo
    {
        DemoApi Result;
        public PopNuevo()
        {
            InitializeComponent();
            llenarpicker();
            llenarregistros();
        }

        public void llenarregistros()
        {

            Result = new DemoApi();

        }

        private void llenarpicker()
        {
            pickersexo.Items.Add("Femenino");
            pickersexo.Items.Add("Masculino");

            pickerescolaridad.Items.Add("Posgrado");
            pickerescolaridad.Items.Add("Universidad");
            pickerescolaridad.Items.Add("Preparatoria");
            pickerescolaridad.Items.Add("Secundaria");
            pickerescolaridad.Items.Add("Primaria");

        }

        private async void close_Clicked(object sender, EventArgs e)
        {
            await PopupNavigation.Instance.PopAllAsync();
        }

        private async void guardar_Clicked(object sender, EventArgs e)
        {
            if (entryname.Text == null && entryedad.Text == null && pickersexo.SelectedIndex == -1 && pickerescolaridad.SelectedIndex == -1)
            {
                sindatos.IsVisible = true;
            }
            else 
            {
                Result.Nombre = entryname.Text;
                Result.Edad = int.Parse(entryedad.Text);
                Result.Sexo = pickersexo.SelectedItem.ToString();
                Result.Escolaridad = pickerescolaridad.SelectedItem.ToString();


                Service service = new Service();
                Result = await service.New(Result);
                Success();
                await PopupNavigation.Instance.PopAllAsync();
            }



        }

        public event EventHandler OnSuccess;
        private void Success()
        {
            EventHandler handler = OnSuccess;
            if (handler != null)
            {
                handler(this, null);
            }
        }
    }
}