using Employee_Report.Model.Models;

namespace Employee_Report.API.Utilities
{
    public static class APIUtility
    {
        public static Response BindResponse(Object Obj = null!, bool Status = true, string Message = "")
        {
            Response resp = new Response();
            resp.response = Obj;
            resp.message = Message;
            resp.status = Status;
            return resp;
        }
    }
}
