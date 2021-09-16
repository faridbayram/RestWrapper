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
using RestWrapper.DataAccess.Abstract;
using RestWrapper.Entities.Concrete;

namespace RestWrapper.Business.Concrete
{
    public class Calculator : ICalculator
    {
        private string baseUrl = "http://www.dneonline.com/calculator.asmx";
        private static int callCounter = 1;
        public const int a = 55;

        private readonly FileLogger _fileLogger;
        private readonly ICallDAL _callDal;
        private readonly IRequestDAL _requestDal;

        public Calculator(FileLogger fileLogger, ICallDAL callDal, IRequestDAL requestDal)
        {
            _fileLogger = fileLogger;
            _callDal = callDal;
            _requestDal = requestDal;
        }


        //[LogAspectRequestToREST(typeof(FileLogger), Priority = 1)]
        public IDataResult<int> Add(int leftOperand, int rightOperand)
        {
            try
            {
                // Logging to file
                string message = LogFormats.RequestToREST(callCounter, leftOperand, rightOperand);
                _fileLogger.Info(message);
                var call = new CallDAO {InsertDate = DateTime.Now};
                _callDal.Add(call);
                var dbRequest = new RequestDAO {CallId = call.Id, InsertDate = DateTime.Now, Value = message};
                _requestDal.Add(dbRequest);

                // Creating client and request objects for soap request
                RestClient client = new RestClient(baseUrl);
                RestRequest request = new RestRequest(baseUrl, default, DataFormat.Xml);
                request.XmlSerializer = new DotNetXmlSerializer();

                // Adding content-type as header
                request.AddHeader("Content-Type", "text/xml");

                string xmlData = string.Format(CustomDataFormats.AdditionDataXML, leftOperand, rightOperand);
                // Adding body as parameter
                request.AddParameter("XmlBody", xmlData, ParameterType.RequestBody);


                message = LogFormats.RequestToSOAP(callCounter, leftOperand, rightOperand);
                _fileLogger.Info(message);
                dbRequest = new RequestDAO { CallId = call.Id, InsertDate = DateTime.Now, Value = message };
                _requestDal.Add(dbRequest);

                //Sending request
                IRestResponse<AddEnvelope> response = client.Post<AddEnvelope>(request);

                message = LogFormats.ResponseFromSOAP(callCounter++, response.Data.Body.AddResponse.AddResult);
                _fileLogger.Info(message);
                dbRequest = new RequestDAO { CallId = call.Id, InsertDate = DateTime.Now, Value = message };
                _requestDal.Add(dbRequest);

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
                string message = LogFormats.RequestToREST(callCounter, leftOperand, rightOperand);
                _fileLogger.Info(message);
                var call = new CallDAO { InsertDate = DateTime.Now };
                _callDal.Add(call);
                var dbRequest = new RequestDAO { CallId = call.Id, InsertDate = DateTime.Now, Value = message };
                _requestDal.Add(dbRequest);

                RestClient client = new RestClient(baseUrl);
                RestRequest request = new RestRequest(baseUrl, default, DataFormat.Xml);
                request.XmlSerializer = new DotNetXmlSerializer();
                request.AddHeader("Content-Type", "text/xml");

                string xmlData = string.Format(CustomDataFormats.SubtractionDataXML, leftOperand, rightOperand);
                request.AddParameter("XmlBody", xmlData, ParameterType.RequestBody);

                message = LogFormats.RequestToSOAP(callCounter, leftOperand, rightOperand);
                _fileLogger.Info(message);
                dbRequest = new RequestDAO { CallId = call.Id, InsertDate = DateTime.Now, Value = message };
                _requestDal.Add(dbRequest);

                IRestResponse<SubtractEnvelope> response = client.Post<SubtractEnvelope>(request);

                message = LogFormats.ResponseFromSOAP(callCounter++, response.Data.Body.SubtractResponse.SubtractResult);
                _fileLogger.Info(message);
                dbRequest = new RequestDAO { CallId = call.Id, InsertDate = DateTime.Now, Value = message };
                _requestDal.Add(dbRequest);

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
                string message = LogFormats.RequestToREST(callCounter, leftOperand, rightOperand);
                _fileLogger.Info(message);
                var call = new CallDAO { InsertDate = DateTime.Now };
                _callDal.Add(call);
                var dbRequest = new RequestDAO { CallId = call.Id, InsertDate = DateTime.Now, Value = message };
                _requestDal.Add(dbRequest);

                RestClient client = new RestClient(baseUrl);
                RestRequest request = new RestRequest(baseUrl, default, DataFormat.Xml);
                request.XmlSerializer = new DotNetXmlSerializer();
                request.AddHeader("Content-Type", "text/xml");

                string xmlData = string.Format(CustomDataFormats.MultiplicationDataXML, leftOperand, rightOperand);
                request.AddParameter("XmlBody", xmlData, ParameterType.RequestBody);

                message = LogFormats.RequestToSOAP(callCounter, leftOperand, rightOperand);
                _fileLogger.Info(message);
                dbRequest = new RequestDAO { CallId = call.Id, InsertDate = DateTime.Now, Value = message };
                _requestDal.Add(dbRequest);

                IRestResponse<MultiplyEnvelope> response = client.Post<MultiplyEnvelope>(request);

                message = LogFormats.ResponseFromSOAP(callCounter++, response.Data.Body.MultiplyResponse.MultiplyResult);
                _fileLogger.Info(message);
                dbRequest = new RequestDAO { CallId = call.Id, InsertDate = DateTime.Now, Value = message };
                _requestDal.Add(dbRequest);

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
                string message = LogFormats.RequestToREST(callCounter, leftOperand, rightOperand);
                _fileLogger.Info(message);
                var call = new CallDAO { InsertDate = DateTime.Now };
                _callDal.Add(call);
                var dbRequest = new RequestDAO { CallId = call.Id, InsertDate = DateTime.Now, Value = message };
                _requestDal.Add(dbRequest);

                RestClient client = new RestClient(baseUrl);
                RestRequest request = new RestRequest(baseUrl, default, DataFormat.Xml);
                request.XmlSerializer = new DotNetXmlSerializer();
                request.AddHeader("Content-Type", "text/xml");

                string xmlData = string.Format(CustomDataFormats.DivisionDataXML, leftOperand, rightOperand);
                request.AddParameter("XmlBody", xmlData, ParameterType.RequestBody);

                message = LogFormats.RequestToSOAP(callCounter, leftOperand, rightOperand);
                _fileLogger.Info(message);
                dbRequest = new RequestDAO { CallId = call.Id, InsertDate = DateTime.Now, Value = message };
                _requestDal.Add(dbRequest);

                IRestResponse<DivideEnvelope> response = client.Post<DivideEnvelope>(request);

                message = LogFormats.ResponseFromSOAP(callCounter++, response.Data.Body.DivideResponse.DivideResult);
                _fileLogger.Info(message);
                dbRequest = new RequestDAO { CallId = call.Id, InsertDate = DateTime.Now, Value = message };
                _requestDal.Add(dbRequest);

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
