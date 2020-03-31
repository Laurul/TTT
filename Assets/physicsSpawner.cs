using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class physicsSpawner : MonoBehaviour
{
    [SerializeField] GameObject mesh;
    [SerializeField] float seconds;
    float timer;
    float posX;
    float posY;
    float posZ;
    int nr = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        timer = seconds;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0.0f)
        {
            SpawnMesh();
            timer = seconds;
        }
        Debug.Log(nr);
    }

    void SpawnMesh()
    {
        posX = Random.Range(-50,50);
        posY = Random.Range(10,100);
        posZ = Random.Range(10,50);
        Instantiate(mesh, new Vector3(posX, posY, posZ), Quaternion.identity);
        nr++;
    }
}
