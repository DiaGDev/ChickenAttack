using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Bar : MonoBehaviour
{
    [field:SerializeField]
    public int MaxValue { get; private set; }

    [field:SerializeField]
    public int Value { get; private set;}

    [SerializeField]
    public Image topBar;

    public float healthAmount = 100f;

    public void TakeDamage(float damage)
    {
        healthAmount -= damage;
        healthAmount = Mathf.Clamp(healthAmount, 0, 100);
        topBar.fillAmount = healthAmount / 100f;

        if (healthAmount <= 0)
        {
            if (transform.root.gameObject.tag == "Player1" || transform.root.gameObject.tag == "Player2")
            {
                SceneManager.LoadScene("Lose");
            }
            Destroy(transform.root.gameObject);

        }
    }

    public void Heal(float healingAmount)
    {
        healthAmount += healingAmount;
        healthAmount = Mathf.Clamp(healthAmount,0,100);

        topBar.fillAmount = healthAmount / 100f;
    }


}
