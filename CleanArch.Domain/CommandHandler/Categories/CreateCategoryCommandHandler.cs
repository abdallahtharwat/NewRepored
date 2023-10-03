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
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, bool>
    {
        private ICategoryRepository  _categoryRepository;

        public CreateCategoryCommandHandler(ICategoryRepository  categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public Task<bool> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = new Category()
            {
                Name = request.Name,
                DisplayOrder = request.DisplayOrder
            };

            _categoryRepository.add(category);

            return Task.FromResult(true);
        }
    }
}
