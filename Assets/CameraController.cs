using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(GetMovementInput());
    }

    private Vector3 GetMovementInput() {
        Vector3 playerMovement = Vector3.zero;

        if (Input.GetKey(KeyCode.W)) {
            playerMovement.z += 1.0f;
        }
        if (Input.GetKey(KeyCode.A)) {
            playerMovement.x -= 1.0f;
        }
        if (Input.GetKey(KeyCode.S)) {
            playerMovement.z -= 1.0f;
        }
        if (Input.GetKey(KeyCode.D)) {
            playerMovement.x += 1.0f;
        }

        return playerMovement * 0.1f;
    }
}
