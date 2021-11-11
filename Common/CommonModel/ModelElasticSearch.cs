namespace Common.CommonModel
{
    public class ModelSearchReturnData
    {
        public dynamic Data { get; set; }
        public dynamic Total { get; set; }
    }

    public class DtoSearch
    {
        public string Query { get; set; }
        public int Take { get; set; }
        public int Skip { get; set; }
    }

    public class QueryBusinessDto
    {
        public string businessurl { get; set; }
        public string namebusiness { get; set; }
        public string typebusines { get; set; }
        public string businessmaneger { get; set; }
        public string description { get; set; }
        public string clock { get; set; }
        public string pathlogomini { get; set; }
        public string address { get; set; }
        public string mobile { get; set; }
        public string homenumber { get; set; } // لیست شماره محل کار
        public string faxnumber { get; set; } // لیست شماره فکس 
        public string email { get; set; }
    }
}
