using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorShooter : MonoBehaviour
{
    public float waitTime = 50.0f;
    private float timer = 0.0f;
    public float MeteorSpeed = 30.0f;
    private float MeteorSpeedInSun = 13.0f;
    public bool inSun = false;

    public int planetsInRow = 0;

    void Start()
    {
        QualitySettings.vSyncCount = 0;
    }
    public void putInSun()
    {
        inSun = true;
        timer = 47.0f;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (inSun)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(0, 0, 0), MeteorSpeedInSun * Time.deltaTime);
        }
        else
        {
            gameObject.GetComponent<Rigidbody>().MovePosition(transform.position + (transform.forward * Time.fixedDeltaTime * MeteorSpeed));
        }



        if (timer > waitTime || System.Array.IndexOf(Physics.OverlapSphere(new Vector3(0, 0, 0), 750), GetComponent<Collider>()) < 0)
        {
            if (planetsInRow == 0 && Camera.main.gameObject.GetComponent<ScoreCounter>().score > 0)
            {
                Camera.main.gameObject.GetComponent<ScoreCounter>().score -= 50;
            }
            Destroy(gameObject);
        }
    }
}
