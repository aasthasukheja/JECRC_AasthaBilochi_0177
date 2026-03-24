const API = "http://localhost:5278/api/todo";

async function loadTodos() {

    const response = await fetch(API);
    const data = await response.json();

    const list = document.getElementById("todoList");
    list.innerHTML = "";

    data.forEach(todo => {

        const li = document.createElement("li");

        let color = "black";

        if (todo.priority === "High") color = "red";
        if (todo.priority === "Medium") color = "orange";
        if (todo.priority === "Low") color = "green";

        li.innerHTML = `
            <span style="color:${color}">
                ${todo.title} (${todo.priority})
            </span>

            <button onclick="deleteTask(${todo.id})">Delete</button>
        `;

        list.appendChild(li);
    });
}



async function addTask() {

    const input = document.getElementById("taskInput");
    const priority = document.getElementById("priority").value;

    await fetch(API, {
        method: "POST",
        headers: {
            "Content-Type": "application/json"
        },
        body: JSON.stringify({
            title: input.value,
            isCompleted: false,
            priority: priority
        })
    });

    input.value = "";

    loadTodos();
}



async function deleteTask(id) {

    await fetch(API + "/" + id, {
        method: "DELETE"
    });

    loadTodos();
}



function toggleDarkMode() {

    document.body.classList.toggle("dark");

}



loadTodos();