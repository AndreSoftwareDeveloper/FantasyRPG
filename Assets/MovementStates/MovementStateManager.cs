using System.Collections;
using UnityEngine;
using UnityEngine.UI;


public class MovementStateManager : MonoBehaviour
{
    #region Movement
        public float currentMoveSpeed, walkSpeed, walkBackSpeed, runSpeed, runBackSpeed, crouchSpeed, crouchBackSpeed;
        bool attack;
        [HideInInspector] public float hzInput, vInput;  
        [HideInInspector] public Vector3 dir;        
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
    public AttackState Attack = new AttackState();

    [HideInInspector] public Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();
        SwitchState(Idle);
    }

    void Update()
    {
        GetDirectionAndMove();
        SwordAttack();
        Gravity();

        anim.SetFloat("hzInput", hzInput);
        anim.SetFloat("vInput", vInput);

        currentState.UpdateState(this);
    }

    public void SwitchState(MovementBaseState state)
    {
        currentState = state;
        currentState.EnterState(this);
    }

    void GetDirectionAndMove()
    {
        hzInput = Input.GetAxis("Horizontal");
        vInput = Input.GetAxis("Vertical");

        dir = transform.forward * vInput + transform.right * hzInput;
        
        controller.Move(dir.normalized * currentMoveSpeed * Time.deltaTime);
    }

    bool IsGrounded()
    {
        spherePos = new Vector3(transform.position.x, transform.position.y - groundYOffset, transform.position.z);
        if (Physics.CheckSphere(spherePos, controller.radius - 0.05f, groundMask)) return true;
        return false;
    }

    void Gravity()
    {
        if (!IsGrounded()) 
            velocity.y += gravity * Time.deltaTime;
        else if (velocity.y < 0) 
            velocity.y = -2;

        controller.Move(velocity * Time.deltaTime);
    }

    void SwordAttack()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("attack_debug");
            SwitchState(Attack);
        }
            
    }
}
