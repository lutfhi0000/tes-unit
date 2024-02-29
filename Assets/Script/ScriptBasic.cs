using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptBasic : MonoBehaviour
{
    Rigidbody _rb;
    float _speed = 5.5f;
    float _swingSpeed = 100f;
    

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Input untuk gerakan maju dan mundur
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = transform.forward * moveVertical * _speed;

        // Input untuk gerakan berayun dari kiri ke kanan
        float swingHorizontal = Input.GetAxis("Horizontal");
        Quaternion swingRotation = Quaternion.Euler(0f, swingHorizontal * _swingSpeed * Time.deltaTime, 0f);

        // Memukul (bergerak maju/mundur dan berayun)
        if (moveVertical != 0f || swingHorizontal != 0f)
        {
            _rb.MovePosition(_rb.position + movement * Time.deltaTime);
            _rb.MoveRotation(_rb.rotation * swingRotation);
        }
    }
}
