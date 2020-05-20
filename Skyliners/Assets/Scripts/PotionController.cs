using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionController : MonoBehaviour
{
    public enum PotionType
    {
        Stamina
    }

    public PotionType potionType;
    public int potionModAmount = 0; //amount of stamina recovery

    private float floatingTimer = 0f;
    private float floatingMax = 1f;
    private float floatingDir = 0.01f;

    private void FixedUpdate()
    {
        if(floatingTimer < floatingMax)
        {
            transform.position = new Vector2(transform.position.x, transform.position.y + floatingDir);
            floatingTimer += Time.fixedDeltaTime;
        }
        else
        {
            floatingDir *= -1;
            floatingTimer = 0f;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 10)
        {
            if(potionType == PotionType.Stamina)
            {
                collision.gameObject.GetComponent<PlayerController>().hasStaminaPotion = true;
            }

            collision.gameObject.GetComponent<PlayerController>().potionModAmount = potionModAmount;

            Destroy(this.gameObject);
        }
    }
}
