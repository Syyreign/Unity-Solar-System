﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitalObject : MonoBehaviour {

	public float mass;
	public float radius;
	public Vector3 initialVelocity;
	public Vector3 currentVelocity;

	public static UniversalConstants universalConstants;

	void Start() {
		currentVelocity = initialVelocity;
	}

	public void GravityCalculator(float timeStep) {
		
		var orbitalTag = FindObjectsOfType<OrbitalObject>();
		foreach (var otherObject in orbitalTag) {
			//Debug.Log(otherObject +""+ this);
			//Debug.Log(otherObject == this);
			if (otherObject != this) {
				float distanceSqr = (otherObject.GetComponent<Rigidbody>().position - GetComponent<Rigidbody>().position).sqrMagnitude;

				float massMult = mass * otherObject.GetComponent<OrbitalObject>().mass;
				float gravitationalConstant = 0.00000000006673f;
				Vector3 forceDir = (otherObject.GetComponent<Rigidbody>().position - GetComponent<Rigidbody>().position).normalized;
				Vector3 force = (forceDir * gravitationalConstant * massMult) / distanceSqr;
				Vector3 acceleration = force / mass;

				currentVelocity += acceleration * timeStep;
			}
		}
	}


	public void UpdatePosition(float timeStep) {
		GetComponent<Rigidbody>().position += currentVelocity * timeStep;
	}
}
