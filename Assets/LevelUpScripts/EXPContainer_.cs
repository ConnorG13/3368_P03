using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EXPContainer_ : MonoBehaviour
{
    [SerializeField] [Tooltip("How much EXP this object provides to the Levelable object.")] public int _EXPProvided = 10;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collision Detected!");
        Levelable_ _otherLevelable = other.gameObject.GetComponent<Levelable_>();
        _otherLevelable.GainEXP(_EXPProvided);
    }
}
