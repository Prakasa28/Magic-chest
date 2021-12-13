using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateLevel : MonoBehaviour
{
    public GameObject[] section;
    public float xPos = 66;
    public int beginningSectionSpawnTimes = 10;
    public int beginningSectionIndex = 0;
    private bool creatingSections = false;
    private int secNum;
    int spawnTimes = 0;


    // Update is called once per frame
    void Update()
    {
        if (!creatingSections && spawnTimes < 30)
        {
            creatingSections = true;
            if (spawnTimes < beginningSectionSpawnTimes)
            {
                StartCoroutine(GenerateSection(beginningSectionIndex));
            }
            else
            {
                StartCoroutine(GenerateSection());
            }
           
            spawnTimes++;
        } 
    }
    IEnumerator GenerateSection(int secNum = -1)
    {
        if (secNum == -1)
        {
            secNum = Random.Range(0, 3);
        }
        
        Instantiate(section[secNum], new Vector3(xPos, 4, 0), Quaternion.identity);
        xPos += 66;
        yield return new WaitForSeconds(.1f);
        creatingSections = false;
    } 
}
