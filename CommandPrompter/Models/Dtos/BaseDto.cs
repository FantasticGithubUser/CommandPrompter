﻿
namespace CommandPrompter.Models.Dtos
{
    public class BaseDto<T> where T : BaseDto<T>, new()
    {
    }
}
