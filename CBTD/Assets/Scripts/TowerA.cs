using UnityEngine;

public class TowerA : MonoBehaviour
{

	private bool IsLocked = false;
	[SerializeField]private Enemy target = null;
	[SerializeField] private float damage = 0f;
	private Animator anim;
	[SerializeField] private float RotateSpeed = 0f;
	private float firedelay = 0f;
	[SerializeField] private float firerate = 60f;
	private bool attack = false;
	[SerializeField] private enum type {OneTarget, SprayNPray, Flame, Lego};
	[SerializeField] private bool infiniteRange = false;

	private Enemy[] enemies = null;

	void Start()
	{
		anim = gameObject.GetComponent<Animator>();
		IsLocked = false;
	}

	void Update()
	{
		if (target.IsDead == true)
		{
			target = null;
		}

	//	GameObject.FindGameObjectsWithTag("enemy");
		if(target == null)
		{
			IsLocked = false;
		}
		else
		{
			Attack(target);
		}

	/*	if(!IsLocked && infiniteRange)
		{

			enemies = FindObjectsOfType<Enemy>();

			float max = enemies[0].health;
			int index = 0;

			for (int i = 0; i < enemies.Length; i++)
			{
				if(enemies[i].health > max)
				{
					max = enemies[i].health;
					index = i;
				}
			}

				target = enemies[index];
				IsLocked = true;
		} */

		firedelay -= Time.deltaTime;
	}

	void Attack(Enemy targ)
	{
		if (firedelay < 0f)
		{
			firedelay = 0f;
		}

	    if (firedelay <= 0f)
		{
			Vector2 direction = targ.transform.position - transform.position;
			float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
			Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
			transform.rotation = Quaternion.Slerp(transform.rotation, rotation, RotateSpeed * Time.deltaTime);

			anim.Play("shoot", 0, 0f);
			firedelay += 60f / firerate;
			targ.TakeDamage(damage);
		}
		else
		{
			return;
		}
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (!IsLocked && col.gameObject.CompareTag("enemy"))
		{
			target = col.gameObject.GetComponent<Enemy>();
			IsLocked = true;
		}
	}

	private void OnTriggerStay2D(Collider2D col)
	{
		if (!IsLocked && col.gameObject.CompareTag("enemy"))
		{
			target = col.gameObject.GetComponent<Enemy>();
			IsLocked = true;
		}
	}

 /*	private void OnTriggerExit2D(Collider2D col)
	{
		if(col.gameObject.GetComponent<Enemy>() == target)
		{
			target = null;
		}
	}*/ 
}
