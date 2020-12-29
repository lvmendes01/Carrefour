using System;
using System.Collections.Generic;
using System.Text;

namespace Prova.Repositorio
{
    public interface ICrud<I, O>
    {
        O Carregar(I i);
        int Salvar(O o);
        int Atualizar(O o);
        int Delete(O o);
        IList<O> Listar();
    }
}
