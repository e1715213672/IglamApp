using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using IglamApp.Droid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

[assembly: Xamarin.Forms.Dependency(typeof(MensajeAndroid))]

namespace IglamApp.Droid
{
    internal class MensajeAndroid : Mensaje
    {
        public void LongAlert(string mensaje)
        {
            //Mostranto un mensaje de 5 segundos
            Toast.MakeText(Application.Context, mensaje, ToastLength.Long).Show();
        }
    }
}