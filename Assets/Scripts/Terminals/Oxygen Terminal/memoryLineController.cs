using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class memoryLineController : MonoBehaviour
{
    // public variables -------------------------
    public Image m_redBtnH;                         // The red button on the left (h column)
    public Image m_redBtnW;                         // The red button on the right (w colomn)
    public memoryController m_memory;               // Controls the memory 
    [Header("Btn Probabilities")]
    public float m_rightChance;                     // Chance to get the right btn to turn off
    public float m_leftChance;                      // Chance to get the left btn to turn off
    [Space(10)]
    public float m_rollInterval;                    // The number of seconds it takes before doing a roll (probabilities)
    public int m_channelSection;                    // Determine in which channel this object is
    [Header("Sprites")]
    public Sprite m_emptyBtn;                       // Sprite to display when the btn is empty
    public Sprite m_fullBtn;                        // Sprite to display when the btn is full

    // private variables ------------------------
    private Image m_greenBtn;                       // The green button attached to this object
    private float m_counter = 0.0f;                 // Counter that will launch the probabilities
    private bool m_leftState;                       // The state of the left btn
    private bool m_rightState;                      // The state of the right btn
    private bool m_rowOverload;                     // State if the btn row have an error or not


    // ------------------------------------------
    // Start is called before update
    // ------------------------------------------
    void Start()
    {
        // Get the green btn image
        m_greenBtn = gameObject.GetComponent<Image>();

        // Start the game with those values
        m_redBtnH.sprite = m_emptyBtn;
        m_redBtnW.sprite = m_emptyBtn;
        m_greenBtn.sprite = m_fullBtn;

        m_rightState = false;
        m_leftState = false;
    }


    // ------------------------------------------
    // Update is called once per frame
    // ------------------------------------------
    void Update()
    {
        // Always check if a red btn get activated
        if (!m_leftState || !m_rightState)
            CheckRedBtn();

        // Check if both red btns are on
        if (m_leftState || m_rightState)
            Overload();
    }


    // ------------------------------------------
    // Methods
    // ------------------------------------------

    // Check if there's a red btn that get activated -------------------
    private void CheckRedBtn()
    {
        // Get the counter to work
        m_counter += Time.deltaTime;

        // Once it's time for a roll
        if (m_counter >= m_rollInterval)
        {
            // Check the left btn 
            // Pick a random number and compare it to the btn's probability
            float leftRando = Random.Range(0f, 100f);

            if (m_leftChance >= leftRando && !m_leftState)
            {
                ChangeState(m_redBtnH, true);
                m_leftState = true;
            }

            // Check the right btn 
            // Pick a random number and compare it to the btn's probability
            float rightRando = Random.Range(0f, 100f);

            if (m_rightChance >= leftRando && !m_rightState)
            {
                ChangeState(m_redBtnW, true);
                m_rightState = true;
            }

            // Reset the counter
            m_counter = 0.0f;
        }
    }


    private void Overload()
    {
        // Change the sprite of the green btn
        ChangeState(m_greenBtn, false);

        // The row is overload
        if (!m_rowOverload)
        {
            m_rowOverload = true;
            m_memory.ErrorCount(m_channelSection, true);
        }

    }


    // Check if there's a red btn that get activated -------------------
    private void ChangeState(Image targetBtn, bool active)
    {
        // Chose a sprite depending on the state of the btn
        if (active)
            targetBtn.sprite = m_fullBtn;
        else
            targetBtn.sprite = m_emptyBtn;
    }


    // Reset the row to its default state -------------------------------
    public void ResetRow(bool direction)
    {
        // Reset value of the btns (true for oxygen, false for water)
        if (direction)
        {
            ChangeState(m_redBtnH, false);
            m_leftState = false;
        }
        else
        {
            ChangeState(m_redBtnW, false);
            m_rightState = false;
        }
        
        // Reset the green btn
        ChangeState(m_greenBtn, true);

        // No more overload, resolve errors
        m_memory.ErrorCount(m_channelSection, false);
        m_rowOverload = false;
    }
}
