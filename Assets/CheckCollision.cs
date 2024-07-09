using UnityEngine;

public class CheckCollision : MonoBehaviour
{
    private Rigidbody _rigidbody;
    private TerrainChecker checker;
    private string currentLayer;
    [SerializeField] public AudioClip m_jumpSound;
    private AudioSource _audioSource;

    public FootstepCollection[] landCollection;
    // Start is called before the first frame update
    void Start()
    {
        checker = new TerrainChecker();
        _audioSource = GetComponent<AudioSource>();
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        CheckLayer();
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Terrain")
        {
            _audioSource.Play();
        }
    }

    public void CheckLayer()
    {
        RaycastHit hit;
        if (Physics.Raycast(_rigidbody.transform.position, Vector3.down, out hit, 1))
        {
            if (hit.transform.GetComponent<Terrain>() != null)
            {
                Terrain t = hit.transform.GetComponent<Terrain>();
                if (currentLayer != checker.GetLayerName(_rigidbody.transform.position, t))
                {
                    currentLayer = checker.GetLayerName(_rigidbody.transform.position, t);
                    foreach (FootstepCollection collection in landCollection)
                    {
                        if (currentLayer == collection.name)
                        {
                            _audioSource.clip = collection.landSound;
                        }
                        
                    }
                }
            }
        }
    }
}
