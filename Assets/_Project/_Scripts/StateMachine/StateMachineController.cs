using UnityEngine;
using UnityEngine.UI;
using TMPro;

public sealed class StateMachineController : MonoBehaviour
{
    private static StateMachineController _instance;
    public static StateMachineController Instance { get { return _instance; } }

    private State _current;
    public State current { get { return _current; } }
    private bool _busy;

    [Header("Loading State")]
    public GameObject LoadingScreen;
    public Slider LoadingBar;
    public TMP_Text LoadingText;

    [Header("In Game State")]
    [SerializeField] private float _timeLimit = 10f;
    [HideInInspector] public float TimeLimit { get { return _timeLimit; } }


    [Header("Events Game")]
    public VoidEventChannelSO OnInitGameEvent = default;

    public bool gameIsRunning;



    public void Initialize()
    {
        _busy = false;
        _timeLimit = 10f;
        Awake();
    }

    private void Awake()
    {
        _instance = this;

        LoadingScreen = GameObject.Find("Loading");
        LoadingBar = GameObject.Find("LoadingBar").GetComponent<Slider>();
        LoadingText = GameObject.Find("LoadText").GetComponent<TMP_Text>();

        LoadingScreen.SetActive(false);
    }

    private void Start()
    {
        ChangeTo<MainMenuState>();
    }

    private void Update()
    {
        current.UpdateState();
    }

    public void ChangeTo<T>() where T : State
    {
        State state = GetState<T>();

        if (_current != state)
            ChangeState(state);
    }

    private T GetState<T>() where T : State
    {
        T target = GetComponent<T>();

        if (target == null)
            target = gameObject.AddComponent<T>();
        return target;
    }

    private void ChangeState(State value)
    {
        if (_busy)
            return;

        _busy = true;

        if (_current != null)
        {
            _current.Exit();
        }

        _current = value;

        if (_current != null)
        {
            _current.Enter();
        }

        _busy = false;

    }


}
