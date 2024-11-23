using System;
using UnityEngine;

public class WeaponCamera : MonoBehaviour
{
    public float sensitivityX = 15F;
    public float sensitivityY = 15F;

    public float minimumX = -60f;
    public float maximumX = 60f;

    public float minimumY = -60F;
    public float maximumY = 60F;

    float rotationY = 0F;
    float rotationX = 0F;

    void Start() 
    {
        rotationX = transform.localEulerAngles.y;
        if (rotationX > 180) rotationX -= 360;
    }

    void Update()
    {
        rotationX += Input.GetAxis("Mouse X") * sensitivityX;
        rotationY += Input.GetAxis("Mouse Y") * sensitivityY;

        rotationX = Mathf.Clamp(rotationX, minimumX, maximumX);
        rotationY = Mathf.Clamp(rotationY, minimumY, maximumY);

        transform.localEulerAngles = new Vector3(-rotationY, rotationX, 0);
    }
}
