namespace RestWrapper.Core.Utilities.Formats
{
    public static class LogFormats
    {
        public static string RequestToREST(int callNumber, int leftParameter, int rightParameter, string operation) => $"Call {callNumber}. Request To REST. Parameter1:{leftParameter} , Parameter2:{rightParameter}, Operation:{operation}";
        public static string RequestToSOAP(int callNumber, int leftParameter, int rightParameter, string operation) => $"Call {callNumber}. Request To SOAP. Parameter1:{leftParameter} , Parameter2:{rightParameter}, Operation:{operation}";
        public static string ResponseFromSOAP(int callNumber, int response) => $"Call {callNumber}. Response From SOAP. Result : {response}";
    } 
}
