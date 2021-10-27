using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Field : Bonus
{
    private SaveField _saveField;

    private void OnEnable()
    {
        if(_saveField == null)
        {
            _saveField = FindObjectOfType<SaveField>();
        }
    }

    public override void Apply()
    {
        _saveField.SetActive(true);
        StartTimer();
    }

    protected override void Remove()
    {
        _saveField.SetActive(false);
    }
}
