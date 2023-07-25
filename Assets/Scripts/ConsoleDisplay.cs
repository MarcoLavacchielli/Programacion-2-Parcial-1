using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConsoleDisplay : MonoBehaviour
{
    public Text consoleText;
    public float messageTime;
    public Image backgroundImage;

    private List<MessageInfo> logMessages;
    private Coroutine clearConsoleCoroutine;

    private class MessageInfo
    {
        public string message;
        public float startTime;
        public bool isDestroyed;
    }

    void Start()
    {
        consoleText.text = "";
        backgroundImage.gameObject.SetActive(false);

        logMessages = new List<MessageInfo>();
    }

    void OnEnable()
    {
        Application.logMessageReceived += HandleLog;
    }

    void OnDisable()
    {
        Application.logMessageReceived -= HandleLog;
    }

    void HandleLog(string logString, string stackTrace, LogType type)
    {
        // Si el tipo de log es LogType.Warning o LogType.Error, no lo registramos.
        if (type == LogType.Warning || type == LogType.Error || logString.ToLower().Contains("nullreferenceexception"))
        {
            return;
        }

        // Resto del código para el caso en que el log no es Warning ni Error.
        var messageInfo = new MessageInfo()
        {
            message = logString,
            startTime = Time.time,
            isDestroyed = false
        };

        logMessages.Add(messageInfo);
        UpdateConsoleText();

        if (!string.IsNullOrEmpty(logString))
        {
            // Mostrar la imagen de fondo
            backgroundImage.gameObject.SetActive(true);

            if (clearConsoleCoroutine != null)
            {
                StopCoroutine(clearConsoleCoroutine);
            }
            clearConsoleCoroutine = StartCoroutine(DestroyTextDelayed(messageInfo, messageTime));
        }
    }

    IEnumerator DestroyTextDelayed(MessageInfo messageInfo, float delay)
    {
        yield return new WaitForSeconds(delay);

        if (!messageInfo.isDestroyed)
        {
            logMessages.Remove(messageInfo);
            UpdateConsoleText();
            messageInfo.isDestroyed = true;
        }

        // Ocultar la imagen de fondo si no hay mensajes en la lista
        if (logMessages.Count == 0)
        {
            backgroundImage.gameObject.SetActive(false);
        }
    }

    void UpdateConsoleText()
    {
        string consoleString = "";
        foreach (var messageInfo in logMessages)
        {
            consoleString += messageInfo.message + "\n\n";
        }
        consoleText.text = consoleString;
    }

    void Update()
    {
        for (int i = logMessages.Count - 1; i >= 0; i--)
        {
            var messageInfo = logMessages[i];
            float elapsedTime = Time.time - messageInfo.startTime;
            if (elapsedTime >= messageTime && !messageInfo.isDestroyed)
            {
                logMessages.RemoveAt(i);
                UpdateConsoleText();
                messageInfo.isDestroyed = true;
            }
        }
    }
}