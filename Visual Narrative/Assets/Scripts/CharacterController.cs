using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    private Rigidbody2D player;
    private Vector2 characterVector;
    public float moveSpeed = 25;
    // Use this for initialization
    void Start()
    {
        player = this.GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale != 0)
        {
            characterVector.y = Input.GetAxis("Vertical");
            characterVector.x = Input.GetAxis("Horizontal");
            if (player.velocity.magnitude > 0)
            {
                player.velocity = Vector2.zero;
            }
            if (characterVector.x == 0 && characterVector.y == 0)
            {
                player.velocity = Vector2.zero;
            }
            player.transform.Translate(characterVector.x * moveSpeed * Time.deltaTime, characterVector.y * moveSpeed * Time.deltaTime, 0);
        }
    }
}
