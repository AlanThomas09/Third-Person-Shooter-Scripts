using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneMovement : MonoBehaviour
{
    public float speed;
    public float maxSpeed;
    public float minSpeed;
    public float rotSpeed1;
    public float rotSpeed2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * Time.deltaTime * speed;

        if (Input.GetKey(KeyCode.W))
        {
            if(speed < maxSpeed)
            {
                speed++;
            }
        }

        if (Input.GetKey(KeyCode.S))
        {
            if (speed > maxSpeed)
            {
                speed--;
            }
        }

        speed -= transform.forward.y * Time.deltaTime * 50;

        if(speed < 70)
        {
            speed = 70.0f;
        }

        if (speed > 500)
        {
            speed = 70.0f;
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(Vector3.forward * rotSpeed1 * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(Vector3.back * rotSpeed1 * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Rotate(Vector3.left * rotSpeed1 * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Rotate(Vector3.right * rotSpeed1 * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(-Vector3.up * rotSpeed1 * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(-Vector3.down * rotSpeed1 * Time.deltaTime);
        }


    }
}
