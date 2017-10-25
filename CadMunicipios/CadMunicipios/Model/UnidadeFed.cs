using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace CadMunicipios.Model
{
    public class UnidadeFed
    {
        [PrimaryKey, Unique]
        public string SiglaUF { get; set; }
        public string NomeUF { get; set; }
    }
}
    