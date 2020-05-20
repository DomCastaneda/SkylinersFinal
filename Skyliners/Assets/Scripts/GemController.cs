using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemController : MonoBehaviour
{
    public enum GemType
    {
        Point,
        EndGame
    }

    public GemType gemType;
    public int pointAmount = 0; 

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 10)
        {
            if (gemType == GemType.Point)
            {
                collision.gameObject.GetComponent<PlayerController>().hasGemType = true;
            }

            collision.gameObject.GetComponent<PlayerController>().pointAmount = pointAmount;

            Destroy(this.gameObject);
        }
    }
}
