using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float velocityUp = 3;
    public float velocityRight = 1;
    private Rigidbody2D rb;

    public AudioClip jumpClip;

    //main audio
    public AudioClip mainAudio;


    // Start is called before the first frame update
    void Start()
    {
        AudioSource.PlayClipAtPoint(mainAudio, transform.position);
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            //jump
            rb.velocity = (Vector2.up * velocityUp) + (Vector2.right * velocityRight);
            AudioSource.PlayClipAtPoint(jumpClip, transform.position);
        }
    }
}
