using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class powerViewController : MonoBehaviour
{
    // public variables -------------------------
    public Sprite m_onSprite;                       // On sprite used by the btn
    public Sprite m_offSprite;                      // Off sprite used by the btn


    // ------------------------------------------
    // Methods
    // ------------------------------------------
    public void changeState(bool active)
    {
        // Change the btn from the data received from light control
        if (active)
            gameObject.GetComponent<Image>().sprite = m_onSprite;
        else
            gameObject.GetComponent<Image>().sprite = m_offSprite;

    }
}
