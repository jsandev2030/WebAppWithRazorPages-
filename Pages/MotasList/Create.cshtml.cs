using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MotasWebRazor.Model;

namespace MotasWebRazor.Pages.MotasList
{
    public class CreateModel : PageModel
    {
        // Acesso à ligação à base de dados
        private readonly ApplicationDbContext _db;

        // Elemento a inserir
        [BindProperty]
        public Motas Mota { get; set; }

        // 2.1 Função Construtora com o argumento - Dependency Injection
        public CreateModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public void OnGet()
        {
        }

        // Função executada quando o formulário é submetido.
        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid) { 
                await _db.Mota.AddAsync(Mota);

                // Guardar as alterações na tabela
                // Deve ser sempre feito com o CREATE e o UPDATE e o DELETE
                await _db.SaveChangesAsync();
                // Redireciona para a página "Index".
                return RedirectToPage("Index");
            }
            else
            {
                return Page();
            }
        }

    }
}
