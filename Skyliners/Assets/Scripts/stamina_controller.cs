using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class stamina_controller : MonoBehaviour
{

    public int stamina = 100;
    // Start is called before the first frame update

    // Update is called once per frame
    public void UpdateStamina()
    {
        GetComponent<Text>().text = "Stamina: " + stamina;

        if (stamina <= 0)
        {
            SceneManager.LoadScene("GameOver");
        }
    }
}
