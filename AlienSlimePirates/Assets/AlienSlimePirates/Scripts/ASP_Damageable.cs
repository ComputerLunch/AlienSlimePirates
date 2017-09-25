namespace VRTK.Examples
{
    using UnityEngine;

    public class ASP_Damageable : MonoBehaviour
    {
		[SerializeField] 
		private ParticleSystem particles;

		[SerializeField]
		private int hitPoints = 100;
		// Use this for initialization
		private int damageReceived  = 0;
		public int HitPoints
		{
			get
			{
				return hitPoints;
			}
		}
			

		private void Start()
		{
			particles = GetComponent<ParticleSystem>();
		}

        private void OnCollisionEnter(Collision collision)
        {

			//all damage inflicting things shoudl have a WeaponCollisionObject tag
			if (collision.collider.gameObject.CompareTag("WeaponCollisionObject"))
			{
				//all damage inflicting objects shoudl have an ASP_WeaponDamage script
				ASP_WeaponDamage damageScript = collision.collider.gameObject.GetComponent<ASP_WeaponDamage>();

				if (damageScript != null){
					CauseDamage(damageScript.DamageInflicted);
				} else {
					//but, in case they don't
					CauseDamage(0);
				}
            }
        }

        private void CauseDamage(int damage)
        {
			damageReceived += damage;
			if (damageReceived >= hitPoints){
				DestroySelf();
			}
        }
		private void DestroySelf()
		{
			if (particles != null){
				particles.Play();
			}
			Destroy(gameObject);
		}
    }
}