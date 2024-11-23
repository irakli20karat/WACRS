using System;
using UnityEngine;

public class WeaponCamera : MonoBehaviour
{

    public float minimumFov = 0.01f;

    public float[] zoomLevels = { 1, 50, 100}; 

    public float diviser = 10;

    public float sensitivityX = 15F;
    public float sensitivityY = 15F;

    public float minimumX = -60f;
    public float maximumX = 60f;

    public float minimumY = -60F;
    public float maximumY = 60F;

    float rotationY = 0F;
    float rotationX = 0F;

    public float dividedSensitivityX;
    public float dividedSensitivityY;

    public float finalFov;

    public Camera camera;

    void Start() 
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        
        rotationX = transform.localEulerAngles.y;
        if (rotationX > 180) rotationX -= 360;

        dividedSensitivityX = sensitivityX / diviser;
        dividedSensitivityY = sensitivityY / diviser;

        setZoomLevel(3);
    }

    void setZoomLevel(int zoomLevel) {
        float normalizedZoomLevel = zoomLevels[zoomLevel - 1] / 100;

        finalFov = normalizedZoomLevel * 100 * minimumFov;

        camera.fieldOfView = finalFov;

        float inversedNormalizedZoomLevel = 1 / normalizedZoomLevel;

        dividedSensitivityX = sensitivityX / diviser / inversedNormalizedZoomLevel;
        dividedSensitivityY = sensitivityY / diviser / inversedNormalizedZoomLevel;
    }

    void Update()
    {
        rotationX += Input.GetAxis("Mouse X") * dividedSensitivityX;
        rotationY += Input.GetAxis("Mouse Y") * dividedSensitivityY;

        rotationX = Mathf.Clamp(rotationX, minimumX, maximumX);
        rotationY = Mathf.Clamp(rotationY, minimumY, maximumY);

        transform.localEulerAngles = new Vector3(-rotationY, rotationX, 0);

        if (Input.GetKeyDown(KeyCode.Alpha1)) {
            setZoomLevel(1);
        } else if (Input.GetKeyDown(KeyCode.Alpha2)) {  
            setZoomLevel(2);
        } else if (Input.GetKeyDown(KeyCode.Alpha3)) {
            setZoomLevel(3);
        }
    }
}
