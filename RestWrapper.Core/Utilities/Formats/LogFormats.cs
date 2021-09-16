using System;
using System.Collections.Generic;
using System.Text;

namespace RestWrapper.Core.Utilities.Formats
{
    public static class LogFormats
    {
        public static string RequestToREST(int callNumber, int leftParameter, int rightParameter) => $"Call {callNumber}. Request To REST. Parameter1 : {leftParameter} , Parameter2 : {rightParameter}";
        public static string RequestToSOAP(int callNumber, int leftParameter, int rightParameter) => $"Call {callNumber}. Request To SOAP. Parameter1 : {leftParameter} , Parameter2 : {rightParameter}";
        public static string ResponseFromSOAP(int callNumber, int response) => $"Call {callNumber}. Response From SOAP. Result : {response}";
    } 
}
