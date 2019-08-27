using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    [Header("UI")]
    public Slider healthSlider;
    public Image healthFill;

    public Slider jetpackSlider;
    public Image jetpackFill;

    public GameObject gameOverPanel;
    public GameObject gameUIPanel;

    [Header("Player Stats")]
    public float curHealth;
    public float health;

    public float curJetpack;
    public float jetpack;


    void Update()
    {
        healthSlider.value = Mathf.Clamp01(curHealth / health);
        jetpackSlider.value = Mathf.Clamp01(curJetpack / jetpack);
    }
    public void PlayerTakeDamage(int damage)
    {
        //health -= damage;
        curHealth -= damage;
        if (curHealth <= 0)
        {
            Destroy(gameObject);
            gameOverPanel.SetActive(true);
            gameUIPanel.SetActive(false);
            healthSlider.enabled = false;

        }
    }
    void ManageHealthBar()
    {
        if (curHealth <= 0 && healthFill.enabled)
        {
            healthFill.enabled = false;
        }
    }
}
