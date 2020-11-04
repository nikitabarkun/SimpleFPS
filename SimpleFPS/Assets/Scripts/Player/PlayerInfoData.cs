using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Player
{
    [CreateAssetMenu(fileName = "PlayerInfoData", menuName = "Player/Player Info", order = 0)]
    public class PlayerInfoData : ScriptableObject
    {
        [SerializeField]
        private float speed = 1f;
        [SerializeField]
        private int health = 100;
        [SerializeField]
        private string fullName = "Bob Bob";
        [SerializeField]
        private Texture texture = null;

        public float Speed
        {
            get => speed;
            set => speed = value;
        }
        public int Health
        {
            get => health;
            set => health = value;
        }
        public string FullName
        {
            get => fullName;
            set => fullName = value;
        }
        public Texture Texture
        {
            get => texture;
            set => texture = value;
        }
    }
}
