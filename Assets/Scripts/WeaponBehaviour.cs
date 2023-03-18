using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponBehaviour : MonoBehaviour
{
    [SerializeField] private GameObject bullet_type_;
    // Start is called before the first frame update
    void Start()
    {
        transform.localPosition = new Vector3(0.0f, 0.6f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Attack()
    {
        Debug.Log("ATTACKING");
        GameObject bullet = Instantiate(bullet_type_, transform.position, transform.rotation);
    }
}
