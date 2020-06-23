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

namespace DisaBioApp.Droid
{
    [Activity(Label = "Genre", MainLauncher = true, Icon = "@drawable/icon")]
    public class Genre : Activity
    {
        TextView result;

        protected override void OnCreate(Bundle bundle)
        {
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Genre);

            // Get UI elements out of the layout
            result = FindViewById<TextView>(Resource.Id.result);
            var Comedy = FindViewById<Button>(Resource.Id.button1);
            Comedy.LongClick += Button1_LongClick;
            var Romance = FindViewById<Button>(Resource.Id.button2);
            Romance.LongClick += Button2_LongClick;
            var Animation = FindViewById<Button>(Resource.Id.button3);
            Animation.LongClick += Button3_LongClick;
            var Adventure = FindViewById<Button>(Resource.Id.button4);
            Adventure.LongClick += Button4_LongClick;
            var Action = FindViewById<Button>(Resource.Id.button5);
            Action.LongClick += Button5_LongClick;
            var Drama = FindViewById<Button>(Resource.Id.button6);
            Drama.LongClick += Button6_LongClick;

            var dropZone = FindViewById<FrameLayout>(Resource.Id.dropzone);

            // Attach event to drop zone
            dropZone.Drag += DropZone_Drag;

            base.OnCreate(bundle);
        }

        void Button1_LongClick(object sender, View.LongClickEventArgs e)
        {
            // Generate clip data package to attach it to the drag
            var data = ClipData.NewPlainText("name", "Comedy");

            // Start dragging and pass data
            ((sender) as Button).StartDrag(data, new View.DragShadowBuilder(((sender) as Button)), null, 0);
        }

        void Button2_LongClick(object sender, View.LongClickEventArgs e)
        {
            // Generate clip data package to attach it to the drag
            var data = ClipData.NewPlainText("name", "Romance");

            // Start dragging and pass data
            ((sender) as Button).StartDrag(data, new View.DragShadowBuilder(((sender) as Button)), null, 0);
        }

        void Button3_LongClick(object sender, View.LongClickEventArgs e)
        {
            // Generate clip data package to attach it to the drag
            var data = ClipData.NewPlainText("name", "Animation");

            // Start dragging and pass data
            ((sender) as Button).StartDrag(data, new View.DragShadowBuilder(((sender) as Button)), null, 0);

        }

        void Button4_LongClick(object sender, View.LongClickEventArgs e)
        {
            // Generate clip data package to attach it to the drag
            var data = ClipData.NewPlainText("name", "Adventure");

            // Start dragging and pass data
            ((sender) as Button).StartDrag(data, new View.DragShadowBuilder(((sender) as Button)), null, 0);

        }

        void Button5_LongClick(object sender, View.LongClickEventArgs e)
        {
            // Generate clip data package to attach it to the drag
            var data = ClipData.NewPlainText("name", "Action");

            // Start dragging and pass data
            ((sender) as Button).StartDrag(data, new View.DragShadowBuilder(((sender) as Button)), null, 0);

        }

        void Button6_LongClick(object sender, View.LongClickEventArgs e)
        {
            // Generate clip data package to attach it to the drag
            var data = ClipData.NewPlainText("name", "Drama");

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
                        result.Text = data.GetItemAt(0).Text + " er nu din fortrukket genre.";
                    break;
            }
        }
    }
}