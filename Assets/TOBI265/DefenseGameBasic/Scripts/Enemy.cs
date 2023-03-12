using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TOBI265.DefenseBasic 
{
    public class Enemy : MonoBehaviour, IComponentChecking
    {
        public float speed;
        public float atkDistance;
        private Animator m_anim;
        private Rigidbody2D m_Rb;
        private Player m_Player;

        private void Awake()
        {
            m_anim = GetComponent<Animator>();
            m_Rb = GetComponent<Rigidbody2D>();
            m_Player = FindObjectOfType<Player>();
        }
        // Start is called before the first frame update
        void Start()
        {

        }

        public bool IsComponentNull() 
        {
            return m_anim == null || m_Rb == null || m_Player == null;
        }

        // Update is called once per frame
        void Update()
        {
            if (IsComponentNull()) return;

            float distToPlayer = Vector2.Distance(m_Player.transform.position, transform.position);

            if (distToPlayer <= atkDistance)
            {
                m_anim.SetBool(Const.ATTACK_ANIM, true);
                m_Rb.velocity = Vector2.zero; // (0, 0)
            }
            else 
            {
                m_Rb.velocity = new Vector2(-speed, m_Rb.velocity.y);
            }
        }
        public void Die() 
        {
            if (IsComponentNull()) return;
            m_anim.SetTrigger(Const.DEAD_ANIM);
            m_Rb.velocity = Vector2.zero;
            gameObject.layer = LayerMask.NameToLayer(Const.DEAD_ANIM);
        }
    }
}
