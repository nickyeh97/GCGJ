using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Megnetic2D : MonoBehaviour {
    [SerializeField]
    float g_Force;
    [SerializeField]
    float addForceSpeed = 0.1f;
    [SerializeField]
    float angularSpeed;//角速度
    [SerializeField]
    RocketObject Rocket;
    Rigidbody2D RocketRigid;
    [SerializeField]
    Vector2 ForceDirection;
    [SerializeField]
    bool isAttraction;
    

    private PlanetObject m_planet;
    private float m_distance;
    void Start()
    {
        m_planet = GetComponent<PlanetObject>();
        RocketRigid = Rocket.GetComponent<Rigidbody2D>();
        m_distance = Vector2.Distance(GetComponent<Transform>().position, Rocket.GetComponent<Transform>().position);
        angularSpeed = 20f;
    }

    private void Update()
    {
        if (isAttraction)
        {
            TestForRotation();                    
        }
    }

    void TestForRotation()
    {
        Vector3 direction = ForceDirection;
        //float vol = m_distance * m_distance * m_distance;
        //angularSpeed = 6.67f * m_planet.mass / vol;       //  (GM/(r的3次方))1/2
        Rocket.GetComponent<Transform>().RotateAround(transform.position, Vector3.back, angularSpeed * Time.deltaTime);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        isAttraction = gameObject.GetComponentInChildren<GravityTrigger>().isAttraction;
        if (isAttraction)
        {
            Mathf.Min(1, m_distance);
            Attraction(m_planet.mass, m_distance);
        }
    }

    void Attraction(float M, float distance)
    {
        //Check the Diretion of the attration !
        m_distance = Vector2.Distance(GetComponent<Transform>().position, Rocket.GetComponent<Transform>().position);
        ForceDirection.x = GetComponent<Transform>().position.x - Rocket.GetComponent<Transform>().position.x;
        ForceDirection.y = GetComponent<Transform>().position.y - Rocket.GetComponent<Transform>().position.y;

        g_Force = 6.67f * M * Rocket.Rocketmass / distance;
        Rocket.GetComponent<Rigidbody2D>().AddForce(g_Force * ForceDirection * addForceSpeed * Time.fixedDeltaTime);

    }

}
