using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitalObject : MonoBehaviour {

	public float mass;
	public float radius;
	public Vector3 initialVelocity;
	Vector3 currentVelocity;

	public static UniversalConstants universalConstants;

	void Awake() {
		currentVelocity = initialVelocity;
	}

	public void GravityCalculator(float timeStep) {
		
		var orbitalObjects = GameObject.FindGameObjectsWithTag("OrbitalObject");
		foreach (var otherObject in orbitalObjects) {
			
			float distanceSqr = (otherObject.GetComponent<Rigidbody>().position - GetComponent<Rigidbody>().position).sqrMagnitude;
			if (distanceSqr == 0) {
				break;
			}

			float massMult = mass * otherObject.GetComponent<OrbitalObject>().mass;
			float gravitationalConstant = 0.00000000006673f;
			Vector3 forceDir = (otherObject.GetComponent<Rigidbody>().position - GetComponent<Rigidbody>().position).normalized;
			Vector3 force = (forceDir * gravitationalConstant * massMult) / distanceSqr;
			Vector3 acceleration = force / mass;

			currentVelocity += acceleration * timeStep;
		}
	}

	void UpdatePosition(float timeStep) {
		GetComponent<Rigidbody>().position += currentVelocity * timeStep;
	}

	void FixedUpdate() {
		GravityCalculator(Time.fixedDeltaTime*1);
		UpdatePosition(Time.fixedDeltaTime * 1);
	}
}
