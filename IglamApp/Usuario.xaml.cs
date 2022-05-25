using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace IglamApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Usuario : ContentPage
    {
        
        private const string Url = "http://192.168.0.4/moviles/postUsr.php";
        private readonly HttpClient client = new HttpClient();
        private ObservableCollection<IglamApp.Modelos.Usuario> _post;
        public Usuario()
        {
            InitializeComponent();
            listaUSR();
        }

        private async void listaUSR()
        {
            var content = await client.GetStringAsync(Url);
            List<IglamApp.Modelos.Usuario> posts = JsonConvert.DeserializeObject<List<IglamApp.Modelos.Usuario>>(content);
            _post = new ObservableCollection<IglamApp.Modelos.Usuario>(posts);
            MyListView.ItemsSource = _post;
        }

    }
}