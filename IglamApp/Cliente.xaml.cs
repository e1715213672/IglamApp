using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace IglamApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Cliente : ContentPage
    {
        public Cliente()
        {
            InitializeComponent();
        }

        private void btnInsertar_Clicked(object sender, EventArgs e)
        {
            try
            {
                WebClient cliente = new WebClient();
                var parametros = new System.Collections.Specialized.NameValueCollection();
                parametros.Add("idCliente", txtId.Text);
                parametros.Add("rucCliente", rucCliente.Text);
                parametros.Add("nombreCliente", nombreCliente.Text);
                parametros.Add("direccionCliente", direccionCliente.Text);
                parametros.Add("telefonoCliente", telefonoCliente.Text);
                parametros.Add("emailCliente", emailCliente.Text);
                cliente.UploadValues("http://192.168.0.4/moviles/postCli.php", "POST", parametros);
                Navigation.PushAsync(new Principal());
                var msj = "Cliente registrado correctamente";
                DependencyService.Get<Mensaje>().LongAlert(msj);


            }
            catch (Exception ex)
            {
                var msj = "Error al registrar el ciente";
                DependencyService.Get<Mensaje>().LongAlert(msj);
            }
        }
    }
}