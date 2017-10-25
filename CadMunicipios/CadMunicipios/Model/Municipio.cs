using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace CadMunicipios.Model
{
    public class Municipio
    {
        [PrimaryKey, AutoIncrement]
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public string SiglaUF { get; set; }
    }
}
