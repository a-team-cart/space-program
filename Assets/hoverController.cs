using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class hoverController : MonoBehaviour
{
    // public variables -------------------------


    // private variables ------------------------
    private Image m_border;                         // The image of the border
    private float m_speed = 1f;                     // The speed of the animation
    private Color m_borderColor;                    // The color of the border

    // ------------------------------------------
    // Start is called before update
    // ------------------------------------------
    void Start()
    {
        // Get the image
        m_border = GetComponent<Image>();
        m_borderColor = m_border.color;
     	   
    }

    // ------------------------------------------
    // Methods
    // ------------------------------------------
    
    // Make the border appear or dissapear --------------------------------
    public void HoverEffect(bool active)
    {
        if (active && m_borderColor.a < 0.25f)
        {
            // Fade in 
            m_borderColor.a += m_speed * Time.deltaTime;
            m_border.color = m_borderColor;
        }
        
        if (!active && m_borderColor.a > 0f)
        {
            // Fade out
            m_borderColor.a -= m_speed * Time.deltaTime;
            m_border.color = m_borderColor;
        }
        
    }
}
