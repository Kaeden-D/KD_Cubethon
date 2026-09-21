using UnityEngine;
using System.Linq;
using System.Collections.Generic;
using Unity.VisualScripting;
using Chapter.Observer;

class Invoker : Chapter.Singleton.Singleton<Invoker>
{

    public bool _isRecording;
    public bool _isReplaying;
    private float _replayTime;
    private float _recordingTime;
    private SortedList<float, Command> _recordedCommands = new SortedList<float, Command>();

    private GameManger _gameManager;

    public void ExecuteCommand(Command command)
    {
        command.Execute();

        if (_isRecording)
            _recordedCommands.Add(_recordingTime, command);

        Debug.Log("Recorded Time: " + _recordingTime);
        Debug.Log("Recorded Command: " + command);
    }

    public void Record()
    {
        _recordingTime = 0.0f;
        _isRecording = true;
    }

    public void Replay()
    {
        _replayTime = 0.0f;
        _isReplaying = true;
        if (_recordedCommands.Count <= 0)
            Debug.LogError("No command to replay!");

        _recordedCommands.Reverse();
    }

    public void refresh(GameManger gameManager)
    {
        _gameManager = gameManager;
        foreach (Command command in _recordedCommands.Values)
        {
            command.replay(_gameManager.player1, _gameManager.player2);
        }
        if (_isReplaying)
            Replay();
    }

    void FixedUpdate()
    {

        if (_isRecording)
            _recordingTime += Time.fixedDeltaTime;

        if (_isReplaying)
        {
            _replayTime += Time.deltaTime;

            if (_recordedCommands.Any())
            {
                if (Mathf.Approximately(_replayTime, _recordedCommands.Keys[0]))
                {
                    Debug.Log("Replay Time: " + _replayTime);
                    Debug.Log("Replay Command: " + _recordedCommands.Values[0]);

                    _recordedCommands.Values[0].Execute();
                    _recordedCommands.RemoveAt(0);
                }
            }
            else
            {
                _isReplaying = false;
            }
        }

    }

    public override void Notify(Subject subject) { }

}