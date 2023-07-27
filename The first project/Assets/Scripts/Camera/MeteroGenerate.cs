using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteroGenerate : MonoBehaviour
{
    public int destroyedPlanets;
    private bool started = false;
    public GameObject comets;
    public Vector3 spawnPoint;
    public Quaternion spawnRotation;
    Texture textureMeteor;
    // Start is called before the first frame update
    void Start()
    {
        spawnPoint = transform.position;
        spawnRotation = transform.rotation;
        textureMeteor = Resources.Load<Texture2D>("Textures/meteor");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            sphere.GetComponent<MeshRenderer>().material.SetTexture("_MainTex", textureMeteor);
            float scale = Random.Range(2.0f, 10.0f);
            sphere.transform.localScale = new Vector3(scale, scale, scale);
            sphere.transform.position = transform.position;

            sphere.transform.SetParent(comets.transform);

            sphere.transform.forward = transform.forward;

            sphere.AddComponent<Rigidbody>().useGravity = false;

            sphere.AddComponent<MeteorShooter>();

        }

        if (destroyedPlanets == 5 && !started)
        {
            started = true;
            for (int i = 0; i < comets.transform.childCount; i++)
            {
                if (Camera.main.gameObject.GetComponent<ScoreCounter>().score > 0)
                {
                    Camera.main.gameObject.GetComponent<ScoreCounter>().score -= 50;
                }
                Destroy(comets.transform.GetChild(i).gameObject);
            }
            transform.parent.GetComponent<CameraMovement>().enabled = false;
            enabled = false;
        }
    }
}
