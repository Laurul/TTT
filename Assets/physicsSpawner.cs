using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Profiling;
using System.IO;
public class physicsSpawner : MonoBehaviour
{
    [SerializeField] GameObject mesh;
    [SerializeField] float seconds;
    float timer;
    float posX;
    float posY;
    float posZ;
    int nr = 0;

    public int FPS { get; private set; }
    // Start is called before the first frame update

    void CreateText()
    {
        string path = Application.dataPath + "/Log.txt";
        if (!File.Exists(path))
        {
            File.WriteAllText(path, "Login log \n\n");
        }

        string content = "FPS data: " + FPS.ToString() + "/n";

        File.AppendAllText(path, content);


    }

    // Start is called before the first frame update
    void Start()
    {
        timer = seconds;
        CreateText();
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0.0f)
        {
            Debug.Log(nr + " " + FPS);
            SpawnMesh();
            timer = seconds;
        }
      
       
       
    }

    void SpawnMesh()
    {
        FPS = (int)(1f / Time.unscaledDeltaTime);
        posX = Random.Range(-50,50);
        posY = Random.Range(10,100);
        posZ = Random.Range(10,50);
        Instantiate(mesh, new Vector3(posX, posY, posZ), Quaternion.identity);
        nr++;
    }
}
