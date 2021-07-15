using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.CPU
{
    public class GunsManager : MonoBehaviour
    {
        [SerializeField] private Gun[] guns = null;

        [SerializeField] private Transform _character = null;

        private Coroutine _fireTargetCoroutine;

        public void InitFireInTarget()
        {
            _fireTargetCoroutine = StartCoroutine(FireInTargetAsyc());
        }

        public void StopFireInTarget()
        {
            StopCoroutine(_fireTargetCoroutine);
        }

        private float _currentRateOfFire;
        private WaitForSeconds _waitTimingForInit = new WaitForSeconds(2f);
        private IEnumerator FireInTargetAsyc()
        {
            _currentRateOfFire = 5f;

            yield return _waitTimingForInit;

            while (true)
            {
                yield return new WaitForSeconds(_currentRateOfFire);

                var gunFire = GetGunFire();
                gunFire.Fire();

                _currentRateOfFire -= 0.1f;
                _currentRateOfFire = _currentRateOfFire < 0 ? 0 : _currentRateOfFire;
            }
        }

        private Gun GetGunFire()
        {
            Gun gunFire = guns[0];
            var distanceGunAndTarget = Vector3.Distance(gunFire.transform.position, _character.transform.position);

            for (int i = 1; i < guns.Length; i++)
            {
                var currentGunDistance = Vector3.Distance(guns[i].transform.position, _character.transform.position);
                if (currentGunDistance < distanceGunAndTarget)
                {
                    gunFire = guns[i];
                    distanceGunAndTarget = currentGunDistance;
                }
            }

            return gunFire;
        }
    }
}
