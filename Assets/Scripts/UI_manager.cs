using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UI_manager : MonoBehaviour
{
    public TextMeshProUGUI txt_score;
    public TextMeshProUGUI txt_vida;
    public TextMeshProUGUI txt_timer;
    public TextMeshProUGUI txt_municiones;
    public TextMeshProUGUI txt_position;

    private int value_score;
    private int value_vida;
    private int value_municiones;
    private float value_timer;
    private string value_position;


    private void Start()
    {
        value_score = 0;
        value_vida = 100;
        value_municiones = 0;
        value_timer = 0.0f;
        value_position = "normal";
    }

    private void Update()
    {
        txt_vida.text = "Vida: " + value_vida.ToString();
        txt_score.text = "Score: " + value_score.ToString();
        txt_municiones.text = "Balas: " + value_municiones.ToString();
        txt_position.text = "Position: " + value_position;
        txt_timer.text = "Time: " + value_timer.ToString(); 
    }

    public void update_position(string new_position)
    {
        value_position = new_position;
    }

}
