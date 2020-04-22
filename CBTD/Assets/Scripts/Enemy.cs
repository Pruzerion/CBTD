using UnityEngine;

public class Enemy : MonoBehaviour {

    public float health = 0f;
	public bool IsDead = false;
	private WaypointManager waypointmanager;
	[SerializeField] private int index = 0;
	[SerializeField] private float speed = 0f;
	private Shop shop = null;
	[SerializeField] private float killvalue = 0f;

	void Start () 
	{
		waypointmanager = GameObject.Find("Waypoint Manager").GetComponent<WaypointManager>();
		shop = GameObject.Find("Shop").GetComponent<Shop>();
	}

	void Update () 
	{
		if(health <= 0f)
        {
			Die();
        }

		if (!IsDead)
		{
			Move();
		}
		else
		{
			return;
		}
	}

	private void Move()
	{
		Vector2 direction = waypointmanager.waypoints[index].transform.position - transform.position;
		float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
		Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
		transform.rotation = Quaternion.Slerp(transform.rotation, rotation, 1000 * Time.deltaTime);

		transform.position = Vector2.MoveTowards(transform.position, waypointmanager.waypoints[index].transform.position, speed * Time.deltaTime);

		if(Vector2.Distance(transform.position, waypointmanager.waypoints[index].transform.position) < 0.02f && index < waypointmanager.waypoints.Length)
		{
			index++;
		}
	}

	public void TakeDamage(float value)
    {
		health -= value;
    }

	private void Die()
	{
		IsDead = true;
		shop.potato += killvalue;
		Destroy(gameObject);
	}
}
