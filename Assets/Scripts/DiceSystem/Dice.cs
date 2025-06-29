using UnityEngine;

namespace DiceSystem
{
    [RequireComponent(typeof(Rigidbody))]
    public class Dice : MonoBehaviour
    {
        private Rigidbody rb;
        private bool hasRolled;
        private int lastResult = -1;

        private void Awake()
        {
            rb = GetComponent<Rigidbody>();
        }

        private void Update()
        {
            HandleRollCheck();

            if (Input.GetKeyDown(KeyCode.D))
            {
                RollDice();
            }
        }

        private void HandleRollCheck()
        {
            if (rb.IsSleeping() && !hasRolled)
            {
                hasRolled = true;
                lastResult = CalculateResult();
                Debug.Log($"🎲 Dice Result is: {lastResult}");
            }
        }

        private void RollDice()
        {
            Vector3 force = new Vector3(Random.Range(-5f, 5f), Random.Range(5f, 10f), Random.Range(-5f, 5f));
            Vector3 torque = new Vector3(Random.Range(-10f, 10f), Random.Range(-10f, 10f), Random.Range(-10f, 10f));
            Throw(force, torque);
        }

        public void Throw(Vector3 force, Vector3 torque)
        {
            hasRolled = false;
            lastResult = -1;
            rb.isKinematic = false;
            rb.AddForce(force, ForceMode.Impulse);
            rb.AddTorque(torque, ForceMode.Impulse);
        }

        private int CalculateResult()
        {
            float maxDot = -1f;
            int result = 1;

            Vector3[] faceNormals =
            {
                transform.forward,    // 1
                transform.up,         // 2
                -transform.right,     // 3
                transform.right,      // 4
                -transform.up,        // 5
                -transform.forward    // 6
            };

            for (int i = 0; i < faceNormals.Length; i++)
            {
                float dot = Vector3.Dot(faceNormals[i], Vector3.up);
                if (dot > maxDot)
                {
                    maxDot = dot;
                    result = i + 1;
                }
            }

            return result;
        }

        public int GetResult() => lastResult;

        public bool IsRolling() => !rb.IsSleeping();
    }
}
