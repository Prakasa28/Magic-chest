using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateLevel : MonoBehaviour
{
    public GameObject[] section;
    public float xPos = 66;
    public bool creatingSections = false;
    public int secNum;
    int spawnTimes = 30;
 

    // Update is called once per frame
    void Update()
    {
       if(!creatingSections && spawnTimes > 0)
        {
            creatingSections = true;
            StartCoroutine(GenerateSection());
            spawnTimes--;
        } 
    }
    IEnumerator GenerateSection()
    {
        secNum = Random.Range(0, 3);
        Instantiate(section[secNum], new Vector3(xPos, 4, 0), Quaternion.identity);
        xPos += 66;
        yield return new WaitForSeconds(2);
        creatingSections = false;
    } 
}
