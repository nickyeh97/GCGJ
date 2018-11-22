using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LauncherController : MonoBehaviour {

    Rigidbody2D rigidbody;
    bool isLaunching = false;
    bool hasPress = false;
    public Transform center;

    public float startSpeed;


	// Use this for initialization
	void Start () {

        rigidbody = GetComponent<Rigidbody2D>();

	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.A)) {

            Launch();
        }
        else if (Input.GetKeyDown(KeyCode.R))
        {

            SceneController.ChangeScene("Level1");
        }

    }

    private void FixedUpdate()
    {
        if (!isLaunching) {

            transform.RotateAround(center.position, Vector3.back, 2);

        }
    }

    void Launch() {

        if (!hasPress) {

            isLaunching = true;
            rigidbody.velocity = transform.up * startSpeed;
            //rigidbody.AddForce(transform.up * startSpeed);
            hasPress = true;
        }

    }
}
