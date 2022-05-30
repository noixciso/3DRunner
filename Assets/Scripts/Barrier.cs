using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrier : MonoBehaviour
{
    private int _damage = 1;

    public int Damage
    {
        get => _damage;
       private set => _damage = value;
    }
}
