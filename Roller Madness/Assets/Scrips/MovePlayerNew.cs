using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayerNew : MonoBehaviour
{
    public Animator Anim;
    private Rigidbody Rigid;
    public LayerMask layerMask;
    public bool grounded;

    public CharacterController PlayerController;

    public float Speed = 6f;
    public Transform Cam;
    public float TurnSmoothTime = 0.1f;
    float TurnSmoothVelocity;

    private void Start()
    {
        this.Rigid = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        Grounded();
        Jump();
        Move();
    }

    private void Jump()
    {
        if(Input.GetKeyDown(KeyCode.Space) && this.grounded)
        {
            this.Rigid.AddForce(Vector3.up * 4, ForceMode.Impulse);
        }
    }

    private void Grounded()
    {
        if(Physics.CheckSphere(this.transform.position + Vector3.down, 0.2f, layerMask))
        {
            this.grounded = true;
            this.Anim.SetBool("Jump", true);
        }
        else
        {
            this.grounded = false;
            this.Anim.SetBool("Jump", false); ;
        }    
    }

    private void Move()
    {
        float Horizontal = Input.GetAxisRaw("Horizontal");
        float Vertical = Input.GetAxisRaw("Vertical");
        Vector3 Direction = new Vector3(Horizontal, 0f, Vertical).normalized;

        if (Direction.magnitude >= 0.1f)
        {
            float TargetAngle = Mathf.Atan2(Direction.x, Direction.z) * Mathf.Rad2Deg + Cam.eulerAngles.y;
            float Angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, TargetAngle, ref TurnSmoothVelocity, TurnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, Angle, 0f);

            Vector3 MoveDirection = Quaternion.Euler(0f, TargetAngle, 0f) * Vector3.forward;
            PlayerController.Move(MoveDirection.normalized * Speed * Time.deltaTime);
        }

        //this.transform.position += Movement * 0.04f;
        this.Anim.SetFloat("Vertical", Vertical);
        this.Anim.SetFloat("Horizontal", Horizontal);

    } 
}
