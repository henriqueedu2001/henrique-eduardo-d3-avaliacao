using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcessoUsuario.FileModification {
    public static class ManipuladorArquivos {
        public static void Escrever(string path, string content) {
            using (StreamWriter sw = new StreamWriter(path)) { 
                sw.WriteLine(content);
            }
        }
        public static string LerTudo(string path) {
            string conteudo = "";
            using (StreamReader sr = new StreamReader(path)) { 
                conteudo = sr.ReadToEnd();
            }
            return conteudo;
        }
    }
}
