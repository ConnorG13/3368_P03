using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
  
    [SerializeField] public float _playerSpeed = 0.5f;

    void Update()
    {

        if (Input.GetKey("up"))
        {
           transform.position += new Vector3(0, 0, _playerSpeed);
        }

        if (Input.GetKey("down"))
        {
           transform.position += new Vector3(0, 0, _playerSpeed * -1);
        }

        if (Input.GetKey("right"))
        {
            transform.position += new Vector3(_playerSpeed, 0, 0);
        }

        if (Input.GetKey("left"))
        {
            transform.position += new Vector3(_playerSpeed * -1, 0, 0);
        }
    }
}
