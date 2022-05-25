using Plugin.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static System.Net.Mime.MediaTypeNames;
using Image = Xamarin.Forms.Image;

namespace IglamApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Instalacion : ContentPage
    {
        public Instalacion()
        {
            InitializeComponent();
        }

        private void btnRegistrar_Clicked(object sender, EventArgs e)
        {
            try
            {
                WebClient cliente = new WebClient();
                var parametros = new System.Collections.Specialized.NameValueCollection();
                parametros.Add("idInstalacion", txtidInstalacion.Text);
                parametros.Add("idCliente", txtIdCliente.Text);
                parametros.Add("idDispositivo", txtIdDispositivo.Text);
                parametros.Add("idUsuario", "1");
                parametros.Add("lugarInstalacion", txtlugarInstalacion.Text);
                parametros.Add("fechaInstalacion", txtfechaInstalacion.Text);
                parametros.Add("latitudInstalacion", "1234");
                parametros.Add("longitudInstalacion", "1234");
                parametros.Add("fotografiaInstalacion", "0");
                parametros.Add("observacionesInstalacion", txtObservaciones.Text);
                cliente.UploadValues("http://192.168.0.4/moviles/postInst.php", "POST", parametros);
                Navigation.PushAsync(new Principal());
                var msj = "Servicio registrado correctamente";
                DependencyService.Get<Mensaje>().LongAlert(msj);

            }
            catch (Exception)
            {
                var msj = "Error al registrar el servicio";
                DependencyService.Get<Mensaje>().LongAlert(msj);
            }
        }

        private async void btnCapturar_Clicked(object sender, EventArgs e)
        {
            var result = await MediaPicker.PickPhotoAsync(new MediaPickerOptions
            {
                Title = "Selecciona la foto"
            });
        }
    }
}