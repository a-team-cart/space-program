using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class lightBtnController : MonoBehaviour
{
    // public variables -------------------------
    [Header("Button State")]
    public Sprite m_onSprite;                       // On sprite state
    public Sprite m_offSprite;                      // Off sprite state
    public Sprite m_onRectSprite;                   // On Rect sprite state
    public Sprite m_offRectSprite;                  // Off Rect sprite state
    public bool m_on;                               // If the btn is on or off
    [Header("Other Objects Linked")]
    public powerViewController[] m_mainViewBtn;     // Link to the btns on the main power view
    public powerTotalController m_totalBar;         // Total bar to send data to
    [Header("In Numbers")]
    public int m_btnValue;                          // Value of this btn in power (1 to 100)
    public float m_activatingChance;                // Chance that the btn get activated by itself

    // public variables -------------------------
    private Image m_longRect;                       // Long Rect image, child of this object
    private bool m_called = true;                   // Do a change of state one time in update (once called)
    private bool m_canGiveValue = false;            // Give value to total at start
    private float m_counter = 0.0f;                  // Counter for probability of activating a btn

    // ------------------------------------------
    // Start is called before update
    // ------------------------------------------
    void Start()
    {
        // Get the rectImage (first child of this object)
        m_longRect = gameObject.transform.GetChild(0).GetComponent<Image>();

        // On btns can give value at start
        if (m_on)
            m_canGiveValue = true;
    }


    // ------------------------------------------
    // Update is called once per frame
    // ------------------------------------------
    void Update()
    {
        // Change the state of the btn depending on its activation
        if (m_on && m_called)
            changeState(true);
        else if (m_called)        
            changeState(false);

        // Always check for a chance to light up
        if (!m_on && !m_totalBar.m_resolving)
            LightUpChance();
    }

    // ------------------------------------------
    // Methods
    // ------------------------------------------

    // Change the state of the btn -----------------------------------
    private void changeState(bool state)
    {
        // Do it once per call
        m_called = false;

        // Change btns srpite state
        if (state)
        {
            gameObject.GetComponent<Image>().sprite = m_onSprite;
            m_longRect.sprite = m_onRectSprite;
        }
        else
        {
            gameObject.GetComponent<Image>().sprite = m_offSprite;
            m_longRect.sprite = m_offRectSprite;
        }

        // Change state on the main view (for each existing btn linked)
        for (int i = 0; i < m_mainViewBtn.Length; i ++)
            m_mainViewBtn[i].changeState(state);

        // Give a power value to the total 
        // and secure initial value of power total
        if (m_canGiveValue)
            m_totalBar.receivePowerData(m_btnValue, state);
        else
            m_canGiveValue = true;
    }


    // Check based on probability to light up on its own ------------
    private void LightUpChance()
    {
        // Roll the probabilities each x seconds
        float roll = 10f;

        // Start timer
        m_counter += Time.deltaTime;

        // Check when a roll is due
        if (m_counter >= roll)
        {
            // Pick a random number and compare it with the btn chance
            float rando = Random.Range(0,100f);

            if (m_activatingChance >= rando)
                masterState(true);

            // Reset counter
            m_counter = 0f;
        }
    }


    // When btn get pressed -----------------------------------------
    public void GotPressed()
    {
        // If the player pressed the btn, inverse its state
        m_on = !m_on;

        // Activate change
        m_called = true;
    }


    // Receive command from btn master ------------------------------
    public void masterState(bool active)
    {
        // Get response from a on/off section master
        if (active)
            m_on = true;
        else
            m_on = false;

        // Activate change
        m_called = true;
    }
}
