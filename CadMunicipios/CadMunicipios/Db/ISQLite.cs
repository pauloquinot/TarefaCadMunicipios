using System;
using System.Collections.Generic;
using System.Text;

namespace CadMunicipios.Db
{
    public interface ISQLite
    {
        SQLite.SQLiteConnection RetornaConexao();
    }
}
