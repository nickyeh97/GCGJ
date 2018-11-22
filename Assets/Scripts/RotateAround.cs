using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAround : MonoBehaviour {

    public Transform target;
    public float angleSpeed;
    Rigidbody2D rigidbody2d;

    private void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        //transform.RotateAround(center.position, Vector3.back, angleSpeed);

        Vector2 vector2 = new Vector2(target.position.x, target.position.y);
        var direction = (vector2 - rigidbody2d.position).normalized;
        var rotation = Quaternion.AngleAxis(60, Vector3.forward) * direction ;
        var desired = new Vector2(rotation.x, rotation.y);
        var change = desired * angleSpeed - rigidbody2d.velocity;

        rigidbody2d.AddForce(change * Time.deltaTime);


    }
}
