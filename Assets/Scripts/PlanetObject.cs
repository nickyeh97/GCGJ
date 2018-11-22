using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetObject : MonoBehaviour
{
    public float mass;
    public float radius;
    public float rotateSpeed = 20f;

    private Planet m_planet;
    [SerializeField]
    private float new_mass;
    private float tep_mass;

    private void Start()
    {
        mass = 10f;
        m_planet = GetComponent<Planet>();
        new_mass = tep_mass = mass;
    }
    private void Update()
    {
        if (new_mass != mass)
        {
            new_mass = mass;
            tep_mass = new_mass;
        }

        if (m_planet.isSelected)
        {
            tep_mass = mass * transform.localScale.x;
        }
        else
        {
            if(tep_mass != mass) mass = tep_mass;            
        }

        transform.Rotate(new Vector3(0, 0, rotateSpeed * Time.deltaTime)) ;

#if UNITY_EDITOR
        Vector3 rotate = transform.rotation.eulerAngles; //獲得遊戲物件當前的旋轉值
        //Debug.Log("rotate is" + rotate);
#endif
    }
}
