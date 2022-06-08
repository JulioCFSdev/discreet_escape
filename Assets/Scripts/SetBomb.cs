using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetBomb : MonoBehaviour
{
    public BombBehaviour bombPrefab;

    
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(bombPrefab.gameObject, transform.position, transform.rotation);
        }
    }
}
