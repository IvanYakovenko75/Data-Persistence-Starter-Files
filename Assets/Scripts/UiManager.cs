using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using UnityEngine.UI;
using UnityEditor;

public class UiManager : MonoBehaviour
{


    public void Quit()
    {
        //������� �� ������ ������ �������� � ��������� ���������
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
