using System;
using System.Text.RegularExpressions;

namespace csconsoletest
{
	public class ff
	{
		public String raw;
		public AlertSig alertSig;
		public String clasific; //Classification
		public String priority;

		public ff (String header)
		{
			this.raw = header;

			//Alert sig Line 
			int sigIndex = header.IndexOf ("[**]");
			String sig = header.Substring (sigIndex + 4,
				header.LastIndexOf ("[**]") - sigIndex-4).Trim();

			// AlertSig alertSig = new AlertSig (sig);

			//Alert 


		}

		public class AlertSig
		{
			public long sigGenerator;
			public long sigId;
			public long sigRev;

			public String alertInterface;
			public String alertMsg;

			public AlertSig(String sig){

				//sig
				int sigIndex = sig.IndexOf("]");
				String eventSig = sig.Substring(1,sigIndex-1).Trim();

				String[] sigs = eventSig.Split(new[] { ":" }, StringSplitOptions.None);

				sigGenerator = (long)Convert.ToDouble(sigs[0]);
				sigId = (long)Convert.ToDouble(sigs[1]);
				sigRev = (long)Convert.ToDouble(sigs[2]);

				//inteface
				int ifIndex = sig.IndexOf(">"); //inteface index
				this.alertInterface = sig.Substring(
					sigIndex+1,ifIndex-sigIndex-1).Trim();

				//msg
				this.alertMsg = sig.Substring(ifIndex+1).Trim();


			}
		}
	}

}

