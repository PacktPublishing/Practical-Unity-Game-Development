using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DissolveController : MonoBehaviour {

    public Material dissolveMaterial;
    public float dissolveAmount;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.O))
        {
            dissolveAmount += 0.05f;
            dissolveMaterial.SetFloat("Vector1_97804D19", dissolveAmount);
        }
        if (Input.GetKeyDown(KeyCode.I))
        {
            dissolveAmount -= 0.05f;
            dissolveMaterial.SetFloat("Vector1_97804D19", dissolveAmount);
        }
    }
}
