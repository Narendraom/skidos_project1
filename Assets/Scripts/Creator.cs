using System;
using System.Collections.Generic;


public class Item
{
    public string subtopic_id { get; set; }
    public string subtopic_name { get; set; }
}

public class Addition
{
    public Item[][] data { get; set; }
}

public class Geometry
{
    public Item[][] data { get; set; }
}

public class MixedOperations
{
    public Item[][] data { get; set; }
}

public class NumberSense
{
    public Item[][] data { get; set; }
}

public class Subtraction
{
    public Item[][] data { get; set; }
}


public class Creator
{
    public string id { get; set; }
    public string createdAt { get; set; }
    public string name { get; set; }
    public string avatar { get; set; }
    public Addition Addition { get; set; }
    public Geometry Geometry { get; set; }
    public MixedOperations MixedOperations { get; set; }
    public NumberSense Numbersense { get; set; }
    public Subtraction Subtraction { get; set; }
    public string myField { get; set; }
}




 
