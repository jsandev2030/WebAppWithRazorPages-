using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MotasWebRazor.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;

namespace MotasWebRazor.Pages.MotasList
{
    public class IndexModel : PageModel
    {
        // Acesso � liga��o da base de dados
        private readonly ApplicationDbContext _db;

        // 2.1 Fun��o Construtora com o argumento - Dependency Injection
        public IndexModel(ApplicationDbContext db)
        {
            _db = db;   // Dependency Injection
        }

        // Para obter a lista de livros 
        public IEnumerable<Motas> Motas { get; set; }

        public async Task OnGet()
        {
            Motas = await _db.Mota.ToListAsync();
        }

        public async Task<IActionResult> OnPostDelete(int id)
        {
            // Obt�m da base de dados o objeto a apagar atrav�s do seu "id"
            var book = await _db.Mota.FindAsync(id);

            // Se n�o existir
            if (book == null)
            {
                return NotFound();
            }

            // Se exitir: apaga e guarda altera��es
            _db.Mota.Remove(book);
            await _db.SaveChangesAsync();

            // Recarrgar a p�gina "Index".
            return RedirectToPage("Index");

        }
    }
}
