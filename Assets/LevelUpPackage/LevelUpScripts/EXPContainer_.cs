using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EXPContainer_ : MonoBehaviour
{
    enum EXPGainMethod { RepeatCollect, OnDestroy, Custom}

    [SerializeField] private Levelable_ _levelable;
    [SerializeField] [Tooltip("How much EXP this object provides to the Levelable object.")] public int _EXPProvided = 10;
    [SerializeField] private EXPGainMethod _collectableMethod;

    private void Update()
    {
        if (_collectableMethod == EXPGainMethod.Custom)
        {
            _levelable.GainEXP(_EXPProvided);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (_collectableMethod == EXPGainMethod.RepeatCollect)
        {
            Debug.Log("Giving EXP!");
            _levelable.GainEXP(_EXPProvided);
        }
    }

    private void OnDestroy()
    {
        if (_collectableMethod == EXPGainMethod.OnDestroy)
        {
            _levelable.GainEXP(_EXPProvided);
        }
    }
}
