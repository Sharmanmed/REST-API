using System;

namespace TodoApi.Models
{
    public class TodoItem
    {
        public int Id { get; set; }            // Уникальный идентификатор задачи
        public string Title { get; set; }      // Название задачи
        public bool IsCompleted { get; set; }  // Статус завершения задачи
    }
}