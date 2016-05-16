using UnityEngine;
using System.Collections;

public class ClawBehaviour : MonoBehaviour {

    //PUBLIC
    public GameObject spawn;
    public float maxHeight = 3.5f;
    public float moveSpeed = 0.2f;

    bool isHittingFloor = false;
    bool isHittingLeftWall = false;
    bool isHittingRightWall = false;
    bool isHittingTopWall = false;
    bool isHittingBottomWall = false;

    // Use this for initialization
    void Start() {
        gameObject.transform.position = GameObject.Find("Spawn").transform.position;
    }

    // Update is called once per frame
    void Update() {
        updateMovementControls();
    }

    void updateMovementControls() {
        float xAxis = Input.GetAxis("Vertical");
        float yAxis = Input.GetAxis("Horizontal");

        if (xAxis > 0) {
            //UP
            if (!isHittingTopWall) {
                gameObject.transform.position += new Vector3(0, 0, moveSpeed*xAxis) * Time.deltaTime;
            }
        }
        else if(xAxis<0){
            //DOWN
            if (!isHittingBottomWall) {
                gameObject.transform.position += new Vector3(0, 0, moveSpeed*xAxis) * Time.deltaTime;
            }
        }

        if(yAxis > 0) {
            //RIGHT
            if (!isHittingRightWall) {
                gameObject.transform.position += new Vector3(moveSpeed*yAxis, 0, 0)*Time.deltaTime;
            }
        }
        else if (yAxis < 0) {
            //LEFT
            if (!isHittingLeftWall) {
                gameObject.transform.position += new Vector3(moveSpeed*yAxis, 0, 0)*Time.deltaTime;
            }
        }
    }

    void OnTriggerEnter(Collider other) {
        Debug.Log("Hit");
        switch (other.gameObject.tag) {
            case "floor":
                isHittingFloor = true;
                break;
            case "leftWall":
                isHittingLeftWall = true;
                break;
            case "rightWall":
                isHittingRightWall = true;
                break;
            case "topWall":
                isHittingTopWall = true;
                break;
            case "bottomWall":
                isHittingBottomWall = true;
                break;
        }
    }

    void OnTriggerExit(Collider other) {
        switch (other.gameObject.tag) {
            case "floor":
                isHittingFloor = false;
                break;
            case "leftWall":
                isHittingLeftWall = false;
                break;
            case "rightWall":
                isHittingRightWall = false;
                break;
            case "topWall":
                isHittingTopWall = false;
                break;
            case "bottomWall":
                isHittingBottomWall = false;
                break;
        }
    }
}
