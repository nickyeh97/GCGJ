using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class AdjustRadius : MonoBehaviour {
    
    //public float rangeMin = 0.5f;
    //public float rangeMax = 2f;
    private Planet selectedPlanet;
    private Vector2 currentPos;
    private Vector2 previousPos;
    public Color planetOriginColor = Color.white;
    public Color planetSelectedColor = Color.gray;
    //private Vector3 planetScale;
    bool isSelecting = false;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Q) || Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(1);
        }
        if(isSelecting){
            UnselectObject();
        }
        else{
            SelectObject();
        }

        RadiusAdjustment();
	}

    void UnselectObject()
    {
        if (Input.GetButtonDown("Fire1") )
        {
            SpriteRenderer renderer;
            renderer = selectedPlanet.gameObject.GetComponent<SpriteRenderer>();
            selectedPlanet.isSelected = false;

            renderer.color = planetOriginColor;
            selectedPlanet = null;
            isSelecting = false;
            return;
        } 
    }
    void SelectObject()
    {
        
        if (Input.GetButtonDown("Fire1"))
        {
            RaycastHit2D hit;
            
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Vector2 origin = new Vector2(ray.origin.x, ray.origin.y);
            Vector2 direction = new Vector2(ray.direction.x, ray.direction.y);
            hit = Physics2D.Raycast(origin, direction);
            SpriteRenderer renderer;
            if (hit)
            {
                selectedPlanet = hit.transform.gameObject.GetComponent<Planet>();
                selectedPlanet.isSelected = !selectedPlanet.isSelected;
                renderer = hit.transform.gameObject.GetComponent<SpriteRenderer>();
                //planetScale = selectedPlanet.transform.localScale;
                isSelecting = true;
                renderer.color = selectedPlanet.isSelected ? planetSelectedColor : planetOriginColor;
                previousPos = Input.mousePosition;
            }
        }
    }

    void RadiusAdjustment()
    {
        if (selectedPlanet != null) {
            //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            //Vector2 origin = new Vector2(ray.origin.x, ray.origin.y);
            //Vector3 point = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 origin = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            currentPos = origin;
            //Debug.Log("PreP: " + previousPos);
            //Debug.Log("CurP: " + currentPos);
            Vector2 distance = currentPos - previousPos;
            //Debug.Log(distance);
            if (distance.x > 0f)
            {
                float range = Mathf.Clamp(distance.x / 10f, selectedPlanet.rangeMin, selectedPlanet.rangeMax);
                selectedPlanet.gameObject.transform.localScale = selectedPlanet.planetScale * range;
                //selectedPlanet.gameObject.transform.localScale 
            }
            else if(distance.x <0f)
            {
                //distance.x LARGE abs SHOULD HAVE SMALLER range 
                //range = Mathf.Clamp(distance.x / 10f * -1f , 1f, 2f);
                //selectedPlanet.gameObject.transform.localScale = planetScale * (1.0f/range) ;
            }

        }

    }

}
