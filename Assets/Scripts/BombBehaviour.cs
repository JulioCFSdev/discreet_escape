using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombBehaviour : MonoBehaviour
{
    public float timeToExplode;
    public int power;
    public Transform[] angles;
    public ExplosionBehavior explosionPrefab;
    public float distanceExplosion;

    private float currentTimeToExplode;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        currentTimeToExplode += Time.deltaTime;

        if(currentTimeToExplode > timeToExplode) Explode();

    }

    public void Explode()
    {
        int i = 0;
        int currentPower;
        foreach(Transform side in angles)
        {
            i++;
            RaycastHit2D hitInfo = Physics2D.Linecast(transform.position, side.position);

            if(hitInfo.collider != null)
            {
                currentPower = power;
            } else
            {
                currentPower = 0;
            }

            Vector2 direction = new Vector2();
            string position = "vertical";

            if(i == 1) direction = Vector2.left;
            else if(i == 2) direction = Vector2.right;
            else if(i == 3) direction = Vector2.up;
            else if(i == 4) direction = Vector2.down;

            if(i == 3 || i == 4) position = "horizontal";

            Vector2 newDistance = distanceExplosion * direction;
            
            InstantiateExplosion(position, currentPower, newDistance);
            
        }

        InstantiateExplosion("center", 0, Vector2.zero);

        Destroy(gameObject);

    }

    public void InstantiateExplosion(string position, int power, Vector2 distance) 
    {
        GameObject explosion = Instantiate(explosionPrefab.gameObject, transform.position, transform.rotation) as GameObject;

        explosion.GetComponent<ExplosionBehavior>().Detonate(position, power, distance);

    }
}
