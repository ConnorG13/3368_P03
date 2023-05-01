using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPoints : MonoBehaviour
{
    [SerializeField] public float _playerPointGain = 1;
    private float _playerPoints = 0;

    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            _playerPoints += _playerPointGain;
            Debug.Log("Points: " + _playerPoints.ToString());
        }
    }
}
