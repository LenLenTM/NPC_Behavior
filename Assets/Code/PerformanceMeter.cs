using System.Diagnostics;

public class PerformanceMeter
{
        private static readonly Stopwatch _stopwatch = new Stopwatch();

        private static int _state = 999;

        public static void StartStopwatch()
        {
                if (!_stopwatch.IsRunning)
                {
                        _stopwatch.Start();
                }
        }

        public static void StopStopwatch(int state)
        {
                if (_state == state) ResetStopwatch();
                _state = state;
                
                _stopwatch.Stop();
                Logger.WriteLog("Calculation time: " + _stopwatch.Elapsed);
                _stopwatch.Reset();
        }

        public static void ResetStopwatch()
        {
                _stopwatch.Stop();
                _stopwatch.Reset();
        }

        public static void ResetState()
        {
                _state = 999;
        }
}