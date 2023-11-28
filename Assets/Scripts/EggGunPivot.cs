using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EggGunPivot : MonoBehaviour
{
    public Transform eggGun_holder;
    public Transform fire_point;

    public GameObject eggAmmoType;

    public TextMeshProUGUI uiText;

    public KeyCode shootKey;

    public int eggAmmoMax;
    public int eggAmmoCurr;
    public int reloadTime;

    private bool isReloading = false;
    private float reloadTimer = 0f;

    private void Update()
    {
        PlayerInput();
        UpdateUI();
    }

    void PlayerInput()
    {
        if (isReloading)
        {
            return;
        }

        if (Input.GetKeyDown(shootKey))
        {
            if (eggAmmoCurr > 0)
            {
                Instantiate(eggAmmoType, fire_point.position, transform.rotation);
                eggAmmoCurr--;
            }
            else
            {
                StartCoroutine(Reload(eggAmmoMax));
            }
        }
    }

    IEnumerator Reload(int eggAmmoMax)
    {
        isReloading = true;
        reloadTimer = reloadTime;

        while (reloadTimer > 0f)
        {
            yield return new WaitForSeconds(0.1f);
            reloadTimer -= 0.1f;
        }

        eggAmmoCurr = eggAmmoMax;
        isReloading = false;
    }

    void UpdateUI()
    {
        string text = "Egg Ammo: " + eggAmmoCurr.ToString();

        if (isReloading)
        {
            text += "\nReloading: " + Mathf.CeilToInt(reloadTimer).ToString() + "s";
        }

        uiText.text = text;
    }
}
