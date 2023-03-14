using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillUI : MonoBehaviour
{
    public SkillDataList_SO skillDataList;
    private List<SkillDetails> currentList;
    public GameObject player1, player2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player1.activeSelf) currentList = skillDataList.fireRabbitSkills;
        if (player2.activeSelf) currentList = skillDataList.iceRabbitSkills;
        updateUI();
    }

    private void updateUI()
    {
        for (int i=1; i<4; i++)
        {
            transform.GetChild(i).GetChild(0).GetComponent<Image>().sprite = currentList[i - 1].skillIcon;
        }
    }
}
