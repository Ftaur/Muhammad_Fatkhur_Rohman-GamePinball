using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour
{
	public KeyCode input;
	// public float springPower;
    private float targetPressed;
    private float targetRelease;
	private HingeJoint hinge;
	public void Start()
    {
        hinge = GetComponent<HingeJoint>();
        // saat Start, kita set kedua target tersebut
        targetPressed = hinge.limits.max;
        targetRelease = hinge.limits.min;
    }

	private void Update()
    {
        ReadInput();
    }

  private void ReadInput()
  {
    JointSpring jointSpring = hinge.spring;
    // JointSpring jointSpring = GetComponent<HingeJoint>().spring;

    if (Input.GetKey(input))
	{
        jointSpring.targetPosition = targetPressed;
        // jointSpring.spring = springPower;
		// jointSpring.spring = 1000;
	}
	else
	{
        jointSpring.targetPosition = targetRelease;
		// jointSpring.spring = 0;
	}

    hinge.spring = jointSpring;
  }
}