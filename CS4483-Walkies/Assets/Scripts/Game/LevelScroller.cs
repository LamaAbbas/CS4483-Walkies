/**
 *      Lama Abbas - 251035313
 *      Individual Game Prototype
 *      Level scroller class that dictates the camera and boundaries of the dogs
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelScroller : MonoBehaviour {

    [SerializeField] private float speed;

    // The upper and lower boundaries of the screen 
    public static float topSide;
    public static float bottomSide;
    public float internalTop;
    public float internalBottom;

    private void Start() {
        // Resetting the camera's positioning with every scene load
        topSide = 9;
        bottomSide = -9;
    }

    private void Update() {
        internalTop = topSide;
        internalBottom = bottomSide;

        // Movements for the camera and boundaries
        transform.Translate(Vector3.forward * Time.deltaTime * speed, Space.World);
        topSide += Time.deltaTime * speed;
        bottomSide += Time.deltaTime * speed;
    }
}
