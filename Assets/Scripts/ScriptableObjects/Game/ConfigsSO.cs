using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Player/Config")]
public class ConfigsSO : ScriptableObject
{
    [SerializeField] public int current_level = 0;
}
