using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class GardenGnome : MonoBehaviour
{
    public Transform _target;
    public Transform idlePoint;
    private NavMeshAgent _agent;
    public bool MoveToGrydka;
    public Grydka grydka;
    public bool WePlant;

    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _agent.updateRotation = false;
        _agent.updateUpAxis = false;
    }

    void Update()
    {
        if (WePlant) return;
        if (EmptyGardenBed() == null)
        {
            _agent.SetDestination(idlePoint.position);
            return;
        }
        var e = EmptyGardenBed().transform;
        // Debug.Log($"target {e}");
        if (!MoveToGrydka && e != null)
        {
            _target = e;
            MoveToGrydka = true;
        }

        if (MoveToGrydka)
        {
             MoveToTarget();
            if (Vector2.Distance(transform.position, _target.position) < 1)
            {
                WePlant = true;
                StartCoroutine( WePlantPlant());
            }
        }
    }
    
    IEnumerator  WePlantPlant()
    {
        yield return new WaitForSeconds(2f);
        _target.GetComponent<Grydka>().PlantaPlant();
        WePlant = false;
        MoveToGrydka = false;
    }

    private Grydka EmptyGardenBed()
    {
        return GameManager.instance.allGrydka.Find(c => c.empty == false);
    }

    public void MoveToTarget()
    {
        // Debug.Log($" _target {_target.position}");
        Vector3 r = new Vector3(_target.position.x, _target.position.y, 0);
        _agent.SetDestination(r);
    }
    
}