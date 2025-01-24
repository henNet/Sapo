using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Setas : MonoBehaviour {

	public bool isSelected;

	// Use this for initialization
	void Start () {
		isSelected = false;
	}
	
	public void buttonDown()
	{
		isSelected = true;
	}

	public void buttonUp()
	{
		isSelected = false;
	}
}
