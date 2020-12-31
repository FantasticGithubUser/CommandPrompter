using System;

namespace CommandPrompter.Models.Dtos
{
    public class UserResponseDto : BaseDto<UserResponseDto>
    {
        public string Username { get; set; }
        public double Contributes { get; set; }
        public string Email { get; set; }
        public DateTime? RegisterTime { get; set; }
    }
}
