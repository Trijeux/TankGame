// Script by : Nanatchy

using System;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;
using UnityEngine.UI;


public class TankController : MonoBehaviour
{
    #region Attributs

    [SerializeField] private GameObject tower;
    [SerializeField] private GameObject gameOver;
    [SerializeField] private Text lifeText;
    
    [SerializeField] private Damage damage;
    
    [SerializeField] private float speed = 0f;
    [SerializeField] private float rotation = 0f;
    [SerializeField] private int life = 0;
    
    private float _upDownInput = 0f;
    private float _rightLeftInput = 0f;
    private float _rotate = 0.0f;
    
    #endregion

    #region Methods

    
    
    #endregion

    #region Behaviors

    private void Update()
    {
        lifeText.text = "Life : " + life;
        
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
            tower.transform.Rotate(0, -rotation, 0);
        }
        else if (_rightLeftInput < -0.5)
        {
            transform.Rotate(0, -rotation, 0);
            tower.transform.Rotate(0, rotation, 0);
        }
        
        if (_rotate < -0.5)
        {
            tower.transform.Rotate(0, -rotation, 0);
        }
        else if (_rotate > 0.5)
        {
            tower.transform.Rotate(0, rotation, 0);
        }

        if (damage.damage)
        {
            life--;
            damage.damage = false;
        }

        if (life <= 0)
        {
            damage.isDead = true;
        }

        if (damage.isDead)
        {
            gameOver.SetActive(true);
            gameObject.SetActive(false);
        }
    }

    private void OnUpDown(InputValue value)
    {
        _upDownInput = value.Get<float>();
    }

    private void OnLeftRight(InputValue value)
    {
        _rightLeftInput = value.Get<float>();
    }

    private void OnMoveRL(InputValue value)
    {
        _rotate = value.Get<float>();
    }
    
    #endregion
}