using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaseLight : MonoBehaviour {

    private Light pointLight;
    public bool done = false;
    public float lightLevel = 1;
    public GameObject overLight;
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
            
            if (!done)
            {
                pointLight.intensity += (Time.deltaTime * 0.5f);
                if(pointLight.intensity >= lightLevel)
                {
                    done = true;
                    overLight.SendMessage("LightOn", SendMessageOptions.DontRequireReceiver);
                }
            }
        }
    }
}
