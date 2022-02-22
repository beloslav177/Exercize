using Library.Model;

namespace Exercize.Services
{
    public interface IExercizeService
    {
        Task<ExercizeModel> GetExercizeByIdAsync(int id);
        Task<ExercizeModel> AddExercizeAsync(string title, string description);
        Task<ExercizeModel> UpdateExercizeAsync(ExercizeModel exercizeModel);
        Task<ExercizeModel> DeleteExercizeAsync(int id);
        Task<bool> IsFinishedExercize(int id);
    }
}
