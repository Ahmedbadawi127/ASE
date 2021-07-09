using Shipping.Domain.Enums;
using System.Threading.Tasks;
using Syncfusion.Blazor.Notifications;
using Syncfusion.Blazor.Spinner;

namespace Shipping.Client
{
    public interface IShippingOperations
    {
        public bool isLoading { get; set; }
        public SfToast ToastObj { get; set; }
        public Task ShowToast(string Title, string Content, ToastType Type, int Timeout = 3000, int ExtendedTimeout = 1000, bool ShowCloseButton = true, bool ShowProgressBar = true);
        public void ShowSpinner(bool Show);
    }

    public class ShippingOperations : IShippingOperations
    {
        public bool isLoading { get; set; }
        public SfToast ToastObj { get; set; }
        public async Task ShowToast(string Title, string Content, ToastType Type, int Timeout = 3000, int ExtendedTimeout = 1000, bool ShowCloseButton = true, bool ShowProgressBar = true)
        {
            ToastModel tModel = new ToastModel
            {
                Title = Title,
                Content = Content,
                Timeout = Timeout,
                ShowCloseButton = ShowCloseButton,
                ShowProgressBar = ShowProgressBar,
                ExtendedTimeout = ExtendedTimeout,
            };

            switch (Type)
            {
                case ToastType.Warning:
                    tModel.CssClass = "e-toast-warning"; tModel.Icon = "e-warning toast-icons";
                    break;

                case ToastType.Success:
                    tModel.CssClass = "e-toast-success"; tModel.Icon = "e-success toast-icons";
                    break;

                case ToastType.Error:
                    tModel.CssClass = "e-toast-danger"; tModel.Icon = "e-danger toast-icons";
                    break;

                case ToastType.Info:
                    tModel.CssClass = "e-toast-warniinfong"; tModel.Icon = "e-info toast-icons";
                    break;

                default:
                    break;
            }

            await ToastObj.Show(tModel);
        }
        public void ShowSpinner(bool Show)
        {
            this.isLoading = Show;
        }

    }
}