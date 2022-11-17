using HouseRentingSystem.Infrastructure.Data.Common;
using Microsoft.EntityFrameworkCore;
using MoneyManager.Core.Contracts;
using MoneyManager.Core.Models.CategoryExpense;
using MoneyManager.Infrastructure.Data.Entities;

namespace MoneyManager.Core.Services
{
    public class CategoryExpenseService : ICategoryExpenseService
    {
        private readonly IRepository repo;
        public CategoryExpenseService(IRepository _repo)
        {
            repo = _repo;
        }
        public async Task<bool> AddCategoryAsync(AddCategoryExpenseViewModel model)
        {
            var allCategories = await repo.AllReadonly<CategoryExpense>().ToListAsync();

            if (!allCategories.Any(x => x.Name.ToLower() == model.Name.ToLower()))
            {
                var entity = new CategoryExpense()
                {
                    Name = model.Name
                };

                await repo.AddAsync(entity);

                await repo.SaveChangesAsync();

                return true;
            }

            return false;
        }

        public async Task EditAsync(EditCategoryExpenseViewModel model)
        {
            var entity = await repo.GetByIdAsync<CategoryExpense>(model.Id);


            entity.Name = model.Name;

            await repo.SaveChangesAsync();
        }

        public async Task<List<CategoryExpenseViewModel>> GetAllAsync()
        {
            return await repo.AllReadonly<CategoryExpense>().OrderBy(x => x.Name).Select(i => new CategoryExpenseViewModel()
            {
                Id = i.Id,
                Name = i.Name
            }).ToListAsync();
        }

        public async Task<EditCategoryExpenseViewModel> GetForEditAsync(Guid id)
        {
            var category = await repo.GetByIdAsync<CategoryExpense>(id);

            return new EditCategoryExpenseViewModel()
            {
                Id = category.Id,
                Name = category.Name
            };
        }
    }
}
