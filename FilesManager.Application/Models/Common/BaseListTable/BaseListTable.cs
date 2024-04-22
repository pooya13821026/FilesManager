namespace FilesManager.Application.Models.Common.BaseListTable;
public class BaseListTable<T> where T : class
{
    public List<T> Rows { get; set; } = [];
    public int Total { get; set; }
    public int TotalNotFiltered { get; set; }
    public bool HasMore { get; set; }
}
