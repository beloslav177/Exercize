using Exercize.Services;
using Library.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Exercize.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExercizeController : ControllerBase
    {
        private readonly IExercizeService exercizeService;

        public ExercizeController(IExercizeService exercizeService)
        {
            this.exercizeService = exercizeService;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<ExercizeModel>> GetExercize(int id)
        {
            try
            {
                var result = await exercizeService.GetExercizeByIdAsync(id);

                if (result == null) return NotFound();

                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        [HttpPost]
        public async Task<ActionResult<ExercizeModel>> CreateExercize(ExercizeModel exercizeModel)
        {
            try
            {
                if (exercizeModel == null)
                {
                    return BadRequest();
                }

                var exercize = exercizeService.GetExercizeByIdAsync(exercizeModel.Id);

                if (exercize != null)
                {
                    ModelState.AddModelError("exercize", "Exercize already in use");
                    return BadRequest(ModelState);
                }

                var createdExercize = await exercizeService.AddExercizeAsync(exercizeModel.Title, exercizeModel.Description);

                return CreatedAtAction(nameof(GetExercize), new { id = createdExercize.Id },
                    createdExercize);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error creating employee");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ExercizeModel>> UpdateEmployee(ExercizeModel exercizeModel, int id)
        {
            try
            {
                if (id != exercizeModel.Id)
                    return BadRequest("ID mismatch");

                var exercize = await exercizeService.GetExercizeByIdAsync(id);

                if (exercize == null)
                    return NotFound($"Exercize with Id = {id} not found");

                return Ok(await exercizeService.UpdateExercizeAsync(exercizeModel));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error updating data");
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<ExercizeModel>> DeleteExercize(int id)
        {
            try
            {
                var exercize = await exercizeService.GetExercizeByIdAsync(id);

                if (exercize == null)
                {
                    return NotFound($"Exercize with Id = {id} not found");
                }

                return await exercizeService.DeleteExercizeAsync(id);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error deleting data");
            }
        }

        [ValidateAntiForgeryToken]
        public async Task<IActionResult> IsFinishedExercize(int id)
        {
            var item = await exercizeService.GetExercizeByIdAsync(id);

            if (item == null)
            {
                return NotFound($"Exercize with Id = {id} not found");
            }

            var successful = await exercizeService.IsFinishedExercize(id);
            if (!successful)
            {
                return BadRequest("Could not mark exercize as done.");
            }

            return Ok(successful);
        }
    }
}
