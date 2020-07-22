using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitalSimulation : MonoBehaviour
{
	OrbitalObject orbitalObject;
	public int timeScale;
	float timeStep;

	void FixedUpdate() {
		SimulationTimeStep();

		var orbitalTag = GameObject.FindGameObjectsWithTag("OrbitalObject");
		foreach (var obj in orbitalTag) {
			OrbitalObject orbitalObject = obj.GetComponent<OrbitalObject>();
			orbitalObject.GravityCalculator(timeStep);
			orbitalObject.UpdatePosition(timeStep);
			//Debug.Log(obj);
		}
	}

	public void SimulationTimeStep() {
		timeStep = Time.fixedDeltaTime * timeScale;
	}
}
