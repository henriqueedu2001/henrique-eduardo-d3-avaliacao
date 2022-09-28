using AcessoUsuario.Models;
using AcessoUsuario.Interfaces;
using AcessoUsuario.FileModification;
using AcessoUsuario.database;

namespace AcessoUsuario {
    public class Program {
        public static void Main() {
            Acesso acesso = new Acesso();
            acesso.IniciarAplicacao();
        }
    }
}