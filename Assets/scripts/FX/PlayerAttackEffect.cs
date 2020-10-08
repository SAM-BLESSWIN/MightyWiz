using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackEffect : MonoBehaviour
{
    public GameObject groundimpactspawn, kickspawn, firetornadospawn, shieldspawn;
    public GameObject[] lightingspawn = new GameObject[8];

    public GameObject groundimpactprefab;
    public GameObject kickprefab;
    public GameObject firetornadoprefab;
    public GameObject shieldprefab;
    public GameObject healprefab;
    public GameObject lightingprefab;

    void GroundImpact()
    {
        Instantiate(groundimpactprefab, groundimpactspawn.transform.position, Quaternion.identity);
    }

    void Kick()
    {
        Instantiate(kickprefab, kickspawn.transform.position, Quaternion.identity);
    }

    void FireTornado()
    {
        Instantiate(firetornadoprefab, firetornadospawn.transform.position, Quaternion.identity);
    }

    void FireShield()
    {
        GameObject shield= Instantiate(shieldprefab, shieldspawn.transform.position, Quaternion.identity)as GameObject;
        shield.transform.SetParent(transform);
    }

    void ThunderAttack()
    {
        for (int i = 0; i < 8; i++) 
        {
            Instantiate(lightingprefab, lightingspawn[i].transform.position, Quaternion.identity);
        }
    }

    void Heal()
    {
        Vector3 temp = transform.position;
        temp.y += 2f;
        GameObject healer= Instantiate(healprefab,temp, Quaternion.identity) as GameObject;
        healer.transform.SetParent(transform);

    }
}
