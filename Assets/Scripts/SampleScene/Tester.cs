using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityToolBox.Utils;
using static UnityToolBox.Utils.FiniteStateMachine;

public class Tester : MonoBehaviour
{
    private readonly FiniteStateMachine finiteStateMachine = new FiniteStateMachine();

    [SerializeField] private ObjectPool objectPool = null;

    private IEnumerator ExecuteDelayedActions()
    {
        List<GameObject> gameObjects = new List<GameObject>();

        for (int i = 0; i < 10; ++i)
        {
            GameObject gameObject = objectPool.GetObject();
            gameObject.transform.parent = transform;

            gameObjects.Add(gameObject);
        }

        yield return new WaitForSecondsRealtime(3);

        foreach (GameObject gameObject in gameObjects)
        {
            gameObject.ReturnToPool();
        }

        finiteStateMachine.TransitionTo("end");
    }

    private void Start()
    {
        Logger.Instance.LogMessage();

        StartCoroutine(ExecuteDelayedActions());

        State emptyState = finiteStateMachine.CreateState("empty");

        State startState = finiteStateMachine.CreateState("start");
        startState.OnEnter = delegate
        {
            Debug.Log("startState OnEnter");
        };

        startState.OnUpdate = delegate
        {
            Debug.Log("startState OnUpdate");
        };

        startState.OnExit = delegate
        {
            Debug.Log("startState OnExit");
        };

        State endState = finiteStateMachine.CreateState("end");
        endState.OnEnter = delegate
        {
            Debug.Log("endState OnEnter");
        };

        endState.OnUpdate = delegate
        {
            Debug.Log("endState OnUpdate");
        };

        endState.OnExit = delegate
        {
            Debug.Log("endState OnExit");
        };

        finiteStateMachine.TransitionTo("start");
    }

    private void Update()
    {
        finiteStateMachine.Update();
    }
}
