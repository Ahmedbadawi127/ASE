using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Shipping.Shared.Commands
{
    public static class FileUtil
    {
        public static ValueTask<object> SaveAs(this IJSRuntime js, string filename, byte[] data)
            => js.InvokeAsync<object>(
                "saveAsFile",
                filename,
                Convert.ToBase64String(data));
    }
}
