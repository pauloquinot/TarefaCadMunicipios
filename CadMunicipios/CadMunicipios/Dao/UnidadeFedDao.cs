using CadMunicipios.Model;
using CadMunicipios.Config;
using CadMunicipios.Db;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace CadMunicipios.Dao
{
    class UnidadeFedDao : IDAO<UnidadeFed>
    {
        private SQLiteConnection conexao;

        public UnidadeFedDao()
        {
            conexao = DependencyService.Get<ISQLite>().RetornaConexao();
            conexao.CreateTable<UnidadeFed>();
        }


        public string Deleta(int codigo)
        {
            conexao.Delete<UnidadeFed>(codigo);
            return Configuracoes.Ok;
        }

        public List<UnidadeFed> GetRegistrosList(string valor)
        {
            string criterio = "";
            if (!string.IsNullOrEmpty(valor))
            {
                criterio = " where Descricao  like '%" + valor + "%'";
            }
            var registros = conexao.Query<UnidadeFed>("select * from UnidadeFed " + criterio);
            return registros;
        }

        public IEnumerable<UnidadeFed> GetRegistros(string valor)
        {
            string criterio = "";
            if (!string.IsNullOrEmpty(valor))
            {
                criterio = " where Descricao  like '%" + valor + "%'";
            }
            var registros = conexao.Query<UnidadeFed>("select * from UnidadeFed " + criterio);
            return registros;
        }

        public string InsereAtualiza(UnidadeFed obj)
        {
            conexao.Insert(obj);
            return Configuracoes.Ok;
        }

        public UnidadeFed getRegistro(int codigo)
        {
            var registros = conexao.Query<UnidadeFed>("select * from UnidadeFed where Codigo=" + codigo);
            UnidadeFed unidadeFed = null;
            if (registros.Count > 0)
            {
                unidadeFed = registros[0];
            }
            return unidadeFed;
        }
    }
}
