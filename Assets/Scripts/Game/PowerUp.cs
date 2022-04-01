using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PowerUp : MonoBehaviour
{
    GameObject player;
    GameObject nimbleDog;
    GameObject heavyDog;

    public void Start(){
        player = GameObject.Find("Dog Walker");
        nimbleDog = GameObject.Find("Nimble");
        heavyDog = GameObject.Find("Heavy");
    } // end start

    public abstract void ActivatePowerup(GameObject dog);
} // end class
