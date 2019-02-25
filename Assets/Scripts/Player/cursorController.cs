using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cursorController : MonoBehaviour
{
    // public variables -------------------------
    public bool m_expandAnim;
    public bool m_returnAnim;
    

    // private variables ------------------------


    // ------------------------------------------
    // Start is called before update
    // ------------------------------------------
    void Start()
    {
        
        
    }

    // ------------------------------------------
    // Update is called once per frame
    // ------------------------------------------
    void Update()
    {
        // Cursor animation on terminals
        if (m_expandAnim)
            Expand();

        if (m_returnAnim)
            DefaultState();
    }

    // ------------------------------------------
    // Methods
    // ------------------------------------------
    private void Expand()
    {
        // Variables used for the animation
        RectTransform cursorTrans = gameObject.GetComponent<RectTransform>();
        float currentSize = cursorTrans.localScale.x;
        float step = 0.5f;

        // Get the size growing until it reaches max value
        if (currentSize < 3f)        
            currentSize += step;

        // Update the value of the cursor size
        cursorTrans.localScale = new Vector3(currentSize, currentSize, 1f);
    }


    private void DefaultState()
    {
        // Variables used for the animation
        RectTransform cursorTrans = gameObject.GetComponent<RectTransform>();
        float currentSize = cursorTrans.localScale.x;
        float step = 0.5f;

        // Get the size growing until it reaches min value
        if (currentSize > 1f)        
            currentSize -= step;
        
        // Update the value of the cursor size
        cursorTrans.localScale = new Vector3(currentSize, currentSize, 1f);
    }
}
