using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    float speed = 8.0f;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, 7.5f);
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position += new Vector3(0, 0, -speed * Time.deltaTime);
    }
}
