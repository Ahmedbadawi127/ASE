using Shipping.Application.Common.Mappings;
using Shipping.Domain.Entities;

namespace Shipping.Application.TodoLists.Queries.ExportTodos
{
    public class TodoItemRecord : IMapFrom<TodoItem>
    {
        public string Title { get; set; }

        public bool Done { get; set; }
    }
}
