namespace Common.OData
{
    public class ODataError
    {
        public ODataErrorCodeMessage Error { get; set; }
    }
    public class ODataErrorCodeMessage
    {
        public string Code { get; set; }

        public string Message { get; set; }

        public ODataInnerError InnerError { get; set; }
    }

    public class ODataInnerError
    {
        public string Message { get; set; }

        public string Type { get; set; }

        public string StackTrace { get; set; }

        public ODataInnerError InternalException { get; set; }
    }

}
