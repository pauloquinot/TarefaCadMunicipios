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
	public partial class ManutencaoMunicipios : ContentPage
	{
        public List<UnidadeFed> ListaUF;
        private UnidadeFedDao daoUnidadeFed;
        private Municipio municipio;

        protected override void OnAppearing()
        {
            base.OnAppearing();
            if (municipio != null)
            {
                CarregaListaUF();
                lstUF.ItemsSource = ListaUF;
                lstUF.SelectedIndex = getIdx(municipio.SiglaUF); ;
            }
        }

        public ManutencaoMunicipios(Municipio municipio)
        {
            this.municipio = municipio;
            InitializeComponent();
            CarregaListaUF();
            lstUF.ItemsSource = ListaUF;

            edtCodigo.Text = this.municipio.Codigo.ToString();
            edtNome.Text = municipio.Nome;
          
            if (municipio.SiglaUF != null)
            {
                lstUF.SelectedIndex = getIdx(municipio.SiglaUF);
            }
        }

        public ManutencaoMunicipios()
        {
            InitializeComponent();
            this.municipio = new Municipio();
            CarregaListaUF();
            lstUF.ItemsSource = ListaUF;
        }

        public void CarregaListaUF()
        {
            daoUnidadeFed = new UnidadeFedDao();
            ListaUF = daoUnidadeFed.GetRegistrosList("");

        }

        public void IncluirMunicipio(object o, EventArgs e)
        {
            Municipio municipio = new Municipio();
            try
            {
                municipio.Codigo = int.Parse(edtCodigo.Text);
            }
            catch (Exception ex)
            {
                municipio.Codigo = 0;
            }
            municipio.Nome = edtNome.Text;

            UnidadeFed unidadeFed = lstUF.SelectedItem as UnidadeFed;

            municipio.SiglaUF = unidadeFed.SiglaUF;

            MunicipioDao dao = new MunicipioDao();
            dao.InsereAtualiza(municipio);
            Navigation.PushModalAsync(new ListaMunicipios(""));
        }

        public void ExcluirMunicipio(object o, EventArgs e)
        {
            MunicipioDao dao = new MunicipioDao();
            dao.Deleta(int.Parse(edtCodigo.Text));
            Navigation.PushModalAsync(new ListaMunicipios(""));
        }


        public async void ListarMunicipios(object o, EventArgs e)
        {
            await Navigation.PushModalAsync(new ListaMunicipios(""));
        }

        public void CadastrarUF(object o, EventArgs e)
        {
            Navigation.PushModalAsync(new CadastroUF());
            CarregaListaUF();
        }

        public int getIdx(string o)
        {
            int index = -1;
            foreach (var item in ListaUF)
            {
                index += 1;
                if (item.SiglaUF == o)
                {
                    return index;
                    break;
                }
            }

            return -1;
        }
    }
}