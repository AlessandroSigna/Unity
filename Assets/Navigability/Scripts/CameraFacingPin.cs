using UnityEngine;
using System.Collections;

public class CameraFacingPin : MonoBehaviour {

    public Camera mainCamera;

    // Use this for initialization
    void Start ()
    {
        transform.LookAt(mainCamera.transform.position,
            mainCamera.transform.rotation * Vector3.up);
        Vector3 rotationV3 = transform.eulerAngles;
        rotationV3.x = 90;
        transform.rotation = Quaternion.Euler(rotationV3);
    }
}
