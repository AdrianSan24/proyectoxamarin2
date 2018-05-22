using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using MySql.Data;

namespace App3000
{
    public partial class MainPage : ContentPage
    {
        //Conexiones conectado = new Conexiones();
        RecogidaDatos fr;
        string codigo="";
        List<string> codes;
        public MainPage()
        {
            InitializeComponent();
            codes = new List<string>();
            codes.Add("A");
            codes.Add("B");
            codes.Add("C");
            codes.Add("D");
            codes.Add("E");
            picker.ItemsSource = codes;
             picker.SelectedIndex=0;
            txtcodigo.Text = picker.SelectedItem.ToString();
        }
        private void Click(object sender, EventArgs e)
        {
            string mensaje = txtnombre.Text;
            string pass = txtpass.Text;
            if (string.IsNullOrEmpty(mensaje) || string.IsNullOrEmpty(pass))
            {
                DisplayAlert("Alerta", "campos vacios", "Aceptar");
            }
            else
            {
                //conectado.conectar();
                //if (conectado.acceso(txtnombre.Text, txtpass.Text))
                if(txtnombre.Text!="" && txtpass.Text!="")
                {
                    DisplayAlert("Alerta", "campos rellenos", "Aceptar");
                    comprobar_BaseDatos();
                }
            }
        }
        private void cambio(object sender, EventArgs e)
        {
            txtcodigo.Text = picker.SelectedItem.ToString();
        }
            private void comprobar_BaseDatos()
        {
            
            //if (conectado.acceso(txtnombre.Text, txtpass.Text))
            //{
              fr = new RecogidaDatos(codigo, txtnombre.Text);
                Navigation.PushModalAsync(fr);
            //}
        }
    }
}
