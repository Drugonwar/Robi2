using UnityEngine;

public class HealthObject : MonoBehaviour
{
    [SerializeField] int maxHp = 100;

    int hp;

    void Start()
    {
        hp = maxHp;
    }

    public void Damage(int damage)
    {
        hp -= damage;
        if (hp <= 0)
            Destroy(gameObject);
    }
    
    public void ResetHP()
    {
        hp = maxHp;
    }
}
