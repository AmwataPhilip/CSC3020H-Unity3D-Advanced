/*
 *  @author: Philip Amwata
 *  Date: 09/05/2019
 * 
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseController : MonoBehaviour
{
    [SerializeField]
    private Transform playerRoot, viewRoot;

    [SerializeField]
    private bool invertedMouse;

    [SerializeField]
    private bool unlockedMouse = true;

    [SerializeField]
    private float sensitivity = 5.0f;

    [SerializeField]
    private int smoothSteps = 10;

    [SerializeField]
    private float smoothWeight = 0.4f;

    [SerializeField]
    private float rollAngle = 10.0f;

    [SerializeField]
    private float rollSpeed = 3.0f;

    [SerializeField]
    private Vector2 defaultViewLimits = new Vector2(-70.0f, 80.0f);

    [SerializeField]
    private GameObject PauseMenu;

    [SerializeField]
    private bool isPaused;

    private Vector2 viewAngles;
    private Vector2 currentMouseView;
    private Vector2 smoothMove;

    private float currentRollAngle;

    private int lastViewFrame;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; // lock cursor in center of view
    }

    // Update is called once per frame
    void Update()
    {
        LockUnlockCursor();

        if(Cursor.lockState == CursorLockMode.Locked)
        {
            LookAround();
        }
    }

     // Set Cursors Lock state to either locked or unlocked on key press
    void LockUnlockCursor()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!isPaused)
            {
                ActivatePauseMenu();
                isPaused = true;
            }
            else if (isPaused)
            {
                DeactivatePauseMenu();
                isPaused = false;
            }
            if(Cursor.lockState == CursorLockMode.Locked)
            {
                Cursor.lockState = CursorLockMode.None;
            }
            else
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
        }
    }

    // Allow player to look around the scene using the cursor
    void LookAround()
    {
        currentMouseView = new Vector2(Input.GetAxis(MouseAxis.MOUSEY),Input.GetAxis( MouseAxis.MOUSEX));

        viewAngles.x += currentMouseView.x * sensitivity * (invertedMouse ? 1.0f : -1.0f);
        viewAngles.y += currentMouseView.y * sensitivity;

        viewAngles.x = Mathf.Clamp(viewAngles.x, defaultViewLimits.x, defaultViewLimits.y);

        // currentRollAngle = Mathf.Lerp(currentRollAngle, Input.GetAxisRaw(MouseAxis.MOUSEX) * rollAngle, Time.deltaTime * rollSpeed);

        viewRoot.localRotation = Quaternion.Euler(viewAngles.x, 0.0f, 0.0f);
        playerRoot.localRotation = Quaternion.Euler(0.0f, viewAngles.y, 0.0f);
    }

    void ActivatePauseMenu()
    {
        Time.timeScale = 0;
        PauseMenu.SetActive(true);
    }

    public void DeactivatePauseMenu()
    {
        if (Cursor.lockState == CursorLockMode.Locked)
        {
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        Time.timeScale = 1;
        PauseMenu.SetActive(false);
        isPaused = false;
    }
}
