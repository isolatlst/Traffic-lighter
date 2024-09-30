using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeLighting : MonoBehaviour
{
    private uint indexer;
    public Material[] Lighters;
    public GameObject[] Lamps;
    private bool isRunning = false;


    // Start is called before the first frame update
    void Start()
    {
        indexer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isRunning)
        {
            isRunning = true;
            StartCoroutine(ChangeTrafficLight());
        }
    }
    
    private void SetDefault ()
    {
        Lamps[indexer].GetComponent<MeshRenderer>().material = Lighters[3];
        if (indexer == 2) indexer = 0;
        else indexer++;
        isRunning = false;
    }

    IEnumerator ChangeTrafficLight()
    {
        Lamps[indexer].GetComponent<MeshRenderer>().material = Lighters[indexer];
        yield return new WaitForSecondsRealtime(1);
        SetDefault();
    }
}