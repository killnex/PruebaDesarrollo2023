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
    public partial class PopDetalle
    {
        DemoApi Result;
        int getid;
        public PopDetalle(int id)
        {
            InitializeComponent();
            getid = id;
            llenarregistros();
        }

        public async void llenarregistros()
        {
            Service service = new Service();
            Result = await service.GetId(getid);

            txtnombre.Text = Result.Nombre;
            txtedada.Text = Result.Edad.ToString();
            txtsexo.Text = Result.Sexo;
            txtescolaridad.Text = Result.Escolaridad;
        }


        private async void Button_Clicked(object sender, EventArgs e)
        {
            await PopupNavigation.Instance.PopAllAsync();
        }
    }
}