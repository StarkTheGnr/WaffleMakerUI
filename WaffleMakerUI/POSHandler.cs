using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Threading.Tasks;
using PaxPOSECR;
using System.IO.Ports;

namespace WaffleMakerUI
{
	class POSHandler
	{
		public string portName = "COM1";
		public POSCardTransResponse response;

		PaxPOSECRDriver driver = new PaxPOSECRDriver();

		public POSHandler(string port)
		{
			portName = port;
		}
		public POSHandler()
		{
			portName = FindPOS() ?? portName;
		}

		public string? FindPOS()
		{
			List<string> ports = new List<string>();
			ports.AddRange(SerialPort.GetPortNames());

			for(int i = 0; i < ports.Count; i++)
			{
				int res = TestConnection(ports[i]);

				if (res == 0)
					return ports[i];
			}

			return null;
		}

		public int TestConnection(string port)
		{
			if (driver == null)
				driver = new PaxPOSECRDriver();

			List<string> ports = new List<string>();
			ports.AddRange(SerialPort.GetPortNames());

			if (ports.Contains(port))
			{
				string eftVer = "", libVer = "";
				int result = driver.POSTestConnection(port, out eftVer, out libVer);

				MessageBox.Show(result.ToString());

				return result;
			}
			else
				return -1;
		}

		string ParseAmount(float amount)
		{
			return string.Format("{0:0.00}", amount);
		}

		public async Task<int> DoTransaction(float amount, string referenceNo, bool testConnFirst)
		{
			await Task.Delay(3000);
			int testConnResult = 0;
			if(testConnFirst)
				TestConnection(portName);

			if (testConnResult == 0)
			{
				if (driver == null)
					driver = new PaxPOSECRDriver();

				response = null;
				string msg = "";
				int result = driver.POSDoCardTransaction(portName, POSTransType.SALE, ParseAmount(amount), referenceNo, out response, out msg);

				return result;
			}

			return testConnResult;
		}
	}
}
