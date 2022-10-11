using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    int jumpCount;
    float jumpPower = 6.0f;

    public Text judge_text;
    public SerialReceive SR;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if ((Input.GetKeyDown("space") || SR.input_check == true) && jumpCount < 2)
        {
            this.GetComponent<Rigidbody>().velocity = new Vector3(0, jumpPower, 0);
            jumpCount++;
        }
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Ground")
        {
            jumpCount = 0;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            StartCoroutine("TimeWait");
            //Debug.Log("‚ ‚½‚Á‚½");
        }
    }

    IEnumerator TimeWait()
    {
        judge_text.gameObject.SetActive(true);

        yield return new WaitForSeconds(0.5f);

        judge_text.gameObject.SetActive(false);
    }
}
