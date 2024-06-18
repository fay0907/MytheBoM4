using UnityEngine;

public class Floor : MonoBehaviour
{
    private HealthManager help;
    private Enemy boterhamworst;
    float attackSpeed = 50f;
    public int state = 0;

    void Start()
    {
        boterhamworst = FindObjectOfType<Enemy>();
        help = FindObjectOfType<HealthManager>();
    }

    void SetTransformX(float n)
    {
        transform.position = new Vector3(transform.position.x, n, transform.position.z);
    }

    float timePassed = 0f;

    void Update()
    {
        timePassed += Time.deltaTime;

        if (timePassed > attackSpeed)
        {
            timePassed = 0f;
        }
    }

    public void Change()
    {
        if (state == 0)
        {
            SetTransformX(transform.position.y + 10f);
            state = 1;
            attackSpeed = 1.5f;
        }
        else if (state == 1)
        {
            attackSpeed = 1.0f;
            state = 2;
        }
        else if (state == 2)
        {
            attackSpeed = 0.5f;
            state = 3;
        }
    }
}
