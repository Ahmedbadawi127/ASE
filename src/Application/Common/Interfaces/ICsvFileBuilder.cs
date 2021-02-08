using Shipping.Application.TodoLists.Queries.ExportTodos;
using System.Collections.Generic;

namespace Shipping.Application.Common.Interfaces
{
    public interface ICsvFileBuilder
    {
        byte[] BuildTodoItemsFile(IEnumerable<TodoItemRecord> records);
    }
}
