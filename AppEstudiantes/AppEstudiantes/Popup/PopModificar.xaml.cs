using AppEstudiantes.Conexion;
using AppEstudiantes.Conexion.Models;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppEstudiantes.Popup
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PopModificar
    {
        DemoApi Result;
        int getid;
        public PopModificar( int id)
        {
            
            InitializeComponent();
            getid = id;
            llenarpicker();
            llenarregistros();
        }

        public async void llenarregistros()
        {
            Service service = new Service();
            Result = await service.GetId(getid);

            entryname.Text = Result.Nombre;
            entryedad.Text = Result.Edad.ToString();
            pickersexo.SelectedItem = Result.Sexo;
            pickerescolaridad.SelectedItem = Result.Escolaridad;
        }

        private  void llenarpicker()
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

            Result.Nombre = entryname.Text;
            Result.Edad = int.Parse(entryedad.Text);
            Result.Sexo = pickersexo.SelectedItem.ToString();
            Result.Escolaridad = pickerescolaridad.SelectedItem.ToString();


            Service service = new Service();
            Result = await service.Update(getid, Result);
            Success();
            await PopupNavigation.Instance.PopAllAsync();

        }

        public event EventHandler OnSuccess;
        private void Success()
        {
            EventHandler handler =  OnSuccess;
            if (handler != null)
            {
                handler(this,null);
            }
        }
    }
}