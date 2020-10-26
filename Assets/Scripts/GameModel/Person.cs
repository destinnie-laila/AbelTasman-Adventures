using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using SQLite4Unity3d;

public class Person
{
    private int iD;
    private string name;

    public Person()
    {
    }

    [AutoIncrement, PrimaryKey]
    public int ID { get => iD; set => iD = value; }
    public string Name { get => name; set => name = value; }
   
}
