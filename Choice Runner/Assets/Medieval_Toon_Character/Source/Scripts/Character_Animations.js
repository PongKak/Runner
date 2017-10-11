#pragma strict
internal var animator:Animator;
var v:float;
var h:float;
var run: float;

function Start () {
    animator = GetComponent(Animator);
}

function Update () {
	v=Input.GetAxis("Vertical");
    h = Input.GetAxis("Horizontal");
    
    if (Input.GetKeyDown("space")){
        animator.SetBool("Jump", true);
            
    }
	Sprinting();
	
}

function FixedUpdate (){
	animator.SetFloat("Walk",v);
	animator.SetFloat("Run",run);
	animator.SetFloat("Turn",h);
}

function Sprinting(){
    run = 0.2f;
}