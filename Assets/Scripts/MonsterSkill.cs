using UnityEngine;

public class MonsterSkill : MonoBehaviour
{
    [Tooltip("The distance at which the monster will start charging towards the player.")]
    public float chargeDistance = 5f;

    [Tooltip("The speed at which the monster will charge towards the player.")]
    public float chargeSpeed = 10f;

    [Tooltip("The duration of the rotation after the charge ends.")]
    public float rotationDuration = 2f;

    [Tooltip("The interval between each charge.")]
    public float chargeInterval = 5f;

    private Transform playerTransform;
    private bool isCharging = false;

    private void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        InvokeRepeating("Charge", chargeInterval, chargeInterval);
    }

    private void Update()
    {
        if (isCharging)
        {
            transform.position = Vector3.MoveTowards(transform.position, playerTransform.position, chargeSpeed * Time.deltaTime);
            if (Vector3.Distance(transform.position, playerTransform.position) < 0.1f)
            {
                isCharging = false;
                Invoke("Rotate", rotationDuration);
            }
        }
    }

    private void Charge()
    {
        if (Vector3.Distance(transform.position, playerTransform.position) < chargeDistance)
        {
            isCharging = true;
        }
    }

    private void Rotate()
    {
        transform.Rotate(Vector3.up, 180f);
    }
}
