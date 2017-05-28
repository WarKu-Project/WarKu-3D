using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitInfo
{

    public float x, y, r, hp;
    public string name,uid;
    public string action;
    public int color;
    public UnitInfo(float x, float y, float r, float hp,string uid, string name, string action, int color)
    {
        this.x = x;
        this.y = y;
        this.r = r;
        this.uid = uid;
        this.name = name;
        this.action = action;
        this.color = color;
    }
}
