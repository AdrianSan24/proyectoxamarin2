using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App3000
{

	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class RecogidaDatos : ContentPage
	{
       
        StreamWriter s;
        public Timer tmr = new Timer();
        string codigo,user;
        public Timer tiempoCodigo = new Timer();
        int seg, min = 0, bandejaM = 0;
        int segT, minT = 0, horaT = 0;

        public RecogidaDatos(string codigo,string user)
        {
#if _ANDROID_
            s = new StreamWriter("sdcard/download/tiemposcodigo" + codigo + ".txt");
#else
            //s = new StreamWriter("..\\..\\tiemposcodigo" + codigo + ".txt");
            this.codigo = codigo;
            tmr.Interval = 1000;
            tmr.Elapsed += new System.Timers.ElapsedEventHandler(clicktimer);
            tiempoCodigo.Interval = 1000;
            tiempoCodigo.Elapsed += new System.Timers.ElapsedEventHandler(clicktimer2);
            tiempoCodigo.Start();
            user = user;
            InitializeComponent();


        }
        private void Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (btn.Text == "Inicio Parada")
            {
                tmr.Start();

                txttiempo2.Placeholder = DateTime.UtcNow.Hour + ":" + DateTime.UtcNow.Minute + ":" + DateTime.UtcNow.Second;


            }
            if (btn.Text == "Fin Parada")
            {

                tmr.Stop();
                txttiempo3.Placeholder = DateTime.UtcNow.Hour + ":" + DateTime.UtcNow.Minute + ":" + DateTime.UtcNow.Second;
                txttiempo.Placeholder = min + ":";
                if (seg < 10)
                {
                    txttiempo.Placeholder += "0" + seg;
                }
                else
                {
                    txttiempo.Placeholder += seg;
                }

              
            }
            if (btn.Text == "Guardar")
            {
                s.WriteLine(txttiempo.Text +" user: "+user);
            }
            if (btn.Text == "Enviar")
            {
                tiempoCodigo.Stop();
                //s.WriteLine("tiempo total: "+ horaT+":"+minT+":"+segT);
                //s.Close();
               

            }
            }
        private void ClickBandeja(object sender, EventArgs e)
        {
            bandejaM += 1;
            lblBandeja.Text = "Nº unidades no conformes =" + bandejaM;
        }
        private void clicktimer(object sender, EventArgs e)
        {

            seg += 1;
            if (seg == 60)
            {
                min += 1;
                seg = 0;
            }

        }
        private void clicktimer2(object sender, EventArgs e)
        {

            segT += 1;
            if (seg == 60)
            {
                minT += 1;
                seg = 0;
            }
            if (minT == 60)
            {
                horaT += 1;
                minT = 0;
            }

        }
    }
#endif 
}