using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform CameraAxisTransform;

    private float _minAngle = -8;
    private float _maxAngle = 30;
    private float _RotationSpeed = 600;

    void Update()
    {
        var newAngleY = transform.localEulerAngles.y + Time.deltaTime * _RotationSpeed * Input.GetAxis("Mouse X");
        transform.localEulerAngles = new Vector3(0, newAngleY, 0);

        var newAngleX = CameraAxisTransform.localEulerAngles.x - Time.deltaTime * _RotationSpeed * Input.GetAxis("Mouse Y");
        if (newAngleX > 180)
            newAngleX -= 360;
        newAngleX = Mathf.Clamp(newAngleX, _minAngle, _maxAngle);

        CameraAxisTransform.localEulerAngles = new Vector3(newAngleX, 0, 0);
    }
}
