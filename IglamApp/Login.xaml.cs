using IglamApp.Modelos;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace IglamApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
    {
        public Login()
        {
            InitializeComponent();
        }

        private async void Ingresar_Clicked(object sender, EventArgs e)
        {
            LoginApp log = new LoginApp
            {
            ciUsuario = txtUsuario.Text,
            pwdUsuario = txtContrasena.Text
            };

            Uri RequestUri =new Uri("http://192.168.0.4/moviles/postUsr.php");
            var client  = new HttpClient();
            var json = JsonConvert.SerializeObject(log);
            var contentJson = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PostAsync(RequestUri, contentJson);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var msj = "Bienvenido";
                DependencyService.Get<Mensaje>().LongAlert(msj);
                await Navigation.PushAsync(new Principal());
            }
            else
            {
                var msj = "Datos incorrectos";
                DependencyService.Get<Mensaje>().LongAlert(msj);
                txtUsuario.Text = "";
                txtContrasena.Text = "";
            }

        }
    }
}