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
    public GameObject hurtPanel;

    [Header("Player Stats")]
    public float curHealth;
    public float health;

    public float curJetpack;
    public float jetpack;

    public int heal = 25;

    


    void Update()
    {
        healthSlider.value = Mathf.Clamp01(curHealth / health);
        jetpackSlider.value = Mathf.Clamp01(curJetpack / jetpack);
        Hurt();
    }
    public void PlayerTakeDamage(int damage)
    {
        
        curHealth -= damage;
        if (curHealth <= 0)
        {
            Destroy(gameObject);
            gameOverPanel.SetActive(true);
            gameUIPanel.SetActive(false);
            healthSlider.enabled = false;

        }
      
    }
    public void Heal()
    {
        curHealth += heal;
    }
    public void DestroyItem(GameObject item)
    {
        Destroy(item);
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "HealthItem")
        {
            Heal();
            DestroyItem(other.gameObject);

        }
    }
        void ManageHealthBar()
    {
        if (curHealth <= 0 && healthFill.enabled)
        {
            healthFill.enabled = false;
        }
    }
    public void Hurt()
    {
        if (curHealth <= 25)
        {
            hurtPanel.SetActive(true);
        }
        else
        {
            hurtPanel.SetActive(false);
        }

    }
  
}
