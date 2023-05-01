using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Levelable_ : MonoBehaviour
{

    [Header("Parameter")]
    [SerializeField]
    [Tooltip("The component to be used for leveling. Enter the script and replace the 'PlayerMovement' class with the desired component, as well as find and replace all '_playerSpeed' instances with the desired variable.")]
    private PlayerMovement _parameterComponent;

    [Header("Leveling")]
    [SerializeField] [Tooltip("The object's current level.")] private int _currentLevel = 1;
    [SerializeField] [Tooltip("The maximum level the object can reach.")] private int _maxLevel = 10;
    [SerializeField] [Tooltip("The base amount of EXP required to level up.")] private int _EXPPerLevel = 100;
    
    private int _currentEXP = 0;
    private int _startingEXPPerLevel;

    enum EXPScaleMethods {Additive, Multiplicative};
    [Header("EXP Scaling")]
    [SerializeField] [Tooltip("Will the amount of EXP needed to level up increase per level?")] private bool _EXPScaling = false;
    [SerializeField] [Tooltip("Additive adds the base EXP per level, multiplied by the below modifier. Multiplicative multiplies the required EXP by the below modifier each level.")] private EXPScaleMethods _scaleMethod;
    [SerializeField] [Tooltip("The modifier for scaling EXP values. Higher values mean later levels will require more EXP.")] [Range(1, 5)] private float _EXPModifier = 1.5f;



    [Header("Usage")]
    [SerializeField] [Tooltip("The starting value for the desired stat.")] private float _startingStat = 0.5f;
    [SerializeField] [Tooltip("The amount added to the stat per level up.")] private float _statModifier = 0.25f;

    private void Awake()
    {
        _parameterComponent._playerSpeed = _startingStat;
        _startingEXPPerLevel = _EXPPerLevel;
    }

    private void Update()
    {
        if (_currentEXP >= _EXPPerLevel && _currentLevel < _maxLevel)
        {
            _currentEXP -= _currentEXP;

            if (_EXPScaling == true)
            {
                switch (_scaleMethod)
                {
                    case EXPScaleMethods.Additive:
                        _EXPPerLevel += Mathf.RoundToInt(_startingEXPPerLevel * _EXPModifier);
                        break;

                    case EXPScaleMethods.Multiplicative:
                        _EXPPerLevel = Mathf.RoundToInt(_EXPPerLevel * _EXPModifier);
                        break;

                }
            }
                
            _currentLevel++;

            _parameterComponent._playerSpeed += _statModifier;
        }
    }

    public void GainEXP(int _expGained)
    {
        _currentEXP += _expGained;
    }

}
