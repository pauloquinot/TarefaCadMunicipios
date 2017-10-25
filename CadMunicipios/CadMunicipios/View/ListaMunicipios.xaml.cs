using CadMunicipios.Dao;
using CadMunicipios.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CadMunicipios.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ListaMunicipios : ContentPage
	{
        public ListaMunicipios(String nome)
        {
            InitializeComponent();
            MunicipioDao dao = new MunicipioDao();
            IEnumerable<Municipio> listaMunicipios = dao.GetRegistros(nome);
            lstMunicipios.ItemsSource = listaMunicipios;
        }

        public async void IncluirMunicipio(object obj, EventArgs e)
        {
            await Navigation.PushModalAsync(new ManutencaoMunicipios());
        }

        public async void BuscarMunicipio(object obj, EventArgs e)
        {
            await Navigation.PushModalAsync(new BuscaMunicipio());
        }

        public async void AoSelecionar(object obj, ItemTappedEventArgs args)
        {
            var municipio = args.Item as Municipio;
            await Navigation.PushModalAsync(new ManutencaoMunicipios(municipio));
        }
    }
}