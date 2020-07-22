using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitalSimulation : MonoBehaviour
{
	OrbitalObject orbitalObject;
	public int timeScale;

	void FixedUpdate() {
		var orbitalObj = GameObject.FindGameObjectsWithTag("OrbitalObject");
		foreach (var obj in orbitalObj) {
			orbitalObject = obj.GetComponent<OrbitalObject>();
			//orbitalObject.GravityCalculator();
			//
			Debug.Log(Time.time);
		}
	}

	public void SimulationTimeStep(int timeScale) {


	}
}
