using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaseLight : MonoBehaviour {

    private Light pointLight;
	// Use this for initialization
	void Start () {
        pointLight = GetComponent<Light>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerStay2D(Collider2D other)
    {

        if (other.gameObject.tag == "player")
        {
            Debug.Log("Light Triggered");
            if (pointLight.intensity < 1)
            {
                pointLight.intensity += (Time.deltaTime * 0.5f);
            }
        }
    }
}
