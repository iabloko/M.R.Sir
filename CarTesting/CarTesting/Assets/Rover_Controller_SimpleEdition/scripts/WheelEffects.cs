using System.Collections;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Car
{
    [RequireComponent(typeof (AudioSource))]
    public class WheelEffects : MonoBehaviour
    {
        public static Transform skidTrailsDetachedParent;

        public ParticleSystem skidParticles_organic;

        public bool skidding { get; private set; }

        private WheelCollider m_WheelCollider;

        private void Start()
        {
            skidParticles_organic = transform.root.GetComponentInChildren<ParticleSystem>();

            if (skidParticles_organic == null)
            {
                Debug.LogWarning("Не найдена система частиц, создайте её для этой машины", gameObject);
            }
            else
            {
                skidParticles_organic.Stop();
            }
            m_WheelCollider = GetComponent<WheelCollider>();
        }

        public void EmitTyreSmoke()
        {
            skidParticles_organic.transform.position = m_WheelCollider.transform.position - Vector3.up * m_WheelCollider.radius;
            skidParticles_organic.Emit(1);
        }

        public void EndSkidTrail()
        {
            if (!skidding)
            {
                return;
            }
            skidding = false;
        }
    }
}
