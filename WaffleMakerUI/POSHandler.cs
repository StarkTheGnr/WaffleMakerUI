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

		PaxPOSECRDriver driver = new PaxPOSECRDriver();
		POSCardTransResponse response = new POSCardTransResponse();

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
	}
}
