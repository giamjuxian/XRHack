using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.MagicLeap;

public class GestureHandler : MonoBehaviour
{

    private float speed = 30.0f;  // Speed of our tennisBall
    private float distance = 2.0f; // Distance between Main Camera and tennisBall
    public GameObject tennisBall; // Reference to our tennisBall
    private MLHandKeyPose[] gestures; // Holds the different gestures we will look for
    private bool holdingBall;

    void Awake()
    {
        MLHands.Start();

        gestures = new MLHandKeyPose[4];
        gestures[0] = MLHandKeyPose.Ok;
        gestures[1] = MLHandKeyPose.Fist;
        gestures[2] = MLHandKeyPose.OpenHandBack;
        gestures[3] = MLHandKeyPose.Finger;
        MLHands.KeyPoseManager.EnableKeyPoses(gestures, true, false);
        tennisBall.SetActive(false);
    }

    void OnDestroy()
    {
        MLHands.Stop();
    }

    void FixedUpdate()
    { 

        if (GetGesture(MLHands.Left, MLHandKeyPose.Fist)
        || GetGesture(MLHands.Right, MLHandKeyPose.Fist))
        {
            holdingBall = true;
            tennisBall.SetActive(true);
            tennisBall.transform.position = MLHands.Left.Index.KeyPoints[0].Position;
        }
        else {
            holdingBall = false;
        }
    }

    bool GetGesture(MLHand hand, MLHandKeyPose type)
    {
        if (hand != null)
        {
            if (hand.KeyPose == type)
            {
                if (hand.KeyPoseConfidence > 0.9f)
                {
                    return true;
                }
            }
        }
        return false;
    }
}