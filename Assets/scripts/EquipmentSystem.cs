using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class EquipmentSystem : MonoBehaviour
{
    [SerializeField] GameObject weaponHolder;
    [SerializeField] GameObject weapon;
    [SerializeField] GameObject weaponSheath;
 
 
    GameObject currentWeaponInHand;
    GameObject currentWeaponInSheath;
    void Start()
    {
        currentWeaponInSheath = Instantiate(weapon, weaponSheath.transform);
        Debug.Log("Start Weaponnn");
    }
 
    public void DrawWeapon()
    {
        currentWeaponInHand = Instantiate(weapon, weaponHolder.transform);
        Destroy(currentWeaponInSheath);
        Debug.Log("Draw Weaponnn");
    }
 
    public void SheathWeapon()
    {
        currentWeaponInSheath = Instantiate(weapon, weaponSheath.transform);
        Destroy(currentWeaponInHand);
        Debug.Log("Sheath Weaponnn");
    }
    /*
    public void StartDealDamage()
    {
        currentWeaponInHand.GetComponentInChildren<DamageDealer>().StartDealDamage();
    }
    public void EndDealDamage()
    {
        currentWeaponInHand.GetComponentInChildren<DamageDealer>().EndDealDamage();
    }
    */
}