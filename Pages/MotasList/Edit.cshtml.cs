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
        // Acesso � liga��o � base de dados
        private ApplicationDbContext _db;

        // Elemento a atualizar
        [BindProperty]
        public Motas Mota { get; set; }

        // Fun��o Construtora "ctor" - para rapidez com o argumento - Dependency Injection
        public EditModel(ApplicationDbContext db)
        {
            _db = db;
        }

        // O que fazer quando a p�gina � carregada
        public async Task OnGet(int id)
        {
            // Obt�m os dados do livro de acordo com o seu Id
            Mota = await _db.Mota.FindAsync(id);
        }

        // Fun��o executada quando o formul�rio � submetido
        public async Task<IActionResult> OnPost()
        {
            // Se o modelo est�
            // V�lido ou seja, se est� de acordo com a tabela.
            if (ModelState.IsValid)
            {
                // Localiza o objeto com o "Id"
                var MotaFromDb = await _db.Mota.FindAsync(Mota.Id);

                // Obt�m os dados dos controlos
                MotaFromDb.Categoria = Mota.Categoria;
                MotaFromDb.Nome = Mota.Nome;
                MotaFromDb.Valor = Mota.Valor;
                MotaFromDb.Cor = Mota.Cor;
                MotaFromDb.Cilindrada = Mota.Cilindrada;
                MotaFromDb.Ano = Mota.Ano;

                // Grava o objeto na base de dados.
                await _db.SaveChangesAsync();

                // Redireciona para a p�gina "Index"
                return RedirectToPage("Index");
            }

            // Se n�o for v�lido, mant�m-se na p�gina atual.
            return RedirectToPage();
        }
    }
}
