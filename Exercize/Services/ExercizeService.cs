using Exercize.Data;
using Library.Model;
using Microsoft.EntityFrameworkCore;

namespace Exercize.Services
{
    public class ExercizeService : IExercizeService
    {
        private readonly DataContext context;

        public ExercizeService(DataContext context)
        {
            this.context = context;
        }
        public async Task<ExercizeModel> AddExercizeAsync(string title, string description)
        {
            var model = await context.Exercizes.FirstOrDefaultAsync(e => e.Title == title);
            if (model == null)
            {
                return model;
            }
            else
            {
                var exercize = new ExercizeModel { Title = title, Description = description };

                context.Exercizes.Add(exercize);
                context.SaveChanges();

                return exercize;
            }            
        }

        public async Task<ExercizeModel> DeleteExercizeAsync(int id)
        {
            var exercize = await context.Exercizes.FirstAsync(e => e.Id == id);

            if (exercize == null)
            {
                return exercize;
            }

            context.Exercizes.Remove(exercize);
            context.SaveChanges();

            return exercize;
        }

        public async Task<ExercizeModel> GetExercizeByIdAsync(int id)
        {
            var exercize = await context.Exercizes.FirstAsync(e => e.Id == id);

            return exercize;
        }

        public async Task<bool> IsFinishedExercize(int id)
        {
            var item = await context.Exercizes.FirstOrDefaultAsync(e => e.Id == id);

            if (item == null)
            {
                return false;
            }

            item.IsFinished = true;

            var result = await context.SaveChangesAsync();

            return result == 1;
        }

        public async Task<ExercizeModel> UpdateExercizeAsync(ExercizeModel exercizeModel)
        {
            context.Entry(exercizeModel).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return exercizeModel;
        }
    }
}
