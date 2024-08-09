﻿namespace SignalRWebUI.DTOs.BookDTOs
{
    public class CreateBookDTO
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int PersonCount { get; set; }
        public DateTime Date { get; set; }
    }
}