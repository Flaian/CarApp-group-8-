using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp4
{
    internal class Engine
    {
		// private field
		private bool _isRunning;

		// public method to start the engine
		public void Start()
		{
			_isRunning = true;
		}

		// public method to stop the engine
		public void Stop()
		{
			_isRunning = false;
		}


	}
}
