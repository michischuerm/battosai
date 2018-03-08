﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stationaryControll : MonoBehaviour
{
	public Transform stationaryFixedHinge;
	private GameObject controllerInteractionBox;
	private List<SteamVR_TrackedObject> trackedObjs;
	private SteamVR_TrackedObject controller1;
	private SteamVR_TrackedObject controller2;
	private int controllersInBox = 0;

	// Use this for initialization
	void Start()
	{
		controllerInteractionBox = gameObject;
		trackedObjs = new List<SteamVR_TrackedObject>();
	}

	// Update is called once per frame
	void Update()
	{
		countControllers(trackedObjs);

		if (controllersInBox > 0)
		{
			Debug.Log("controllersInBox: " + controllersInBox);
		}

		if (controllersInBox >= 2)
		{

		}
	}

	private void OnTriggerEnter(Collider other)
	{
		//Debug.Log("Trigger Enter");
		addTrackedObjs(other);
	}

	private void OnTriggerStay(Collider other)
	{
	}

	private void OnTriggerExit(Collider other)
	{
		//Debug.Log("Trigger Exit");
		removeTrackedObjs(other);
	}

	private void addTrackedObjs(Collider collidingObj)
	{
		if (collidingObj.GetComponent<SteamVR_TrackedObject>() != null)
		{
			trackedObjs.Add(collidingObj.GetComponent<SteamVR_TrackedObject>());
		}
	}

	private void removeTrackedObjs(Collider collidingObj)
	{
		if (collidingObj.GetComponent<SteamVR_TrackedObject>() != null)
		{
			trackedObjs.Remove(collidingObj.GetComponent<SteamVR_TrackedObject>());
		}
	}

	private void countControllers(List<SteamVR_TrackedObject> objList)
	{
		controllersInBox = 0;

		objList.ForEach(delegate (SteamVR_TrackedObject obj)
		{
			checkForController(obj);
		});
	}

	private void checkForController(SteamVR_TrackedObject trackedObj)
	{
		if (isController(trackedObj))
		{
			controllersInBox++;
		}
	}

	private bool isController(SteamVR_TrackedObject trackedObj)
	{
		if (SteamVR_Controller.Input((int)trackedObj.index) == null)
		{
			Debug.Log("no index");
		}

		Debug.Log("tracked obj as controller: " + trackedObj);
		return true;
	}
}