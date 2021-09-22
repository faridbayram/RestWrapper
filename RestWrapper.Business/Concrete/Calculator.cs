using System;
using RestSharp;
using RestSharp.Serializers;
using RestWrapper.Business.Abstract;
using RestWrapper.Core.CrossCuttingConcerns.Logging.DatabaseLoggers;
using RestWrapper.Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using RestWrapper.Core.Utilities.Deserialization.Addition;
using RestWrapper.Core.Utilities.Deserialization.Division;
using RestWrapper.Core.Utilities.Deserialization.Multiplication;
using RestWrapper.Core.Utilities.Deserialization.Subtraction;
using RestWrapper.Core.Utilities.Enums;
using RestWrapper.Core.Utilities.Formats;
using RestWrapper.Core.Utilities.Results;

namespace RestWrapper.Business.Concrete
{
    public class Calculator : ICalculator
    {
        private readonly RestClient _client;
        private readonly RestRequest _request;

        private readonly FileLogger _fileLogger;
        private readonly CallDBLogger _callDbLogger;
        private readonly RequestDBLogger _requestDbLogger;
         
        private string baseUrl = "http://www.dneonline.com/calculator.asmx";
        private static int callCounter = 1;
        public const int a = 55;
        private static object _lockObject = new object();


        public Calculator(FileLogger fileLogger, CallDBLogger callLogger, RequestDBLogger requestDbLogger)
        {
            // Initializing client and request objects for soap request
            _client = new RestClient(baseUrl);
            _request = new RestRequest(baseUrl, default, DataFormat.Xml);
            _request.XmlSerializer = new DotNetXmlSerializer();
            _request.AddHeader("Content-Type", "text/xml");
            _fileLogger = fileLogger;
            _callDbLogger = callLogger;
            _requestDbLogger = requestDbLogger;
        }

        public IDataResult<int> Add(int leftOperand, int rightOperand)
        {
            lock (_lockObject)
            {
                try
                {
                    string message = LogFormats.RequestToREST(callCounter, leftOperand, rightOperand, Operation.Addition);
                    _fileLogger.Info(message);
                    var callId = _callDbLogger.Info();
                    _requestDbLogger.Info(callId, message);

                    string xmlData = string.Format(CustomDataFormats.AdditionDataXML, leftOperand, rightOperand);
                    // Adding body as parameter
                    _request.AddParameter("XmlBody", xmlData, ParameterType.RequestBody);


                    message = LogFormats.RequestToSOAP(callCounter, leftOperand, rightOperand, Operation.Addition);
                    _fileLogger.Info(message);
                    _requestDbLogger.Info(callId, message);

                    //Sending request to SOAP
                    IRestResponse<AddEnvelope> response = _client.Post<AddEnvelope>(_request);

                    message = LogFormats.ResponseFromSOAP(callCounter++, response.Data.Body.AddResponse.AddResult);
                    _fileLogger.Info(message);
                    _requestDbLogger.Info(callId, message);

                    return DataResult<int>.Succeeded(response.Data.Body.AddResponse.AddResult);
                }
                catch (Exception e)
                {
                    _fileLogger.Error(e.Message);
                    return DataResult<int>.Failure(e.Message);
                }
            }
        }

        public IDataResult<int> Subtract(int leftOperand, int rightOperand)
        {
            lock (_lockObject)
            {
                try
                {
                    string message = LogFormats.RequestToREST(callCounter, leftOperand, rightOperand, Operation.Subtraction);
                    _fileLogger.Info(message);
                    var callId = _callDbLogger.Info();
                    _requestDbLogger.Info(callId, message);

                    string xmlData = string.Format(CustomDataFormats.SubtractionDataXML, leftOperand, rightOperand);
                    _request.AddParameter("XmlBody", xmlData, ParameterType.RequestBody);

                    message = LogFormats.RequestToSOAP(callCounter, leftOperand, rightOperand, Operation.Subtraction);
                    _fileLogger.Info(message);
                    _requestDbLogger.Info(callId, message);

                    IRestResponse<SubtractEnvelope> response = _client.Post<SubtractEnvelope>(_request);

                    message = LogFormats.ResponseFromSOAP(callCounter++, response.Data.Body.SubtractResponse.SubtractResult);
                    _fileLogger.Info(message);
                    _requestDbLogger.Info(callId, message);

                    return DataResult<int>.Succeeded(response.Data.Body.SubtractResponse.SubtractResult);
                }
                catch (Exception e)
                {
                    _fileLogger.Error(e.Message);
                    return DataResult<int>.Failure(e.Message);
                }
            }
        }

        public IDataResult<int> Multiply(int leftOperand, int rightOperand)
        {
            lock (_lockObject)
            {
                try
                {
                    string message = LogFormats.RequestToREST(callCounter, leftOperand, rightOperand, Operation.Multiplication);
                    _fileLogger.Info(message);
                    var callId = _callDbLogger.Info();
                    _requestDbLogger.Info(callId, message);

                    string xmlData = string.Format(CustomDataFormats.MultiplicationDataXML, leftOperand, rightOperand);
                    _request.AddParameter("XmlBody", xmlData, ParameterType.RequestBody);

                    message = LogFormats.RequestToSOAP(callCounter, leftOperand, rightOperand, Operation.Multiplication);
                    _fileLogger.Info(message);
                    _requestDbLogger.Info(callId, message);

                    IRestResponse<MultiplyEnvelope> response = _client.Post<MultiplyEnvelope>(_request);

                    message = LogFormats.ResponseFromSOAP(callCounter++, response.Data.Body.MultiplyResponse.MultiplyResult);
                    _fileLogger.Info(message);
                    _requestDbLogger.Info(callId, message);

                    return DataResult<int>.Succeeded(response.Data.Body.MultiplyResponse.MultiplyResult);
                }
                catch (Exception e)
                {
                    _fileLogger.Error(e.Message);
                    return DataResult<int>.Failure(e.Message);
                }
            }
        }

        public IDataResult<int> Divide(int leftOperand, int rightOperand)
        {
            lock (_lockObject)
            {
                try
                {
                    string message = LogFormats.RequestToREST(callCounter, leftOperand, rightOperand, Operation.Division);
                    _fileLogger.Info(message);
                    var callId = _callDbLogger.Info();
                    _requestDbLogger.Info(callId, message);

                    string xmlData = string.Format(CustomDataFormats.DivisionDataXML, leftOperand, rightOperand);
                    _request.AddParameter("XmlBody", xmlData, ParameterType.RequestBody);

                    message = LogFormats.RequestToSOAP(callCounter, leftOperand, rightOperand, Operation.Division);
                    _fileLogger.Info(message);
                    _requestDbLogger.Info(callId, message);

                    IRestResponse<DivideEnvelope> response = _client.Post<DivideEnvelope>(_request);

                    message = LogFormats.ResponseFromSOAP(callCounter++, response.Data.Body.DivideResponse.DivideResult);
                    _fileLogger.Info(message);
                    _requestDbLogger.Info(callId, message);

                    return DataResult<int>.Succeeded(response.Data.Body.DivideResponse.DivideResult);
                }
                catch (Exception e)
                {
                    _fileLogger.Error(e.Message);
                    return DataResult<int>.Failure(e.Message);
                }
            }
        }
    }
}
