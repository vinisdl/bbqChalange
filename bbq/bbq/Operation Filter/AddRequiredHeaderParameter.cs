using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;
namespace bbq.Application.Operation_Filter
{


    public class AddRequiredHeaderParameter : IOperationFilter
    {
        public void Apply(Operation operation, OperationFilterContext context)
        {
            if (operation.Parameters == null)
                operation.Parameters = new List<IParameter>();

            operation.Parameters.Add(new NonBodyParameter
            {
                Name = "token",
                In = "header",
                Type = "string",
                Required = false
            });
            operation.Parameters.Add(new NonBodyParameter
            {
                Name = "username",
                In = "header",
                Type = "string",
                Required = false
            });
        }
    }

}
