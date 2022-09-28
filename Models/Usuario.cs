using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcessoUsuario.Models {
    public  class Usuario {
        public string Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Curso { get; set; }
        public string Ocupacao { get; set; }
        public Usuario(string id, string nome, string email , string curso, string ocupacao) {
            Id = id;
            Nome = nome;
            Email = email;
            Curso = curso;
            Ocupacao = ocupacao;
        }
        public Usuario()
        {

        }
        
    }
}
