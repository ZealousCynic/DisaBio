using Android.Content;

namespace DisaBioApp.Services
{
    public interface IFirebaseService
    {
        void SendRegistrationToServer(string token, Context context);

    }
}
