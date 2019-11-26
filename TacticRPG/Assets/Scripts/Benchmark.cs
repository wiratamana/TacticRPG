using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace TacticRPG
{
    public static class Benchmark
    {
        private static Stopwatch _stopwatch;
        private static Stopwatch stopwatch
        {
            get
            {
                if (_stopwatch == null)
                    _stopwatch = new Stopwatch();

                return _stopwatch;
            }
        }

        public static void Start(string message = null)
        {
            if (!string.IsNullOrEmpty(message))
                UnityEngine.Debug.Log(message);

            stopwatch.Restart();
        }

        public static void Stop(string message = null)
        {
            stopwatch.Stop();

            if (!string.IsNullOrEmpty(message))
                UnityEngine.Debug.Log($"Message : {message} | Elapsed time : {stopwatch.ElapsedMilliseconds} ms");
            else UnityEngine.Debug.Log($"Elapsed time : {stopwatch.ElapsedMilliseconds} ms");
        }
    }
}
