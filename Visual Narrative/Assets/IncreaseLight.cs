using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaseLight : MonoBehaviour {

    private Light pointLight;
    public bool done = false;
    public float lightLevel = 1;
    public GameObject overLight;
	public GameObject location;
    public AudioSource audioSource;
	// Use this for initialization
	void Start () {
        pointLight = GetComponent<Light>();
        audioSource = GetComponentInParent<AudioSource>();
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
                audioSource.volume += (Time.deltaTime * 0.5f / lightLevel);
                if(pointLight.intensity >= lightLevel)
                {
                    done = true;
					StartCoroutine (Move (location.transform.position));
                    overLight.SendMessage("LightOn", SendMessageOptions.DontRequireReceiver);
                }
            }
        }
    }
	public IEnumerator Move(Vector3 toPosition) {
		Vector3 fromPosition = transform.position;
		float duration = 1.75f;
		for (float t=0f;t<duration;t+=Time.deltaTime) {
			transform.position = Vector3.Lerp(fromPosition, toPosition, t/duration);
			yield return 0;
		}
		transform.position = toPosition;
	}
}
