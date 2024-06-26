namespace Dpoint.BackEnd.Checkin.Services.Models.Responses
{
    public class LeaveOfAbsenceResponse
    {
        public bool Success { get; set; }
        public int Code { get; set; }
        public string UserMessage { get; set; }
        public string SystemMessage { get; set; }
        public IList<LQResponseData> Data { get; set; }
    }

    public class LQResponseData
    {
        public bool Success { get; set; }
        public LQResponseDataDetail Data { get; set; }
    }

    public class LQResponseDataDetail
    {
        public LQDataProcessExecution ProcessExecution { get; set; }
    }

    public class LQDataProcessExecution
    {
        public string ProcessExecutionID { get; set; }
    }
}
