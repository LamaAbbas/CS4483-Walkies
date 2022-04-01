/**
 *      Lama Abbas - 251035313
 *      Individual Game Prototype
 *      Dog class that controls their individual movement
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Dog : MonoBehaviour {

    private Rigidbody dog;
    private Animator anim;
    [SerializeField] private float speed;
    [SerializeField] private float forwardSpeed;

    [SerializeField] private float horizontalSpeed;
    [SerializeField] private float verticalSpeed;

    // Determining which dog in question
    [SerializeField] private bool Nimble;
    [SerializeField] private bool Heavy;

    [SerializeField] public bool hasShield;

    private void Awake() {
        dog = GetComponent<Rigidbody>();
        anim = GetComponentInChildren<Animator>();
        hasShield = false;
        forwardSpeed = speed;
    }

    private void OnTriggerEnter(Collider other) {
        
        if ((other.tag == "HeavyObstacle" && isNimble()) || (other.tag == "NimbleObstacle" && !isNimble()) || (other.tag == "Obstacle")) {
            if(hasShield){
                hasShield = false;
                transform.GetChild(0).Find("Shield").gameObject.GetComponent<MeshRenderer>().enabled = false;
            } // end if
            else {
                //SceneManager.LoadScene(3); 
            } 
        }
        else if(other.tag == "PowerUp") {
            other.gameObject.GetComponent<PowerUp>().ActivatePowerup(this.gameObject);
        } else if (other.tag == "NimbleObstacle" && isNimble()) {
            anim.SetTrigger("jump");
        } else if (other.tag == "HeavyObstacle" && !isNimble()) {
            Debug.Log("me");
            anim.SetTrigger("dash");
        }
    }

    

    public void setSpeed(float _speed){
        speed = _speed;
    } // end method

    private void FixedUpdate() {
        // Constant speed 
        //transform.Translate(Vector3.forward * Time.deltaTime * forwardSpeed, Space.World);
        //dog.AddForce(Vector3.forward * speed, ForceMode.VelocityChange);

        if (Nimble) {
            // The keys that control the dog and remaining within the boundaries
            if (Input.GetKey(KeyCode.A)) {
                if (this.gameObject.transform.position.x > LevelBoundary.leftSide) {
                    //transform.Translate(Vector3.left * Time.deltaTime * horizontalSpeed);
                    dog.AddForce(Vector3.left * horizontalSpeed);
                }
            }
            if (Input.GetKey(KeyCode.D)) {
                if (this.gameObject.transform.position.x < LevelBoundary.rightSide) {
                    //transform.Translate(Vector3.left * Time.deltaTime * -horizontalSpeed);
                    dog.AddForce(Vector3.left * -horizontalSpeed);
                }
            }
            if (Input.GetKey(KeyCode.W)) {
                if (this.gameObject.transform.position.z < LevelScroller.topSide) {
                    //transform.Translate(Vector3.forward * Time.deltaTime * verticalSpeed);
                    dog.AddForce(Vector3.forward * verticalSpeed);
                }
            }
            if (Input.GetKey(KeyCode.S)) {
                if (this.gameObject.transform.position.z > LevelScroller.bottomSide) {
                    //transform.Translate(Vector3.forward * Time.deltaTime * -verticalSpeed);
                    dog.AddForce(Vector3.forward * -verticalSpeed);
                }
            }
        } 
        
        if (Heavy) {

            if (Input.GetKey(KeyCode.LeftArrow)) {
                if (this.gameObject.transform.position.x > LevelBoundary.leftSide) {
                    //transform.Translate(Vector3.left * Time.deltaTime * horizontalSpeed);
                    dog.AddForce(Vector3.left * horizontalSpeed);
                }
            }
            if (Input.GetKey(KeyCode.RightArrow)) {
                if (this.gameObject.transform.position.x < LevelBoundary.rightSide) {
                    //transform.Translate(Vector3.left * Time.deltaTime * -horizontalSpeed);
                    dog.AddForce(Vector3.left * -horizontalSpeed);
                }
            }
            if (Input.GetKey(KeyCode.UpArrow)) {
                if (this.gameObject.transform.position.z < LevelScroller.topSide) {
                    //transform.Translate(Vector3.forward * Time.deltaTime * verticalSpeed);
                    dog.AddForce(Vector3.forward * verticalSpeed);
                }
            }
            if (Input.GetKey(KeyCode.DownArrow)) {
                if (this.gameObject.transform.position.z > LevelScroller.bottomSide) {
                    //transform.Translate(Vector3.forward * Time.deltaTime * -verticalSpeed);
                    dog.AddForce(Vector3.forward * -verticalSpeed);
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
