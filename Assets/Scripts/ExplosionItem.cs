using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionItem : MonoBehaviour {

    public GameObject explosionObj;

    public GameObject losePanel;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {

            //other.GetComponent<RocketObject>().Explosion();
            GameObject gameObject = Instantiate(explosionObj, other.transform.position, Quaternion.identity);
            gameObject.GetComponent<Animator>().SetTrigger("explosion");
            SceneController.PlayExplosionAudio();
            Destroy(other.gameObject);

            losePanel.SetActive(true);
            //other.GetComponent<RocketObject>().Explosion();
            
        }
    }



}
