using UnityEngine;
using DG.Tweening;
using Cinemachine;
public class PlayerMovementController : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _jumpPower;
    [SerializeField] private float _fallMultiplier;
    [SerializeField] private float _lowJumpMultiplier;
    [SerializeField] private bool canJump;
    [SerializeField] Transform _groundCheck;
    [SerializeField] LayerMask _groundLayer;
    [SerializeField] ParticleSystem _jumpParticle;
    [SerializeField] AudioSource _jumpSound;
   
    [SerializeField] CinemachineVirtualCamera cam;
  
    
    
    PlayerTriggers playerTrigger;

  

    private void Awake()
    {
        
        playerTrigger = GetComponent<PlayerTriggers>();       
        DOTween.Init(recycleAllByDefault: true);
       
        
    }

    private void Update()
    {


        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            canJump = true;
        }

        if (transform.position.y < 10)
        {
            cam.enabled = false;
        }
        else
        {
            return;
        }


    }

    private void FixedUpdate()
    {
       
        if (!playerTrigger.isDead) 
        {
            Move();

        }
        else
        {
            _rigidbody.velocity = Vector3.zero;
        }

        if (canJump)
        {
            JumpAction();
            
        }
        if (_rigidbody.velocity.y > 0)
        {
            _rigidbody.velocity += Vector3.up * Physics.gravity.y * (_lowJumpMultiplier - 1) * Time.deltaTime;
        }

        else
        {
            _rigidbody.velocity += Vector3.up * Physics.gravity.y * (_fallMultiplier - 1) * Time.deltaTime;
        }
        canJump = false;

        

    }

    private void Move()
    {
        Vector3 newVelocity = transform.forward * _moveSpeed;
        newVelocity.y = _rigidbody.velocity.y;
        _rigidbody.velocity = newVelocity;
        //_rigidbody.velocity += transform.forward * _moveSpeed * Time.deltaTime;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(_groundCheck.position, .06f);
    }

    private bool IsGrounded()
    {
        return Physics.CheckSphere(_groundCheck.position, .06f, _groundLayer);
    }

    private void CreateJumpParticle()
    {
        _jumpParticle.Play();
    }

    private void JumpAction()
    {
        Vector3 velocity = Vector3.up * _jumpPower;
        _rigidbody.velocity += velocity;
        if(_jumpSound != null)
        {
            _jumpSound.Play(); 
        }
        
        CreateJumpParticle();
       
    }
}
