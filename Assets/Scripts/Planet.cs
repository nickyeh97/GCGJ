using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour {

    public bool isSelected;
    public float rangeMin = 0.5f;
    public float rangeMax = 2.0f;
    public Vector3 planetScale = Vector3.one;
	// Use this for initialization
	void Start () {
        isSelected = false;
        planetScale = transform.localScale;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
