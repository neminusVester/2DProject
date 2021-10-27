using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IntToString : MonoBehaviour
{
    [SerializeField] private Text _text;

    public void SetInt(int value)
    {
        _text.text = value.ToString();
    }
}
