using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Player/Player Health")]
public class PlayerHealthSO : ScriptableObject
{
    [SerializeField] public int MaxHealth = 100;
    [SerializeField] public int Health;

    private void Awake()
    {
        Health = MaxHealth;
    }

}
