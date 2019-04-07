using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fadeScreenController : MonoBehaviour
{
    // public variables -------------------------
    public float m_fadeSpeed;                       // Fading speed animation

    // private variables ------------------------
    private Image m_fadeScreen;                     // Fading screen (black image)
    private Color m_fadeColor;                      // The color of that image
    private bool bootUp;                            // Boot up at the start of the scene

    // ------------------------------------------
    // Start is called before update
    // ------------------------------------------
    void Start()
    {
        // For the fading effect
        m_fadeScreen = GetComponent<Image>();
        m_fadeColor = m_fadeScreen.color;

        StartCoroutine(Waiter());
    }

    // ------------------------------------------
    // Update is called once per frame
    // ------------------------------------------
    void Update()
    {
        // At the start of the program
        if (bootUp)
        {
            FadeIn(false);
        }
    	    
    }

    // ------------------------------------------
    // Methods
    // ------------------------------------------

    // Call this for fade effect ---------------------------------
    public void FadeIn(bool active)
    {
        if (active && m_fadeColor.a < 1f)
        {
            // Fade in
            m_fadeColor.a += m_fadeSpeed * Time.deltaTime;
            m_fadeScreen.color = m_fadeColor;
        }
        
        if (!active && m_fadeColor.a > 0f)
        {
            // Fade out
            m_fadeColor.a -= m_fadeSpeed * Time.deltaTime;
            m_fadeScreen.color = m_fadeColor;
        }

        // Check after boot up
        if (bootUp && m_fadeColor.a <= 0f)
            bootUp = false;
    }

    // Just wait a bit before fading -------------------------------
    private IEnumerator Waiter()
    {
        // Wait before starting the animation
        yield return new WaitForSeconds(1);
        bootUp = true;
    }
}
