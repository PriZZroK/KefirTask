using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFireController : MonoBehaviour
{
    public void FirePrj(float _prjSpeed, Transform _spawnPoint, GameObject _prjPref, float Damage)
    {
       GameObject prj = Instantiate(_prjPref, _spawnPoint.position, transform.rotation);
       prj.GetComponent<Rigidbody2D>().AddRelativeForce(Vector2.up * _prjSpeed * Time.deltaTime, ForceMode2D.Impulse);
        prj.GetComponent<MissileDamage>().Damage = Damage;
       Destroy(prj, 5f);
    }
    public void FireBeam(LineRenderer _beam, Transform _beamSpawnPoint, Transform _beamEndPoint, float Timer,float _BeamDamage)
    {
        if(Timer>0)
        {
            
            RaycastHit2D hit = Physics2D.Raycast(_beamSpawnPoint.position, transform.TransformDirection(Vector2.up), 10f);
            Debug.DrawRay(_beamSpawnPoint.position, transform.TransformDirection(Vector2.up * 10f), Color.red);
            _beam.enabled = true;
            _beam.SetPosition(0, _beamSpawnPoint.position);
            _beam.SetPosition(1, _beamEndPoint.position);
            
            if (hit.collider != null)
            {
                if (hit.collider.gameObject.tag == "Enemy")
                {
                    hit.collider.gameObject.GetComponent<DamageableObj>().TakeDamage(_BeamDamage);
                }
            }
        }
        else _beam.enabled = false;

    }
}
