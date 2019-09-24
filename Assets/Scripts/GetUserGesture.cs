using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.MagicLeap;

public class GetUserGesture : MonoBehaviour
{
    public static bool GetGesture (MLHand hand, MLHandKeyPose type) {
		if (hand != null) {
			if (hand.KeyPose == type) {
				if (hand.KeyPoseConfidence > 0.8f) {
					return true;
				}
			}
		}
		return false;
	}
}
