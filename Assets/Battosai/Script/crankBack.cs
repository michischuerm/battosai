﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crankBack : MonoBehaviour
{
	public float distanceToStartCranked = 0.0f;
	public float crankToDistanceFactor = 1.0f;
	public float fixedUpdateDistanceDelta = 0.0f;
	private HingeJoint hingeJoint;
	private float radius;
	private float lastFixedUpdateAngle = 0.0f;

	// Use this for initialization
	void Start ()
	{
		hingeJoint = GetComponent<HingeJoint>();
		
		if (hingeJoint != null)
		{
			radius = Vector3.Magnitude(hingeJoint.anchor);
		}
		else
		{
			Debug.Log("No Hinge Joint on this Object");
		}
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	private void FixedUpdate()
	{
		// distance travelled this update. calulating the arc and set the sign for the direction
		float angle = hingeJoint.angle;
		Debug.Log("velocity: " + hingeJoint.velocity);
		Debug.Log("angle: " + angle);
		float deltaAngle = deltaDegree(Mathf.Abs(angle), lastFixedUpdateAngle);
		Debug.Log("deltaAngle: " + deltaAngle);
		this.lastFixedUpdateAngle = angle;
		//this.fixedUpdateDistanceDelta = hingeJoint.angle / 360 * Mathf.PI * 2 * radius * Mathf.Sign(hingeJoint.velocity);
		this.fixedUpdateDistanceDelta = angle / 360 * Mathf.PI * 2 * radius * Mathf.Sign(hingeJoint.velocity);
		// calculated distance travelled with factor. Relative to the start.
		this.distanceToStartCranked += crankToDistanceFactor * fixedUpdateDistanceDelta;
		//Debug.Log("distanceCranked: " + distanceToStartCranked);
		//Debug.Log("fixedUpdateDistanceDelta: " + fixedUpdateDistanceDelta);
	}

	// takes values from 0 to 360
	private float deltaDegree(float angle, float previousAngle, float velocity)
	{
		// two special cases:
		// velocity is positive, previousAngle greater then new
		// then 360 - previousAngle + new angle
		//
		// case two:
		// velocity is negative, previousAngle less then new
		// then previousAngle + 360 - new angle
		// 
		// all other cases:
		// when velo positive
		// new angle - previous
		//
		// velo negative
		// previous - new angle
		return -1.0f;
	}
}
