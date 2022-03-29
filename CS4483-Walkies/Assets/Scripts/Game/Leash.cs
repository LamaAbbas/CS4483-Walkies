/**
 *      Lama Abbas - 251035313
 *      Individual Game Prototype
 *      Leash class that handles the line renderers appropriately
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leash : MonoBehaviour {

    /* Initializing several variables */
    // Specified max length for the leashes before they begin tugging at the dog walker
    [SerializeField] private float maxLength;

    // The dog that is attached to this leash
    [SerializeField] private Dog Dog;
    private LineRenderer lineRenderer;

    // Whether the dog walker should get pulled or not
    public static bool pullWalker = false;

    // The direction of the leash to determine pull
    public static Vector3 leashDirection;

    private void Start() {
        lineRenderer = GetComponent<LineRenderer>();
    }

    private void Update() {
        // Where the leash is attached to on the dog walker is determined by which dog
        if (Dog.isNimble()) {
            lineRenderer.SetPosition(0, GameObject.FindGameObjectWithTag("Left").transform.position); 
        } else {
            lineRenderer.SetPosition(0, GameObject.FindGameObjectWithTag("Right").transform.position);
        }
        // Attaching the other end of the leash to the dog
        lineRenderer.SetPosition(1, Dog.transform.localPosition);

        // Calculating the current length of the leash, and determining pull necessity with the direction
        float length = (lineRenderer.GetPosition(1) - lineRenderer.GetPosition(0)).magnitude;
        if (length > maxLength) {
            pullWalker = true;
            leashDirection = lineRenderer.GetPosition(1) - lineRenderer.GetPosition(0);
        }
    }
}