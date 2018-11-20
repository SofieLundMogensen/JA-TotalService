using MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace JATotalservice.Core.ViewModels
{
    public class TimeViewModel : MvxViewModel
    {
        string testString = "Du er i TimeView'et";

        public string TestString
        {
            get { return testString; }
            set { SetProperty(ref testString, value); }
        }
    }
}
