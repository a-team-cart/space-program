using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerTerminal : MonoBehaviour
{

	[Header("Power values")]
    
    //timers and variables
    public float totalPower = 100f;
    public float targetTime = 10f;
    public float resetTime;
    public float voiceWarningTargetTime = 5.0f;

    //components
	AudioSource _audioSrc;
	BoxCollider _boxCol;
	Light _lightSrc;

    // Start is called before the first frame update
    void Start()
    {
    	//init function at the start
    	init();   
    }

    // Update is called once per frame
    void Update()
    {
    	//the behaviour of the power in the shuttle
        PowerBehaviour();
    }

    public void init(){
    	//assign default times
    	resetTime = targetTime;

    	//fetch the components
    	_audioSrc = gameObject.GetComponent<AudioSource>();
    	_boxCol = gameObject.GetComponent<BoxCollider>(); 
    	_lightSrc = GameObject.FindGameObjectWithTag("_Light").GetComponent<Light>();   	
    }

    public void PowerBehaviour(){

    	//constrain values
    	// .........

    	//calculating timers over time
    	targetTime -= Time.deltaTime;

    	//if it reaches under , warning voice plays
    	if(targetTime <= voiceWarningTargetTime)
    		_audioSrc.Play();

    	//if it reaches under , power shuts down
    	if(targetTime <= 0) {
    		_lightSrc.enabled = false;
    	}
    	else {
    		//reset
    		_lightSrc.enabled = true;
    	}

    	//INTERACTION TO RESET LIGHTS, PUT IT IN CHARLES-SENPAI!!!
    	if(Input.GetKeyDown("space"))
    		targetTime = resetTime;
    }
}
