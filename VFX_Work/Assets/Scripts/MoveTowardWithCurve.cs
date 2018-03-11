using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTowardWithCurve : MonoBehaviour 
{

	Vector3 startPos = new Vector3(0, 0, 0);
	Vector3 endPos = new Vector3(0, 0, 10);
 	float trajectoryHeight = 5;

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		
		// calculate current time within our lerping time range
		float cTime = Time.time * 0.2f;

		// calculate straight-line lerp position:
		Vector3 currentPos = Vector3.Lerp(startPos, endPos, cTime);

		// add a value to Y, using Sine to give a curved trajectory in the Y direction
		currentPos.y += trajectoryHeight * Mathf.Sin(Mathf.Clamp01(cTime) * Mathf.PI);

		// finally assign the computed position to our gameObject:
		transform.position = currentPos;

	}
}
