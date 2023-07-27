using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetDestroyer : MonoBehaviour
{

    void OnCollisionEnter(Collision col)
    {
        if (gameObject.name == "The sun" && col.gameObject.name != "Camera's Body")
        {
            col.gameObject.GetComponent<MeteorShooter>().putInSun();
        }
        else if (col.gameObject.name != "Camera's Body")
        {
            gameObject.GetComponent<Renderer>().enabled = false; //Makes the planet invisible
            gameObject.GetComponent<PlanetMovement>().enabled = false;
            gameObject.GetComponent<Collider>().enabled = false;
            transform.GetChild(0).gameObject.SetActive(true);
            int planetsInRow = col.gameObject.GetComponent<MeteorShooter>().planetsInRow;
            shardSpawner(transform.position, gameObject.GetComponent<MeshRenderer>().material.mainTexture, shardGenerator(transform.localScale.x), planetsInRow);
            shardSpawner(col.transform.position, col.gameObject.GetComponent<MeshRenderer>().material.mainTexture, shardGenerator(col.transform.localScale.x), planetsInRow);

            Camera.main.gameObject.GetComponent<ScoreCounter>().score += 200 * planetsInRow + 100;
            Destroy(col.gameObject); //Delete the meteor

            Camera.main.gameObject.GetComponent<MeteroGenerate>().destroyedPlanets += 1;
        }
        else if (col.gameObject.name == "Camera's Body")
        {
            col.transform.position = col.transform.GetChild(0).GetComponent<MeteroGenerate>().spawnPoint;
            col.transform.rotation = col.transform.GetChild(0).GetComponent<MeteroGenerate>().spawnRotation;
            if (Camera.main.gameObject.GetComponent<ScoreCounter>().score > 0)
            {
                Camera.main.gameObject.GetComponent<ScoreCounter>().score -= 50;
            }
        }
    }
        

    float[] shardGenerator(float planetScale)
    {
        int shards = Random.Range(2, 5); //Shards in range 2-4
        float[] r = new float[shards];
        float rn = Mathf.Pow(planetScale/2, 3); //Comet's radius
        int i;
        for (i = 0; i < shards - 1; i++)
        {
            r[i] = Random.Range(Mathf.Pow(rn / 5f, 1 / 3f), Mathf.Pow(rn / 2f, 1 / 3f));
            rn = rn - Mathf.Pow(r[i], 3);
        }
        r[i] = Mathf.Pow(rn, 1 / 3f);
        return r;
    }
    void shardSpawner(Vector3 position, Texture texture, float[] r, int old)
    {
        for (int i = 0; i < r.Length; i++)
        {
            GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            sphere.GetComponent<MeshRenderer>().material.SetTexture("_MainTex", texture);
            float scale = r[i] * 2;
            sphere.transform.localScale = new Vector3(scale, scale, scale);
            sphere.transform.position = position;

            sphere.layer = 7;
            sphere.transform.forward = new Vector3(Random.Range(-360f, 360f), Random.Range(-360f, 360f), Random.Range(-360f, 360f));
            sphere.AddComponent<Rigidbody>().useGravity = false;
            sphere.AddComponent<MeteorShooter>();
            sphere.GetComponent<MeteorShooter>().waitTime = 5;
            sphere.GetComponent<MeteorShooter>().MeteorSpeed = 10;

            sphere.GetComponent<MeteorShooter>().planetsInRow += old + 1; 
        }
    }
}
