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
			serialPort.Handshake = handshake;
		}

		public bool Open()
		{
			if (!serialPort.IsOpen && CheckPortName(serialPort.PortName))
			{
				serialPort.Open();
				return true;
			}

			return false;
		}

		public void Close()
		{
			if (serialPort.IsOpen)
				serialPort.Close();
		}

		public int SendData(string data)
		{
			if (!serialPort.IsOpen)
				return -1;

			serialPort.WriteLine(data);
			return serialPort.BytesToWrite;
		}

		public void ReadDataSync(Action<char> callback)
		{
			if (!serialPort.IsOpen)
				return;

			char output = 'n';
			output = (char)serialPort.ReadChar();

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
