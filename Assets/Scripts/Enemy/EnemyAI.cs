using UnityEngine;


public class EnemyAI : MonoBehaviour
{
    [SerializeField]
    private float speed = 2f;
    [SerializeField]
    private float positionOfPatrol = 5f;
    [SerializeField]
    private Transform point;
    [SerializeField]
    private bool isFacingRight;

    Transform player;
    [SerializeField]
    private float stoppingDistance;

    public Animator animator;
    public Rigidbody2D body;
    [SerializeField]
    bool chill;
    [SerializeField]
    bool angry;
    [SerializeField]
    bool goback;
    Vector2 _pointOfSpawn;
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        _pointOfSpawn = transform.position;
        direction = new Vector2(transform.position.x + speed * Time.deltaTime, 0).normalized;
    }

    void FixedUpdate()
    {
        //Chill();
        if (Vector2.Distance(transform.position, point.position) < positionOfPatrol && angry == false)
        {
            chill = true;
        }

        if (Vector2.Distance(transform.position, player.position) < stoppingDistance)
        {
            angry = true;
            chill = false;
            goback = false;
        }

        if (Vector2.Distance(transform.position, player.position) > stoppingDistance)
        {
            goback = true;
            angry = false;
        }
        //if (chill == true)
        else if (angry == true)
            Angry();
        else if (goback == true)
            GoBack();
    }
    public Transform[] patrolPoints; // Массив точек патрулирования

    private Transform currentPatrolPoint; // Текущая точка патрулирования
    [SerializeField]
    Vector3 direction;// = (currentPatrolPoint.position - transform.position).normalized;
    void Chill()
    {
        if (transform.position.x >= _pointOfSpawn.x + positionOfPatrol)
        {
            direction = new Vector2(-transform.position.x + speed * Time.deltaTime, 0).normalized;
            isFacingRight = false;
        }
        else if (transform.position.x < _pointOfSpawn.x - positionOfPatrol)
        {
            direction = new Vector2(transform.position.x + speed * Time.deltaTime, 0).normalized;
            isFacingRight = true;
        }

        if (isFacingRight)
        {
            transform.position = new Vector2(transform.position.x + speed * Time.deltaTime, transform.position.y);
        }
        else
        {
            transform.position = new Vector2(transform.position.x - speed * Time.deltaTime, transform.position.y);
        }
        transform.Translate(direction * speed * Time.deltaTime);

    }

    void Flip()
    {

        isFacingRight = !isFacingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;

    }
    void Angry()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
    }

    void GoBack()
    {
        transform.position = Vector2.MoveTowards(transform.position, _pointOfSpawn, speed * Time.deltaTime);
    }
    private void Update()
    {
        Animation();
    }
    private void Animation()
    {
        animator.SetFloat("Speed", body.velocity.sqrMagnitude);

        if (Mathf.Abs(body.velocity.y) > 0.5)
            animator.SetBool("Jump", true);
        else
            animator.SetBool("Jump", false);
    }
}