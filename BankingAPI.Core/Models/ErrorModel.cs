﻿namespace BankingAPI.Core.Models
{
    public record ErrorModel
    {
        public string FieldName { get; set; }
        public string Message { get; set; }
    }
}