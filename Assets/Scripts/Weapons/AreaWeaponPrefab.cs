using UnityEngine;

public class AreaWeaponPrefab : MonoBehaviour
{
  public AreaWeapon weapon;
  private Vector3 targetSize;
  private float timer;

  void Start()
  {
    weapon = GameObject.Find("Area Weapon").GetComponent<AreaWeapon>();
    targetSize = Vector3.one * weapon.range;
    transform.localScale = Vector3.zero;
    timer = weapon.duration;
  }

  void Update()
  {
    transform.localScale = Vector3.MoveTowards(transform.localScale, targetSize, Time.deltaTime * 5);
    timer -= Time.deltaTime;
    if (timer <= 0)
    {
      targetSize = Vector3.zero;
      if (transform.localScale.x == 0f)
      {
        Destroy(gameObject);
      }
    }
  }

  private void OnTriggerStay2D(Collider2D collider)
  {
    if (collider.CompareTag("Enemy"))
    {
      Inimigos enemy = collider.GetComponent<Inimigos>();
      enemy.TakeDamage(weapon.damage);
    }
  }
}
