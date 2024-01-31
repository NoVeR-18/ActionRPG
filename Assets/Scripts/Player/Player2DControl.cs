using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class Player2DControl : MonoBehaviour
{
    [SerializeField]
    private float speed = 7;
    [SerializeField]
    private float addForce = 15;
    [SerializeField]
    private KeyCode downButton = KeyCode.S;
    [SerializeField]
    private KeyCode jumpButton = KeyCode.Space;
    [SerializeField]
    private bool isFacingRight = true;


    private float vertical;

    private Rigidbody2D body;
    private bool jump;
    private Animator animator;
    private int _playerObject, _platformObject;
    private bool _jumpDown = false;

    void Start()
    {
        _playerObject = LayerMask.NameToLayer("Player");
        _platformObject = LayerMask.NameToLayer("Platform");
        body = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        body.freezeRotation = true;
    }

    void OnCollisionStay2D(Collision2D coll)
    {
        if (coll.transform.tag == "ground")
        {
            body.drag = 10;
            jump = true;
            animator.SetBool("Jump", false);
        }
    }

    void OnCollisionExit2D(Collision2D coll)
    {
        if (coll.transform.tag == "ground")
        {
            body.drag = 0;
            animator.SetBool("Jump", true);
            jump = false;
        }
    }

    void FixedUpdate()
    {
        PlatformJump();
        var horizontal = Input.GetAxis("Horizontal");

        body.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, body.velocity.y);

        if (Input.GetKey(jumpButton) && jump)
        {
            body.velocity = (new Vector2(body.velocity.x, addForce));
        }

        if (horizontal > 0 && !isFacingRight) Flip(); else if (horizontal < 0 && isFacingRight) Flip();
    }
    private void PlatformJump()
    {
        if (Input.GetKey(downButton))
        {
            StartCoroutine("PlatformIgnor");
        }
        if (body.velocity.y > 0.1f || _jumpDown)
        {
            Physics2D.IgnoreLayerCollision(_playerObject, _platformObject, true);
        }
        else
        {
            Physics2D.IgnoreLayerCollision(_playerObject, _platformObject, false);
        }

    }
    private IEnumerator PlatformIgnor()
    {
        _jumpDown = true;
        Physics2D.IgnoreLayerCollision(_playerObject, _platformObject, true);
        yield return new WaitForSeconds(0.7f);
        Physics2D.IgnoreLayerCollision(_playerObject, _platformObject, false);
        _jumpDown = false;
    }

    void Flip()
    {

        isFacingRight = !isFacingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;

    }

    void Update()
    {
        Animation();
    }

    private void Animation()
    {
        animator.SetFloat("Speed", Mathf.Abs(body.velocity.x));

        //if (Mathf.Abs(body.velocity.y) > 0.5)
        //    animator.SetBool("Jump", true);
        //else
        //    animator.SetBool("Jump", false);
    }
}