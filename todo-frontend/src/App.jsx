import React, { useEffect, useState } from 'react';
import TaskForm from './components/TaskForm';
import TaskList from './components/TaskList';

const App = () => {
  const [tasks, setTasks] = useState([]);

  const fetchTasks = async () => {
    const res = await fetch('http://localhost:5000/api/tasks');
    const data = await res.json();
    setTasks(data);
  };

  const addTask = async (task) => {
    const res = await fetch('http://localhost:5000/api/tasks', {
      method: 'POST',
      headers: { 'Content-Type': 'application/json' },
      body: JSON.stringify(task),
    });
    if (res.ok) fetchTasks();
  };

  const markAsDone = async (id) => {
    await fetch(`http://localhost:5000/api/tasks/${id}/complete`, {
      method: 'PUT',
    });
    fetchTasks();
  };

  useEffect(() => {
    fetchTasks();
  }, []);

  return (
    <div className="container border mt-4 p-4 shadow-sm bg-white rounded">
      <div className="row">
        <div className="col-md-6 border-end">
          <TaskForm onAdd={addTask} />
        </div>
        <div className="col-md-6">
          <TaskList tasks={tasks} onDone={markAsDone} />
        </div>
      </div>
    </div>
  );
};

export default App;
