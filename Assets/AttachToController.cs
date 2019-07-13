using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.MagicLeap;

public class AttachToController : MonoBehaviour
{

   // public Vector3[] pos;
    public GameObject racket;
   // public Quaternion rot;
    private MLInputController _controller;

    void Awake()
    {
        MLInput.Start();
        _controller = MLInput.GetController(MLInput.Hand.Left);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Debug.Log(_controller.Position);
        racket.transform.position = _controller.Position;
        racket.transform.rotation = _controller.Orientation;
    }
}
