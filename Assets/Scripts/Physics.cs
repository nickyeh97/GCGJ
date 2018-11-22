using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Physics : MonoBehaviour {
    [SerializeField]
    float g_Force;
    [SerializeField]
    RocketObject Rocket;
    [SerializeField]
    Rigidbody RocketRigid;
    [SerializeField]
    Vector3 ForceDirection;
    [SerializeField]
    bool isAttraction;

    private PlanetObject m_planet;
    private float m_distance;
    void Start () {
        m_planet = GetComponent<PlanetObject>();
        Vector3 Force = GetComponent<Transform>().position - Rocket.GetComponent<Transform>().position;
        m_distance = Force.magnitude;
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        if (isAttraction)
        {
            Attraction(m_planet.mass, m_distance);
        }
	}

    void Attraction(float M,float distance)
    {
        
        g_Force = 9.8f * M * Rocket.Rocketmass / Mathf.Min(1, Vector3.Distance(transform.position, Rocket.transform.position));
        Rocket.GetComponent<Rigidbody>().AddForce(g_Force * ForceDirection * 0.001f);

#if UNITY_EDITOR
        Debug.LogFormat("分子 = {0}, 分母 = {1}, Distance ={2} , 分子", 9.8f * M * Rocket.Rocketmass, Vector3.Distance(transform.position, Rocket.transform.position), distance);
#endif
    }

    private void OnTriggerStay(Collider other)
    {
        isAttraction = true;

        Debug.Log("Rocket is staying the TriggerArea!");
        //Check the Diretion of the attration !
        Vector3 Force = GetComponent<Transform>().position - Rocket.GetComponent<Transform>().position;
        ForceDirection = Force.normalized;
        m_distance = Force.magnitude;
    }

    private void OnTriggerExit(Collider other)
    {
        isAttraction = false;

        Debug.Log("Rocket exits the TriggerArea!");
    }
}
