using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using DisaBioApp.Droid;
using DisaBioApp.Services;
using Xamarin.Forms;

[assembly: Dependency(typeof(AndroidGenreHelper))]
namespace DisaBioApp.Droid
{
    class AndroidGenreHelper : IGenreHelper
    {

        TaskCompletionSource<string> tcs;

        public Task<string> SelectGenre()
        {
            var uniqueId = Guid.NewGuid();
            var next = new TaskCompletionSource<string>(uniqueId);

            // Interlocked.CompareExchange(ref object location1, object value, object comparand)
            // Compare location1 with comparand.
            // If equal replace location1 by value.
            // Returns the original value of location1.
            // ---
            // In this context, tcs is compared to null, if equal tcs is replaced by next,
            // and original tcs is returned.
            // We then compare original tcs with null, if not null it means that a task was 
            // already started.
            if (Interlocked.CompareExchange(ref tcs, next, null) != null)
            {
                return Task.FromResult<string>(null);
            }

            EventHandler<GenrePicked> handler = null;

            handler = (sender, e) =>
            {

                // Interlocaked.Exchange(ref object location1, object value)
                // Sets an object to a specified value and returns a reference to the original object.
                // ---
                // In this context, sets tcs to null and returns it.
                var task = Interlocked.Exchange(ref tcs, null);

                Genre.OnGenrePicked -= handler;

                if (!String.IsNullOrWhiteSpace(e.Name))
                {
                    task.SetResult(e.Name);
                }
                else
                {
                    task.SetCanceled();
                }
            };

            Genre.OnGenrePicked += handler;

            var toRun = new Intent(Forms.Context, typeof(Genre));
            toRun.SetFlags(ActivityFlags.NewTask);
            Forms.Context.StartActivity(toRun);

            return tcs.Task;
        }
    }
}