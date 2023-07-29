using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPS_Controller : MonoBehaviour
{
    public float rotation_speed = 3.0f;

    private CharacterController character_controller;

    public bool invert_vertical_axis = false;

    public float vertical_rotation = 0.0f;
    public float vertical_rotation_limit = 45.0f;

    // Variables de posiciones y sus velocidades
    public float normal_speed = 5.0f;
    public float crounch_speed = 2.5f;
    public float prone_speed = 1.5f;

    public float normal_heigth = 1.0f;
    public float crounch_heigth = 0.5f;
    public float prone_heigth = 0.2f;

    public bool is_croundhing = false;
    public bool is_proning = false;

    [SerializeField] UI_manager ui_manager;

    // Start is called before the first frame update
    void Start()
    {
        character_controller = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float vertical;
        float horizontal;
        float move_speed;

        if (is_croundhing)
        {
            move_speed = crounch_speed;
        }else if (is_proning)
        {
            move_speed = prone_speed;
        }
        else
        {
            move_speed = normal_speed;
        }

        vertical = Input.GetAxis("Vertical") * move_speed;
        horizontal = Input.GetAxis("Horizontal") * move_speed;

        Vector3 movement = transform.forward * vertical + transform.right * horizontal;
        character_controller.SimpleMove(movement);

        toggle_crouch();

        // Camera 
        float mouseX = Input.GetAxis("Mouse X") * rotation_speed;
        float mouseY = Input.GetAxis("Mouse Y") * rotation_speed;

        if (invert_vertical_axis)
        {
            mouseY *= -1.0f;
        }

        // 

        vertical_rotation -= mouseY;
        vertical_rotation = Mathf.Clamp(vertical_rotation, -vertical_rotation_limit, vertical_rotation_limit);

        Camera.main.transform.localRotation = Quaternion.Euler(vertical_rotation,0 , 0);
        transform.Rotate(0, mouseX, 0);

    }

    private void toggle_crouch()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            if (!is_croundhing && !is_proning)
            {
                is_croundhing = true;
                ui_manager.update_position("Crounch");
                Camera.main.transform.localPosition = new Vector3(0, crounch_heigth, 0);
            } else if (is_croundhing)
            {
                is_croundhing = false;
                is_proning = true;
                ui_manager.update_position("Prune");
                Camera.main.transform.localPosition = new Vector3(0, prone_heigth, 0);
            } else if (is_proning)
            {
                is_proning = false;
                ui_manager.update_position("Normal");
                Camera.main.transform.localPosition = new Vector3(0, normal_heigth, 0);
            }
        }
    }
}
