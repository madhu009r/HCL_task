namespace Task_Management2.Model
{
    public class TasksItem
    {

        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public string Status { get; set; }
        public int CreatedBy { get; set; }

    }
}
