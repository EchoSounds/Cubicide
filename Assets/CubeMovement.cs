using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMovement : Movement
{
    // Start is called before the first frame update

    public int moveSpeed = 20;

    void Update()
    {
        Move(this.gameObject, moveSpeed);
        //MoveBackward();
        //MoveLeft();
        //MoveRight();

    }
}

