#pragma strict

private var mainCam:GameObject;

function Awake(){
	// We search the main camera
	mainCam = GameObject.FindGameObjectWithTag("MainCamera");
}

function Update () {

	transform.eulerAngles = mainCam.transform.eulerAngles;
}