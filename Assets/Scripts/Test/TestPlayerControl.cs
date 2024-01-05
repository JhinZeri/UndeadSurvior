using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TestCodes
{
    public class TestPlayerControl : MonoBehaviour
    {
        private Rigidbody2D mRigid;
        public Vector2 MoveVector2;
        public float Speed;

        private void Awake()
        {
            mRigid = GetComponent<Rigidbody2D>();
        }

        // Update is called once per frame
        void Update()
        {
            var xInput = Input.GetAxisRaw("Horizontal");
            var yInput = Input.GetAxisRaw("Vertical");

            MoveVector2 = new Vector2(xInput, yInput);
            mRigid.velocity = MoveVector2 * Speed;
        }
    }
}