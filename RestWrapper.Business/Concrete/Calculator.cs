using System;
using RestSharp;
using RestSharp.Serializers;
using RestWrapper.Business.Abstract;
using RestWrapper.Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using RestWrapper.Core.Utilities.Deserialization.Addition;
using RestWrapper.Core.Utilities.Deserialization.Division;
using RestWrapper.Core.Utilities.Deserialization.Multiplication;
using RestWrapper.Core.Utilities.Deserialization.Subtraction;
using RestWrapper.Core.Utilities.Formats;
using RestWrapper.Core.Utilities.Results;

namespace RestWrapper.Business.Concrete
{
    public class Calculator : ICalculator
    {
        private string baseUrl = "http://www.dneonline.com/calculator.asmx";
        private FileLogger _fileLogger;
        private static int callCounter = 1;
        public const int a = 55;
        

        public Calculator(FileLogger fileLogger)
        {
            _fileLogger = fileLogger;
        }


        //[LogAspectRequestToREST(typeof(FileLogger), Priority = 1)]
        public IDataResult<int> Add(int leftOperand, int rightOperand)
        {
            try
            {
                // Logging to file
                _fileLogger.Info(LogFormats.RequestToREST(callCounter, leftOperand, rightOperand));

                // Creating client and request objects for soap request
                RestClient client = new RestClient(baseUrl);
                RestRequest request = new RestRequest(baseUrl, default, DataFormat.Xml);
                request.XmlSerializer = new DotNetXmlSerializer();

                // Adding content-type as header
                request.AddHeader("Content-Type", "text/xml");

                string xmlData = string.Format(CustomDataFormats.AdditionDataXML, leftOperand, rightOperand);
                // Adding body as parameter
                request.AddParameter("XmlBody", xmlData, ParameterType.RequestBody);


                _fileLogger.Info(LogFormats.RequestToSOAP(callCounter, leftOperand, rightOperand));

                //Sending request
                IRestResponse<AddEnvelope> response = client.Post<AddEnvelope>(request);
                _fileLogger.Info(LogFormats.ResponseFromSOAP(callCounter++, response.Data.Body.AddResponse.AddResult));
                return DataResult<int>.Succeeded(response.Data.Body.AddResponse.AddResult);
            }
            catch (Exception e)
            {
                _fileLogger.Error(e.Message);
                return DataResult<int>.Failure(e.Message);
            }
        }

        public IDataResult<int> Subtract(int leftOperand, int rightOperand)
        {
            try
            {
                _fileLogger.Info(LogFormats.RequestToREST(callCounter, leftOperand, rightOperand));

                RestClient client = new RestClient(baseUrl);
                RestRequest request = new RestRequest(baseUrl, default, DataFormat.Xml);
                request.XmlSerializer = new DotNetXmlSerializer();
                request.AddHeader("Content-Type", "text/xml");

                string xmlData = string.Format(CustomDataFormats.SubtractionDataXML, leftOperand, rightOperand);
                request.AddParameter("XmlBody", xmlData, ParameterType.RequestBody);

                _fileLogger.Info(LogFormats.RequestToSOAP(callCounter, leftOperand, rightOperand));
                IRestResponse<SubtractEnvelope> response = client.Post<SubtractEnvelope>(request);
                _fileLogger.Info(LogFormats.ResponseFromSOAP(callCounter++, response.Data.Body.SubtractResponse.SubtractResult));
                return DataResult<int>.Succeeded(response.Data.Body.SubtractResponse.SubtractResult);
            }
            catch (Exception e)
            {
                _fileLogger.Error(e.Message);
                return DataResult<int>.Failure(e.Message);
            }
        }

        public IDataResult<int> Multiply(int leftOperand, int rightOperand)
        {
            try
            {
                _fileLogger.Info(LogFormats.RequestToREST(callCounter, leftOperand, rightOperand));

                RestClient client = new RestClient(baseUrl);
                RestRequest request = new RestRequest(baseUrl, default, DataFormat.Xml);
                request.XmlSerializer = new DotNetXmlSerializer();
                request.AddHeader("Content-Type", "text/xml");

                string xmlData = string.Format(CustomDataFormats.MultiplicationDataXML, leftOperand, rightOperand);
                request.AddParameter("XmlBody", xmlData, ParameterType.RequestBody);

                _fileLogger.Info(LogFormats.RequestToSOAP(callCounter, leftOperand, rightOperand));
                IRestResponse<MultiplyEnvelope> response = client.Post<MultiplyEnvelope>(request);
                _fileLogger.Info(LogFormats.ResponseFromSOAP(callCounter++, response.Data.Body.MultiplyResponse.MultiplyResult));
                return DataResult<int>.Succeeded(response.Data.Body.MultiplyResponse.MultiplyResult);
            }
            catch (Exception e)
            {
                _fileLogger.Error(e.Message);
                return DataResult<int>.Failure(e.Message);
            }
        }

        public IDataResult<int> Divide(int leftOperand, int rightOperand)
        {
            try
            {
                _fileLogger.Info(LogFormats.RequestToREST(callCounter, leftOperand, rightOperand));

                RestClient client = new RestClient(baseUrl);
                RestRequest request = new RestRequest(baseUrl, default, DataFormat.Xml);
                request.XmlSerializer = new DotNetXmlSerializer();
                request.AddHeader("Content-Type", "text/xml");

                string xmlData = string.Format(CustomDataFormats.DivisionDataXML, leftOperand, rightOperand);
                request.AddParameter("XmlBody", xmlData, ParameterType.RequestBody);

                _fileLogger.Info(LogFormats.RequestToSOAP(callCounter, leftOperand, rightOperand));
                IRestResponse<DivideEnvelope> response = client.Post<DivideEnvelope>(request);
                _fileLogger.Info(LogFormats.ResponseFromSOAP(callCounter++, response.Data.Body.DivideResponse.DivideResult));
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
