
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using tarea2_clientes.Models;
using tarea2_clientes.Data;

public class ClienteController : Controller
{
    private readonly ApplicationDbContext _context;

    public ClienteController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: CLIENTEMODELS
    public async Task<IActionResult> Index()    
    {
        return View(await _context.Clientes.ToListAsync());
    }

    // GET: CLIENTEMODELS/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var clientemodel = await _context.Clientes
            .FirstOrDefaultAsync(m => m.Id == id);
        if (clientemodel == null)
        {
            return NotFound();
        }

        return View(clientemodel);
    }

    // GET: CLIENTEMODELS/VerModal/5
    public async Task<IActionResult> VerModal(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var clientemodel = await _context.Clientes
            .FirstOrDefaultAsync(m => m.Id == id);
        if (clientemodel == null)
        {
            return NotFound();
        }

        return PartialView("_VerModal", clientemodel);
    }

    // GET: CLIENTEMODELS/Create
    public IActionResult Create()
    {
        return View(new ClienteModel { FechaRegistro = DateTime.Today });
    }

    // POST: CLIENTEMODELS/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,Nombre,Apellido,TipoDocumento,NumeroDocumento,Direccion,Ciudad,Telefono,Correo,FechaRegistro")] ClienteModel clientemodel)
    {
        if (ModelState.IsValid)
        {
            _context.Add(clientemodel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(clientemodel);
    }

    // GET: CLIENTEMODELS/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var clientemodel = await _context.Clientes.FindAsync(id);
        if (clientemodel == null)
        {
            return NotFound();
        }
        return View(clientemodel);
    }

    // POST: CLIENTEMODELS/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int? id, [Bind("Id,Nombre,Apellido,TipoDocumento,NumeroDocumento,Direccion,Ciudad,Telefono,Correo,FechaRegistro")] ClienteModel clientemodel)
    {
        if (id != clientemodel.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(clientemodel);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClienteModelExists(clientemodel.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));
        }
        return View(clientemodel);
    }

    // GET: CLIENTEMODELS/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var clientemodel = await _context.Clientes
            .FirstOrDefaultAsync(m => m.Id == id);
        if (clientemodel == null)
        {
            return NotFound();
        }

        return View(clientemodel);
    }

    // POST: CLIENTEMODELS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? id)
    {
        var clientemodel = await _context.Clientes.FindAsync(id);
        if (clientemodel != null)
        {
            _context.Clientes.Remove(clientemodel);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool ClienteModelExists(int? id)
    {
        return _context.Clientes.Any(e => e.Id == id);
    }
}
