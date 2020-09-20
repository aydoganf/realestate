using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class JSEstateTpe
{
    public string id { get; set; }
    public string text { get; set; }
    public string icon { get; set; }
    public string li_attr { get; set; }
    public JSa_attr a_attr { get; set; }

    public JSEstateTpe[] children;
    public JSEstateTpeState state { get; set; }
}

public class JSEstateTpeState
{
    public bool opened { get; set; }
    public bool disabled { get; set; }
    public bool selected { get; set; }
}

public class JSa_attr
{
    public string @class { get; set; }
}