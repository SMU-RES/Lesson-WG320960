namespace taskweb.Models
{
    // 错误页模型：用于展示 RequestId。
    public class ErrorViewModel
    {
        public string? RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
