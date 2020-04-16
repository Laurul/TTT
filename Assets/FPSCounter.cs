using System.IO;
using UnityEngine;
using UnityEngine.Profiling;

public class FPSCounter : MonoBehaviour
{
    [SerializeField] int frameRange=1;
    public int AverageFPS { get; private set; }
    // Start is called before the first frame update

    public int HighestFPS { get; private set; }
    public int LowestFPS { get; private set; }



    int[] fpsBuffer;
    int fpsBufferIndex;

    void CreateText()
    {
        //string path = Application.dataPath + "/Log.txt";
        //if (!File.Exists(path))
        //{
        //    File.WriteAllText(path, "Login log \n\n");
        //}

        //string content = "FPS data: " +FPS.ToString() + "\n";

        //File.AppendAllText(path, content);

       
    }
    void Start()
    {

       
        //Profiler.logFile = "mylog"; //Also supports passing "myLog.raw"
        //Profiler.enableBinaryLog = true;
        //Profiler.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (fpsBuffer == null || fpsBuffer.Length != frameRange)
        {
            InitializeBuffer();
        }
        UpdateBuffer();
        CalculateFPS();
        //CreateText();
        // Debug.Log(Application.dataPath.ToString());
        //FPS = (int)(1f / Time.unscaledDeltaTime);
    }


    void UpdateBuffer()
    {
        fpsBuffer[fpsBufferIndex++] = (int)(1f / Time.unscaledDeltaTime);
        if (fpsBufferIndex >= frameRange)
        {
            fpsBufferIndex = 0;
        }
    }

    void InitializeBuffer()
    {
        if (frameRange <= 0)
        {
            frameRange = 1;
        }
        fpsBuffer = new int[frameRange];
        fpsBufferIndex = 0;
    }

    void CalculateFPS()
    {
        int sum = 0;
        int highest = 0;
        int lowest = int.MaxValue;
        for (int i = 0; i < frameRange; i++)
        {
            int fps = fpsBuffer[i];
            sum += fps;
            if (fps > highest)
            {
                highest = fps;
            }
            if (fps < lowest)
            {
                lowest = fps;
            }
        }
        AverageFPS = sum / frameRange;
        HighestFPS = highest;
        LowestFPS = lowest;
    }

}
