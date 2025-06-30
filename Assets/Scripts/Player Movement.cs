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

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

  // Update is called once per frame
  void Update()
  {
      _vInput = Input.GetAxis("Vertical");
      _hInput = Input.GetAxis("Horizontal");

      this.transform.Translate(Vector3.forward * _vInput * MoveSpeed * Time.deltaTime);
      this.transform.Rotate(Vector3.up * _hInput * RotateSpeed * Time.deltaTime);


  }

//     void FixedUpdate()
//     {
//         Vector3 rotation = Vector3.up * _hInput;

//         Quaternion angleRot = Quaternion.Euler(rotation * Time.fixedDeltaTime);

//         _rb.MovePosition(this.transform.position + this.transform.forward * _vInput * Time.fixedDeltaTime);

//         _rb.MoveRotation(_rb.rotation * angleRot);
//   }



}
