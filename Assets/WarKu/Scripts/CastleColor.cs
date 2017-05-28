using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastleColor : MonoBehaviour {
    public ParticleSystem psys;


    public void SetColor(int color)
    {
        if (color == 3)
        {
            psys.startColor = new Color(255 / 255f, 69 / 255f, 69 / 255f);
        }else if (color == 2)
        {
            psys.startColor = new Color(255 / 255f, 165 / 255f, 69 / 255f);
        }
        else if (color == 1)
        {
            psys.startColor = new Color(80 / 255f, 184 / 255f, 80 / 255f);
        }
        else if (color == 0)
        {
            psys.startColor = new Color(64 / 255f, 200 / 255f, 255 / 255f);
        }
    }
}
