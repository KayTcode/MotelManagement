using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects.DTOs.Authentication
{
    public class RegisterRequestDto
    {
        [Required]
        public string FullName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [RegularExpression(@"^[A-Z](?=.*[!@#$%^&*()]).{7,}$",
            ErrorMessage = "Mật khẩu bắt đầu bằng chữ Hoa, ít nhất 1 ký tự đặc biệt, tối thiểu 8 ký tự")]
        public string PasswordHash { get; set; }
        public string RePasswordHash { get; set; }
        [Required]
        [RegularExpression(@"^0/d{9}$", ErrorMessage = "SĐT phải có 10 số")]
        public string PhoneNumber { get; set; }
        public string Role { get; set; } //'Owner','Tenant'
    }
}
