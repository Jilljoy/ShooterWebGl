using UnityEngine;

/// <summary>
/// A quick and dirty player controller.
/// </summary>
public class PlayerController : MonoBehaviour
{

    [SerializeField]
    private float horizontalSpeed = 0.0f;

    [SerializeField]
    private float verticalSpeed = 0.0f;

    private Vector2 cameraRotation = Vector2.zero;

    private Vector3 playerRotation = Vector3.zero;

    private GameObject playerCamera;
 
    [SerializeField]
    private GameObject projectilePrefab = null;

    void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
        if (playerCamera == null)
        {
            Debug.LogWarning("playerCamera not set! Setting to Camera.main.gameObject", this);
            playerCamera = Camera.main.gameObject;
        }
        if (projectilePrefab == null)
        {
            Debug.LogError("projectilePrefab not set!", this);
        }
    }

    void Update()
    {
        CameraRotate();
        PlayerRotate();
        PlayerMove();
        PlayerShoot();
    }

    private void CameraRotate()
    {
        cameraRotation.x += -Input.GetAxis("Mouse Y") * verticalSpeed;
        cameraRotation.y += Input.GetAxis("Mouse X") * horizontalSpeed;
        playerCamera.transform.eulerAngles = cameraRotation;
    }

    private void PlayerRotate()
    {
        transform.rotation = Quaternion.AngleAxis(cameraRotation.y, transform.up);
    }

    private void PlayerMove()
    {
        Vector3 playerMovement = Vector3.zero;

        if (Input.GetKey(KeyCode.W))
        {
            playerMovement.z += 1.0f;
        }
        if (Input.GetKey(KeyCode.A))
        {
            playerMovement.x -= 1.0f;
        }
        if (Input.GetKey(KeyCode.S))
        {
            playerMovement.z -= 1.0f;
        }
        if (Input.GetKey(KeyCode.D))
        {
            playerMovement.x += 1.0f;
        }

        transform.Translate(playerMovement * 0.1f);
    }

    /// <summary>
    /// Creates a projectile every time the mouse left click is pressed down. The camera's rotation is used to fire where the camera is looking.
    /// </summary>
    private void PlayerShoot()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Instantiate(projectilePrefab, transform.position, playerCamera.transform.rotation);
        }
    }
}
