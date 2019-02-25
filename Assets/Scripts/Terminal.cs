using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Terminal : MonoBehaviour
{

	//all our variables my dudes

	[Header("Terminal Type")]
	public bool _oxygenTerminal;
	public bool _foodTerminal;
	public bool _waterTerminal;
	public bool _navigationTerminal;
	public bool _powerTerminal;
	public bool _airlockTerminal;
	public bool _garbageTerminal;
	public bool _groundControlTerminal;
	public bool _lightTerminal;

	//components
	AudioSource _audioSrc;
	BoxCollider _boxCol;

	[HideInInspector]
	public bool _isCurrentlyInteracting = false; //is the player currently raycasting the terminal 

	[Header("Power Terminal")]
    
    //timers and variables
    public int totalPower = 100;
    public float powerStopsTimer = 5.0f;
    public float annoyingVoiceTimer = 4.0f;

    // Start is called before the first frame update
    void Start()
    {
    	//set the initials variables 
        //.... air = to ballalajsljlska
        init();
    }

    // Update is called once per frame
    void Update()
    {
    	//use the function for the appropriate terminal 
    	if(_oxygenTerminal)
    		Oxygen();
    	if(_foodTerminal)
    		Food();
    	if(_waterTerminal)
    		Water();
    	if(_navigationTerminal)
    		Navigation();
    	if(_powerTerminal)
    		Power();
    	if(_airlockTerminal)
    		Airlock();
    	if(_garbageTerminal)
    		Garbage();
    	if(_groundControlTerminal)
    		GroundControl();    
    	if(_lightTerminal)
    		Light(); 
    	
    }

    public void init(){
    	//fetch the components
    	_audioSrc = gameObject.GetComponent<AudioSource>();
    	_boxCol = gameObject.GetComponent<BoxCollider>();
    }


    //where we put all our functions my dudes
    public void Oxygen(){

    }

    public void Food(){
    	
    }

    public void Water(){
    	
    }

    public void Navigation(){
    	
    }

    public void Power(){

    	//constrain values

    	//calculating timers over time

    	//if it reaches under , power shuts down

    	//annoying voice plays
    	if(powerStopsTimer <= 0)
    		_audioSrc.Play();

    	//resets 

    	
    }

    public void Airlock(){
    	
    }

    public void Garbage(){
    	
    }

    public void GroundControl(){
    	
    }

    public void Light(){
    	
    }
}
