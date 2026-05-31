
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using tarea2_clientes.Models;
using tarea2_clientes.Data;

public class AlumnoController : Controller
{
    private readonly ApplicationDbContext _context;

    public AlumnoController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: ALUMNOMODELS
    public async Task<IActionResult> Index()
    {
        return View(await _context.Alumnos.ToListAsync());
    }

    // GET: ALUMNOMODELS/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var alumnoModel = await _context.Alumnos
            .FirstOrDefaultAsync(m => m.Id == id);
        if (alumnoModel == null)
        {
            return NotFound();
        }

        return View(alumnoModel);
    }

    // GET: ALUMNOMODELS/VerModal/5
    public async Task<IActionResult> VerModal(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var alumnoModel = await _context.Alumnos
            .FirstOrDefaultAsync(m => m.Id == id);
        if (alumnoModel == null)
        {
            return NotFound();
        }

        return PartialView("_VerModal", alumnoModel);
    }

    // GET: ALUMNOMODELS/Create
    public IActionResult Create()
    {
        return View(new AlumnoModel { FechaIngreso = DateTime.Today });
    }

    // POST: ALUMNOMODELS/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,Nombre,Apellido,Codigo,Carrera,Semestre,Promedio,Telefono,Correo,FechaIngreso")] AlumnoModel alumnoModel)
    {
        if (ModelState.IsValid)
        {
            _context.Add(alumnoModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(alumnoModel);
    }

    // GET: ALUMNOMODELS/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var alumnoModel = await _context.Alumnos.FindAsync(id);
        if (alumnoModel == null)
        {
            return NotFound();
        }
        return View(alumnoModel);
    }

    // POST: ALUMNOMODELS/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int? id, [Bind("Id,Nombre,Apellido,Codigo,Carrera,Semestre,Promedio,Telefono,Correo,FechaIngreso")] AlumnoModel alumnoModel)
    {
        if (id != alumnoModel.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(alumnoModel);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AlumnoModelExists(alumnoModel.Id))
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
        return View(alumnoModel);
    }

    // GET: ALUMNOMODELS/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var alumnoModel = await _context.Alumnos
            .FirstOrDefaultAsync(m => m.Id == id);
        if (alumnoModel == null)
        {
            return NotFound();
        }

        return View(alumnoModel);
    }

    // POST: ALUMNOMODELS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? id)
    {
        var alumnoModel = await _context.Alumnos.FindAsync(id);
        if (alumnoModel != null)
        {
            _context.Alumnos.Remove(alumnoModel);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool AlumnoModelExists(int? id)
    {
        return _context.Alumnos.Any(e => e.Id == id);
    }
}
