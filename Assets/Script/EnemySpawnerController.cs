using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerController : MonoBehaviour
{
    public GameObject Enemy;
    float timer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        
        if (timer > 2)
        {
            Instantiate(Enemy, this.transform.position + new Vector3(Random.Range(-3.0f, 3.0f), 0, 0), this.transform.rotation);
            timer = 0;
        }
        
    }
}
