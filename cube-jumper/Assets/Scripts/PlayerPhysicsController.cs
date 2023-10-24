using UnityEngine;

public class PlayerPhysicsController : MonoBehaviour
{
    Rigidbody _rb;
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _moveSpeed;
    [SerializeField] LayerMask _groundLayer;
    [SerializeField] Transform _groundCheck;
    [SerializeField] ParticleSystem _jumpParticle;
    [SerializeField] AudioSource _jumpSound;
    [SerializeField] private float _gravity = -5;
    [SerializeField] private float airMoveSpeed = 10;
    private bool canJump;
    PlayerTriggers playerTrigger;


    // Start is called before the first frame update
    void Start()
    {

        _rb = GetComponent<Rigidbody>();
        playerTrigger = GetComponent<PlayerTriggers>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            canJump = true;
        }

    }

    private void FixedUpdate()
    {
        if (!playerTrigger.isDead)
        {
            Debug.Log("Is not dead");
            Move();

            if (canJump)
            {
                Jump();
                //set it to false after jump because we dont wanna go flying upwards.
                canJump = false;
            }

            if (IsGrounded())
            {
                Move();
            }
            else if (!IsGrounded())
            {
                //belki force mode impulse deneyebiliriz.
                Leap();
            }

        }
        else
        {
            Debug.Log("Is Dead");
            _rb.velocity = Vector3.zero;
        }




    }

    private void Jump()
    {
        {
            _jumpSound.Play();
            CreateJumpParticle();
            _rb.AddForce(transform.up * _jumpForce * _gravity, ForceMode.Impulse);
        }

    }

    private void Move()
    {
        Vector3 forward = transform.forward;
        float currentYVel = _rb.velocity.y;
        Vector3 newVelocity = transform.forward * _moveSpeed;
        newVelocity.y = currentYVel;
        _rb.velocity = newVelocity;
        //_rb.velocity = transform.forward * _moveSpeed;
    }

    private void Leap()
    {
        _rb.AddForce(transform.forward * airMoveSpeed, ForceMode.Force);
    }
    private bool IsGrounded()
    {

        return Physics.CheckSphere(_groundCheck.position, .002f, _groundLayer);

    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(_groundCheck.position, .002f);
    }

    private void CreateJumpParticle()
    {
        _jumpParticle.Play();
    }

}
