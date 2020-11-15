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

		PaxPOSECRDriver driver = new PaxPOSECRDriver();

		public POSHandler(string port)
		{
			portName = port;
		}

		public int TestConnection(string port)
		{
			string eftVer = String.Empty, libVer = String.Empty;
			int result = driver.POSTestConnection(port, out eftVer, out libVer);

			return result;
		}

		public async Task<int> DoTransaction(float amount, string referenceNo, bool testConnFirst)
		{
			int testConnResult = TestConnection(portName);
			if (!testConnFirst || testConnResult == 0)
			{
				response = null;
				string msg = String.Empty;
				int result = driver.POSDoCardTransaction(portName, POSTransType.SALE, amount.ToString(), referenceNo, out response, out msg);

				return result;
			}

			return testConnResult;
		}
	}
}
