using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace IglamApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Dispositivo : ContentPage
    {
        public Dispositivo()
        {
            InitializeComponent();
        }

        private void btnRegistrar_Clicked(object sender, EventArgs e)
        {
            try
            {
                WebClient cliente = new WebClient();
                var parametros = new System.Collections.Specialized.NameValueCollection();
                parametros.Add("idDispositivo", txtIdDispositivo.Text);
                parametros.Add("marcaDispositivo", txtMarcaDispositivo.Text);
                parametros.Add("modeloDispositivo", txtModeloDispositivo.Text);
                parametros.Add("serieDispositivo", txtSerieDispositivo.Text);
                parametros.Add("observacionDispositivo", txtObservacionDispositivo.Text);
                cliente.UploadValues("http://192.168.0.4/moviles/postDisp.php", "POST", parametros);
                Navigation.PushAsync(new Principal());
                var msj = "Dispositivo registrado correctamente";
                DependencyService.Get<Mensaje>().LongAlert(msj);


            }
            catch (Exception ex)
            {
                var msj = "Error al registrar el dispositivo";
                DependencyService.Get<Mensaje>().LongAlert(msj);
            }
        }
    }
}