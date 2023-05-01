using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EXPContainer_ : MonoBehaviour
{
    enum EXPGainMethod { Collectable, Enemy, Objective, Other }

    [SerializeField] private Levelable_ _levelable;
    [SerializeField] [Tooltip("How much EXP this object provides to the Levelable object.")] public int _EXPProvided = 10;
    [SerializeField] private EXPGainMethod _collectableMethod;

    private void OnTriggerEnter(Collider other)
    {
        if (_collectableMethod == EXPGainMethod.Collectable)
        {
            _levelable.GainEXP(_EXPProvided);
        }
    }

    private void OnDestroy()
    {
        if (_collectableMethod == EXPGainMethod.Enemy)
        {
            _levelable.GainEXP(_EXPProvided);
        }
    }
}
