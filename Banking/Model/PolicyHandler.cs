using Microsoft.ApplicationInsights;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Banking.Model
{
    
    public static class PolicyHandler
    {
        
        public static void HandledbyPolicy(this Exception e, TelemetryClient appinisghts)
        {
            if (e is OutOfMemoryException ooe)
                appinisghts.TrackException(ooe);
            else if (e is OperationCanceledException oce)
                System.Diagnostics.Debug.WriteLine("This is operation canceled exception and this is not something we want to log into application insights becuase it's not intresting by policy");
            else if (e is NullReferenceException nre)
                appinisghts.TrackException(nre);
            
            appinisghts.Flush();
            
            System.Threading.Thread.Sleep(5000);
        }

    }
}
