using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace TryCore.Model
{
    public static class SampleData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetService<ProductContext>();
            if (!context.Categories.Any())
            {
                context.Categories.AddRange(
                    new Category
                    {
                        Name = "Samsung"
                    },
                    new Category
                    {
                        Name = "Apple"
                    },
                    new Category
                    {
                        Name = "Lenovo"
                    }
                    );
                context.SaveChanges();
            }

        }

    }
}
