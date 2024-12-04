using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

public class TankController : MonoBehaviour
{
    [SerializeField] private float speed = 0f;
    [SerializeField] private float rotation = 0f;
    [SerializeField] private GameObject Tower_;
    
    private float _upDownInput = 0f;
    private float _rightLeftInput = 0f;
    private float rotate = 0.0f;
    
    //private Rigidbody _rigidbody;
    
    void Start()
    {
        //_rigidbody = GetComponent<Rigidbody>();
    }
    void Update()
    {
        if (_upDownInput > 0.5)
        {
            transform.position += transform.forward * (speed * Time.deltaTime);
        }
        else if (_upDownInput < -0.5)
        {
            transform.position -= transform.forward * (speed * Time.deltaTime);
        }

        if (_rightLeftInput > 0.5)
        {
            transform.Rotate(0, rotation, 0);
            Tower_.transform.Rotate(0, -rotation, 0);
        }
        else if (_rightLeftInput < -0.5)
        {
            transform.Rotate(0, -rotation, 0);
            Tower_.transform.Rotate(0, rotation, 0);
        }
        
        if (rotate < -0.5)
        {
            Tower_.transform.Rotate(0, -rotation, 0);
        }
        else if (rotate > 0.5)
        {
            Tower_.transform.Rotate(0, rotation, 0);
        }
    }

    void OnUpDown(InputValue value)
    {
        _upDownInput = value.Get<float>();
    }

    void OnLeftRight(InputValue value)
    {
        _rightLeftInput = value.Get<float>();
    }
    
    void OnMoveRL(InputValue value)
    {
        rotate = value.Get<float>();
    }
}