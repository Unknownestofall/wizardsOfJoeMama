using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    float _baseSpeed;
    [SerializeField] float jumpForce;
    [SerializeField] enum playerMoveState { walk, run }
    [SerializeField] playerMoveState moveState;
    [SerializeField]List<materialResouce> inventory = new List<materialResouce>();

    public static Action changeCam;

    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerFunctions();
        SwitchMoveSpeed();
    }
    void FixedUpdate(){
        Movement();
    }
    void PlayerFunctions() {
        if (Input.GetKeyDown(KeyCode.F)) changeCamera();
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded()) Jump();
    }
    void Movement() {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveZ = Input.GetAxisRaw("Vertical");

        Vector3 movePlayer = new Vector3(moveX, 0, moveZ).normalized;
        transform.Translate(_baseSpeed * Time.deltaTime * movePlayer);
    }
    void Jump() => rb.velocity = new Vector3(0, jumpForce);
    bool isGrounded() { 
        RaycastHit hit;
        if(Physics.Raycast(transform.position, Vector3.down, out hit, 1.1f)) {
            if (hit.transform.CompareTag("floor")) return true;
        }return false;
    }
    void SwitchMoveSpeed() {
        switch (moveState) { 
            case playerMoveState.walk:
                _baseSpeed = 5;
                break;
            case playerMoveState.run:
                _baseSpeed = 7;
            break;
            default: Debug.LogError("player state not assigned"); return;
        }
    }
    void changeCamera() => changeCam?.Invoke();
}
