using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject[] _prefabs;

    [SerializeField] bool _spawnInTime = true;
    float _timeSpent;

	private void FixedUpdate()
	{
		if (GameManager.Single.GameActive)
		{
			if (_spawnInTime)
			{
				_timeSpent += Time.deltaTime;
				if (_timeSpent > GameManager.Single.Interval)
				{
					_timeSpent = 0;

					Spawn();
				}
			}
		}
	}

	public void Spawn()
	{
		if (Random.value > 0.8f) return;
		var newGO = Instantiate(_prefabs[Random.Range(0, _prefabs.Length)], SetPosition(), Quaternion.identity);
		newGO.transform.SetParent(transform, true);
	}

	private Vector3 SetPosition()
	{
		var randomProtrusion = Random.Range(-0.2f, 1);

        return new Vector3(Random.value > 0.5f ? -GameManager.Single.RightUpperCorner.x + randomProtrusion : GameManager.Single.RightUpperCorner.x - randomProtrusion, GameManager.Single.MainCamera.transform.position.y + 6, 0);
	}
}
