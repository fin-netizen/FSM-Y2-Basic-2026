
//player.cs is the Monobehaviour and owns the Unity components
//It passes control to the statemachine

using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerScript : MonoBehaviour
{
    public SpriteRenderer sr;
    public Rigidbody2D rb;
    public Animator anim;

    StateMachine sm;
    public GameObject weapon;

    //define the actions
    public InputAction moveAction;
    public InputAction crouchAction;
    public InputAction jumpAction;
    public InputAction interactAction;
    public InputAction attackAction;
    public InputAction deathAction;



    private void Start()
    {
        sm = new StateMachine(this); //"this" means - pass a reference of this script (player script) to the statemachine
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        
        sm.Init(sm.idleState); //this will be the first state to run 

        //initialise the actions
        moveAction = InputSystem.actions.FindAction("Move");
        crouchAction = InputSystem.actions.FindAction("Crouch");
        interactAction = InputSystem.actions.FindAction("Interact");
        jumpAction = InputSystem.actions.FindAction("Jump");
        attackAction = InputSystem.actions.FindAction("Attack");
        

    }

    private void Update()
    {
        //do not put any of your own methods here - they go in the individual state files
        sm.Update();
        
        UIscript.ui.DrawText("Current state= " + sm.currentState + "  Last state= " + sm.lastState);

    }

    private void FixedUpdate()
    {
        //do not put any of your own methods here - they go in the state files
        sm.FixedUpdate();
    }

    //add your additional collision handling here
    void OnCollisionEnter2D(Collision2D collision)
    {
        sm.currentState.OnCollisionEnter2D(collision);
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        sm.currentState.OnTriggerEnter2D(collision);
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        sm.currentState.OnTriggerExit2D(collision);
    }

    public void SpawnWeapon()
    {
        GameObject clone;
        clone = Instantiate(weapon, transform.position, Quaternion.identity);

        Rigidbody2D rb = clone.GetComponent<Rigidbody2D>();

        rb.linearVelocity = new Vector2(12, 0);

        rb.transform.position = new Vector3(transform.position.x + 2, transform.position.y + 1, transform.position.z + 1);

        rb.transform.Rotate(new Vector3(0, 0, 0));
    }
    


}
