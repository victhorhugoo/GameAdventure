using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

public class StateMachine<T> where T : System.Enum 
{

    public Dictionary<T, StateBase> dictionaryState;
    public float timeToStartGame = 1f;

    private StateBase _currentState;

    public StateBase CurrentState
    {
        get {  return _currentState; }
    }

    public void Init()
    {
        dictionaryState = new Dictionary<T, StateBase>();
    }

    public void RegisterStates(T typeEnum, StateBase state)
    {
        //dictionaryState = new Dictionary<T, StateBase>();

        dictionaryState.Add(typeEnum, state);

        //SwitchState(T.NONE);

        //Invoke(nameof(StartGame), timeToStartGame);
    }

    /*
#if UNITY_EDITOR
    #region DEBUG

    [Button]
    private void ChangeStateToStateX()
    {
        SwitchState(T.NONE);
    }

    [Button]
    private void ChangeStateToStateY()
    {
        SwitchState(T.NONE);
    }
    #endregion
#endif
    */
    public void SwitchState(T state)
    {
        if (_currentState != null)
        {
            _currentState.OnStateExit();
        }

        _currentState = dictionaryState[state];
        _currentState.OnStateEnter();
    }

    public void Update()
    {
        if (_currentState != null)
        {
            _currentState.OnStateStay();
        }

    }
}
/*
public class Test
{
    public enum Test2
    {
        NONE
    }

    public void A()
    {
        StateMachine<Test2> stateMachine = new StateMachine<Test2>();
        stateMachine.RegisterStates(Test.Test2.NONE, new StateBase());
    }
}

*/