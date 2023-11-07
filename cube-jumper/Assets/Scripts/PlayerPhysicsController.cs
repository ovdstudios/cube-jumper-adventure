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
    //[SerializeField] private float airMoveSpeed = 10;
    private bool allowLeap;
    private bool canJump;
    PlayerTriggers playerTrigger;
    PressSpaceToStart spaceToStart;


    private void Awake()
    {
        spaceToStart = GameObject.Find("GameController").GetComponent<PressSpaceToStart>();
        _rb = GetComponent<Rigidbody>();
        playerTrigger = GetComponent<PlayerTriggers>();

    }
    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            canJump = true;
        }

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

            //if (IsGrounded())
            //{

            //    Move();
            //}
            if (_rb.velocity.y > 0)
            {
                _rb.velocity += Vector3.up * Physics.gravity.y * (3 - 1) * Time.deltaTime;
            }
            //else if (!IsGrounded())
            //{

            //    //Leap();
            //}

        }
        else
        {
            Debug.Log("Is Dead");
            _rb.velocity = Vector3.zero;
        }

        //if (spaceToStart.isPaused)
        //{
        //    _rb.velocity = Vector3.zero;
        //    if (IsGrounded())
        //    {
        //        float currentXVelocity = _rb.velocity.x;
        //        Vector3 newVelocity = transform.up * _jumpForce;
        //        newVelocity.x = currentXVelocity;
        //        _rb.velocity = newVelocity;
        //        canJump = false;
        //        allowLeap = false;
        //    }

        //}
        //else
        //{
        //    return;
        //}
    }

    private void FixedUpdate()
    {


    }

    private void Jump()
    {
        {
            _jumpSound.Play();
            CreateJumpParticle();

            _rb.velocity = Vector3.up * _jumpForce;
            //_rb.AddForce(transform.up * _jumpForce, ForceMode.Force);
            //_rb.useGravity = false;
            //_rb.velocity = new Vector3(_rb.velocity.x, 0, _rb.velocity.z);
            //DOVirtual.DelayedCall(1f, () =>
            //{
            //    _rb.useGravity = true;
            //});

        }

    }

    private void Move()
    {
        //Vector3 forward = transform.forward;

        transform.position += transform.forward * _moveSpeed * Time.deltaTime;
        //Vector3 newVelocity = transform.forward * _moveSpeed;
        //newVelocity.y = _rb.velocity.y;
        //_rb.velocity = newVelocity;
        //_rb.velocity = transform.forward * _moveSpeed;
    }

    //private void Leap()
    //{
    //    if (allowLeap)
    //    {
    //        _rb.AddForce(transform.forward * airMoveSpeed, ForceMode.Force);
    //    }

    //}
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

    public void AutoJump()
    {
        _rb.AddForce(transform.up * _jumpForce, ForceMode.Impulse);

    }

}
