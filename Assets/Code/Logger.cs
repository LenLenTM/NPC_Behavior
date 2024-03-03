using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class Logger : MonoBehaviour
{
        private static TextMeshPro _textField;
        private static List<string> _logEntries = new List<string>();

        private void Awake()
        {
                _textField = this.transform.GetComponent<TextMeshPro>();
        }

        public static void WriteLog(string entry)
        {
                if (_logEntries.Count != 0 && _logEntries[^1].Equals(entry)) return;
                
                if (_logEntries.Count > 15)
                {
                        _logEntries.RemoveAt(0);
                }
                _logEntries.Add(entry);
                PrintLog();
        }

        private static void PrintLog()
        {
                var log = "";
                foreach (var entry in _logEntries)
                {
                        log = log + entry + "\n";
                }
                _textField.text = log;
        }

        public static void ResetLog()
        {
                _logEntries = new List<string>();
        }
}