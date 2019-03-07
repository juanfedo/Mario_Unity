using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class _SceneManager : MonoBehaviour
{

    public InputField mainInputField;
    public InputField GoombaProbInputField;
    public InputField SoildProbInputField;


    public void LoadLevel(string level)
    {
        _Parameters.Ground_prob = mainInputField.text;
        _Parameters.Soild_prob = SoildProbInputField.text;
        _Parameters.Goomba_prob = GoombaProbInputField.text;

        SceneManager.LoadScene(level);
    }
}
