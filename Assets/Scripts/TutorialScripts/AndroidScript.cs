using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AndroidScript : MonoBehaviour
{
    public GameObject dialogBox2;
    public GameObject dialogBox3;
    public GameObject dialogBox4;
    public GameObject dialogBox5;
    void Start()
    {
#if (UNITY_ANDROID || UNITY_EDITOR)
        dialogBox2.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = "����������� �������� ��� ������������.";
        dialogBox3.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = "����� ���������� ����� ���, ��������, ��� ��������� �����, �� ������ �������� ��� ���������� ������.";
        dialogBox4.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = "�� ������ ������������ � ������� ���� � �������, ����� ����� ������ ������ ������.������ ������ ����� �� �������������� ������� �������, ������ ������� ����������� ��������� ��������� ��������, ��������, �������� �������.";
        dialogBox5.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = "��������� ���� 3 ����� �����, ��� ������������ � ����� ������� ����. ����� ��������� ���� �� �����, ��� ������ ����� ������, ����� ������ ������ � ������� �����. " +
            "����� ���������� ������ �� ����� ���� �� ������ �����. ���� ���� ���� ������ �� ����� ����� � ������� ��, ��� �� ��������� ��� ������������ � ���." +
            " ����� ������������ ���� ������������ � ��� � ��������� 1 ����� ����";
#endif
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
