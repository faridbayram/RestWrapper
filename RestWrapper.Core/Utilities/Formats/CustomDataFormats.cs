using System;
using System.Collections.Generic;
using System.Text;

namespace RestWrapper.Core.Utilities.Formats
{
    public static class CustomDataFormats
    {
        public static string AdditionDataXML = "<Envelope xmlns=\"http://schemas.xmlsoap.org/soap/envelope/\"><Body><Add xmlns=\"http://tempuri.org/\"><intA>{0}</intA><intB>{1}</intB></Add></Body></Envelope>";
        public static string SubtractionDataXML = "<Envelope xmlns=\"http://schemas.xmlsoap.org/soap/envelope/\"><Body><Subtract xmlns=\"http://tempuri.org/\"><intA>{0}</intA><intB>{1}</intB></Subtract></Body></Envelope>";
        public static string MultiplicationDataXML = "<Envelope xmlns=\"http://schemas.xmlsoap.org/soap/envelope/\"><Body><Multiply xmlns=\"http://tempuri.org/\"><intA>{0}</intA><intB>{1}</intB></Multiply></Body></Envelope>";
        public static string DivisionDataXML = "<Envelope xmlns=\"http://schemas.xmlsoap.org/soap/envelope/\"><Body><Divide xmlns=\"http://tempuri.org/\"><intA>{0}</intA><intB>{1}</intB></Divide></Body></Envelope>";
    }
}
