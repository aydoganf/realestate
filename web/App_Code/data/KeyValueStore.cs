using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for KeyValueStore
/// </summary>
//public class KeyValueStore
//{
//    public KeyValueStore()
//    {
//        //
//        // TODO: Add constructor logic here
//        //
//    }
//}


public struct KeyValueStore
{
    public int Id { get; set; }
    public string Key { get; set; }
    public string Value { get; set; }
    public string ParentValue { get; set; }

    public KeyValueStore(string key, string value, string parentValue = "") : this()
    {
        Key = key;
        Value = value;
        ParentValue = parentValue;
    }
}