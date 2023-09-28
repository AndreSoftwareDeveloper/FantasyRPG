using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMovement : MonoBehaviour
{
    #region Movement
    public float currentMoveSpeed = 1.5F;
    public float walkSpeed = 1.5F;

    [HideInInspector] public Vector3 dir;
    [HideInInspector] public float hzInput, vInput, enemyHealth;
    CharacterController controller;
    #endregion

    #region GroundCheck
    [SerializeField] float groundYOffset;
    [SerializeField] LayerMask groundMask;
    Vector3 spherePos;
    #endregion

    #region Gravity
    [SerializeField] float gravity = -9.81f;
    Vector3 velocity;
    #endregion

    MovementBaseState currentState;

    public IdleState Idle = new IdleState();
    public WalkState Walk = new WalkState();
    public CrouchState Crouch = new CrouchState();
    public RunState Run = new RunState();

    [HideInInspector] public Animator anim;
    ragdollManager rgdlManager;


    void Start()
    {
        anim = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();
        rgdlManager = GetComponent<ragdollManager>();
        anim = GetComponent<Animator>();
        rgdlManager.TriggerRagdoll();

    }

    void Update()
    {
        GetDirectionAndMove();
        Gravity();

        anim.SetFloat("hzInput", hzInput);
        anim.SetFloat("vInput", vInput);
    }

    void GetDirectionAndMove()
    {
        hzInput = Input.GetAxis("Horizontal");
        vInput = Input.GetAxis("Vertical");

        dir = transform.forward + transform.right;

        controller.Move(dir.normalized * currentMoveSpeed * Time.deltaTime);
    }

    bool IsGrounded()
    {
        spherePos = new Vector3(transform.position.x, transform.position.y - groundYOffset, transform.position.z);
        if (Physics.CheckSphere(spherePos, controller.radius - 0.05f, groundMask)) 
            return true;
        return false;
    }

    void Gravity()
    {
        if (!IsGrounded()) velocity.y += gravity * Time.deltaTime;
        else if (velocity.y < 0) velocity.y = -2;

        controller.Move(velocity * Time.deltaTime);
    }
}
