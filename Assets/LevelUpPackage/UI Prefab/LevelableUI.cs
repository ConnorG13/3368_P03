using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelableUI : MonoBehaviour
{
    [SerializeField] private Levelable_ _levelable;
    [SerializeField] private TextMeshProUGUI _levelableDisplay;
    [SerializeField] private Slider _slider;


    private void Awake()
    {
        _slider.value = _levelable._currentEXP;
        _levelableDisplay.text = "Lvl. " + _levelable._currentLevel.ToString();
    }
    private void Update()
    {
        if (_levelable._EXPGained == true)
        {
            _slider.value += _levelable._EXPAmount;

            _levelable._EXPAmount = 0;
            _levelable._EXPGained = false;
        }

        if (_levelable._hasLeveledUp == true)
        {
            _slider.value -= _levelable._EXPPerLevel;
            _levelableDisplay.text = "Lvl. " + _levelable._currentLevel.ToString();

            _slider.maxValue = _levelable._EXPPerLevel;

            _levelable._hasLeveledUp = false;
        }
    }


}
