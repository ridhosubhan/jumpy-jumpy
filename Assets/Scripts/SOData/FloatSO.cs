using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class FloatSO : ScriptableObject
{

    [SerializeField] public float _value;
    public float Value { 
        get{ return _value; } 
        set{ _value = value; } 
    }
}
