using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Movement : MonoBehaviour
{

    protected string up = "W";


    protected void Move(GameObject thing, int speed)
    {
        if (Input.GetKey(KeyCode.W) == true && thing.transform.position.z <= 10)
        {
            this.transform.position += this.transform.forward * Time.deltaTime * speed;
        }
        if (Input.GetKey(KeyCode.S) == true)
        {
            this.transform.position -= this.transform.forward * Time.deltaTime * speed;
        }
        if (Input.GetKey(KeyCode.Q) == true)
        {
            this.transform.position += this.transform.up * Time.deltaTime * speed;
        }
        if (Input.GetKey(KeyCode.E) == true)
        {
            this.transform.position -= this.transform.up * Time.deltaTime * speed;
        }
        if (Input.GetKey(KeyCode.A) == true)
        {
            this.transform.position -= this.transform.right * Time.deltaTime * speed;
        }
        if (Input.GetKey(KeyCode.D) == true)
        {
            this.transform.position += this.transform.right * Time.deltaTime * speed;

        }
    }
}
/*if (Input.GetKey(KeyCode.W) == true)
        {
            this.transform.position += this.transform.forward * moveSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S) == true)
        {
            this.transform.position -= this.transform.forward * moveSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D) == true)
        {
            this.transform.position += this.transform.right * moveSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A) == true)
        {
            this.transform.position -= this.transform.right * moveSpeed * Time.deltaTime;
        }
protected void MoveForward(int speed)
{
    this.transform.position += this.transform.forward * moveSpeed * Time.deltaTime * speed;
}
protected void MoveBackward(int speed)
{
    this.transform.position -= this.transform.forward * moveSpeed * Time.deltaTime * speed;
}
protected void MoveLeft(int speed)
{
    this.transform.position += this.transform.right * moveSpeed * Time.deltaTime * speed;
}
protected void MoveRight(int speed)
{
    this.transform.position -= this.transform.right * moveSpeed * Time.deltaTime * speed;
}
protected void MoveUp(int speed)
{
    this.transform.position += this.transform.up * moveSpeed * Time.deltaTime * speed;
}
protected void MoveDown(int speed)
{
    this.transform.position -= this.transform.up * moveSpeed * Time.deltaTime * speed;
}*/
