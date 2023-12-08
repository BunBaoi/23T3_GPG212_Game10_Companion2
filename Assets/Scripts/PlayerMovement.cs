using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Speeds")]
    public float moveSpeed;

    [Header("Camera")]
    [SerializeField] private float mouseSensitivity;
    [SerializeField] private float upDownRange;


    [Header("Inputs Customisation")] // Able to customise the horizontal & vertical from inspector
    [SerializeField] private string horizontalMoveInput = "Horizontal";
    [SerializeField] private string verticalMoveInput = "Vertical";

    [SerializeField] private string MouseXInput = "Mouse X";
    [SerializeField] private string MouseYinput = "Mouse Y";

    public Camera mainCamera;
    private float verticalRotation;
    private CharacterController characterController;


    void Start()
    {
        characterController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        mainCamera = Camera.main;
    }


    private void Update()
    {
        movement();
        rotation();
        sprint();

    }

    void movement()
    {
        float verticalSpeed = Input.GetAxis(verticalMoveInput) * moveSpeed;
        float horizontalSpeed = Input.GetAxis(horizontalMoveInput) * moveSpeed;

        Vector3 speed = new Vector3(horizontalSpeed, 0, verticalSpeed); // Move left and right
        speed = transform.rotation * speed;

        characterController.SimpleMove(speed);

    }
    void rotation()
    {
        float mouseXRoation = Input.GetAxis(MouseXInput) * mouseSensitivity;
        transform.Rotate(0, mouseXRoation, 0);

        verticalRotation -= Input.GetAxis(MouseYinput) * mouseSensitivity;
        verticalRotation = Mathf.Clamp(verticalRotation, -upDownRange, upDownRange);
        mainCamera.transform.localRotation = Quaternion.Euler(verticalRotation, 0, 0);
    }

    void sprint()
    {

    }
   
}
