using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmerMovement : PlayerMovement
{
    Vector3 CheckBoundary(Vector3 pos) 
    {
        if (pos.x > 7.5f)
            return new Vector3(-7.2f, pos.y, 0);

        if (pos.x < -7.2f)
            return new Vector3(7.5f, pos.y, 0);

        if (pos.y > 3)
            return new Vector3(pos.x, -5, 0);

        if (pos.y < -5)
            return new Vector3(pos.x, 3, 0);

        return pos;
    }
}
