using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] Vector2 _dir;
    [SerializeField] float _force;

    float _distanceCounter = 0;
    float _maxHeight;

    Spawner _spawner;
    Rigidbody2D _rb;
    SpriteRenderer _sr;
    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _sr = GetComponent<SpriteRenderer>();
        _spawner = FindObjectOfType<Spawner>();

        if (Random.value > 0.5f)
            ChangeDir();
        _maxHeight = transform.position.y;
    }

    private void ChangeDir()
    {
        _dir = new Vector2(-_dir.x, _dir.y);
        _sr.flipX = _dir.x < 0;
    }

    private void Update()
    {
        if (GameManager.Single.GameActive)
        {
            if (Input.GetMouseButton(0))
            {
                Jump();
            }
        }
    }

    private void FixedUpdate()
    {
        if (transform.position.y > _maxHeight)
        {
            _distanceCounter += transform.position.y - _maxHeight;
            _maxHeight = transform.position.y;

            if (_distanceCounter > GameManager.Single.Interval)
            {
                GameManager.Single.Score++;
                _spawner.Spawn();
                _distanceCounter = 0;
            }
        }

        if (transform.position.y < GameManager.Single.MainCamera.transform.position.y - 5)
        {
            GameManager.Single.LostLive();
            Destroy(gameObject);
        }
    }

    private void Jump()
    {
        _rb.velocity= Vector2.zero;
        _rb.AddForce(_dir * _force, ForceMode2D.Impulse);
    }

    internal void StartFall()
    {
        _rb.gravityScale = 1;
        Jump();
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        ChangeDir();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameManager.Single.LostLive();
    }
}
