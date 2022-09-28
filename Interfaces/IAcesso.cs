using AcessoUsuario.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcessoUsuario.Interfaces {
    public interface IAcesso {
        void IniciarAplicacao();
        void Acessar();
        void RegistrarAcesso(Usuario usuario, string horario, string operacao);

    }
}
