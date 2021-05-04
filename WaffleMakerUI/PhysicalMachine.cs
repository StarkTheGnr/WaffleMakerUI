using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.IO.Ports;
using System.Threading;

namespace WaffleMakerUI
{
	class PhysicalMachine
	{
		private readonly string PORT = "COM1";
		private readonly int BAUDRATE = 9600, DATABITS = 8;
		private readonly Parity PARITY = Parity.None;
		private readonly StopBits STOPBITS = StopBits.One;
		private readonly Handshake HANDSHAKE = Handshake.None;

		ComPortHandler portHandler = new ComPortHandler();

		private MachineState _state = MachineState.Disconnected;
		public MachineState State
		{
			get
			{
				return _state;
			}
		}

		public void InitPort()
		{
			portHandler.initializePort(PORT, BAUDRATE, PARITY, DATABITS, STOPBITS, HANDSHAKE);
			_state = MachineState.Initialized;
		}

		public void StartReadThread(bool forceInit = false)
		{
			if (forceInit || State == MachineState.Disconnected)
				InitPort();

			//TODO if not openable, send user to error screen
			if (portHandler.Open())
			{
				Task task = Task.Run(() => portHandler.ReadDataSync(HandleResponse));
			}
		}

		public void SendData(string data)
		{
			portHandler.SendData(data);
			_state = MachineState.Waiting;
		}

		public async Task<bool> WaitForAcknowledgment(int timeout = 5000)
		{
			int timeElapsed = 0;
			while (timeElapsed < timeout)
			{
				if (State == MachineState.Acknowledged)
					return true;

				await Task.Delay(100);
				timeElapsed += 100;
			}

			return false;
		}

		public async Task<int> SendOrder(string refNum, int waffleNum, int chocNum)
		{
			if (State != MachineState.Waiting)
				return -1;

			SendData(refNum);
			if (!await WaitForAcknowledgment())
				return -2;

			SendData(waffleNum.ToString());
			if (!await WaitForAcknowledgment())
				return -2;

			SendData(chocNum.ToString());
			if (!await WaitForAcknowledgment())
				return -2;

			return 0;
		}

		private void HandleResponse(char res)
		{
			if (res == 'n')
				return;
			else if (res == 'R')
			{
				_state = MachineState.Waiting;
			}
			else if (res == 'o')
			{
				_state = MachineState.Acknowledged;
			}
			else if (res == 'r')
			{
				_state = MachineState.OrderReady;
			}
		}

		public enum MachineState
		{
			Disconnected, Initialized, Waiting, Acknowledged, OrderReady
		}
	}
}
