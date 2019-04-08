using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerData : MonoBehaviour
{

    // public variables ------------------
    public GameObject m_workUI;             // work slider object on the ui
    public GameObject m_restUI;             // rest slider object on the ui
    public GameObject m_creditUI;           // credit value object on the ui

    // private variables -----------------
    private GameObject m_gm;                // GM in the scene
    private float m_workValue;              // Value of work 1 to 100
    private float m_restValue;              // Value of rest 1 to 100
    private float m_creditValue;            // Value of credit.

    // -----------------------------------
    // Start is called before update
    // -----------------------------------
    void Start()
    {
        // Get the gm
        m_gm = GameObject.FindWithTag("GameController");
    }

    // -----------------------------------
    // Update is called once per frame
    // -----------------------------------
    void Update()
    {
        // Check for the different values
        m_workValue = m_gm.GetComponent<GameManager>()._evaluation;
        m_restValue = m_gm.GetComponent<GameManager>()._energy;
        m_creditValue = m_gm.GetComponent<GameManager>()._credit;

        // Round up
        m_workValue = (int)m_workValue;
        m_restValue = (int)m_restValue;

        // Update the ui for feedback
        m_workUI.GetComponent<Text>().text = m_workValue.ToString();
        m_restUI.GetComponent<Text>().text = m_restValue.ToString();
        m_creditUI.GetComponent<Text>().text = m_creditValue.ToString();
    }

    // -----------------------------------
    // Methods
    // -----------------------------------
}
