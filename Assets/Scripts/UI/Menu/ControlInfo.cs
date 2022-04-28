using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlInfo : MonoBehaviour
{
    public GameObject InfoEnemy;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void CloseInfo()
    {
        InfoEnemy.SetActive(false);
    }
    public void OpenText()
    {
        InfoEnemy.SetActive(true);
    }
    public void CloseText()
    {
        InfoEnemy.SetActive(false);
    }
}
