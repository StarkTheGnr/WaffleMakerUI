using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PaxPOSECR;
using System.IO.Ports;

namespace WaffleMakerUI
{
	class POSHandler
	{
		public string portName = "COM1";
		public POSCardTransResponse response;

		PaxPOSECRDriver driver;

		public POSHandler(string port)
		{
			portName = port;
		}

		public int TestConnection(string port)
		{
			if (driver == null)
				driver = new PaxPOSECRDriver();

			List<String> ports = new List<string>();
			ports.AddRange(SerialPort.GetPortNames());

			if (ports.Contains(port))
			{
				string eftVer = "", libVer = "";
				int result = driver.POSTestConnection(port, out eftVer, out libVer);

				return result;
			}
			else
				return -1;
		}

		public async Task<int> DoTransaction(float amount, string referenceNo, bool testConnFirst)
		{
			int testConnResult = TestConnection(portName);
			if (!testConnFirst || testConnResult == 0)
			{
				response = null;
				string msg = "";
				int result = driver.POSDoCardTransaction(portName, POSTransType.SALE, amount.ToString(), referenceNo, out response, out msg);

				return result;
			}

			return testConnResult;
		}
	}
}
