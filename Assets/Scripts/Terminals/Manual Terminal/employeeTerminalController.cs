using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class employeeTerminalController : MonoBehaviour
{
    
    // public variables ------------------
    public GameObject m_dayNum;                 // Object that holds orbits Value
    public Slider m_progessDay;                 // The slider that shows the progress days
    public Text m_workNumber;                   // Number of the work engagement

    // private variables -----------------
    private GameObject m_gm;                    // The Gm present in the scene

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
        // Update the number of orbit
        orbitNumber();

        // Update work engagement number
        UpdateWork();

    }

    // -----------------------------------
    // Methods
    // -----------------------------------
    private void orbitNumber() 
    {
        int orbitIndex = m_gm.GetComponent<GameManager>().m_orbitNum;

        // Update the slider
        m_progessDay.value = orbitIndex;

        // Check if no null and how many 0 to put before variable
        if (m_dayNum && orbitIndex < 10)
            m_dayNum.GetComponent<Text>().text = "00" + orbitIndex;

        if (m_dayNum && orbitIndex >= 10)
            m_dayNum.GetComponent<Text>().text = "0" + orbitIndex;
    }


    private void UpdateWork()
    {
        float workIndex = m_gm.GetComponent<GameManager>()._evaluation;

        // No decimals
        workIndex = (int)workIndex;

        // Update the number
        m_workNumber.text = workIndex.ToString() + "%";
    }
}
