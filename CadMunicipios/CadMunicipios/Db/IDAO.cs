using System;
using System.Collections.Generic;
using System.Text;

namespace CadMunicipios.Db
{
    public interface IDAO<T>
    {
        /*Busca todos os registros ou parte dele*/
        IEnumerable<T> GetRegistros(String valor);


        /*Atualiza ou insere um novo registro*/
        string InsereAtualiza(T obj);


        /*Exclui um registro*/
        string Deleta(int codigo);
    }
}
