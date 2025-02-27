using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Windows.Forms;


namespace TodoApp
{
    public partial class Form1 : Form
    {
        private readonly HttpClient _httpClient;

        public Form1()
        {
            InitializeComponent();
            _httpClient = new HttpClient { BaseAddress = new Uri("https://localhost:7109/api/Todo") };
            LoadTodos();
        }

        private async void LoadTodos()
        {
            var todos = await _httpClient.GetFromJsonAsync<List<TodoItem>>("todo");
            listBoxTodos.DataSource = todos;
            listBoxTodos.DisplayMember = "Title";
        }


        private async void buttonDelete_Click(object sender, EventArgs e)
        {
            if (listBoxTodos.SelectedItem is TodoItem selectedItem)
            {
                await _httpClient.DeleteAsync($"todo/{selectedItem.Id}");
                LoadTodos();
            }
        }

        private async void buttonAdd_Click_1(object sender, EventArgs e)
        {
            var newItem = new TodoItem { Title = textBoxTitle.Text, IsCompleted = false };
            await _httpClient.PostAsJsonAsync("todo", newItem);
            LoadTodos();
            textBoxTitle.Clear(); // Очистка текстового поля после добавления
        }

        private async void buttonDelete_Click_1(object sender, EventArgs e)
        {
            if (listBoxTodos.SelectedItem is TodoItem selectedItem)
            {
                await _httpClient.DeleteAsync($"todo/{selectedItem.Id}");
                LoadTodos();
            }
        }

        private void listBoxTodos_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
    public class TodoItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool IsCompleted { get; set; }
    }
}
