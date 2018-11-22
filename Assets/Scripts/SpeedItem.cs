using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedItem : MonoBehaviour {

    [Range(0.0f,2.0f)]
    public float forceScale;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        AddForce(collision.gameObject);
    }

    void AddForce(GameObject rocket) {

        Rigidbody2D rigidbody2D;
        rigidbody2D = rocket.GetComponent<Rigidbody2D>();

        float rocketSpeed = rigidbody2D.velocity.magnitude;

        rigidbody2D.velocity = rigidbody2D.velocity * forceScale;

        if (forceScale > 1) {

            rocket.GetComponent<RocketObject>().AddSpeedAnim();
        }
    }


    Vector2 AbsVector(Vector2 v2) {

        Vector2 result = new Vector2(Mathf.Abs(v2.x), Mathf.Abs(v2.y));
        return result;
    }
}
