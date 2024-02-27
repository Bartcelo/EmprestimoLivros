using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations;

namespace EmprestimoLivros.Models
{
    public class EmprestimosModel
    {
        public int Id { get; set; }


       

        [Required (ErrorMessage = "Deve conter o nome do Recebedor")]
        public string Recebedor  { get; set; }


        [Required (ErrorMessage = "Deve conter o nome do Fornecedor")]
        public string Fornecedor  { get; set; }
        
        
        [Required (ErrorMessage = "Deve conter o nome do Livro")]
        public string LivroEmprestado  { get; set; }
        public DateTime DataUltimaAtualizacao  { get; set; } = DateTime.Now;




    }
}
