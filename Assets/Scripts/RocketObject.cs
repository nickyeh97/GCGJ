using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class RocketObject : MonoBehaviour {
    public float Rocketmass = 10f;
    Animator animator;
    public GameObject explosionObj;

    void Start()
    {
        Rocketmass = GetComponent<Rigidbody2D>().mass;
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GetComponent<Rigidbody>().AddForce(Vector3.up * 10);
        }
    }

    public void AddSpeedAnim() {

        //animator.SetTrigger("addSpeed");
    }

    public void Explosion() {
        Destroy(gameObject);
        explosionObj.transform.position = transform.position;
        explosionObj.GetComponent<Animator>().SetTrigger("explosion");

    }


}
