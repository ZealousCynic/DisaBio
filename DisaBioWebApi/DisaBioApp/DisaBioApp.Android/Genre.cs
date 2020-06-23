using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using DisaBioModel;

namespace DisaBioApp.Droid
{
    [Activity(Label = "Genre", Icon = "@drawable/icon")]
    public class Genre : Activity
    {
        TextView result;

        protected override void OnCreate(Bundle bundle)
        {
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Genre);

            // Get UI elements out of the layout
            result = FindViewById<TextView>(Resource.Id.result);
            var Comedy = FindViewById<Button>(Resource.Id.btnComedy);
            Comedy.LongClick += Button_LongClick;
            var Romance = FindViewById<Button>(Resource.Id.btnRomance);
            Romance.LongClick += Button_LongClick;
            var Animation = FindViewById<Button>(Resource.Id.btnAnimation);
            Animation.LongClick += Button_LongClick;
            var Adventure = FindViewById<Button>(Resource.Id.btnAdventure);
            Adventure.LongClick += Button_LongClick;
            var Action = FindViewById<Button>(Resource.Id.btnAction);
            Action.LongClick += Button_LongClick;
            var Drama = FindViewById<Button>(Resource.Id.btnDrama);
            Drama.LongClick += Button_LongClick;

            var dropZone = FindViewById<FrameLayout>(Resource.Id.dropzone);

            // Attach event to drop zone
            dropZone.Drag += DropZone_Drag;

            base.OnCreate(bundle);
        }

        void Button_LongClick(object sender, View.LongClickEventArgs e)
        {
            Button b = sender as Button;
            // Generate clip data package to attach it to the drag
            var data = ClipData.NewPlainText("name", b.Text);

            // Start dragging and pass data
            ((sender) as Button).StartDrag(data, new View.DragShadowBuilder(((sender) as Button)), null, 0);
        }

        void DropZone_Drag(object sender, View.DragEventArgs e)
        {
            // React on different dragging events
            var evt = e.Event;
            switch (evt.Action)
            {
                case DragAction.Ended:
                case DragAction.Started:
                    e.Handled = true;
                    break;
                // Dragged element enters the drop zone
                case DragAction.Entered:
                    result.Text = "Slip din fortrukket genre";
                    break;
                // Dragged element exits the drop zone
                case DragAction.Exited:
                    result.Text = "Træk din fortrukket genre her op!";
                    break;
                // Dragged element has been dropped at the drop zone
                case DragAction.Drop:
                    // You can check if element may be dropped here
                    // If not do not set e.Handled to true
                    e.Handled = true;

                    // Try to get clip data
                    var data = e.Event.ClipData;
                    if (data != null)
                    {
                        DisaBioModel.Model.Genre preferredGenre = new DisaBioModel.Model.Genre { Name = e.Event.ToString() };

                        result.Text = data.GetItemAt(0).Text + " er nu din fortrukket genre.";
                    }
                    break;
            }
        }
    }
}