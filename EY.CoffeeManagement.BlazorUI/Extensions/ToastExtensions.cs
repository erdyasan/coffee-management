using BlazorBootstrap;

namespace EY.CoffeeManagement.BlazorUI.Extensions;

public static class ToastExtensions
{
    public static void Success(this ToastService toast)
    {
        toast.Notify(new ToastMessage(ToastType.Success, "İşlem başarılı!"));
    }

    public static void Error(this ToastService toast)
    {
        toast.Notify(new ToastMessage(ToastType.Danger, "Başarısız", "İşlem gerçekleştirilirken hata oluştu!"));
    }

    public static void NotifyByResult(this ToastService toast, bool isSuccess)
    {
        if (isSuccess)
        {
            toast.Success();
        }
        else
        {
            toast.Error();
        }
    }
}