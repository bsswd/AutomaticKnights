using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Unit : MonoBehaviour
{
    public float health;
    public float damage;
    public float speed;
    public float movementDirectionFromX;
    public float distanceAttack;

    private bool _isKilled = false;

    private Coroutine _attackCoroutine;
    private Animator _animator => GetComponent<Animator>();

    protected List<Unit> EnemiesList;

    private void Start()
    {
        _animator.Play("Move");
    }

    private void Update()
    {
        SearchEnemy();

        if (_attackCoroutine == null)
            Move();
    }

    public void Move()
    {
        var currentPosition = transform.position;
        var targetPosition = currentPosition + Vector3.right * movementDirectionFromX;

        if (!_isKilled)
            transform.position = Vector3.MoveTowards(currentPosition, targetPosition, speed * Time.deltaTime);
    }

    private void SearchEnemy()
    {
        var enemiesInDistance =
            EnemiesList.Where(x => Vector2.Distance(transform.position, x.transform.position) <= distanceAttack);


        if (enemiesInDistance.Any() && _attackCoroutine == null)
        {
            var enemyInDistance =
            EnemiesList.First(x => Vector2.Distance(transform.position, x.transform.position) <= distanceAttack);

            _attackCoroutine = StartCoroutine(AttackNumerator(enemyInDistance));
        }
    }

    protected virtual void Kill() => StartCoroutine(KillNumerator());

    IEnumerator KillNumerator()
    {
        _isKilled = true;
        _animator.Play("Die");
        yield return new WaitForSeconds(5f);
        Destroy(gameObject);
    }


    IEnumerator AttackNumerator(Unit unit)
    {
        _animator.Play("Attack");

        while (true)
        {
            if (!_isKilled)
                unit.health -= damage;

            if (unit.health <= 0)
            {
                unit.Kill();
                break;
            }

            yield return new WaitForSeconds(1f);
        }

        _animator.Play("Move");
        _attackCoroutine = null;
    }
}
