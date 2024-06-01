using UnityEngine;

class Shooter : MonoBehaviour
{
    [SerializeField] GameObject prototype;
    [SerializeField] int maxAmmo;

    int ammo;

    void Start()
    {
        ammo = maxAmmo;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (ammo > 0)
            {
                GameObject newProjectile = Instantiate(prototype);
                newProjectile.transform.position = transform.position;
                newProjectile.transform.rotation = transform.rotation;

                ammo--;
            }
            else
            {
                Debug.Log("Klikk");
            }
        }

        if (Input.GetKeyDown(KeyCode.Return) && ammo == 0)
            ammo = maxAmmo;
    }
}
