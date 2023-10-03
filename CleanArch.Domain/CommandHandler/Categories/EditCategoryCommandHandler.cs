using CleanArch.Domain.Commands.Categorys;
using CleanArch.Domain.Interfaces;
using CleanArch.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Domain.CommandHandler.Categories
{
    public class EditCategoryCommandHandler : IRequestHandler<EditCategoryCommand,bool>
    {
        private ICategoryRepository  _categoryRepository;

        public EditCategoryCommandHandler(ICategoryRepository  categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

   
        public Task<bool> Handle(EditCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = new Category()
            {
                 Id = request.Id,
                Name = request.Name,
                DisplayOrder = request.DisplayOrder
            };

            _categoryRepository.Update(category);

            return Task.FromResult(true);
        }
    }
}
