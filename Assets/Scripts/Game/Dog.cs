/**
 *      Lama Abbas - 251035313
 *      Individual Game Prototype
 *      Dog class that controls their individual movement
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dog : MonoBehaviour {

    private Rigidbody dog;
    [SerializeField] private float speed;
    [SerializeField] private float horizontalSpeed;
    [SerializeField] private float verticalSpeed;

    // Determining which dog in question
    [SerializeField] private bool Nimble;
    [SerializeField] private bool Heavy;

    private void Awake() {
        dog = GetComponent<Rigidbody>();
    }

    private void Update() {
        // Constant speed 
        transform.Translate(Vector3.forward * Time.deltaTime * speed, Space.World);

        if (Nimble) {
            // The keys that control the dog and remaining within the boundaries
            if (Input.GetKey(KeyCode.A)) {
                if (this.gameObject.transform.position.x > LevelBoundary.leftSide) {
                    transform.Translate(Vector3.left * Time.deltaTime * horizontalSpeed);
                }
            }
            if (Input.GetKey(KeyCode.D)) {
                if (this.gameObject.transform.position.x < LevelBoundary.rightSide) {
                    transform.Translate(Vector3.left * Time.deltaTime * -horizontalSpeed);
                }
            }
            if (Input.GetKey(KeyCode.W)) {
                if (this.gameObject.transform.position.z < LevelScroller.topSide) {
                    transform.Translate(Vector3.forward * Time.deltaTime * verticalSpeed);
                }
            }
            if (Input.GetKey(KeyCode.S)) {
                if (this.gameObject.transform.position.z > LevelScroller.bottomSide) {
                    transform.Translate(Vector3.forward * Time.deltaTime * -verticalSpeed);
                }
            }
        } else if (Heavy) {

            if (Input.GetKey(KeyCode.LeftArrow)) {
                if (this.gameObject.transform.position.x > LevelBoundary.leftSide) {
                    transform.Translate(Vector3.left * Time.deltaTime * horizontalSpeed);
                }
            }
            if (Input.GetKey(KeyCode.RightArrow)) {
                if (this.gameObject.transform.position.x < LevelBoundary.rightSide) {
                    transform.Translate(Vector3.left * Time.deltaTime * -horizontalSpeed);
                }
            }
            if (Input.GetKey(KeyCode.UpArrow)) {
                if (this.gameObject.transform.position.z < LevelScroller.topSide) {
                    transform.Translate(Vector3.forward * Time.deltaTime * verticalSpeed);
                }
            }
            if (Input.GetKey(KeyCode.DownArrow)) {
                if (this.gameObject.transform.position.z > LevelScroller.bottomSide) {
                    transform.Translate(Vector3.forward * Time.deltaTime * -verticalSpeed);
                }
            }
        }
    }

    // Referenced to determine which dog in question
    public bool isNimble() {
        if (Nimble) {
            return true;
        } else {
            return false;
        }
    }
}
