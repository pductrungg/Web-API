using Microsoft.AspNetCore.SignalR;

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

    //Post OUT OF OFFICE
    public class Out_off_office_response{
        public bool Success { get; set; }
        public int Code { get; set; }
        public string UserMessage { get; set; }
        public string SystemMessage { get; set; }
        public IList<CF_ResponseData> Data {get;set;}

    }

    public class CF_ResponseData{
        public bool Successful {get;set;}
        public CF_reponse_data_detail Data{get;set;}
    }

    public class CF_reponse_data_detail{
        public CF_execution ProcessExe{get;set;}
    }

    public class CF_execution{
        public string process_execution_id{get;set;}
    }
}
