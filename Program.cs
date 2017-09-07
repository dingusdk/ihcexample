using Dingus.IHCSdkWR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IHCExample {
	class Program {
		static int Main(string[] args) {

			if ( args.Count() != 4) {
				Console.WriteLine("Syntax: IHCExample ihc-controller-url username password resourceid");
				return 0;
			}
			IHCController ihc = new IHCController( args[0]);
			if ( ! ihc.Authenticate(  args[1],args[2])) {
				Console.WriteLine("Authentication failed");
				return 0;
			}

			int resourceid = int.Parse( args[3]);

			// Get the value and toggle it 
			bool value = ihc.GetRuntimeValueBool(resourceid);
			ihc.SetRuntimeValueBool(resourceid, ! value);

			// Register a callback for changes to the resourceid
			ihc.RegisterNotify(resourceid, ResourceChange);
			// Start the notify thread
			ihc.StartNotify();

			// Wait until a key is pressed
			Console.ReadKey();

			Console.WriteLine("Disconnecting");
			ihc.Disconnect();
			return 1;
		}

		// This function will be called when the resource changes
		static void ResourceChange(int id, object v) {
			Console.WriteLine(id.ToString() + " -> " + v.ToString());
		}
	}
}
