using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using APIFARM.Models;
using APIFARM.Data;

namespace APIFARM.Controllers
{
    [Route("api/Salaries")]
    [ApiController]
    public class SalariesController : ControllerBase
    {
        // GET: api/Salaries
        [HttpGet]
        public ActionResult<IEnumerable<Salarie>> GetAllSalaries()
        {
            // TODO: Récupérer tous les salariés depuis la base de données
            return Ok(); // Retourne une réponse vide pour le moment
        }

        // GET: api/Salaries/5
        [HttpGet("{id}")]
        public ActionResult<Salarie> GetSalarieById(int id)
        {
            // TODO: Récupérer le salarié avec l'ID spécifié depuis la base de données
            return Ok(); // Retourne une réponse vide pour le moment
        }

        // POST: api/Salaries
        [HttpPost]
        public ActionResult<Salarie> AddSalarie(Salarie salarie)
        {
            // TODO: Ajouter le salarié à la base de données
            return CreatedAtAction(nameof(GetSalarieById), new { id = salarie.Id }, salarie); // Retourne une réponse de création
        }

        // PUT: api/Salaries/5
        [HttpPut("{id}")]
        public IActionResult UpdateSalarie(int id, Salarie salarie)
        {
            // TODO: Mettre à jour le salarié dans la base de données
            return NoContent(); // Retourne une réponse indiquant que la mise à jour a réussi
        }

        // DELETE: api/Salaries/5
        [HttpDelete("{id}")]
        public IActionResult DeleteSalarie(int id)
        {
            // TODO: Supprimer le salarié de la base de données
            return NoContent(); // Retourne une réponse indiquant que la suppression a réussi
        }
    }
}
