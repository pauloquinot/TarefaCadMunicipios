using CadMunicipios.Db;
using CadMunicipios.Model;
using CadMunicipios.Config;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace CadMunicipios.Dao
{
    public class MunicipioDao : IDAO<Municipio>
    {
        private SQLiteConnection conexao;
        //Cria uma conexão
        public MunicipioDao()
        {
            conexao = DependencyService.Get<ISQLite>().RetornaConexao();
            conexao.CreateTable<Municipio>();
        }

        public string Deleta(int codigo)
        {
            conexao.Delete<Municipio>(codigo);
            return Configuracoes.Ok;
        }

        public IEnumerable<Municipio> GetRegistros(string valor)
        {
            string criterio = "";
            if (!string.IsNullOrEmpty(valor))
            {
                criterio = " where Nome  like '%" + valor + "%'";
            }
            var municipios = conexao.Query<Municipio>("select * from Municipio " + criterio);
            return municipios;
        }

        public string InsereAtualiza(Municipio obj)
        {
            //se for municipio.codigo==0 é um novo municipio
            if (obj.Codigo == 0)
            {
                conexao.Insert(obj);
            }
            else
            {
                conexao.Update(obj);
            }
            return Configuracoes.Ok;
        }
    }
}
