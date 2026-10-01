
//This is the base class 
// It defines the common methods and fields that all other states inherit
// You can include methods that you want to allow other states to use here

using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public abstract class State
{
    protected PlayerScript player;
    protected StateMachine sm;
    public bool isFacingRight;
    protected float xvel, yvel;
    public float verticalInput;
    public float horizontalInput;
    public LayerMask groundLayer;
    public bool isGrounded;
    // base constructor
    public State(PlayerScript player, StateMachine sm)
    {
        this.player = player;
        this.sm = sm;
    }

    //methods that can be overriden by each state
    public virtual void Enter() 
    {


    }
    public virtual void Update() 
    {
       
    }
    public virtual void FixedUpdate() { }
    public virtual void Exit() { }
    public virtual void OnCollisionEnter2D(Collision2D collision) { }
    public virtual void OnTriggerEnter2D(Collider2D collision) { }
    public virtual void OnTriggerExit2D(Collider2D collision) { }

    //Common Shared Methods
    //Put methods that you wish to share between other states here
    //Set them to be public
    public void TestMethod(string text)
    {
        Debug.Log(text);
    }


    public void ReadInput()
    {
    }
    public void IsGrounded()
    {
        groundLayer = LayerMask.GetMask("Ground");

        Color color = Color.red;
        isGrounded = false;

        Debug.Log("gl=" + groundLayer.value);


        Vector2 position = player.transform.position;
        Vector2 direction = Vector2.down;
        float distance = 1.0f;

        RaycastHit2D hit = Physics2D.Raycast(position, direction, distance, groundLayer);
        if (hit.collider != null)
        {
            isGrounded = true;
            color = Color.green;

        }

        Debug.DrawRay(position, direction, color);
        hit = Physics2D.Raycast(position, direction, distance, groundLayer);
    }
    public void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 localScale = player.transform.localScale;
        localScale.x *= -1f;
        player.transform.localScale = localScale;
    }

}
