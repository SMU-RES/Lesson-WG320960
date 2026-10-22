using System.ComponentModel.DataAnnotations;

namespace taskweb.Models;

// 登录表单模型。
public sealed class LoginViewModel
{
    // 用户名。
    [Required]
    [Display(Name = "用户名")]
    public string? Username { get; set; }

    // 密码。
    [Required]
    [DataType(DataType.Password)]
    [Display(Name = "密码")]
    public string? Password { get; set; }

    // 登录成功后的回跳地址。
    public string? ReturnUrl { get; set; }
}
