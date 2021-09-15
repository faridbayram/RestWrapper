using System;
using RestSharp;
using RestSharp.Serializers;
using RestWrapper.Business.Abstract;
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
        private readonly RestClient client;
        private readonly RestRequest request;
        

        public Calculator()
        {
            client = new RestClient(baseUrl);
            request = new RestRequest(baseUrl, default, DataFormat.Xml);
            request.XmlSerializer = new DotNetXmlSerializer();
            request.AddHeader("Content-Type", "text/xml");
        }

        public IDataResult<int> Add(int leftOperand, int rightOperand)
        {
            try
            {
                string xmlData = string.Format(CustomDataFormats.AdditionDataXML, leftOperand, rightOperand);
                request.AddParameter("XmlBody", xmlData, ParameterType.RequestBody);

                IRestResponse<AddEnvelope> response = client.Post<AddEnvelope>(request);
                return DataResult<int>.Succeeded(response.Data.Body.AddResponse.AddResult);
            }
            catch (Exception e)
            {
                return DataResult<int>.Failure(e.Message);
            }
        }

        public IDataResult<int> Subtract(int leftOperand, int rightOperand)
        {
            try
            {
                string xmlData = string.Format(CustomDataFormats.SubtractionDataXML, leftOperand, rightOperand);
                request.AddParameter("XmlBody", xmlData, ParameterType.RequestBody);

                IRestResponse<SubtractEnvelope> response = client.Post<SubtractEnvelope>(request);
                return DataResult<int>.Succeeded(response.Data.Body.SubtractResponse.SubtractResult);
            }
            catch (Exception e)
            {
                return DataResult<int>.Failure(e.Message);
            }
        }

        public IDataResult<int> Multiply(int leftOperand, int rightOperand)
        {
            try
            {
                string xmlData = string.Format(CustomDataFormats.MultiplicationDataXML, leftOperand, rightOperand);
                request.AddParameter("XmlBody", xmlData, ParameterType.RequestBody);

                IRestResponse<MultiplyEnvelope> response = client.Post<MultiplyEnvelope>(request);
                return DataResult<int>.Succeeded(response.Data.Body.MultiplyResponse.MultiplyResult);
            }
            catch (Exception e)
            {
                return DataResult<int>.Failure(e.Message);
            }
        }

        public IDataResult<int> Divide(int leftOperand, int rightOperand)
        {
            try
            {
                string xmlData = string.Format(CustomDataFormats.DivisionDataXML, leftOperand, rightOperand);
                request.AddParameter("XmlBody", xmlData, ParameterType.RequestBody);

                IRestResponse<DivideEnvelope> response = client.Post<DivideEnvelope>(request);
                return DataResult<int>.Succeeded(response.Data.Body.DivideResponse.DivideResult);
            }
            catch (Exception e)
            {
                return DataResult<int>.Failure(e.Message);
            }
        }
    }
}
