using UnityEngine;
using System.Collections;
public class MouseLook : MonoBehaviour
{
    // enum to set values by name instead of number.
    // makes code more readable!
    public enum RotationAxes
    {
        MouseXAndY,
        MouseX,
        MouseY
    }

    public float speed = 50f;

    public float sensitivityHoriz = 9.0f;

    public float sensitivityVert = 9.0f;
    public float minVert = -45.0f;
    public float maxVert = 45.0f;

    private float rotationX = 0.0f;

    // public class-scope variable so it shows up in Inspector
    public RotationAxes axes = RotationAxes.MouseXAndY;
    // Update is called once per frame

    void Update()
    {
        if (axes == RotationAxes.MouseX)
        {
            float deltaHoriz = Input.GetAxis("Mouse X") * sensitivityHoriz;
            transform.Rotate(Vector3.up * deltaHoriz);
        }
        else if (axes == RotationAxes.MouseY)
        {
            rotationX -= Input.GetAxis("Mouse Y") * sensitivityVert;
            rotationX = Mathf.Clamp(rotationX, minVert, maxVert);
            transform.localEulerAngles = new Vector3(rotationX, 0, 0);
        }
        else
        {
            rotationX -= Input.GetAxis("Mouse Y") * sensitivityVert;
            rotationX = Mathf.Clamp(rotationX, minVert, maxVert);
            float deltaHoriz = Input.GetAxis("Mouse X") * sensitivityHoriz;
            float rotationY = transform.localEulerAngles.y + deltaHoriz;
            transform.localEulerAngles = new Vector3(rotationX, rotationY, 0);
        }
    }
}
