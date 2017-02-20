using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ERPManagement.ViewModel.Authorize
{
    [AttributeUsage(AttributeTargets.Class)]
    class AuthorizeAttribute : Attribute
    {
        public String Method { get; set; }

        public AuthorizeAttribute()
        {

        }
    }
}