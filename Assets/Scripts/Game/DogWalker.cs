/**
 *      Lama Abbas - 251035313
 *      Individual Game Prototype
 *      Dog Walker class that handles the behaviour of the dog walker
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogWalker : MonoBehaviour {

    // Retrieving the rigid bodies of every body part of the dog walker
    private Rigidbody[] bodies;
    // Specified thrust and speed of the walker for different forms of movement
    [SerializeField] private float thrust;
    [SerializeField] private float speed;

    private void Start() {
        bodies = GetComponentsInChildren<Rigidbody>();
    }

    private void Update() {
        // Constant movement
        transform.Translate(Vector3.forward * Time.deltaTime * speed, Space.World);

        // If the dog walker is lagging behind off-screen then a boost is given to push him forward
        foreach (Rigidbody body in bodies) {
            if (body.transform.position.z < LevelScroller.bottomSide) {
                body.AddForce(this.transform.forward * thrust);
            }
        }

        // If the leash is growing too long then the dog walker will be pushed towards the leash to shorten it
        if (Leash.pullWalker) {
            foreach (Rigidbody body in bodies) {
                body.AddForceAtPosition(Leash.leashDirection * thrust/2, body.transform.position);
            }
            Leash.pullWalker = false;
        }
    }
}

