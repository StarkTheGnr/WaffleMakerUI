using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Threading.Tasks;
using PaxPOSECR;
using System.IO;
using System.IO.Ports;

namespace WaffleMakerUI
{
	class POSHandler
	{
		public string portName = "COM1";
		public POSCardTransResponse response;
		public ReferenceNumber referenceNumber = new ReferenceNumber();

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

		public async Task<int> DoTransaction(float amount, bool testConnFirst)
		{
			int testConnResult = 0;
			if(testConnFirst)
				testConnResult = TestConnection(portName);

			if (testConnResult == 0)
			{
				if (driver == null)
					driver = new PaxPOSECRDriver();

				response = null;
				string msg = "";
				string RNo = referenceNumber.GetNewRNo();
				int result = driver.POSDoCardTransaction(portName, POSTransType.SALE, ParseAmount(amount), RNo, out response, out msg);

				Log(RNo, amount, result);
				referenceNumber.IncrementRNo();

				return result;
			}

			return testConnResult;
		}

		public void Log(string RNo, float amount, int errorCode)
		{
			using (StreamWriter log = File.AppendText("transaction_log.txt"))
			{
				string result = (errorCode == 0) ? "SUCCESS" : "FAILURE(" + errorCode + ")";

				log.WriteLine(DateTime.Now.ToLongTimeString().PadRight(12) + " " + DateTime.Now.ToLongDateString().PadRight(29) + "  Reference Number: " + RNo + ", Amount Paid: " + amount + " EGP, Transaction Result: " + result);
				log.Close();
			}
		}
	}
}
