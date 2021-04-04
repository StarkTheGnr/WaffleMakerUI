using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaffleMakerUI
{
	class ComPortHandler
	{
		bool CheckPortName(string portName)
		{
			string[] ports = SerialPort.GetPortNames();
			for (int i = 0; i < ports.Length; i++)
			{
				if (ports[i].Contains(portName))
					return true;
			}

			return false;
		}
	}
}
