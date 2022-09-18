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
        // Acesso � liga��o � base de dados
        private readonly ApplicationDbContext _db;

        // Elemento a inserir
        [BindProperty]
        public Motas Mota { get; set; }

        // 2.1 Fun��o Construtora com o argumento - Dependency Injection
        public CreateModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public void OnGet()
        {
        }

        // Fun��o executada quando o formul�rio � submetido.
        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid) { 
                await _db.Mota.AddAsync(Mota);

                // Guardar as altera��es na tabela
                // Deve ser sempre feito com o CREATE e o UPDATE e o DELETE
                await _db.SaveChangesAsync();
                // Redireciona para a p�gina "Index".
                return RedirectToPage("Index");
            }
            else
            {
                return Page();
            }
        }

    }
}
