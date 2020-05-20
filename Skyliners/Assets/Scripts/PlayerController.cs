using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float velocityUp = 3;
    public float velocityRight = 1;
    private Rigidbody2D rb;

    private Text stamText;

    public int stamina = 100;

    public AudioClip jumpClip;

    public bool hasStaminaPotion = false;
    public int potionModAmount = 0;

    //main audio
    public AudioClip mainAudio;


    // Start is called before the first frame update
    void Start()
    {
        AudioSource.PlayClipAtPoint(mainAudio, transform.position);
        rb = GetComponent<Rigidbody2D>();

        stamText = GameObject.Find("StaminaText").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (stamina > 0)
        {
            if (Input.GetMouseButtonDown(0))
            {
                //jump
                rb.velocity = (Vector2.up * velocityUp) + (Vector2.right * velocityRight);
                AudioSource.PlayClipAtPoint(jumpClip, transform.position);
                stamText.GetComponent<stamina_controller>().stamina -= 2;
                stamText.GetComponent<stamina_controller>().UpdateStamina();
            }

        }else if(stamina <= 0)
        {

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        if (hasStaminaPotion)
        {
            stamText.GetComponent<stamina_controller>().stamina += potionModAmount;
            hasStaminaPotion = false;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(collision.gameObject);
        if (collision.gameObject.tag == "Enemy")
        {
            stamText.GetComponent<stamina_controller>().stamina -= 5;
            stamText.GetComponent<stamina_controller>().UpdateStamina();
        }
    }
}
