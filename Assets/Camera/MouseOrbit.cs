
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseOrbit : MonoBehaviour
{

    Vector3 offest;
    Vector3 target;

    Vector3 P1;

    float distance = 30.0f;
    float xSpeed = 250.0f;
    float ySpeed = 120.0f;
    float x = 0.0f;
    float y = 0.0f;
    float Speed = 40.0f;

    void Start()
    {

        var angles = transform.eulerAngles;
        x = angles.y;
        y = angles.x;

        target = new Vector3(0, 0, 0);
    }

    void LateUpdate()
    {
        if(Input.GetAxis("Mouse ScrollWheel")!=0)
        {
            float wheel = Input.GetAxis("Mouse ScrollWheel") * Time.deltaTime * 100;
            transform.Translate(Vector3.forward * wheel*10);
            P1 = transform.position;
            offest = transform.position - P1;
            target = target + offest;
            distance = (target - transform.position).magnitude;
        }
        

        if (Input.GetMouseButton(0))
        {
            x += Input.GetAxis("Mouse X") * xSpeed * 0.02f;
            y -= Input.GetAxis("Mouse Y") * ySpeed * 0.02f;

            var rotation = Quaternion.Euler(y, x, 0);
            var position = rotation * new Vector3(0.0f, 0.0f, -distance) + target;

            transform.rotation = rotation;
            transform.position = position;
        }
        else if (Input.GetMouseButton(1))
        {

            float x;
            float y;
            x = Input.GetAxis("Mouse X");
            y = Input.GetAxis("Mouse Y");
            transform.Translate(new Vector3(-x, -y, 0) * Time.deltaTime * Speed);
        }

        if (Input.GetMouseButtonDown(1))
        {
            P1 = transform.position;
        }
        if (Input.GetMouseButtonUp(1))
        {
            offest = transform.position - P1;
            target = target + offest;
            distance = (target - transform.position).magnitude;
        }
    }
}