using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;
using Quaternion = UnityEngine.Quaternion;


public class PlayerMovement : MonoBehaviour
{
    public float MoveSpeed = 10f;
    public float RotateSpeed = 75f;

    private float _vInput;
    private float _hInput;

    private Rigidbody _rb;

    public float JumpVelocity = 10f;
    private bool _isJumping;

    public float DistanceToGround = 0.1f;
    public LayerMask GroundLayer;
    private CapsuleCollider _col;

    public GameObject Bullet;
    public float BulletSpeed = 100f;
    private bool _isShooting;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _col = GetComponent<CapsuleCollider>();

    }

    // Update is called once per frame
    void Update()
    {
        _vInput = Input.GetAxis("Vertical");
        _hInput = Input.GetAxis("Horizontal");

        this.transform.Translate(Vector3.forward * _vInput * MoveSpeed * Time.deltaTime);
        this.transform.Rotate(Vector3.up * _hInput * RotateSpeed * Time.deltaTime);


        _isJumping |= Input.GetKeyDown(KeyCode.J);

        _isShooting |= Input.GetKeyDown(KeyCode.Space);

    }

    void FixedUpdate()
    {
        Vector3 rotation = Vector3.up * _hInput;

        Quaternion angleRot = Quaternion.Euler(rotation * Time.fixedDeltaTime);

        _rb.MovePosition(this.transform.position + this.transform.forward * _vInput * Time.fixedDeltaTime);

        _rb.MoveRotation(_rb.rotation * angleRot);


        if (_isJumping && IsGrounded())
        {
            _rb.AddForce(Vector3.up * JumpVelocity, ForceMode.Impulse);
        }

        _isJumping = false;


        if (_isShooting)
        {
            GameObject newBullet = Instantiate(Bullet, this.transform.position + new Vector3(0, 0, 1), this.transform.rotation);

            Rigidbody BulletRB = newBullet.GetComponent<Rigidbody>();

            BulletRB.linearVelocity = this.transform.forward * BulletSpeed;
        }
        _isShooting = false;



    }

    private bool IsGrounded()
    {
        Vector3 capsuleBottom = new Vector3(_col.bounds.center.x, _col.bounds.min.y, _col.bounds.center.z);

        bool grounded = Physics.CheckCapsule(_col.bounds.center, capsuleBottom, DistanceToGround, GroundLayer, QueryTriggerInteraction.Ignore);

        return grounded;
    }







}
