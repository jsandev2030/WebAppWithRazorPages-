using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MotasWebRazor.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MotasWebRazor.Pages.MotasList
{
    public class EditModel : PageModel
    {
        // Acesso à ligação à base de dados
        private ApplicationDbContext _db;

        // Elemento a atualizar
        [BindProperty]
        public Motas Mota { get; set; }

        // Função Construtora "ctor" - para rapidez com o argumento - Dependency Injection
        public EditModel(ApplicationDbContext db)
        {
            _db = db;
        }

        // O que fazer quando a página é carregada
        public async Task OnGet(int id)
        {
            // Obtém os dados do livro de acordo com o seu Id
            Mota = await _db.Mota.FindAsync(id);
        }

        // Função executada quando o formulário é submetido
        public async Task<IActionResult> OnPost()
        {
            // Se o modelo está
            // Válido ou seja, se está de acordo com a tabela.
            if (ModelState.IsValid)
            {
                // Localiza o objeto com o "Id"
                var MotaFromDb = await _db.Mota.FindAsync(Mota.Id);

                // Obtém os dados dos controlos
                MotaFromDb.Categoria = Mota.Categoria;
                MotaFromDb.Nome = Mota.Nome;
                MotaFromDb.Valor = Mota.Valor;
                MotaFromDb.Cor = Mota.Cor;
                MotaFromDb.Cilindrada = Mota.Cilindrada;
                MotaFromDb.Ano = Mota.Ano;

                // Grava o objeto na base de dados.
                await _db.SaveChangesAsync();

                // Redireciona para a página "Index"
                return RedirectToPage("Index");
            }

            // Se não for válido, mantém-se na página atual.
            return RedirectToPage();
        }
    }
}
