using CadMunicipios.Dao;
using CadMunicipios.Model;
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
	public partial class CadastroUF : ContentPage
	{
		public CadastroUF ()
		{
			InitializeComponent ();
		}
        public async void Salvar(object o, EventArgs e)
        {
            UnidadeFedDao dao = new UnidadeFedDao();
            UnidadeFed unidadeFed = new UnidadeFed();
            unidadeFed.SiglaUF = edtSiglaUF.Text;
            unidadeFed.NomeUF = edtNomeUF.Text;
            dao.InsereAtualiza(unidadeFed);
            await Navigation.PopModalAsync(false);
        }

        public async void Voltar(object o, EventArgs e)
        {
            await Navigation.PopModalAsync(false);

        }
    }
}