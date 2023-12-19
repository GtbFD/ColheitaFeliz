using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{

    private Camera _camera;
    private float _sensitivity;

    private float _aditionalSensi;
    void Start()
    {
        _camera = transform.GetComponent<Camera>();
        _sensitivity = 50f;
        _aditionalSensi = 20f;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            var mousePositionX = Input.GetAxis("Mouse X");
            var mousePositionY = Input.GetAxis("Mouse Y");

            var vectorMousePosition = new Vector3(-mousePositionX, -mousePositionY, 0);
            
            transform.Translate(vectorMousePosition * MoveSmooth());
        }

        if (Input.mouseScrollDelta.y != 0)
        {
            _camera.fieldOfView += Input.mouseScrollDelta.y * MoveSmooth() * _aditionalSensi;
        }
    }

    float MoveSmooth()
    {
        return Time.deltaTime * _sensitivity;
    }
}
