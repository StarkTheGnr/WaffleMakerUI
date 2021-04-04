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
		readonly string writePort = "COM1";
		readonly string readPort = "COM2";

		SerialPort serialPort;

		public void initializePort(string portName, int baudRate, Parity parity, int databits, StopBits stopbits, Handshake handshake)
		{
			serialPort = new SerialPort(portName, baudRate, parity, databits, stopbits);
			serialPort.Handshake =  handshake;
		}

		public void Open()
		{
			if (!serialPort.IsOpen && CheckPortName(serialPort.PortName))
				serialPort.Open();
		}

		public void Close()
		{
			if (serialPort.IsOpen)
				serialPort.Close();
		}

		public void SendData(string data)
		{
			if (!serialPort.IsOpen)
				return;

			serialPort.WriteLine(data);
		}

		public async void ReadData(Action<string> callback)
		{
			if (!serialPort.IsOpen)
				return;

			string output = "";
			await Task.Run(() => { output = serialPort.ReadLine(); });

			callback(output);
		}

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
