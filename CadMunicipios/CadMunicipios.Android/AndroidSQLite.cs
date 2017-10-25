using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

using CadMunicipios.Config;
using CadMunicipios.Droid;
using Xamarin.Forms;
using CadMunicipios.Db;


[assembly: Dependency(typeof(AndroidSQLite))]
namespace CadMunicipios.Droid
{
    public class AndroidSQLite : ISQLite //interface ISQLite criada lá no Xamarin.Forms
    {
        public SQLite.SQLiteConnection RetornaConexao()
        {
            //Nome do banco de dados
            var dbName = Configuracoes.NOME_ARQUIVO_DB;
            //Caminho do arquivo - Especial para Android
            var dbPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData);
            var path = System.IO.Path.Combine(dbPath, dbName);
            //retorna a conexao
            var conexao = new SQLite.SQLiteConnection(path);

            return conexao;
        }

    }
}