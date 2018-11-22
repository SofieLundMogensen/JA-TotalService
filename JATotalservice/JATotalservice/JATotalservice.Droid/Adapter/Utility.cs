using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace JATotalservice.Droid.Adapter
{
    public class Utility
    {
        public static void setListViewHeightBasedOnChildren(ListView listView)
        {
            if (listView.Adapter == null)
            {
                // pre-condition
                return;
            }

            int totalHeight = listView.PaddingTop + listView.PaddingBottom;
            for (int i = 0; i < listView.Count; i++)
            {
                View listItem = listView.Adapter.GetView(i, null, listView);
                if (listItem.GetType() == typeof(ViewGroup))
                {
                    listItem.LayoutParameters = new LinearLayout.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.WrapContent);
                }
                listItem.Measure(0, 0);
                totalHeight += listItem.MeasuredHeight;
            }

            listView.LayoutParameters.Height = totalHeight + (listView.DividerHeight * (listView.Count - 1));
        }
    }
}