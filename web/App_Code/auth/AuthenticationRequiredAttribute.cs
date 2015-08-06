using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
public class AuthenticationRequiredAttribute : System.Attribute
{
    public AuthenticationRequiredAttribute()
    {
        
    }
}