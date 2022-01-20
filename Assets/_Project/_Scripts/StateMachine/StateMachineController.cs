using UnityEngine;
using UnityEngine.UI;
using TMPro;

public sealed class StateMachineController : MonoBehaviour
{
    private static StateMachineController _instance;
    public static StateMachineController Instance { get { return _instance; } }

    private State _current;
    public State Current { get { return _current; } }
    private bool _busy;

    [Header("Loading State")]
    public GameObject LoadingScreen;
    public Slider LoadingBar;
    public TMP_Text LoadingText;

    [Header("In Game State")]
    [SerializeField] private float _timeLimit = 10f;
    [SerializeField] private float _maxSpeedGame = 25f;
    [SerializeField] private float _timeMultiplayerSpeed = 1.2f;
    [SerializeField] private float _startSpeedGame = 12f;

    public float SpeedGame = 12f;
    [HideInInspector] public float StartSpeedGame { get { return _startSpeedGame; } }
    [HideInInspector] public float MaxSpeedGame { get { return _maxSpeedGame; } }
    [HideInInspector] public float TimeLimit { get { return _timeLimit; } }
    [HideInInspector] public float TimeMultiplayerSpeed { get { return _timeMultiplayerSpeed; } }




    [Header("Save System")]
    public SaveWrapper SaveMain;


    [Header("Events Game")]
    public VoidEventChannelSO OnInitGameEvent = default;
    public VoidEventChannelSO OnScoreUpdateEvent = default;
    public VoidEventChannelSO OnGameIsStarted = default;



    public bool gameIsRunning;



    public void Initialize(float limitOfTime, float maxSpeed, float StartSpeedGame,
        VoidEventChannelSO initEvent, VoidEventChannelSO scoreUpEvent, VoidEventChannelSO GameStartEvent)
    {
        _busy = false;
        _timeLimit = limitOfTime;
        _maxSpeedGame = maxSpeed;
        _startSpeedGame = StartSpeedGame;

        OnInitGameEvent = initEvent;
        OnScoreUpdateEvent = scoreUpEvent;
        OnGameIsStarted = GameStartEvent;

        Awake();
    }

    private void Awake()
    {
        _instance = this;

        LoadingScreen = GameObject.Find("Loading");
        LoadingBar = GameObject.Find("LoadingBar").GetComponent<Slider>();
        LoadingText = GameObject.Find("LoadText").GetComponent<TMP_Text>();

        SaveMain = GameObject.Find("DataManager").GetComponent<SaveWrapper>();

        LoadingScreen.SetActive(false);
    }

    private void Start()
    {
        ChangeTo<MainMenuState>();
    }

    private void Update()
    {
        Current.UpdateState();
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
