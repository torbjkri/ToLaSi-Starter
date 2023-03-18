using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Player/Player Health")]
public class PlayerHealthSO : ScriptableObject
{
    [SerializeField] public int MaxHealth { get; set; } = 100;
    [SerializeField] public int Health { get; set; }

    private void Awake()
    {
        Health = MaxHealth;
    }

}
