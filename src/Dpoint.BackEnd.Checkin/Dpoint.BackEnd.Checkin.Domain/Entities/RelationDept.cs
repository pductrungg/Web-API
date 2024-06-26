namespace Dpoint.BackEnd.Checkin.Domain.Entities
{
    public class RelationDept
    {
        public int ID { get; set; }
        public string Description { get; set; }
        public int RelationID { get; set; }
        public int LevelID { get; set; }
        public string DeptCode { get; set; }
        public int TempID { get; set; }
        public int TempRelationID { get; set; }

    }
}
