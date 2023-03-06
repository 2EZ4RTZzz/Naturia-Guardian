using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffTreeGenerator : MonoBehaviour
{
    [SerializeField] private GameObject buffDetails;
    public GameObject buffTree;
    public List<Vector3> posList = new List<Vector3>();
    public int buffID = 0;
    [SerializeField] private GameObject buffInfo;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (buffDetails.GetComponent<BuffDetails>().buffTreeGenerating)
        {
            buffID = buffDetails.GetComponent<BuffDetails>().SetBuffID();
            int index = Random.Range(0, posList.Count);
            Instantiate(buffTree, transform.position = posList[index], Quaternion.identity);
            posList.RemoveAt(index);
            buffDetails.GetComponent<BuffDetails>().buffTreeGenerating = false;
        }
    }

   
}
