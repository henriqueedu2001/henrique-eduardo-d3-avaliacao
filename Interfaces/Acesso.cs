using AcessoUsuario.database;
using AcessoUsuario.FileModification;
using AcessoUsuario.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace AcessoUsuario.Interfaces
{
    public class Acesso : IAcesso {
        /// <summary>
        /// dá início à aplicação, com exibição da interface inicial
        /// </summary>
        public void IniciarAplicacao() {
            bool sair = false;
            while(sair == false) {
                // leitura da escolha do cliente
                Console.WriteLine("Bem Vindo ao Sistema!\nSelecione uma das opções:\n[a] Acessar\n[b] Sair");
                string? escolha = Console.ReadLine();
                // chamada de interface Acessar ou encerramento da aplicação
                switch (escolha) {
                    case "a" or "A" or "Acessar" or "acessar":
                        Acessar();
                        break;
                    case "b" or "B" or "Sair" or "sair":
                        sair = true;
                        break;
                    default:
                        Console.WriteLine("");
                        break;
                }
            }
            
        }

        /// <summary>
        /// exibe interface da zona de acesso, para verificação das credenciais
        /// </summary>
        public void Acessar() {
            Console.WriteLine("Zona de Acesso. Insira suas Credenciais:");
            // captura dos dados do cliente
            Console.WriteLine("Email: ");
            string? email = Console.ReadLine();
            Console.WriteLine("Senha: ");
            string? senha = Console.ReadLine();

            // verificação das credenciais no banco de dados
            if(LeitorSQL.CredenciaisVerificadas(email, senha)) {
                // registro da entrada
                Usuario usuario = LeitorSQL.GetUsuario(email);
                string horario = DateTime.Now.ToString();
                RegistrarAcesso(usuario, horario, "entrada no sistema");

                // oferecimento de opções deslogar e sair ao usuário, ambas com registro de saída
                Console.WriteLine("Autenticação bem sucedida!\nDesejas mais alguma coisa?");
                Console.WriteLine("[a] Deslogar\n[b] Voltar");
                string? acao = Console.ReadLine();
                switch (acao) {
                    case "a" or "A" or "Deslogar" or "deslogar":
                        Console.WriteLine("Deslogando...\nPronto");
                        RegistrarAcesso(usuario, DateTime.Now.ToString(), "checkout do sistema");
                        break;
                    case "b" or "B" or "Voltar" or "voltar":
                        Console.WriteLine("Saindo da Aplicação...\nPronto");
                        RegistrarAcesso(usuario, DateTime.Now.ToString(), "saída do sistema");
                        break;
                    default:
                        break;
                }
            } else {
                Console.WriteLine("Falha na autenticação!\nVerifique suas credenciais");
            }
        }

        /// <summary>
        /// registra as informações de acesso do usuário em LogUsuarios, tanto dados quanto horários
        /// </summary>
        /// <param name="usuario"></param>
        public void RegistrarAcesso(Usuario usuario, string horario, string operacao) {
            string caminho = "C:\\Users\\Henrique Eduardo\\projects\\AcessoUsuario\\AcessoUsuario\\database\\LogUsuarios.txt";
            string dados_previos = ManipuladorArquivos.LerTudo(caminho);
            string log_usuario = operacao + $":\n  -id: {usuario.Id}\n  -horário: {horario}\n  -nome: {usuario.Nome}\n  -email:{usuario.Email}\n  -curso: {usuario.Curso}\n  -ocupação: {usuario.Ocupacao}\n";
            ManipuladorArquivos.Escrever(caminho, dados_previos + log_usuario);
        }
    }
}
