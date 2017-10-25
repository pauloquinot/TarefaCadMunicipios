using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CadMunicipios.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class BuscaMunicipio : ContentPage
	{
		public BuscaMunicipio ()
		{
			InitializeComponent ();
		}
        public async void ListarMunicipios(object o, EventArgs e)
        {
            await Navigation.PushModalAsync(new ListaMunicipios(""));
        }


        public async void BuscarMunicipios(object o, EventArgs e)
        {
            await Navigation.PushModalAsync(new ListaMunicipios(edtBusca.Text));
        }
    }
}