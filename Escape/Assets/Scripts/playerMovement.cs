using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    private CharacterController cc;
    public float speed = 5;
    private Vector3 velocity;
    public float gravity = -9.81f*2;
    public Transform GroundCheck;
    public float groundDistance = 0.5f;
    public LayerMask groundMask;
    public Animator anim;
    bool isGrounded;
    // Start is called before the first frame update
    void Start()
    {
        cc = this.GetComponent<CharacterController>();
        anim = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(GroundCheck.position, groundDistance, groundMask);

        if(isGrounded && velocity.y < 0) {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        
        anim.SetFloat("vertical_speed", z);
        anim.SetFloat("horizontal_speed", x);

        Vector3 move = transform.right * x + transform.forward * z;
        
        cc.Move(move * speed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;

        cc.Move(velocity * Time.deltaTime);
        
    }
}
