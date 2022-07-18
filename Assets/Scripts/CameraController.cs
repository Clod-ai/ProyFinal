using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public Camera mainCamera;
    public Camera weaponCamera;
    //float sensX = 1f;
    //float sensY = 1f;
    float sensX;
    float sensY;
    float baseFov = 90f;
    float maxFov = 140f;
    float wallRunTilt = 15f;

    float wishTilt = 0;
    float curTilt = 0;
    Vector2 currentLook;
    Vector2 sway = Vector3.zero;
    float fov;
    Rigidbody rb;
    GameManager gameManager;

    void Start()
    {
        gameManager = GameManager.instance;
        rb = GetComponentInParent<Rigidbody>();
        curTilt = transform.localEulerAngles.z;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        if (gameManager) sensX = gameManager.rotationXSensitivity;
        if (gameManager) sensY = gameManager.rotationYSensitivity;
        PauseMenu.GamePaused += UnlockMouse;
        PauseMenu.GameResumed += LockMouse;
    }

    void Update()
    {
        RotateMainCamera();
    }

    void FixedUpdate()
    {
        float addedFov = rb.velocity.magnitude - 3.44f;
        fov = Mathf.Lerp(fov, baseFov + addedFov, 0.5f);
        fov = Mathf.Clamp(fov, baseFov, maxFov);
        mainCamera.fieldOfView = fov;
        if (weaponCamera) weaponCamera.fieldOfView = fov;

        currentLook = Vector2.Lerp(currentLook, currentLook + sway, 0.8f);
        curTilt = Mathf.LerpAngle(curTilt, wishTilt * wallRunTilt, 0.05f);

        sway = Vector2.Lerp(sway, Vector2.zero, 0.2f);
    }

    void RotateMainCamera()
    {
        if (!PauseMenu.gameIsPaused)
        {
            Vector2 mouseInput = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));
            mouseInput.x *= sensX;
            mouseInput.y *= sensY;

            currentLook.x += mouseInput.x;
            currentLook.y = Mathf.Clamp(currentLook.y += mouseInput.y, -90, 90);

            transform.localRotation = Quaternion.AngleAxis(-currentLook.y, Vector3.right);
            transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y, curTilt);
            transform.root.transform.localRotation = Quaternion.Euler(0, currentLook.x, 0);
        }
    }

    public void Punch(Vector2 dir)
    {
        sway += dir;
    }

    #region Setters
    public void SetTilt(float newVal)
    {
        wishTilt = newVal;
    }

    public void SetXSens(float newVal)
    {
        sensX = newVal;
        // Setting In Singleton As Well
        gameManager.rotationXSensitivity = newVal;
    }

    public void SetYSens(float newVal)
    {
        sensY = newVal;
        // Setting In Singleton As Well
        gameManager.rotationYSensitivity = newVal;
    }

    public void SetFov(float newVal)
    {
        baseFov = newVal;
    }
    #endregion

    public void LockMouse()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void UnlockMouse()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}